using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;
using QuanLyDiemSV.Forms;
using System.Text.RegularExpressions;
using ClosedXML.Excel;

namespace QuanLyDiemSV
{
    public partial class UC_LopHocPhan : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsLopHP = new BindingSource();
        bool xuLyThem = false;
        bool daTaiDuLieu = false; // Biến cờ

        public UC_LopHocPhan()
        {
            InitializeComponent();
            this.Load += UC_LopHocPhan_Load;
            StyleDataGridView(dgvLopHocPhan);
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

        private void UC_LopHocPhan_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            KhoiTaoCboTimKiemSapXep();
        }
        // Hàm này có chữ 'public' để Form1 có thể gọi được
        public void CapNhatDuLieuMoiNhat()
        {
            using (var freshContext = new QLDSVDbContext())
            {
                var oldGV = cboMaGV.SelectedValue;
                var oldMon = cboMaMon.SelectedValue;
                var oldHK = cboHocKy.SelectedValue; // Thêm dòng này

                cboMaGV.DataSource = freshContext.GiangVien.AsNoTracking().ToList();
                cboMaGV.DisplayMember = "HoTen";
                cboMaGV.ValueMember = "MaGV";

                cboMaMon.DataSource = freshContext.MonHoc.AsNoTracking().ToList();
                cboMaMon.DisplayMember = "TenMon";
                cboMaMon.ValueMember = "MaMon";

                // THÊM 3 DÒNG NÀY ĐỂ NẠP HỌC KỲ
                cboHocKy.DataSource = freshContext.HocKy.AsNoTracking().ToList();
                cboHocKy.DisplayMember = "TenHK";
                cboHocKy.ValueMember = "MaHK";

                if (oldGV != null) cboMaGV.SelectedValue = oldGV;
                if (oldMon != null) cboMaMon.SelectedValue = oldMon;
                if (oldHK != null) cboHocKy.SelectedValue = oldHK; // Thêm dòng này
            }

            if (!daTaiDuLieu)
            {
                LoadData();
                daTaiDuLieu = true;
            }
        }

        #region 1. HÀM HỖ TRỢ VÀ LOAD DỮ LIỆU

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnLamLai.Enabled = giaTri;

            txtMaLHP.Enabled = giaTri;
            txtTenLHP.Enabled = giaTri;
            txtPhongHoc.Enabled = giaTri;
            txtSiSo.Enabled = giaTri;

            cboMaMon.Enabled = giaTri;
            cboMaGV.Enabled = giaTri;
            cboHocKy.Enabled = giaTri;
            cboTrangThai.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnXepLop.Enabled = !giaTri;
        }
        private void KhoiTaoCboTimKiemSapXep()
        {
            // 1. ComboBox Loại Tìm Kiếm (cboLoaiTK)
            cboTimKiem.Items.Clear();
            cboTimKiem.Items.AddRange(new string[] { "Mã Lớp học phần", "Tên Lớp Học Phần", "Giảng viên", "Mã Môn", "Học Kỳ" });
            cboTimKiem.SelectedIndex = 1; // Mặc định tìm theo Tên LHP

            // 2. ComboBox Kiểu Sắp Xếp
            cboKieuSX.Items.Clear();
            cboKieuSX.Items.AddRange(new string[] { "Mã Lớp học phần", "Tên Lớp Học Phần", "Giảng viên", "Học Kỳ" });
            cboKieuSX.SelectedIndex = 0; // Mặc định sắp xếp theo Mã GV
        }
        private void LoadComboBoxData()
        {
            using (var freshContext = new QLDSVDbContext())
            {
                // -- NẠP GIẢNG VIÊN --
                cboMaGV.DataSource = null; // Ép reset
                cboMaGV.DataSource = freshContext.GiangVien.ToList();
                cboMaGV.DisplayMember = "HoTen";
                cboMaGV.ValueMember = "MaGV";

                // -- NẠP MÔN HỌC --
                cboMaMon.DataSource = null;
                cboMaMon.DataSource = freshContext.MonHoc.ToList();
                cboMaMon.DisplayMember = "TenMon";
                cboMaMon.ValueMember = "MaMon";

                // -- NẠP HỌC KỲ (Nếu có ComboBox Học Kỳ) --
                cboHocKy.DataSource = null;
                cboHocKy.DataSource = freshContext.HocKy.ToList();
                cboHocKy.DisplayMember = "TenHK";
                cboHocKy.ValueMember = "MaHK";
            }
        }

        private void LoadData()
        {
            try
            {
                dgvLopHocPhan.AutoGenerateColumns = false;

                var query = context.LopHocPhan.Include(l => l.MaGVNavigation)
                                                .Include(l => l.MaHKNavigation)
                                                .AsQueryable();
                string tuKhoa = txtTuKhoa.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa) && cboTimKiem.SelectedIndex != -1)
                {
                    string loaiTK = cboTimKiem.SelectedItem.ToString();
                    switch (loaiTK)
                    {
                        case "Mã Lớp học phần":
                            query = query.Where(g => g.MaLHP.ToString().Contains(tuKhoa));
                            break;
                        case "Tên Lớp Học Phần":
                            query = query.Where(g => g.TenLopHP.ToLower().Contains(tuKhoa));
                            break;
                        case "Giảng viên":
                            query = query.Where(g => g.MaGVNavigation.HoTen.ToLower() == tuKhoa);
                            break;
                        case "Mã Môn":
                            query = query.Where(g => g.MaMon.Contains(tuKhoa));
                            break;
                        case "Học Kỳ":
                            query = query.Where(g => g.MaHK.ToLower().Contains(tuKhoa));
                            break;
                    }
                }
                bool isTang = radTang.Checked;
                if (cboKieuSX.SelectedIndex != -1)
                {
                    string kieuSX = cboKieuSX.SelectedItem.ToString();
                    switch (kieuSX)
                    {
                        case "Mã Lớp học phần":
                            query = isTang ? query.OrderBy(g => g.MaLHP) : query.OrderByDescending(g => g.MaLHP);
                            break;
                        case "Tên Lớp Học Phần":
                            query = isTang ? query.OrderBy(g => g.TenLopHP) : query.OrderByDescending(g => g.TenLopHP);
                            break;
                        case "Giảng viên":
                            query = isTang ? query.OrderBy(g => g.MaGVNavigation.HoTen) : query.OrderByDescending(g => g.MaGVNavigation.HoTen);
                            break;
                        case "Học Kỳ":
                            query = isTang ? query.OrderBy(g => g.MaHK) : query.OrderByDescending(g => g.MaHK);
                            break;
                    }
                }

                var listLHP = query.ToList();

                bsLopHP.DataSource = listLHP;

                txtMaLHP.DataBindings.Clear();
                txtTenLHP.DataBindings.Clear();
                txtPhongHoc.DataBindings.Clear();
                txtSiSo.DataBindings.Clear();
                cboMaMon.DataBindings.Clear();
                cboMaGV.DataBindings.Clear();
                cboHocKy.DataBindings.Clear();
                cboTrangThai.DataBindings.Clear();

                // Binding MaLHP (int) vào Text (string) - Tự động convert khi hiển thị
                txtMaLHP.DataBindings.Add("Text", bsLopHP, "MaLHP", true, DataSourceUpdateMode.Never);
                txtTenLHP.DataBindings.Add("Text", bsLopHP, "TenLopHP", true, DataSourceUpdateMode.Never);
                txtPhongHoc.DataBindings.Add("Text", bsLopHP, "PhongHoc", true, DataSourceUpdateMode.Never);
                txtSiSo.DataBindings.Add("Text", bsLopHP, "SiSoToiDa", true, DataSourceUpdateMode.Never);

                cboMaMon.DataBindings.Add("SelectedValue", bsLopHP, "MaMon", true, DataSourceUpdateMode.Never);
                cboMaGV.DataBindings.Add("SelectedValue", bsLopHP, "MaGV", true, DataSourceUpdateMode.Never);
                cboHocKy.DataBindings.Add("SelectedValue", bsLopHP, "MaHK", true, DataSourceUpdateMode.Never);
                cboTrangThai.DataBindings.Add("SelectedValue", bsLopHP, "TrangThai", true, DataSourceUpdateMode.Never);

                // dgvLopHocPhan.AutoGenerateColumns = false;
                dgvLopHocPhan.DataSource = bsLopHP;

                bsLopHP.CurrentChanged += BsLopHP_CurrentChanged;
                BsLopHP_CurrentChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void BsLopHP_CurrentChanged(object sender, EventArgs e)
        {
            if (bsLopHP.Current != null && !xuLyThem)
            {
                var lhp = (LopHocPhan)bsLopHP.Current;
                // Giả sử: 1 = "Mở lớp", 0 = "Đóng"
                if (lhp.TrangThai == 1) cboTrangThai.SelectedIndex = 0;
                else cboTrangThai.SelectedIndex = 1;
            }
        }

        #endregion

        #region 2. XỬ LÝ NÚT BẤM (CRUD)

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            bsLopHP.SuspendBinding();
            BatTatChucNang(true);

            txtMaLHP.Clear();
            txtTenLHP.Clear();
            txtPhongHoc.Clear();
            txtSiSo.Text = "0";
            cboMaMon.SelectedIndex = -1;
            cboMaGV.SelectedIndex = -1;
            cboHocKy.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;

            txtMaLHP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (bsLopHP.Current == null) return;

            xuLyThem = false;
            BatTatChucNang(true);
            txtMaLHP.Enabled = false; // Không sửa khóa chính
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bsLopHP.Current == null) return;
            var lhp = (LopHocPhan)bsLopHP.Current;

            if (MessageBox.Show($"Bạn có chắc muốn xóa lớp {lhp.TenLopHP}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    context.LopHocPhan.Remove(lhp);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa: " + ex.Message);
                }
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                LopHocPhan lhp;

                // --- ĐÂY LÀ CHÌA KHÓA GIẢI QUYẾT LỖI ---
                if (xuLyThem)
                {
                    // KIỂM TRA ĐIỀU KIỆN MÃ LỚP KHI THÊM MỚI
                    if (!int.TryParse(txtMaLHP.Text.Trim(), out int maLopMoi))
                    {
                        MessageBox.Show("Mã Lớp Học Phần phải là số nguyên hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaLHP.Focus();
                        return;
                    }

                    // Kiểm tra xem Mã này đã tồn tại trong Database chưa
                    if (context.LopHocPhan.Any(x => x.MaLHP == maLopMoi))
                    {
                        MessageBox.Show("Mã Lớp Học Phần này đã tồn tại! Vui lòng nhập mã khác.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaLHP.Focus();
                        return;
                    }
                    
                    // NẾU THÊM MỚI: Phải tạo một đối tượng hoàn toàn mới (Mã LHP sẽ trống để SQL tự sinh)
                    lhp = new LopHocPhan();
                    
                    lhp.MaLHP = maLopMoi;
                }
                else
                {
                    // NẾU SỬA: Mới được phép lấy đối tượng đang chọn trên lưới
                    lhp = (LopHocPhan)bsLopHP.Current;
                }

                // Cập nhật các giá trị từ Combobox và Textbox vào đối tượng
                if (cboHocKy.SelectedValue != null) lhp.MaHK = cboHocKy.SelectedValue.ToString();
                if (cboMaGV.SelectedValue != null) lhp.MaGV = cboMaGV.SelectedValue.ToString();
                if (cboMaMon.SelectedValue != null) lhp.MaMon = cboMaMon.SelectedValue.ToString();

                lhp.TenLopHP = txtTenLHP.Text.Trim();
                lhp.PhongHoc = txtPhongHoc.Text.Trim();


                if (int.TryParse(txtSiSo.Text, out int siso)) lhp.SiSoToiDa = siso;
                else lhp.SiSoToiDa = 40;

                // Tiến hành lưu
                if (xuLyThem)
                {
                    lhp.TrangThai = 1; // Mặc định mở
                    context.LopHocPhan.Add(lhp); // Thêm mới tinh, không sợ lỗi Identity nữa!
                }
                else
                {
                    context.LopHocPhan.Update(lhp); // Cập nhật dòng cũ
                }

                await context.SaveChangesAsync();

                bsLopHP.ResumeBinding();
                LoadData();
                BatTatChucNang(false);
                MessageBox.Show("Lưu lớp học phần thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Móc lỗi sâu nhất từ SQL Server ra để hiển thị (như bước trước)
                Exception realError = ex;
                while (realError.InnerException != null)
                {
                    realError = realError.InnerException;
                }
                MessageBox.Show("Lỗi Database: \n" + realError.Message, "Phát Hiện Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {

            BatTatChucNang(false);
            bsLopHP.ResetBindings(false);
            BsLopHP_CurrentChanged(null, null);
        }

        private void btnAddHocKy_Click(object sender, EventArgs e)
        {
            FrmHocKy frm = new FrmHocKy();
            frm.ShowDialog();
            LoadComboBoxData();
        }

        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            cboTimKiem.SelectedIndex = 1; // Đưa về mặc định tìm theo Tên LHP
            cboKieuSX.SelectedIndex = 0;  // Đưa về mặc định sắp xếp theo Mã LHP
            radTang.Checked = true;
            LoadData();
        }

        private void cboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radTang_CheckedChanged(object sender, EventArgs e)
        {
            if (radTang.Checked) LoadData();
        }

        private void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiam.Checked) LoadData();
        }

        private void dgvLopHocPhan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem có đúng cột TrangThai không (Tên cột dựa theo Designer của bạn)
            if (dgvLopHocPhan.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string val = e.Value.ToString().ToLower();
                // Tùy theo CSDL của bạn lưu là int (1/0) hay bool (true/false)
                if (val == "1" || val == "true")
                {
                    e.Value = "Mở lớp";
                    e.CellStyle.ForeColor = Color.MediumSeaGreen; // Chữ xanh lá
                    e.CellStyle.Font = new Font(dgvLopHocPhan.Font, FontStyle.Bold); // In đậm
                }
                else
                {
                    e.Value = "Đóng";
                    e.CellStyle.ForeColor = Color.Crimson; // Chữ đỏ
                    e.CellStyle.Font = new Font(dgvLopHocPhan.Font, FontStyle.Bold);
                }
                e.FormattingApplied = true; // Báo cho WinForms biết ta đã tự format xong
            }
            //Ten GV
            if (dgvLopHocPhan.Columns[e.ColumnIndex].Name == "MaGV" && e.RowIndex >= 0)
            {
                // Ép kiểu dòng hiện tại về đối tượng LopHocPhan gốc
                var lhp = dgvLopHocPhan.Rows[e.RowIndex].DataBoundItem as LopHocPhan;

                // Vì trong hàm LoadData() bạn đã dùng lệnh .Include(l => l.MaGVNavigation)
                // Nên lhp đã chứa sẵn toàn bộ thông tin của Giảng Viên đó.
                if (lhp != null && lhp.MaGVNavigation != null)
                {
                    e.Value = lhp.MaGVNavigation.HoTen; // Bốc Tên Giảng Viên ra hiển thị
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "Chưa phân công"; // Phòng hờ trường hợp lớp chưa được gắn GV
                    e.FormattingApplied = true;
                }
            }
            // THÊM MỚI: Xử lý hiển thị Tên Học Kỳ thay vì Mã Học Kỳ
            if (dgvLopHocPhan.Columns[e.ColumnIndex].Name == "MaHK" && e.RowIndex >= 0)
            {
                var lhp = dgvLopHocPhan.Rows[e.RowIndex].DataBoundItem as LopHocPhan;

                if (lhp != null && lhp.MaHKNavigation != null)
                {
                    e.Value = lhp.MaHKNavigation.TenHK; // Bốc Tên Học Kỳ ra hiển thị
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", Title = "Chọn file Excel Lớp Học Phần" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook(ofd.FileName))
                        {
                            var worksheet = workbook.Worksheet(1);
                            var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Bỏ qua dòng tiêu đề

                            int rowCount = 0;
                            int duplicateCount = 0;

                            foreach (var row in rows)
                            {
                                string maLhpStr = row.Cell(1).Value.ToString().Trim();

                                // Bỏ qua nếu dòng trống hoặc Mã Lớp Học Phần không phải là số nguyên
                                if (string.IsNullOrEmpty(maLhpStr) || !int.TryParse(maLhpStr, out int maLHP)) continue;

                                // Bỏ qua nếu trùng mã
                                if (context.LopHocPhan.Any(x => x.MaLHP == maLHP))
                                {
                                    duplicateCount++;
                                    continue;
                                }

                                LopHocPhan lhp = new LopHocPhan();
                                lhp.MaLHP = maLHP;
                                lhp.TenLopHP = row.Cell(2).Value.ToString().Trim();
                                lhp.PhongHoc = row.Cell(3).Value.ToString().Trim().ToUpper();

                                if (int.TryParse(row.Cell(4).Value.ToString(), out int siSo) && siSo >= 0)
                                    lhp.SiSoToiDa = siSo;
                                else
                                    lhp.SiSoToiDa = 0; // Mặc định nếu nhập sai format

                                lhp.MaMon = row.Cell(5).Value.ToString().Trim();
                                lhp.MaGV = row.Cell(6).Value.ToString().Trim();
                                lhp.MaHK = row.Cell(7).Value.ToString().Trim();

                                if (int.TryParse(row.Cell(8).Value.ToString(), out int trangThai))
                                    lhp.TrangThai = trangThai;
                                else
                                    lhp.TrangThai = 1;

                                context.LopHocPhan.Add(lhp);
                                rowCount++;
                            }

                            context.SaveChanges();
                            LoadData(); // Cập nhật lại DataGridView

                            string msg = $"Đã nhập thành công {rowCount} lớp học phần mới.";
                            if (duplicateCount > 0)
                                msg += $"\nĐã bỏ qua {duplicateCount} lớp bị trùng mã.";

                            MessageBox.Show(msg, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập file: Vui lòng kiểm tra lại cấu trúc file Excel.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                var listLHP = context.LopHocPhan.ToList();
                if (listLHP.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachLopHocPhan_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("LopHocPhan");

                            // 1. Tạo dòng Tiêu đề (Header)
                            worksheet.Cell(1, 1).Value = "Mã Lớp Học Phần";
                            worksheet.Cell(1, 2).Value = "Tên Lớp Học Phần";
                            worksheet.Cell(1, 3).Value = "Phòng Học";
                            worksheet.Cell(1, 4).Value = "Sĩ Số Tối Đa";
                            worksheet.Cell(1, 5).Value = "Mã Môn";
                            worksheet.Cell(1, 6).Value = "Mã Giảng Viên";
                            worksheet.Cell(1, 7).Value = "Mã Học Kỳ";
                            worksheet.Cell(1, 8).Value = "Trạng Thái (1:Mở, 0:Đóng)";

                            // 2. Đổ dữ liệu vào
                            int row = 2;
                            foreach (var lhp in listLHP)
                            {
                                worksheet.Cell(row, 1).Value = lhp.MaLHP;
                                worksheet.Cell(row, 2).Value = lhp.TenLopHP;
                                worksheet.Cell(row, 3).Value = lhp.PhongHoc;
                                worksheet.Cell(row, 4).Value = lhp.SiSoToiDa;
                                worksheet.Cell(row, 5).Value = lhp.MaMon;
                                worksheet.Cell(row, 6).Value = lhp.MaGV;
                                worksheet.Cell(row, 7).Value = lhp.MaHK;
                                worksheet.Cell(row, 8).Value = lhp.TrangThai;
                                row++;
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXepLop_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn lớp trên lưới chưa
            if (bsLopHP.Current == null)
            {
                MessageBox.Show("Vui lòng chọn một lớp học phần trên lưới để xếp lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lhp = (LopHocPhan)bsLopHP.Current;

            // 2. Logic thực tế: Lớp đã ĐÓNG thì không cho xếp thêm sinh viên
            if (lhp.TrangThai == 0)
            {
                MessageBox.Show("Lớp học phần này đã đóng, không thể thêm sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Mở Form Xếp Lớp và truyền Mã Lớp, Tên Lớp sang
            FrmXepLop frm = new FrmXepLop(lhp.MaLHP, lhp.TenLopHP);
            frm.ShowDialog();
        }
    }
}