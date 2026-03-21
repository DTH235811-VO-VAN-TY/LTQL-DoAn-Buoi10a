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
    public partial class UC_GiangVien_ChamDiem : UserControl
    {
        public UC_GiangVien_ChamDiem()
        {
            InitializeComponent();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {

        }
        // Hàm này có nhiệm vụ tạo ra 1 "Thẻ" (GroupBox) chứa thông tin lớp học phần
        // Bạn sẽ gọi hàm này trong vòng lặp khi lấy dữ liệu từ CSDL
        private void TaoCardLopHocPhan(int maLHP, string tenMon, string maLop, int siSo)
        {
            // 1. Tạo GroupBox bên ngoài
            GroupBox gb = new GroupBox();
            gb.Text = $"Mã LHP: {maLHP} - {tenMon}";
            gb.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gb.Size = new Size(350, 160); // Kích thước của 1 thẻ
            gb.BackColor = Color.White;
            gb.ForeColor = Color.Blue;
            gb.Margin = new Padding(15); // Khoảng cách giữa các thẻ

            // 2. Tạo Label Lớp
            Label lblLop = new Label();
            lblLop.Text = $"Lớp hành chính: {maLop}";
            lblLop.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblLop.Location = new Point(15, 40);
            lblLop.AutoSize = true;
            gb.Controls.Add(lblLop);

            // 3. Tạo Label Sĩ số
            Label lblSiSo = new Label();
            lblSiSo.Text = $"Sĩ số: {siSo} Sinh viên";
            lblSiSo.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSiSo.Location = new Point(15, 75);
            lblSiSo.AutoSize = true;
            gb.Controls.Add(lblSiSo);

            // 4. Tạo Nút "Nhập Điểm"
            Button btnNhapDiem = new Button();
            btnNhapDiem.Text = "Nhập Điểm";
            btnNhapDiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhapDiem.BackColor = Color.FromArgb(46, 204, 113); // Màu xanh lá
            btnNhapDiem.ForeColor = Color.White;
            btnNhapDiem.FlatStyle = FlatStyle.Flat;
            btnNhapDiem.FlatAppearance.BorderSize = 0;
            btnNhapDiem.Size = new Size(120, 35);
            btnNhapDiem.Location = new Point(210, 110); // Góc dưới bên phải
            btnNhapDiem.Cursor = Cursors.Hand;

            // Lưu lại Mã Lớp Học Phần vào thuộc tính Tag của nút để lát nữa xử lý sự kiện Click
            btnNhapDiem.Tag = maLHP;
            btnNhapDiem.Click += BtnNhapDiem_Click; // Gắn sự kiện Click

            gb.Controls.Add(btnNhapDiem);

            // 5. Thêm GroupBox vừa tạo vào FlowLayoutPanel trên màn hình
            flpDanhSachLop.Controls.Add(gb);
        }

        // Sự kiện khi Giảng viên bấm nút "Nhập Điểm" trên bất kỳ Card nào
        private void BtnNhapDiem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                int maLHP_DuocChon = (int)btn.Tag;
                MessageBox.Show($"Bạn vừa chọn nhập điểm cho Lớp Học Phần mã: {maLHP_DuocChon}");

                // Sau này ta sẽ viết code chuyển sang màn hình chấm điểm chi tiết ở đây
            }
        }

        private void UC_GiangVien_ChamDiem_Load(object sender, EventArgs e)
        {
            // Xóa sạch các thẻ cũ trước khi load thẻ mới
            flpDanhSachLop.Controls.Clear();

            // Tạo thử 5 lớp học phần giả lập để xem thiết kế
            TaoCardLopHocPhan(101, "Cơ sở dữ liệu", "DH23TTA", 45);
            TaoCardLopHocPhan(102, "Lập trình Windows", "DH23TTA", 42);
            TaoCardLopHocPhan(103, "Cấu trúc dữ liệu", "DH23TTB", 50);
            TaoCardLopHocPhan(104, "Trí tuệ nhân tạo", "DH23TTC", 30);
            TaoCardLopHocPhan(105, "Mạng máy tính", "DH23TTA", 40);
        }
    }
}
