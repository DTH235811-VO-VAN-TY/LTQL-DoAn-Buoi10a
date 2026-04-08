using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data; // Namespace chứa Context và Models
using QuanLyDiemSV.Forms; // Namespace chứa FrmNganh

namespace QuanLyDiemSV.Forms
{
    public partial class UC_LopHanhChinh : UserControl
    {
        // 1. Khởi tạo Context và BindingSource
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsLop = new BindingSource();
        bool xuLyThem = false;
        bool daTaiDuLieu = false; // Biến cờ

        public UC_LopHanhChinh()
        {
            InitializeComponent();
            this.Load += UC_LopHanhChinh_Load;
            StyleDataGridView(dgvLopHanhChinh);

        }
        private void StyleDataGridView(DataGridView dgv)
        {
            try
            {
                // 0. Bật Double Buffering để chống giật lag khi cuộn chuột
                typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
                dgv, new object[] { true });

                // 1. TẮT Visual Styles mặc định của Windows
                dgv.EnableHeadersVisualStyles = false;

                // 2. CHỈNH HEADER (Tiêu đề cột)
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); // Xanh dương
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersHeight = 45;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                // 3. CHỈNH DÒNG XEN KẼ (Zebra striping)
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250); // Xám nhạt
                dgv.RowsDefaultCellStyle.BackColor = Color.White;

                // 4. CHỈNH FONT CHỮ VÀ CHIỀU CAO DÒNG
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgv.RowTemplate.Height = 40; // Dòng cao thoáng dễ click

                // 5. CHỈNH DÒNG KHI ĐƯỢC CHỌN (Highlight)
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 230, 241); // Xanh lơ nhạt
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                // 6. CHỈNH VIỀN Ô PHÂN CÁCH (Bảng nét đơn)
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgv.GridColor = Color.FromArgb(200, 200, 200); // Màu đường kẻ xám vừa
            }
            catch { } // Bỏ qua lỗi ngầm nếu có
        }

        private void UC_LopHanhChinh_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            KhoiTaoCboTimKiemSapXep();
        }
        public async Task CapNhatDuLieuMoiNhat()
        {
            // 1. Tải lại danh sách ComboBox bằng một Context mới hoàn toàn
            using (var freshContext = new QLDSVDbContext())
            {
                var oldNganh = cboNganh.SelectedValue;
                var oldGV = cboGCVN.SelectedValue;

                cboNganh.DataSource = await freshContext.Nganh.AsNoTracking().ToListAsync();
                cboNganh.DisplayMember = "TenNganh";
                cboNganh.ValueMember = "MaNganh";

                cboGCVN.DataSource = await freshContext.GiangVien.AsNoTracking().ToListAsync();
                cboGCVN.DisplayMember = "HoTen";
                cboGCVN.ValueMember = "MaGV";

                if (oldNganh != null) cboNganh.SelectedValue = oldNganh;
                if (oldGV != null) cboGCVN.SelectedValue = oldGV;
            }

            // 2. Ép Context chính xóa bộ nhớ đệm và tải lại lưới Lớp hành chính
            context.ChangeTracker.Clear();
            LoadData();
        }


        private void KhoiTaoCboTimKiemSapXep()
        {
            // 1. ComboBox Loại Tìm Kiếm (cboLoaiTK)
            cboAdTimKiem_SV.Items.Clear();
            cboAdTimKiem_SV.Items.AddRange(new string[] { "Mã Lớp", "Tên Lớp", "Cố vấn học tập" });
            cboAdTimKiem_SV.SelectedIndex = 1; // Mặc định tìm theo Tên Lớp

            // 2. ComboBox Kiểu Sắp Xếp
            cboKieuSX.Items.Clear();
            cboKieuSX.Items.AddRange(new string[] { "Mã Lớp", "Tên Lớp", "Cố vấn học tập" });
            cboKieuSX.SelectedIndex = 0; // Mặc định sắp xếp theo Mã Lớp
        }

        #region 1. HÀM HỖ TRỢ VÀ LOAD DỮ LIỆU

        private void BatTatChucNang(bool giaTri)
        {
            // Các nút lưu/hủy
            btnLuu.Enabled = giaTri;
            btnLamLai.Enabled = giaTri;

            // Các ô nhập liệu
            txtMaLop.Enabled = giaTri;
            txtTenLop.Enabled = giaTri;
            txtNienKhoa.Enabled = giaTri;

            cboNganh.Enabled = giaTri; // Đã sửa tên biến từ cboHocVi -> cboNganh
            cboGCVN.Enabled = giaTri;  // Đã thêm xử lý cho GVCN

            btnAddNganh.Enabled = giaTri; // Nút thêm nhanh ngành

            // Các nút chức năng
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Thêm AsNoTracking() vào đây
                var listNganh = context.Nganh.AsNoTracking().ToList();
                cboNganh.DataSource = listNganh;
                cboNganh.DisplayMember = "TenNganh";
                cboNganh.ValueMember = "MaNganh";
                cboNganh.SelectedIndex = -1;

                // Thêm AsNoTracking() vào đây
                var listGV = context.GiangVien.AsNoTracking().ToList();
                cboGCVN.DataSource = listGV;
                cboGCVN.DisplayMember = "HoTen";
                cboGCVN.ValueMember = "MaGV";
                cboGCVN.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }
        bool dangTruyVan = false;
        private async Task LoadData()
        {
            if (dangTruyVan) return; // Tránh gọi chồng chéo nếu người dùng bấm liên tục
            dangTruyVan = true;
            try
            {
                var query = context.LopHanhChinh.Include(l => l.MaGVCNNavigation).AsQueryable();
                string tuKhoa = txtAdTuKhoa_SV.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa) && cboAdTimKiem_SV.SelectedIndex != -1)
                {
                    string loaiTK = cboAdTimKiem_SV.SelectedItem.ToString();
                    switch (loaiTK)
                    {
                        case "Mã Lớp":
                            query = query.Where(g => g.MaLop.ToLower().Contains(tuKhoa));
                            break;
                        case "Tên Lớp":
                            query = query.Where(g => g.TenLop.ToLower().Contains(tuKhoa));
                            break;
                        case "Cố vấn học tập":
                            query = query.Where(g => g.MaGVCNNavigation.HoTen.ToLower() == tuKhoa);
                            break;
                    }
                }
                bool isTang = radTang.Checked;
                if (cboKieuSX.SelectedIndex != -1)
                {
                    string kieuSX = cboKieuSX.SelectedItem.ToString();
                    switch (kieuSX)
                    {
                        case "Mã Lớp":
                            query = isTang ? query.OrderBy(g => g.MaLop) : query.OrderByDescending(g => g.MaLop);
                            break;
                        case "Tên Lớp":
                            query = isTang ? query.OrderBy(g => g.TenLop) : query.OrderByDescending(g => g.TenLop);
                            break;
                        case "Cố vấn học tập":
                            query = isTang ? query.OrderBy(g => g.MaGVCNNavigation.HoTen) : query.OrderByDescending(g => g.MaGVCNNavigation.HoTen);
                            break;
                    }
                }

                // ---Dùng LINQ để lấy Tên Giảng Viên ---
                /*  var listLop = (from lop in context.LopHanhChinh
                                 join gv in context.GiangVien on lop.MaGVCN equals gv.MaGV into groupGV
                                 from subGV in groupGV.DefaultIfEmpty() // Left Join (Để lớp chưa có GV vẫn hiện ra)
                                 select new
                                 {
                                     lop.MaLop,
                                     lop.TenLop,
                                     lop.NienKhoa,
                                     lop.MaNganh,
                                     lop.MaGVCN, // Vẫn giữ Mã GV để Binding vào ComboBox

                                     // Tạo cột mới hiển thị Tên GV
                                     TenGV = (subGV == null) ? "Chưa phân công" : subGV.HoTen
                                 }).ToList();*/

                var listLop = await query.Select(l => new
                {
                    MaLop = l.MaLop,
                    TenLop = l.TenLop,
                    NienKhoa = l.NienKhoa,
                    MaNganh = l.MaNganh,
                    MaGVCN = l.MaGVCN,
                    // 2 Cột này chỉ dùng để hiển thị chữ lên DataGridView cho đẹp
                    TenNganh = l.MaNganhNavigation != null ? l.MaNganhNavigation.TenNganh : "Chưa có ngành",
                    TenGV = l.MaGVCNNavigation != null ? l.MaGVCNNavigation.HoTen : "Chưa phân công"
                }).ToListAsync();

                // Gán dữ liệu vào BindingSource
                bsLop.DataSource = listLop;

                // Xóa Binding cũ
                txtMaLop.DataBindings.Clear();
                txtTenLop.DataBindings.Clear();
                txtNienKhoa.DataBindings.Clear();
                cboNganh.DataBindings.Clear();
                cboGCVN.DataBindings.Clear();

                // Tạo Binding mới
                txtMaLop.DataBindings.Add("Text", bsLop, "MaLop", true, DataSourceUpdateMode.Never);
                txtTenLop.DataBindings.Add("Text", bsLop, "TenLop", true, DataSourceUpdateMode.Never);
                txtNienKhoa.DataBindings.Add("Text", bsLop, "NienKhoa", true, DataSourceUpdateMode.Never);

                // Binding ComboBox (Vẫn dùng Mã để chọn đúng dòng trong ComboBox)
                cboNganh.DataBindings.Add("SelectedValue", bsLop, "MaNganh", true, DataSourceUpdateMode.Never);
                cboGCVN.DataBindings.Add("SelectedValue", bsLop, "MaGVCN", true, DataSourceUpdateMode.Never);

                // Hiển thị lên Grid
                dgvLopHanhChinh.AutoGenerateColumns = false;
                dgvLopHanhChinh.DataSource = bsLop;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                // 2. MỞ KHÓA: Dù lấy dữ liệu thành công hay bị lỗi cũng phải mở cửa ra cho luồng khác
                dangTruyVan = false;
            }
        }

        #endregion

        #region 2. XỬ LÝ NÚT BẤM (CRUD)

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            // Xóa trắng dữ liệu nhập
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtNienKhoa.Clear();
            cboNganh.SelectedIndex = -1;
            cboGCVN.SelectedIndex = -1;

            txtMaLop.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (bsLop.Current == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!");
                return;
            }

            xuLyThem = false;
            BatTatChucNang(true);
            txtMaLop.Enabled = false; // Khóa chính không được sửa
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bsLop.Current == null) return;
            var lop = (LopHanhChinh)bsLop.Current;

            if (MessageBox.Show($"Bạn có chắc muốn xóa lớp {lop.TenLop}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    context.LopHanhChinh.Remove(lop);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (Lớp này đang có sinh viên): " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp và Tên lớp!");
                return;
            }
            if (cboNganh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Ngành!");
                return;
            }

            try
            {
                if (xuLyThem) // --- THÊM MỚI ---
                {
                    // Check trùng mã
                    if (context.LopHanhChinh.Any(x => x.MaLop == txtMaLop.Text.Trim()))
                    {
                        MessageBox.Show("Mã lớp đã tồn tại!");
                        return;
                    }

                    LopHanhChinh lop = new LopHanhChinh();
                    lop.MaLop = txtMaLop.Text.Trim();
                    lop.TenLop = txtTenLop.Text.Trim();
                    lop.NienKhoa = txtNienKhoa.Text.Trim();
                    lop.MaNganh = cboNganh.SelectedValue.ToString();

                    // Lưu MaGV (GVCN) - Nếu có chọn thì lưu, không thì để null
                    if (cboGCVN.SelectedValue != null)
                        lop.MaGVCN = cboGCVN.SelectedValue.ToString();

                    context.LopHanhChinh.Add(lop);
                }
                else // --- CẬP NHẬT (SỬA) ---
                {
                    var lop = context.LopHanhChinh.Find(txtMaLop.Text.Trim());
                    if (lop != null)
                    {
                        lop.TenLop = txtTenLop.Text.Trim();
                        lop.NienKhoa = txtNienKhoa.Text.Trim();
                        lop.MaNganh = cboNganh.SelectedValue.ToString();

                        if (cboGCVN.SelectedValue != null)
                            lop.MaGVCN = cboGCVN.SelectedValue.ToString();
                        else
                            lop.MaGVCN = null; // Nếu bỏ chọn GVCN

                        context.LopHanhChinh.Update(lop);
                    }
                }

                context.SaveChanges();
                LoadData();
                BatTatChucNang(false);
                MessageBox.Show("Lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            bsLop.ResetBindings(false); // Reset lại giá trị cũ
        }

        // Nút thêm nhanh Ngành (nút nhỏ bên cạnh combobox)
        private void btnAddNganh_Click(object sender, EventArgs e)
        {
            FrmNganh frm = new FrmNganh();
            frm.ShowDialog();
            // Sau khi tắt form ngành thì load lại combobox để thấy ngành mới
            LoadComboBoxData();
        }

        #endregion

        private async void btnAdTimKiem_SV_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnAdShowAll_SV_Click(object sender, EventArgs e)
        {
            txtAdTuKhoa_SV.Clear();
            cboAdTimKiem_SV.SelectedIndex = 1;
            cboKieuSX.SelectedIndex = 0;
            radTang.Checked = true;
            await LoadData();
        }

        private async void cboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void radTang_CheckedChanged(object sender, EventArgs e)
        {
            if (radTang.Checked) await LoadData();
        }

        private async void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiam.Checked) await LoadData();

        }
    }
}