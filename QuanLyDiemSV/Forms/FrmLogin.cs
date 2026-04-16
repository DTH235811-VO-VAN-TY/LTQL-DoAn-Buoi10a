using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDiemSV.Data;
using BCrypt.Net;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap; // Nhấn Enter sẽ kích hoạt nút Đăng nhập
        }
        private string MaHoaMatKhau(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2")); // Ép về chuỗi Hexa in thường (x2)
                }
                return sb.ToString(); // Trả về chuỗi đã mã hóa
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim(); // Ô nhập tài khoản
            string password = txtMatKhau.Text.Trim(); // Ô nhập mật khẩu

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            using (var context = new QLDSVDbContext())
            {
                // 1. CHỈ TÌM TÀI KHOẢN THEO USERNAME (Giống dòng 193 trong PDF)
                var user = context.UserAccount.SingleOrDefault(u => u.Username == username);


                // Hàm Verify sẽ tự động lấy password người dùng nhập, băm ra và so sánh với chuỗi $2a$... trong DB
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    // Nếu khớp mật khẩu -> Kiểm tra xem tài khoản có bị khóa không
                    if (user.IsActive == false)
                    {
                        MessageBox.Show("Tài khoản của bạn đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor.Current = Cursors.Default;
                        return;
                    }

                    // 3. LƯU THÔNG TIN SESSION VÀ PHÂN QUYỀN
                    Session.UserID = user.UserID;
                    Session.Username = user.Username.Trim();
                    Session.RoleID = Convert.ToInt32(user.RoleID);

                    //// Tìm mã Sinh viên / Giảng viên tương ứng với UserID
                    if (Session.RoleID == 2) // Giảng viên
                    {
                        var gv = context.GiangVien.FirstOrDefault(g => g.UserID == user.UserID);
                        Session.MaNguoiDung = gv != null ? gv.MaGV.Trim() : Session.Username;
                    }
                    else if (Session.RoleID == 3) // Sinh viên
                    {
                        var sv = context.SinhVien.FirstOrDefault(s => s.UserID == user.UserID);
                        Session.MaNguoiDung = sv != null ? sv.MaSV.Trim() : Session.Username;
                    }

                    // 4. MỞ FORM CHÍNH
                    this.Hide();
                    Application.DoEvents();
                    Form1 form = new Form1();
                    form.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Sai tài khoản hoặc sai mật khẩu
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void checkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = checkHienMatKhau.Checked ? '\0' : '*'; // Hiện mật khẩu nếu checked, ngược lại ẩn
        }
    }
}
