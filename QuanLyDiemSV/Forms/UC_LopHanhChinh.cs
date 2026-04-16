using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // =====================================================================
            // 1. PHÍM TẮT HỆ THỐNG: HOẠT ĐỘNG TOÀN CỤC (Kể cả khi đang gõ chữ)
            // =====================================================================

            // Ctrl + S: Lưu dữ liệu
            if (keyData == (Keys.Control | Keys.S))
            {
                // Lưu ý: Kiểm tra nút Lưu có đang hiện/bật không trước khi click
                if (btnLuu.Enabled)
                {
                    btnLuu.PerformClick();
                    return true;
                }
            }

            // F5: Làm lại / Tải lại dữ liệu (Thay cho phím R cũ)
            if (keyData == Keys.F5)
            {
                btnLamLai.PerformClick();
                return true;
            }

            // Enter: Tìm kiếm khi đang đứng ở ô Từ khóa
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl == txtAdTuKhoa_SV)
                {
                    btnAdTimKiem_SV.PerformClick();
                    return true;
                }
            }

            // =====================================================================
            // 2. KHÓA AN TOÀN: Chặn phím tắt đơn khi người dùng đang nhập liệu
            // (Để tránh việc gõ chữ 'C' trong tên mà lại nhảy sang lệnh Thêm mới)
            // =====================================================================
            if (this.ActiveControl is TextBox || this.ActiveControl is ComboBox)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            // =====================================================================
            // 3. CÁC PHÍM TẮT ĐƠN: CHỈ HOẠT ĐỘNG KHI KHÔNG GÕ CHỮ
            // =====================================================================
            switch (keyData)
            {
                case Keys.C: // Thêm mới (Create)
                    btnThem.PerformClick();
                    return true;

                case Keys.U: // Sửa (Update)
                    btnSua.PerformClick();
                    return true;

                case Keys.D: // Xóa (Delete)
                    btnXoa.PerformClick();
                    return true;

                case Keys.F: // Tìm kiếm (Find)
                    txtAdTuKhoa_SV.Focus();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
            try
            {
                await LoadCboKhoaAsync();
                await LoadData();
                daTaiDuLieu = true; // Đánh dấu đã tải dữ liệu để sự kiện lọc dữ liệu hoạt động
            }
            catch
            {

            }
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
        private async Task LoadCboKhoaAsync()
        {
            try
            {
                // Lấy danh sách Khoa từ Database
                var listKhoa = await context.Khoa.ToListAsync();

                // Chèn thêm mục "Tất cả" lên vị trí đầu tiên (index 0)
                listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "--- Tất cả các khoa ---" });

                // Đổ dữ liệu vào ComboBox
                cboLocDuLieu.DataSource = listKhoa;
                cboLocDuLieu.DisplayMember = "TenKhoa";
                cboLocDuLieu.ValueMember = "MaKhoa";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool dangTruyVan = false;
        private async Task LoadData()
        {
            if (dangTruyVan) return; // Tránh gọi chồng chéo nếu người dùng bấm liên tục
            dangTruyVan = true;
            try
            {
                var query = context.LopHanhChinh
                                    .Include(l => l.MaGVCNNavigation)
                                    .Include(l => l.MaNganhNavigation)
                                    .AsQueryable();
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
                if (cboLocDuLieu.SelectedValue != null && cboLocDuLieu.SelectedValue.ToString() != "ALL")
                {
                    string maKhoaChon = cboLocDuLieu.SelectedValue.ToString();
                    // Lọc các Lớp Học Phần có Môn Học thuộc Khoa đã chọn
                    query = query.Where(l => l.MaNganhNavigation != null && l.MaNganhNavigation.MaKhoa == maKhoaChon);
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

        private async void cboLocDuLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (daTaiDuLieu)
            {
                await LoadData();
            }
        }

        private async void btnNhap_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        int countThanhCong = 0;
                        List<string> dsLoi = new List<string>();

                        using (var workbook = new XLWorkbook(ofd.FileName))
                        {
                            var worksheet = workbook.Worksheet(1);
                            // Lấy các dòng dữ liệu, bỏ qua dòng tiêu đề (Skip 1)
                            var rows = worksheet.RangeUsed().RowsUsed().Skip(1).ToList();

                            // Lấy trước danh sách Mã Ngành và Mã GV để kiểm tra nhanh trên RAM (tối ưu tốc độ)
                            var listMaNganh = await context.Nganh.Select(n => n.MaNganh).ToListAsync();
                            var listMaGV = await context.GiangVien.Select(g => g.MaGV).ToListAsync();

                            foreach (var row in rows)
                            {
                                string maLop = row.Cell(1).GetString().Trim();
                                string tenLop = row.Cell(2).GetString().Trim();
                                string nienKhoa = row.Cell(3).GetString().Trim();
                                string maNganh = row.Cell(4).GetString().Trim();
                                string maGVCN = row.Cell(5).GetString().Trim();

                                if (string.IsNullOrEmpty(maLop)) continue;

                                // KIỂM TRA RÀNG BUỘC
                                // 1. Kiểm tra trùng mã lớp
                                if (await context.LopHanhChinh.AnyAsync(x => x.MaLop == maLop))
                                {
                                    dsLoi.Add($"- Dòng {row.RowNumber()}: Mã lớp [{maLop}] đã tồn tại.");
                                    continue;
                                }

                                // 2. Kiểm tra mã ngành có tồn tại không
                                if (!listMaNganh.Contains(maNganh))
                                {
                                    dsLoi.Add($"- Dòng {row.RowNumber()}: Mã ngành [{maNganh}] không tồn tại.");
                                    continue;
                                }

                                // 3. Kiểm tra mã GVCN có tồn tại không
                                if (!listMaGV.Contains(maGVCN))
                                {
                                    dsLoi.Add($"- Dòng {row.RowNumber()}: Mã GVCN [{maGVCN}] không tồn tại.");
                                    continue;
                                }

                                // Nếu mọi thứ OK -> Thêm mới
                                LopHanhChinh lopMoi = new LopHanhChinh()
                                {
                                    MaLop = maLop,
                                    TenLop = tenLop,
                                    NienKhoa = nienKhoa,
                                    MaNganh = maNganh,
                                    MaGVCN = maGVCN
                                };

                                context.LopHanhChinh.Add(lopMoi);
                                countThanhCong++;
                            }

                            // Lưu tất cả xuống Database
                            if (countThanhCong > 0)
                            {
                                await context.SaveChangesAsync();
                                await LoadData(); // Tải lại lưới

                                string thongBao = $"Đã nhập thành công {countThanhCong} lớp hành chính.";
                                if (dsLoi.Count > 0)
                                {
                                    thongBao += $"\n\nCác dòng bị lỗi:\n" + string.Join("\n", dsLoi.Take(5));
                                    if (dsLoi.Count > 5) thongBao += "\n...";
                                    MessageBox.Show(thongBao, "Hoàn tất (Có lỗi)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu hợp lệ để nhập!\n" + string.Join("\n", dsLoi), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachLopHanhChinh.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Lớp Hành Chính");

                            // 1. Tạo Tiêu đề cột
                            worksheet.Cell(1, 1).Value = "Mã Lớp";
                            worksheet.Cell(1, 2).Value = "Tên Lớp";
                            worksheet.Cell(1, 3).Value = "Niên Khóa";
                            worksheet.Cell(1, 4).Value = "Mã Ngành";
                            worksheet.Cell(1, 5).Value = "Mã GVCN";

                            var header = worksheet.Range("A1:E1");
                            header.Style.Font.Bold = true;
                            header.Style.Fill.BackgroundColor = XLColor.LightGray;

                            // 2. Lấy dữ liệu từ BindingSource (bsLop)
                            var danhSach = bsLop.List;
                            int row = 2;
                            foreach (dynamic item in danhSach)
                            {
                                worksheet.Cell(row, 1).Value = item.MaLop?.ToString() ?? "";
                                worksheet.Cell(row, 2).Value = item.TenLop?.ToString() ?? "";
                                worksheet.Cell(row, 3).Value = item.NienKhoa?.ToString() ?? "";
                                worksheet.Cell(row, 4).Value = item.MaNganh?.ToString() ?? "";
                                worksheet.Cell(row, 5).Value = item.MaGVCN?.ToString() ?? "";
                                row++;
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }
    }
}