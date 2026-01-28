using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyDiemSV.Data;
using GUI; // Namespace chứa UC_Diem

namespace QuanLyDiemSV.Forms
{
    public partial class UC_QuanLyDiem_Container : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        UC_Diem ucNhapDiem; // Màn hình nhập điểm (Con)

        public UC_QuanLyDiem_Container()
        {
            InitializeComponent();
            this.Load += UC_QuanLyDiem_Container_Load;
            dgvDanhSachSV.CellClick += dgvDanhSachSV_CellClick;
        }

        private void UC_QuanLyDiem_Container_Load(object sender, EventArgs e)
        {
            LoadDanhSachSinhVien();
            AddButtonColumn(); // Thêm cột nút bấm
            InitUserControlDiem(); // Khởi tạo màn hình con
        }

        // Khởi tạo màn hình nhập điểm và ẩn nó đi
        private void InitUserControlDiem()
        {
            ucNhapDiem = new UC_Diem();
            ucNhapDiem.Dock = DockStyle.Fill;
            ucNhapDiem.Visible = false; // Mặc định ẩn

            // Đăng ký sự kiện: Khi bấm "Quay lại" ở màn hình con -> Gọi hàm xử lý ở đây
            ucNhapDiem.OnBackClicked += UcNhapDiem_OnBackClicked;

            // Thêm vào Controls của Container (Đè lên các panel khác)
            this.Controls.Add(ucNhapDiem);
        }

        private void LoadDanhSachSinhVien()
        {
            try
            {
                var listSV = from sv in context.SinhVien
                             join lop in context.LopHanhChinh on sv.MaLop equals lop.MaLop
                             join nganh in context.Nganh on lop.MaNganh equals nganh.MaNganh
                             join khoa in context.Khoa on nganh.MaKhoa equals khoa.MaKhoa
                             select new
                             {
                                 MaSV = sv.MaSV,
                                 HoTen = sv.HoTen,
                                 NgaySinh = sv.NgaySinh,
                                 GioiTinh = sv.GioiTinh,
                                 Lop = lop.TenLop,
                                 Khoa = khoa.TenKhoa,
                                 TrangThai = sv.TrangThai == 1 ? "Đang học" : "Đã nghỉ"
                             };

                dgvDanhSachSV.DataSource = listSV.ToList();

                // Định dạng cột (nếu cần)
                if (dgvDanhSachSV.Columns["MaSV"] != null) dgvDanhSachSV.Columns["MaSV"].HeaderText = "Mã SV";
                if (dgvDanhSachSV.Columns["HoTen"] != null) dgvDanhSachSV.Columns["HoTen"].HeaderText = "Họ Tên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        private void AddButtonColumn()
        {
            if (dgvDanhSachSV.Columns["btnNhapDiem"] == null)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Thao tác";
                btn.Name = "btnNhapDiem";
                btn.Text = "Nhập điểm";
                btn.UseColumnTextForButtonValue = true;
                dgvDanhSachSV.Columns.Add(btn);
            }
        }

        // Sự kiện khi bấm vào nút "Nhập điểm" trên lưới
        private void dgvDanhSachSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDanhSachSV.Columns[e.ColumnIndex].Name == "btnNhapDiem")
            {
                string maSV = dgvDanhSachSV.Rows[e.RowIndex].Cells["MaSV"].Value.ToString();
                ucNhapDiem.LoadThongTinSinhVien(maSV);

                // --- SỬA LẠI ĐOẠN NÀY ĐỂ FULL MÀN HÌNH ---
                ucNhapDiem.Visible = true;
                ucNhapDiem.BringToFront();

                // Ẩn tạm thời các thanh tìm kiếm đi cho đỡ vướng
                panel1.Visible = false; // Panel Tìm kiếm
                panel2.Visible = false; // Panel Sắp xếp
            }
        }

        // Xử lý sự kiện khi nút "Quay lại" được bấm ở màn hình con
        private void UcNhapDiem_OnBackClicked(object sender, EventArgs e)
        {
            ucNhapDiem.Visible = false;

            // Hiện lại các thanh tìm kiếm
            panel1.Visible = true;
            panel2.Visible = true;
        }
    }
}