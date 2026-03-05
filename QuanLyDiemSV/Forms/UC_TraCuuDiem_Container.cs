using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;
using QuanLyDiemSV.DTO;
using GUI;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_TraCuuDiem_Container : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        UC_TraCuu_ChiTiet ucChiTiet;

        public UC_TraCuuDiem_Container()
        {
            InitializeComponent();
            this.Load += UC_TraCuuDiem_Container_Load;
        }

        private void UC_TraCuuDiem_Container_Load(object sender, EventArgs e)
        {
            InitChiTietView();
            LoadComboBoxKhoa();
            LoadDanhSachSinhVien();

            // Gán sự kiện sau khi load dữ liệu xong để tránh trigger sớm
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            cboLop.SelectedIndexChanged += (s, ev) => LoadDanhSachSinhVien();
            cboLoaiSX.SelectedIndexChanged += (s, ev) => LoadDanhSachSinhVien();
            radTang.CheckedChanged += (s, ev) => LoadDanhSachSinhVien();
            radGiam.CheckedChanged += (s, ev) => LoadDanhSachSinhVien();
        }

        private void InitChiTietView()
        {
            if (ucChiTiet == null)
            {
                ucChiTiet = new UC_TraCuu_ChiTiet();
                ucChiTiet.Dock = DockStyle.Fill;
                ucChiTiet.Visible = false;
                ucChiTiet.QuayLaiTraCuulicked += UcChiTiet_QuayLaiClicked;
                this.Controls.Add(ucChiTiet);
                ucChiTiet.BringToFront();
            }
        }

        private void LoadComboBoxKhoa()
        {
            try
            {
                var listKhoa = context.Khoa.ToList();
                listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "--- Tất cả Khoa ---" });
                cboKhoa.DataSource = listKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
                cboKhoa.SelectedIndex = 0;

                cboLoaiSX.Items.Clear();
                cboLoaiSX.Items.AddRange(new string[] { "Mã Sinh Viên", "Họ Tên", "Điểm Tích Lũy" });
                cboLoaiSX.SelectedIndex = 0;
            }
            catch { }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue == null) return;
            // Kiểm tra an toàn xem giá trị có phải chuỗi ID không
            if (cboKhoa.SelectedValue is string maKhoa)
            {
                List<LopHanhChinh> listLop;
                if (maKhoa == "ALL")
                {
                    listLop = context.LopHanhChinh.ToList();
                }
                else
                {
                    listLop = context.LopHanhChinh
                                     .Include(l => l.MaNganhNavigation)
                                     .Where(l => l.MaNganhNavigation.MaKhoa == maKhoa)
                                     .ToList();
                }

                listLop.Insert(0, new LopHanhChinh { MaLop = "ALL", TenLop = "--- Tất cả Lớp ---" });

                cboLop.DataSource = null;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = listLop;
                cboLop.SelectedIndex = 0;

                LoadDanhSachSinhVien();
            }
        }

        public void LoadDanhSachSinhVien()
        {
            try
            {
                dgvDanhSachSV.AutoGenerateColumns = false;

                var query = context.SinhVien
                    .Include(s => s.MaLopNavigation).ThenInclude(l => l.MaNganhNavigation).ThenInclude(n => n.MaKhoaNavigation)
                    .Include(s => s.KetQuaHocTap).ThenInclude(k => k.MaLHPNavigation).ThenInclude(h => h.MaMonNavigation)
                    .AsQueryable();
                


                // Lọc
                if (cboKhoa.SelectedValue is string maKhoa && maKhoa != "ALL")
                {
                    query = query.Where(s => s.MaLopNavigation.MaNganhNavigation.MaKhoa == maKhoa);
                }
                if (cboLop.SelectedValue is string maLop && maLop != "ALL")
                {
                    query = query.Where(s => s.MaLop == maLop);
                }
                if (!string.IsNullOrEmpty(txtTuKhoa.Text))
                {
                    string k = txtTuKhoa.Text.ToLower().Trim();
                    query = query.Where(s => s.MaSV.ToLower().Contains(k) || s.HoTen.ToLower().Contains(k));
                }

                var rawList = query.ToList();

                var listHienThi = rawList.Select(sv =>
                {
                    var monCoDiem = sv.KetQuaHocTap.Where(k => k.DiemTongKet != null).ToList();
                    double tongDiem = 0;
                    int tongTC = 0;

                    foreach (var k in monCoDiem)
                    {
                        int tinChi = k.MaLHPNavigation?.MaMonNavigation?.SoTinChi ?? 0;
                        decimal diem = k.DiemTongKet ?? 0;
                        tongDiem += (double)diem * tinChi;
                        tongTC += tinChi;
                    }

                    return new SinhVienTraCuuDTO
                    {
                        MaSV = sv.MaSV,
                        HoTen = sv.HoTen,
                        TenLop = sv.MaLopNavigation?.TenLop ?? "",
                        TenKhoa = sv.MaLopNavigation?.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa ?? "",
                        TinChiTichLuy = tongTC,
                        DiemTrungBinh = tongTC > 0 ? Math.Round(tongDiem / tongTC, 2) : 0
                    };
                }).ToList();

                // Sắp xếp
                if (cboLoaiSX.SelectedItem != null)
                {
                    string kieuSX = cboLoaiSX.SelectedItem.ToString();

                    if (kieuSX == "Họ Tên")
                    {
                        listHienThi = radTang.Checked
                            ? listHienThi.OrderBy(x => x.HoTen).ToList()
                            : listHienThi.OrderByDescending(x => x.HoTen).ToList();
                    }
                    else if (kieuSX == "Điểm Tích Lũy" || kieuSX == "Điểm số")
                    {
                        listHienThi = radTang.Checked
                            ? listHienThi.OrderBy(x => x.DiemTrungBinh).ToList()
                            : listHienThi.OrderByDescending(x => x.DiemTrungBinh).ToList();
                    }
                    else // Mặc định là sắp xếp theo Mã Sinh Viên
                    {
                        listHienThi = radTang.Checked
                            ? listHienThi.OrderBy(x => x.MaSV).ToList()
                            : listHienThi.OrderByDescending(x => x.MaSV).ToList();
                    }
                }

                dgvDanhSachSV.DataSource = listHienThi;

                // Map cột
                if (dgvDanhSachSV.Columns["MaSV"] != null) dgvDanhSachSV.Columns["MaSV"].DataPropertyName = "MaSV";
                if (dgvDanhSachSV.Columns["HoTen"] != null) dgvDanhSachSV.Columns["HoTen"].DataPropertyName = "HoTen";
                if (dgvDanhSachSV.Columns["TenLop"] != null) dgvDanhSachSV.Columns["TenLop"].DataPropertyName = "TenLop";
                if (dgvDanhSachSV.Columns["TenKhoa"] != null) dgvDanhSachSV.Columns["TenKhoa"].DataPropertyName = "TenKhoa";
                if (dgvDanhSachSV.Columns["DiemTrungBinh"] != null) dgvDanhSachSV.Columns["DiemTrungBinh"].DataPropertyName = "DiemTrungBinh";
                if (dgvDanhSachSV.Columns["SoTinChi"] != null) dgvDanhSachSV.Columns["SoTinChi"].DataPropertyName = "TinChiTichLuy";
                // CẤU HÌNH CỘT NÚT BẤM "NHẬP ĐIỂM" BẰNG CODE
                // =========================================================
                if (dgvDanhSachSV.Columns["ThaoTac"] is DataGridViewButtonColumn btnCol)
                {
                    // Nếu đã là cột Button thì chỉ cần ép nó hiện chữ
                    btnCol.Text = "Xem chi tiết";
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
                    newBtnCol.Text = "Xem chi tiết";
                    newBtnCol.UseColumnTextForButtonValue = true; // Bắt buộc = true để hiện chữ
                    dgvDanhSachSV.Columns.Insert(index, newBtnCol);
                }
                else
                {
                    // Nếu chưa có cột nào tên ThaoTac, tự tạo mới ở cuối lưới
                    DataGridViewButtonColumn newBtnCol = new DataGridViewButtonColumn();
                    newBtnCol.Name = "ThaoTac";
                    newBtnCol.HeaderText = "Thao Tác";
                    newBtnCol.Text = "Xem chi tiết";
                    newBtnCol.UseColumnTextForButtonValue = true;
                    dgvDanhSachSV.Columns.Add(newBtnCol);
                }
            }
            catch { }
        }

        private void btnXemChitiet_Click(object sender, EventArgs e)
        {
            XemChiTietSinhVien();
        }

        private void dgvDanhSachSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (dgvDanhSachSV.Columns[e.ColumnIndex].Name == "ThaoTac" || dgvDanhSachSV.Columns[e.ColumnIndex].Name == "btnXemChiTiet"))
            {
                XemChiTietSinhVien();
            }
        }

        private void XemChiTietSinhVien()
        {
            if (dgvDanhSachSV.CurrentRow == null || dgvDanhSachSV.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cellValue = dgvDanhSachSV.CurrentRow.Cells["MaSV"].Value;
            if (cellValue == null) return;

            string maSV = cellValue.ToString();
            if (ucChiTiet == null) InitChiTietView();

            ucChiTiet.LoadDuLieuChiTiet(maSV);
            ucChiTiet.Visible = true;
            ucChiTiet.BringToFront();

            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void UcChiTiet_QuayLaiClicked(object sender, EventArgs e)
        {
            ucChiTiet.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e) { LoadDanhSachSinhVien(); }
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboKhoa.SelectedIndex = 0;
            txtTuKhoa.Clear();
            LoadDanhSachSinhVien();
        }

        private void radTang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radGiam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboLoaiSX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}