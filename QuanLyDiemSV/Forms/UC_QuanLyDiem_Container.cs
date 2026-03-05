using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore; // Thêm thư viện này để dùng Include
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_QuanLyDiem_Container : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        public event Action<string> OnChuyenManHinhNhapDiem;

        public UC_QuanLyDiem_Container()
        {
            InitializeComponent();
            this.Load += UC_QuanLyDiem_Container_Load;
            dgvDanhSachSV.CellContentClick += dgvDanhSachSV_CellContentClick;
        }

        private void UC_QuanLyDiem_Container_Load(object sender, EventArgs e)
        {
            SetupDataGridView();       // Cấu hình cột
            KhoiTaoCacComboBox();      // Nạp dữ liệu cho các ComboBox (Khoa, Tìm kiếm, Sắp xếp)
            LoadData();                // Tải dữ liệu lên lưới

            // Đăng ký các sự kiện tương tác
            cboKhoa.SelectedIndexChanged += (s, ev) => LoadData();
            cboKieuSX.SelectedIndexChanged += (s, ev) => LoadData();
            radTang.CheckedChanged += (s, ev) => { if (radTang.Checked) LoadData(); };
            radGiam.CheckedChanged += (s, ev) => { if (radGiam.Checked) LoadData(); };
        }

        // ==========================================
        // 1. KHỞI TẠO GIAO DIỆN & COMBOBOX
        // ==========================================
        private void SetupDataGridView()
        {
            dgvDanhSachSV.AutoGenerateColumns = false;

            // Map cột trên lưới với thuộc tính của biến vô danh (Anonymous type) ở hàm LoadData
            if (dgvDanhSachSV.Columns["MaSV"] != null) dgvDanhSachSV.Columns["MaSV"].DataPropertyName = "MaSV";
            if (dgvDanhSachSV.Columns["HoTen"] != null) dgvDanhSachSV.Columns["HoTen"].DataPropertyName = "HoTen";
            if (dgvDanhSachSV.Columns["NgaySinh"] != null)
            {
                dgvDanhSachSV.Columns["NgaySinh"].DataPropertyName = "NgaySinh";
                dgvDanhSachSV.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDanhSachSV.Columns["GioiTinh"] != null) dgvDanhSachSV.Columns["GioiTinh"].DataPropertyName = "GioiTinh";

            // Map tên hiển thị thay vì hiện ID
            if (dgvDanhSachSV.Columns["LopHanhChinh"] != null) dgvDanhSachSV.Columns["LopHanhChinh"].DataPropertyName = "TenLop";
            if (dgvDanhSachSV.Columns["MaKhoa"] != null) dgvDanhSachSV.Columns["MaKhoa"].DataPropertyName = "TenKhoa";

            if (dgvDanhSachSV.Columns["TrangThai"] != null) dgvDanhSachSV.Columns["TrangThai"].DataPropertyName = "TrangThaiHienThi";

            // CẤU HÌNH CỘT NÚT BẤM "NHẬP ĐIỂM" BẰNG CODE
            // =========================================================
            if (dgvDanhSachSV.Columns["ThaoTac"] is DataGridViewButtonColumn btnCol)
            {
                // Nếu đã là cột Button thì chỉ cần ép nó hiện chữ
                btnCol.Text = "Nhập điểm";
                btnCol.UseColumnTextForButtonValue = true;
            }
            else if (dgvDanhSachSV.Columns["ThaoTac"] != null)
            {
                // Nếu lỡ tạo nhầm thành cột Text trong Designer thì xóa đi tạo lại
                int index = dgvDanhSachSV.Columns["ThaoTac"].Index;
                dgvDanhSachSV.Columns.Remove("ThaoTac");

                DataGridViewButtonColumn newBtnCol = new DataGridViewButtonColumn();
                newBtnCol.Name = "ThaoTac";
                newBtnCol.HeaderText = "Thao Tác";
                newBtnCol.Text = "Nhập điểm";
                newBtnCol.UseColumnTextForButtonValue = true; // Bắt buộc = true để hiện chữ
                dgvDanhSachSV.Columns.Insert(index, newBtnCol);
            }
            else
            {
                // Nếu chưa có cột nào tên ThaoTac, tự tạo mới ở cuối lưới
                DataGridViewButtonColumn newBtnCol = new DataGridViewButtonColumn();
                newBtnCol.Name = "ThaoTac";
                newBtnCol.HeaderText = "Thao Tác";
                newBtnCol.Text = "Nhập điểm";
                newBtnCol.UseColumnTextForButtonValue = true;
                dgvDanhSachSV.Columns.Add(newBtnCol);
            }
        }

        private void KhoiTaoCacComboBox()
        {
            try
            {
                // 1. ComboBox Lọc Khoa
                var listKhoa = context.Khoa.ToList();
                listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "--- Tất cả Khoa ---" }); // Thêm mục mặc định
                cboKhoa.DataSource = listKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
                cboKhoa.SelectedIndex = 0;

                // 2. ComboBox Loại Tìm Kiếm
                cboTimKiem.Items.Clear();
                cboTimKiem.Items.AddRange(new string[] { "Mã Sinh Viên", "Họ Tên", "Lớp" });
                cboTimKiem.SelectedIndex = 1; // Mặc định tìm theo tên

                // 3. ComboBox Kiểu Sắp Xếp
                cboKieuSX.Items.Clear();
                cboKieuSX.Items.AddRange(new string[] { "Mã Sinh Viên", "Họ Tên", "Lớp" });
                cboKieuSX.SelectedIndex = 0;
                radTang.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo danh mục: " + ex.Message);
            }
        }

        // ==========================================
        // 2. XỬ LÝ LỌC, TÌM KIẾM & SẮP XẾP CHÍNH
        // ==========================================
        private void LoadData()
        {
            try
            {
                // 1. Khởi tạo Query & Join các bảng liên quan (Include)
                var query = context.SinhVien
                    .Include(s => s.MaLopNavigation).ThenInclude(l => l.MaNganhNavigation).ThenInclude(n => n.MaKhoaNavigation)
                    .AsQueryable();

                // 2. Xử lý LỌC THEO KHOA
                if (cboKhoa.SelectedValue != null && cboKhoa.SelectedValue.ToString() != "ALL")
                {
                    string maKhoa = cboKhoa.SelectedValue.ToString();
                    query = query.Where(s => s.MaLopNavigation.MaNganhNavigation.MaKhoa == maKhoa);
                }

                // 3. Xử lý TÌM KIẾM
                string tuKhoa = txtTuKhoa.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa) && cboTimKiem.SelectedIndex != -1)
                {
                    string loaiTK = cboTimKiem.SelectedItem.ToString();
                    switch (loaiTK)
                    {
                        case "Mã Sinh Viên":
                            query = query.Where(s => s.MaSV.ToLower().Contains(tuKhoa));
                            break;
                        case "Họ Tên":
                            query = query.Where(s => s.HoTen.ToLower().Contains(tuKhoa));
                            break;
                        case "Lớp":
                            query = query.Where(s => s.MaLopNavigation.TenLop.ToLower().Contains(tuKhoa));
                            break;
                    }
                }

                // 4. Xử lý SẮP XẾP
                bool isTang = radTang.Checked;
                if (cboKieuSX.SelectedIndex != -1)
                {
                    string kieuSX = cboKieuSX.SelectedItem.ToString();
                    switch (kieuSX)
                    {
                        case "Mã Sinh Viên":
                            query = isTang ? query.OrderBy(s => s.MaSV) : query.OrderByDescending(s => s.MaSV);
                            break;
                        case "Họ Tên":
                            query = isTang ? query.OrderBy(s => s.HoTen) : query.OrderByDescending(s => s.HoTen);
                            break;
                        case "Lớp":
                            query = isTang ? query.OrderBy(s => s.MaLopNavigation.TenLop) : query.OrderByDescending(s => s.MaLopNavigation.TenLop);
                            break;
                    }
                }

                // 5. Chuẩn bị dữ liệu hiển thị (Định dạng lại cho đẹp)
                var listHienThi = query.ToList().Select(s => new
                {
                    MaSV = s.MaSV,
                    HoTen = s.HoTen,
                    NgaySinh = s.NgaySinh,
                    GioiTinh = s.GioiTinh,
                    // Lấy Tên Lớp, Tên Khoa từ các bảng đã Include
                    TenLop = s.MaLopNavigation?.TenLop ?? "",
                    TenKhoa = s.MaLopNavigation?.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa ?? "",
                    TrangThaiHienThi = s.TrangThai == 1 ? "Đang học" : "Đã nghỉ"
                }).ToList();

                dgvDanhSachSV.DataSource = listHienThi;
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi mốc thời gian load form chưa xong
            }
        }

        // ==========================================
        // 3. SỰ KIỆN NÚT BẤM
        // ==========================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            // Reset các bộ lọc về mặc định
            txtTuKhoa.Clear();
            cboTimKiem.SelectedIndex = 1;
            cboKhoa.SelectedIndex = 0;
            cboKieuSX.SelectedIndex = 0;
            radTang.Checked = true;

            LoadData();
        }

        // Sự kiện Click vào cột nút "Nhập Điểm"
        private void dgvDanhSachSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tên cột nút bấm trong Designer của bạn là "ThaoTac" hoặc "btnNhapDiem"
            if (e.RowIndex >= 0 && dgvDanhSachSV.Columns[e.ColumnIndex].Name == "ThaoTac")
            {
                string maSV = dgvDanhSachSV.Rows[e.RowIndex].Cells["MaSV"].Value.ToString();
                // Bắn sự kiện sang Form Chính để mở UC_Diem
                OnChuyenManHinhNhapDiem?.Invoke(maSV);
            }
        }

        private void cboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radTang_CheckedChanged(object sender, EventArgs e)
        {
            if (radTang.Checked == true)
                LoadData();
        }

        private void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            if(radGiam.Checked)
                LoadData();
        }
    }
}