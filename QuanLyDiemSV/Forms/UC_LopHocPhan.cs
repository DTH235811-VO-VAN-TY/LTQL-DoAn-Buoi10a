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
            this.VisibleChanged += UC_LopHocPhan_VisibleChanged;
        }

        private void UC_LopHocPhan_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            KhoiTaoCboTimKiemSapXep();
        }

        private void UC_LopHocPhan_VisibleChanged(object sender, EventArgs e)
        {
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            // Mỗi khi tab Lớp Học Phần được hiện lên màn hình
            if (this.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;

                // --- 1. COMBOBOX: LUÔN LUÔN TẢI LẠI ĐỂ CẬP NHẬT DỮ LIỆU MỚI NHẤT ---
                // (Mẹo nhỏ: Lưu lại giá trị đang chọn để không bị mất khi reload)
                var oldMaGV = cboMaGV.SelectedValue;
                var oldMaMon = cboMaMon.SelectedValue;

                LoadComboBoxData(); // Cập nhật lại danh sách Giảng viên, Môn học... từ SQL

                // Phục hồi lại giá trị đang chọn (nếu có)
                if (oldMaGV != null) cboMaGV.SelectedValue = oldMaGV;
                if (oldMaMon != null) cboMaMon.SelectedValue = oldMaMon;


                // --- 2. LƯỚI DATAGRIDVIEW: CHỈ TẢI 1 LẦN DUY NHẤT KHI MỞ APP ---
                if (!daTaiDuLieu)
                {
                    LoadData();
                    daTaiDuLieu = true;
                }

                Cursor.Current = Cursors.Default;
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
        }
        private void KhoiTaoCboTimKiemSapXep()
        {
            // 1. ComboBox Loại Tìm Kiếm (cboLoaiTK)
            cboTimKiem.Items.Clear();
            cboTimKiem.Items.AddRange(new string[] { "Mã Lớp học phần", "Tên Lớp Học Phần", "Giảng viên", "Mã Môn" });
            cboTimKiem.SelectedIndex = 1; // Mặc định tìm theo Tên LHP

            // 2. ComboBox Kiểu Sắp Xếp
            cboKieuSX.Items.Clear();
            cboKieuSX.Items.AddRange(new string[] { "Mã Lớp học phần", "Tên Lớp Học Phần", "Giảng viên" });
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

                var query = context.LopHocPhan.Include(l => l.MaGVNavigation).AsQueryable();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLHP.Text) || string.IsNullOrWhiteSpace(txtTenLHP.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp và Tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMaMon.SelectedValue == null || cboMaGV.SelectedValue == null || cboHocKy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Môn, Giảng viên và Học kỳ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Kiểm tra định dạng Mã Lớp Học Phần (Phải là số nguyên)
            if (!int.TryParse(txtMaLHP.Text.Trim(), out int maLHP))
            {
                MessageBox.Show("Mã Lớp Học Phần phải là số nguyên!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLHP.Focus();
                return;
            }

            // 2. Kiểm tra định dạng Sĩ số (Phải là số và >= 0)
            if (!int.TryParse(txtSiSo.Text.Trim(), out int siSo) || siSo < 0)
            {
                MessageBox.Show("Sĩ số tối đa phải là số nguyên và không được âm!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiSo.Focus();
                return;
            }

            // 3. Kiểm tra định dạng Phòng học (1 chữ cái đứng đầu, theo sau là 3 số. VD: A401)
            string phongHoc = txtPhongHoc.Text.Trim();
            if (!Regex.IsMatch(phongHoc, @"^[a-zA-Z]\d{3}$"))
            {
                MessageBox.Show("Phòng học không hợp lệ!\n(Định dạng đúng: Bắt đầu bằng 1 chữ cái và 3 chữ số. Ví dụ: A401, B302)", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhongHoc.Focus();
                return;
            }

            try
            {
                if (xuLyThem) // --- THÊM ---
                {
                    if (context.LopHocPhan.Any(x => x.MaLHP == maLHP))
                    {
                        MessageBox.Show("Mã lớp học phần đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    LopHocPhan lhp = new LopHocPhan();
                    lhp.MaLHP = maLHP;
                    lhp.TenLopHP = txtTenLHP.Text.Trim();
                    lhp.PhongHoc = phongHoc.ToUpper(); // Viết hoa chữ cái phòng học cho đẹp (VD: a401 -> A401)
                    lhp.SiSoToiDa = siSo;
                    lhp.MaMon = cboMaMon.SelectedValue.ToString();
                    lhp.MaGV = cboMaGV.SelectedValue.ToString();
                    lhp.MaHK = cboHocKy.SelectedValue.ToString();
                    lhp.TrangThai = cboTrangThai.SelectedIndex == 0 ? 1 : 0;

                    context.LopHocPhan.Add(lhp);
                }
                else // --- SỬA ---
                {
                    var lhp = context.LopHocPhan.Find(maLHP);
                    if (lhp != null)
                    {
                        lhp.TenLopHP = txtTenLHP.Text.Trim();
                        lhp.PhongHoc = phongHoc.ToUpper();
                        lhp.SiSoToiDa = siSo;
                        lhp.MaMon = cboMaMon.SelectedValue.ToString();
                        lhp.MaGV = cboMaGV.SelectedValue.ToString();
                        lhp.MaHK = cboHocKy.SelectedValue.ToString();
                        lhp.TrangThai = cboTrangThai.SelectedIndex == 0 ? 1 : 0;

                        context.LopHocPhan.Update(lhp);
                    }
                }

                context.SaveChanges();
                LoadData();
                BatTatChucNang(false);
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Kiểm tra xem có đúng là đang vẽ cột Giảng Viên không (Cột của bạn đặt tên là "MaGV")
            if (dgvLopHocPhan.Columns[e.ColumnIndex].Name == "MaGV" && e.RowIndex >= 0)
            {
                // Lấy đối tượng Lớp Học Phần của dòng hiện tại
                var lhp = dgvLopHocPhan.Rows[e.RowIndex].DataBoundItem as LopHocPhan;

                // Nếu có thông tin liên kết Giảng viên, thay thế Mã GV bằng Họ Tên
                if (lhp != null && lhp.MaGVNavigation != null)
                {
                    e.Value = lhp.MaGVNavigation.HoTen; // Hiển thị tên ra lưới
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
    }
}