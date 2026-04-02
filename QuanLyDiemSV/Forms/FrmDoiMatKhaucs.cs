using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDiemSV.Data;
using BCrypt.Net;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmDoiMatKhaucs : Form
    {
        public FrmDoiMatKhaucs()
        {
            InitializeComponent();
        }

        private void FrmDoiMatKhaucs_Load(object sender, EventArgs e)
        {
            // Tự động điền tên đăng nhập từ Session và khóa lại không cho sửa
            txtTenDangNhap.Text = Session.Username;
            txtTenDangNhap.ReadOnly = true;

            // Che mật khẩu bằng dấu chấm đen
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text.Trim();
            string mkMoi = txtMatKhauMoi.Text.Trim();
            string xacNhan = txtXacNhanMatKhau.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra xác nhận mật khẩu có khớp không
            if (mkMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXacNhanMatKhau.Focus();
                return;
            }

            // 3. Tiến hành kiểm tra DB và đổi mật khẩu
            try
            {
                using (var db = new QLDSVDbContext())
                {
                    // Truy vấn vào bảng UserAccount theo UserID
                    var user = db.UserAccount.FirstOrDefault(u => u.UserID == Session.UserID);

                    if (user == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra mật khẩu cũ có đúng không
                    bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(mkCu, user.PasswordHash);

                    if (!isPasswordCorrect)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtMatKhauCu.Focus();
                        return;
                    }

                    // Gán mật khẩu mới vào cột PasswordHash và lưu xuống DB
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(mkMoi);
                    db.SaveChanges();

                    MessageBox.Show("Đổi mật khẩu thành công! Hãy dùng mật khẩu mới cho lần đăng nhập sau.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Hủy bỏ và đóng form
        }
    }
}
