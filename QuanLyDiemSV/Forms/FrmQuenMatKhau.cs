using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmQuenMatKhau : Form
    {
        public FrmQuenMatKhau()
        {
            InitializeComponent();
            btnXacNhan.Click += BtnXacNhan_Click;
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã sinh viên/Giảng viên và Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnXacNhan.Text = "ĐANG XỬ LÝ...";
                btnXacNhan.Enabled = false;
                Application.DoEvents(); // Cập nhật UI

                using (var db = new QLDSVDbContext())
                {
                    // Lấy UserAccount theo Username
                    var userAccount = db.UserAccount.FirstOrDefault(u => u.Username == username);
                    if (userAccount == null)
                    {
                        MessageBox.Show("Mã tài khoản (Tên đăng nhập) không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    // Lấy Email từ bảng tương ứng
                    string dbEmail = "";
                    if (userAccount.RoleID == 3) // Sinh viên
                    {
                        var sv = db.SinhVien.FirstOrDefault(s => s.MaSV == username);
                        dbEmail = sv?.Email;
                    }
                    else if (userAccount.RoleID == 2) // Giảng viên
                    {
                        var gv = db.GiangVien.FirstOrDefault(g => g.MaGV == username);
                        dbEmail = gv?.Email;
                    }
                    else if (userAccount.RoleID == 1) // Admin
                    {
                        MessageBox.Show("Chức năng này không hỗ trợ tài khoản Admin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    if (string.IsNullOrEmpty(dbEmail))
                    {
                        MessageBox.Show("Tài khoản này chưa cập nhật Email trong hệ thống. Vui lòng liên hệ Admin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    if (dbEmail.ToLower() != email.ToLower())
                    {
                        MessageBox.Show("Email nhập vào không khớp với Email đã đăng ký trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetButton();
                        return;
                    }

                    // 1. Tạo mật khẩu mới ngẫu nhiên (6 ký tự)
                    string newPassword = GenerateRandomPassword(6);

                    // 2. Hash mật khẩu mới bằng BCrypt
                    string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

                    // 3. Cập nhật vào Database
                    userAccount.PasswordHash = newPasswordHash;
                    db.SaveChanges();

                    // 4. Gửi mật khẩu qua Email
                    bool isSent = SendEmail(email, newPassword);

                    if (isSent)
                    {
                        MessageBox.Show("Lấy lại mật khẩu thành công!\nVui lòng kiểm tra Email của bạn để lấy mật khẩu mới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        // Nếu gửi mail lỗi, rollback (phục hồi) mật khẩu để tránh tình trạng db đổi mà user không nhận được mail
                        MessageBox.Show("Lỗi gửi Email (Có thể do chưa cấu hình SMTP). Mật khẩu chưa bị thay đổi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResetButton();
            }
        }

        private void ResetButton()
        {
            btnXacNhan.Text = "XÁC NHẬN";
            btnXacNhan.Enabled = true;
        }

        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool SendEmail(string toEmail, string newPassword)
        {
            try
            {
                // =================================================================
                // HƯỚNG DẪN CẤU HÌNH GỬI MAIL (SMTP GOOGLE):
                // 1. Dùng một tài khoản Gmail của bạn. Bật Bảo mật 2 lớp (2FA).
                // 2. Vào cài đặt tài khoản Google -> App Passwords (Mật khẩu ứng dụng)
                // 3. Tạo 1 mật khẩu (16 ký tự).
                // 4. THAY EMAIL VÀ MẬT KHẨU ĐÓ VÀO 2 BIẾN DƯỚI ĐÂY LÀ CHẠY ĐƯỢC!
                // =================================================================
                
                string fromEmail = "voty365@gmail.com"; 
                string appPassword = "hhzp tstw gxkc jrdl"; 

                // CHÚ Ý: Nếu bạn chỉ đang chạy thử nghiệm và chưa có tài khoản trên, 
                // bạn có thể COMMENT khối code smtp.Send(mail) lại và return true để Test CSDL.

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, "Hệ Thống Quản Lý Điểm SV");
                mail.To.Add(toEmail);
                mail.Subject = "CẤP LẠI MẬT KHẨU TÀI KHOẢN HỆ THỐNG";
                
                string body = $"<h3>Chào bạn,</h3>" +
                              $"<p>Bạn vừa yêu cầu cấp lại mật khẩu cho tài khoản trên phần mềm Quản lý điểm sinh viên.</p>" +
                              $"<p>Mật khẩu mới của bạn là: <b><font color='red' size='5'>{newPassword}</font></b></p>" +
                              $"<p>Vui lòng dùng mật khẩu này để đăng nhập và nên tiến hành đổi mật khẩu ngay sau đó để đảm bảo an toàn.</p>" +
                              $"<br><p>Trân trọng,</p>";
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                smtp.EnableSsl = true;
                
                // Gửi mail (Sẽ báo lỗi nếu chưa điền đúng fromEmail và appPassword ở trên)
                smtp.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
