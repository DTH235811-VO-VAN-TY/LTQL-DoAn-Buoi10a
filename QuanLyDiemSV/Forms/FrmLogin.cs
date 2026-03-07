using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           // 1.Đổi con trỏ chuột thành hình xoay xoay(đang tải)
            Cursor.Current = Cursors.WaitCursor;

            // 2. Ẩn form login đi ngay lập tức để màn hình không bị kẹt
            this.Hide();
            Application.DoEvents(); // Ép hệ thống phản hồi giao diện ngay

            // 3. Khởi tạo và mở Form1 (Lúc này nó đang âm thầm load dữ liệu)
            Form1 form = new Form1();
            form.ShowDialog();

            // 4. Khi Form1 tắt (người dùng bấm X), thì đóng luôn chương trình
            this.Close();
        }
    }
}
