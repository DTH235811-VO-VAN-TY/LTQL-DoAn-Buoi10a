using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using QuanLyDiemSV.Data; // Đảm bảo namespace này đúng

namespace QuanLyDiemSV.Forms
{
    public partial class UC_GiangVien : UserControl
    {
        // Khởi tạo Context và BindingSource
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsGiangVien = new BindingSource();
        bool xuLyThem = false;
        bool daTaiDuLieu = false;
        ErrorProvider errorProvider = new ErrorProvider();
        public UC_GiangVien()
        {
            InitializeComponent();
            this.Load += UC_GiangVien_Load;
            this.VisibleChanged += UC_GiangVien_VisibleChanged;
            StyleDataGridView(dgvAdminGiangVien);

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
                if (this.ActiveControl == txtTuKhoaTK)
                {
                    btnTimKiem.PerformClick();
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
                    txtTuKhoaTK.Focus();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void RegisterValidations()
        {
            // Kiểm tra Mã GV không được để trống
            txtMaGV.Validating += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtMaGV.Text))
                    errorProvider.SetError(txtMaGV, "Mã Giảng Viên không được để trống!");
                else
                    errorProvider.SetError(txtMaGV, "");
            };

            // Kiểm tra Email Giảng viên (Định dạng email chung)
            txtEmail.Validating += (s, e) => {
                if (!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    errorProvider.SetError(txtEmail, "Định dạng Email không hợp lệ!");
                else
                    errorProvider.SetError(txtEmail, "");
            };

            // Kiểm tra Số điện thoại (10 số, bắt đầu bằng 0)
            txtSDT.Validating += (s, e) => {
                if (!string.IsNullOrEmpty(txtSDT.Text) && !Regex.IsMatch(txtSDT.Text, @"^0\d{9}$"))
                    errorProvider.SetError(txtSDT, "Số điện thoại phải có đúng 10 chữ số và bắt đầu bằng số 0!");
                else
                    errorProvider.SetError(txtSDT, "");
            };
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

        private void UC_GiangVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            KhoiTaoCboTimKiemSapXep();
            RegisterValidations();
            // Đã ẩn các hàm Load dữ liệu khỏi đây
        }

        private void UC_GiangVien_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !daTaiDuLieu)
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadCboKhoa();
                LoadCboHocVi();
                LoadData();
                daTaiDuLieu = true;
                Cursor.Current = Cursors.Default;
            }
        }
        private void KhoiTaoCboTimKiemSapXep()
        {
            // 1. ComboBox Loại Tìm Kiếm (cboLoaiTK)
            cboLoaiTK.Items.Clear();
            cboLoaiTK.Items.AddRange(new string[] { "Mã Giảng Viên", "Họ Tên", "Giới Tính", "Học Vị" });
            cboLoaiTK.SelectedIndex = 1; // Mặc định tìm theo Họ Tên

            // 2. ComboBox Kiểu Sắp Xếp (comboBox2)
            cboKieuSX.Items.Clear();
            cboKieuSX.Items.AddRange(new string[] { "Mã Giảng Viên", "Họ Tên", "Ngày Sinh" });
            cboKieuSX.SelectedIndex = 0; // Mặc định sắp xếp theo Mã GV
        }

        #region 1. HÀM HỖ TRỢ & LOAD DỮ LIỆU

        private void BatTatChucNang(bool giaTri)
        {
            // Các nút thao tác
            btnLuu.Enabled = giaTri;
            btnLamLai.Enabled = giaTri;

            // Các ô nhập liệu
            txtMaGV.Enabled = giaTri;
            txtHoTenGV.Enabled = giaTri;
            dtpNamSinhGV.Enabled = giaTri;
            radNam.Enabled = giaTri;
            radNu.Enabled = giaTri;
            txtEmail.Enabled = giaTri;   // Ô Email
            txtSDT.Enabled = giaTri;  // Ô Số điện thoại (do tên biến trong designer đặt hơi lạ)
            cboHocVi.Enabled = giaTri;
            cboKhoa.Enabled = giaTri;

            // Nút chức năng
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void LoadCboKhoa()
        {
            var listKhoa = context.Khoa.ToList();
            cboKhoa.DataSource = listKhoa;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.SelectedIndex = -1;
        }

        private void LoadCboHocVi()
        {
            // Tạo danh sách học vị (hoặc load từ DB nếu có bảng riêng)
            List<string> listHocVi = new List<string>() { "Cử nhân", "Thạc sĩ", "Tiến sĩ", "Phó Giáo sư", "Giáo sư" };
            cboHocVi.DataSource = listHocVi;
        }

        public void LoadData()
        {
            try
            {
                // 1. Khởi tạo Query cơ bản (chưa tải về RAM)
                var query = context.GiangVien.AsQueryable();

                // ==========================================
                // 2. XỬ LÝ TÌM KIẾM
                // ==========================================
                string tuKhoa = txtTuKhoaTK.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa) && cboLoaiTK.SelectedIndex != -1)
                {
                    string loaiTK = cboLoaiTK.SelectedItem.ToString();
                    switch (loaiTK)
                    {
                        case "Mã Giảng Viên":
                            query = query.Where(g => g.MaGV.ToLower().Contains(tuKhoa));
                            break;
                        case "Họ Tên":
                            query = query.Where(g => g.HoTen.ToLower().Contains(tuKhoa));
                            break;
                        case "Giới Tính": // Nhập "nam" hoặc "nữ"
                            query = query.Where(g => g.GioiTinh.ToLower() == tuKhoa);
                            break;
                        case "Học Vị":
                            query = query.Where(g => g.HocVi.Contains(tuKhoa));
                            break;
                    }
                }

                // ==========================================
                // 3. XỬ LÝ SẮP XẾP
                // ==========================================
                bool isTang = radTang.Checked; // radioButton1 là Tăng, radioButton2 là Giảm
                if (cboKieuSX.SelectedIndex != -1)
                {
                    string kieuSX = cboKieuSX.SelectedItem.ToString();
                    switch (kieuSX)
                    {
                        case "Mã Giảng Viên":
                            query = isTang ? query.OrderBy(g => g.MaGV) : query.OrderByDescending(g => g.MaGV);
                            break;
                        case "Họ Tên":
                            query = isTang ? query.OrderBy(g => g.HoTen) : query.OrderByDescending(g => g.HoTen);
                            break;
                        case "Ngày Sinh":
                            query = isTang ? query.OrderBy(g => g.NgaySinh) : query.OrderByDescending(g => g.NgaySinh);
                            break;
                    }
                }

                // 4. Lấy dữ liệu đã lọc & sắp xếp từ SQL về
                var listGV = query.ToList();

                // 5. Gán vào BindingSource
                bsGiangVien.DataSource = listGV;

                // 6. Xóa Binding cũ
                txtMaGV.DataBindings.Clear();
                txtHoTenGV.DataBindings.Clear();
                dtpNamSinhGV.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
                cboKhoa.DataBindings.Clear();
                cboHocVi.DataBindings.Clear();

                // 7. Tạo Binding mới
                txtMaGV.DataBindings.Add("Text", bsGiangVien, "MaGV", true, DataSourceUpdateMode.Never);
                txtHoTenGV.DataBindings.Add("Text", bsGiangVien, "HoTen", true, DataSourceUpdateMode.Never);
                dtpNamSinhGV.DataBindings.Add("Value", bsGiangVien, "NgaySinh", true, DataSourceUpdateMode.Never);
                txtEmail.DataBindings.Add("Text", bsGiangVien, "Email", true, DataSourceUpdateMode.Never);
                txtSDT.DataBindings.Add("Text", bsGiangVien, "SDT", true, DataSourceUpdateMode.Never);
                cboKhoa.DataBindings.Add("SelectedValue", bsGiangVien, "MaKhoa", true, DataSourceUpdateMode.Never);
                cboHocVi.DataBindings.Add("SelectedItem", bsGiangVien, "HocVi", true, DataSourceUpdateMode.Never);

                // 8. Hiển thị lên Grid
                dgvAdminGiangVien.AutoGenerateColumns = false;
                dgvAdminGiangVien.DataSource = bsGiangVien;

                bsGiangVien.CurrentChanged += BsGiangVien_CurrentChanged;
                BsGiangVien_CurrentChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện xử lý riêng cho RadioButton Giới tính
        private void BsGiangVien_CurrentChanged(object sender, EventArgs e)
        {
            if (bsGiangVien.Current != null && !xuLyThem)
            {
                var gv = (GiangVien)bsGiangVien.Current;
                if (gv.GioiTinh == "Nam") radNam.Checked = true;
                else radNu.Checked = true;
            }
        }
        private bool ValidateInput()
        {
            // 1. Kiểm tra rỗng Mã GV
            if (string.IsNullOrWhiteSpace(txtMaGV.Text))
            {
                MessageBox.Show("Mã giảng viên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGV.Focus();
                return false;
            }

            // 2. Kiểm tra rỗng Họ tên
            if (string.IsNullOrWhiteSpace(txtHoTenGV.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenGV.Focus();
                return false;
            }

            // 3. Kiểm tra ComboBox Khoa
            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return false;
            }

            // 4. Kiểm tra ComboBox Học vị
            if (cboHocVi.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cboHocVi.Text))
            {
                MessageBox.Show("Vui lòng chọn Học vị!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHocVi.Focus();
                return false;
            }

            // 5. Kiểm tra Tuổi (>= 18)
            int tuoi = DateTime.Now.Year - dtpNamSinhGV.Value.Year;
            if (tuoi < 18)
            {
                MessageBox.Show($"Giảng viên chưa đủ 18 tuổi! (Tuổi hiện tại: {tuoi})", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNamSinhGV.Focus();
                return false;
            }

            // 6. Kiểm tra Số điện thoại (Bắt đầu bằng 0, đủ 10 số)
            string sdt = txtSDT.Text.Trim();
            if (!Regex.IsMatch(sdt, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (Phải bắt đầu bằng số 0 và đủ 10 số)", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // 7. Kiểm tra Email (Không được rỗng và phải đúng định dạng abc@xyz.com)
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!\nVí dụ hợp lệ: giangvien@gmail.com", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true; // Dữ liệu hợp lệ tất cả
        }

        #endregion

        #region 2. XỬ LÝ NÚT BẤM (CRUD)

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            xuLyThem = true;
            BatTatChucNang(true);

           // bsGiangVien.SuspendBinding();

            // Xóa trắng để nhập mới
            txtMaGV.Clear();
            txtHoTenGV.Clear();
            txtEmail.Clear();
            txtSDT.Clear(); // SDT
            dtpNamSinhGV.Value = DateTime.Now.AddYears(-18);
            radNam.Checked = true;
            cboKhoa.SelectedIndex = -1;
            cboHocVi.SelectedIndex = 0;

            txtMaGV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (bsGiangVien.Current == null) return;

            xuLyThem = false;
            BatTatChucNang(true);
            txtMaGV.Enabled = false; // Không sửa khóa chính
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (bsGiangVien.Current == null) return;
            var gv = (GiangVien)bsGiangVien.Current;

            if (MessageBox.Show($"Bạn có chắc muốn xóa giảng viên {gv.HoTen}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    context.GiangVien.Remove(gv);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (dữ liệu đang được sử dụng): " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            // --- GỌI HÀM KIỂM TRA RÀNG BUỘC Ở ĐÂY ---
            if (!ValidateInput())
            {
                return; // Nếu dữ liệu sai, dừng lại không lưu
            }
            // ----------------------------------------

            try
            {
                if (xuLyThem) // --- THÊM MỚI ---
                {
                    // Check trùng mã
                    if (context.GiangVien.Any(x => x.MaGV == txtMaGV.Text.Trim()))
                    {
                        MessageBox.Show("Mã giảng viên đã tồn tại!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaGV.Focus();
                        return;
                    }

                    GiangVien gv = new GiangVien();
                    gv.MaGV = txtMaGV.Text.Trim();
                    gv.HoTen = txtHoTenGV.Text.Trim();
                    gv.NgaySinh = DateOnly.FromDateTime(dtpNamSinhGV.Value); // DateTime
                    gv.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                    gv.Email = txtEmail.Text.Trim();
                    gv.SDT = txtSDT.Text.Trim();
                    gv.HocVi = cboHocVi.SelectedItem?.ToString();
                    gv.MaKhoa = cboKhoa.SelectedValue?.ToString();

                    context.GiangVien.Add(gv);
                }
                else // --- SỬA ---
                {
                    var gv = context.GiangVien.Find(txtMaGV.Text);
                    if (gv != null)
                    {
                        gv.HoTen = txtHoTenGV.Text.Trim();
                        gv.NgaySinh = DateOnly.FromDateTime(dtpNamSinhGV.Value);
                        gv.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                        gv.Email = txtEmail.Text.Trim();
                        gv.SDT = txtSDT.Text.Trim();
                        gv.HocVi = cboHocVi.SelectedItem?.ToString();
                        gv.MaKhoa = cboKhoa.SelectedValue?.ToString();

                        context.GiangVien.Update(gv);
                    }
                }

                context.SaveChanges();
              //  bsGiangVien.ResumeBinding(); // Chặn đổ dữ liệu từ lưới khi thêm
                LoadData();
                BatTatChucNang(false);
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            // xuLyThem = false;
            BatTatChucNang(false);

            //bsGiangVien.ResumeBinding();

            bsGiangVien.ResetBindings(false); // Reset về giá trị cũ

            // Gọi lại hàm này để reset radio button về đúng dòng đang chọn
            BsGiangVien_CurrentChanged(null, null);
        }

        #endregion

        private void radTang_CheckedChanged(object sender, EventArgs e)
        {
            if (radTang.Checked)
            {
                LoadData();
            }
        }

        private void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiam.Checked)
                LoadData();
        }

        private void cboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtTuKhoaTK.Clear();
            cboLoaiTK.SelectedIndex = 1;
            cboKieuSX.SelectedIndex = 0;
            radTang.Checked = true;

            LoadData();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu sinh viên từ Excel";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Mở hộp thoại chọn file Excel
                    using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", Title = "Chọn file Excel Giảng Viên" })
                    {
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            using (var workbook = new XLWorkbook(ofd.FileName))
                            {
                                var worksheet = workbook.Worksheet(1); // Lấy sheet đầu tiên
                                var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Bỏ qua dòng tiêu đề 1

                                int rowCount = 0;
                                int duplicateCount = 0;

                                foreach (var row in rows)
                                {
                                    string maGV = row.Cell(1).Value.ToString().Trim();

                                    // Bỏ qua các dòng trống
                                    if (string.IsNullOrEmpty(maGV)) continue;

                                    // Kiểm tra trùng lặp Mã GV
                                    if (context.GiangVien.Any(x => x.MaGV == maGV))
                                    {
                                        duplicateCount++;
                                        continue;
                                    }

                                    GiangVien gv = new GiangVien();
                                    gv.MaGV = maGV;
                                    gv.HoTen = row.Cell(2).Value.ToString().Trim();

                                    // Xử lý Ngày Sinh (Chuyển thành DateOnly giống cách lưu thông thường)
                                    if (DateTime.TryParse(row.Cell(3).Value.ToString(), out DateTime ngaySinh))
                                        gv.NgaySinh = DateOnly.FromDateTime(ngaySinh);
                                    else
                                        gv.NgaySinh = DateOnly.FromDateTime(DateTime.Now); // Mặc định nếu nhập sai format

                                    gv.GioiTinh = row.Cell(4).Value.ToString().Trim();
                                    gv.Email = row.Cell(5).Value.ToString().Trim();
                                    gv.SDT = row.Cell(6).Value.ToString().Trim();
                                    gv.HocVi = row.Cell(7).Value.ToString().Trim();
                                    gv.MaKhoa = row.Cell(8).Value.ToString().Trim();

                                    context.GiangVien.Add(gv);
                                    rowCount++;
                                }

                                // Lưu toàn bộ xuống DB
                                context.SaveChanges();

                                // Load lại DataGridView
                                LoadData();

                                // Hiển thị thống kê
                                string msg = $"Đã nhập thành công {rowCount} giảng viên mới.";
                                if (duplicateCount > 0)
                                    msg += $"\nĐã bỏ qua {duplicateCount} giảng viên bị trùng mã.";

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
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu giảng viên từ database
                var listGV = context.GiangVien.ToList();
                if (listGV.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở hộp thoại chọn nơi lưu file
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachGiangVien.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("GiangVien");

                            // 1. Tạo dòng Tiêu đề (Header)
                            worksheet.Cell(1, 1).Value = "Mã Giảng Viên";
                            worksheet.Cell(1, 2).Value = "Họ Tên";
                            worksheet.Cell(1, 3).Value = "Ngày Sinh";
                            worksheet.Cell(1, 4).Value = "Giới Tính";
                            worksheet.Cell(1, 5).Value = "Email";
                            worksheet.Cell(1, 6).Value = "Số Điện Thoại";
                            worksheet.Cell(1, 7).Value = "Học Vị";
                            worksheet.Cell(1, 8).Value = "Mã Khoa";

                            // 2. Đổ dữ liệu vào các dòng
                            int row = 2;
                            foreach (var gv in listGV)
                            {
                                worksheet.Cell(row, 1).Value = gv.MaGV;
                                worksheet.Cell(row, 2).Value = gv.HoTen;
                                worksheet.Cell(row, 3).Value = gv.NgaySinh.Value.ToString("dd/MM/yyyy");
                                worksheet.Cell(row, 4).Value = gv.GioiTinh;
                                worksheet.Cell(row, 5).Value = gv.Email;
                                worksheet.Cell(row, 6).Value = gv.SDT;
                                worksheet.Cell(row, 7).Value = gv.HocVi;
                                worksheet.Cell(row, 8).Value = gv.MaKhoa;
                                row++;
                            }

                            // Căn chỉnh tự động độ rộng các cột
                            worksheet.Columns().AdjustToContents();

                            // Lưu file
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