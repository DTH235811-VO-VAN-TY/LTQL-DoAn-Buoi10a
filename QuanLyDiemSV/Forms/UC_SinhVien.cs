using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions; // Thư viện dùng để kiểm tra số (Regex)
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore; // Cần thư viện này để dùng .Include
using QuanLyDiemSV.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ClosedXML.Excel;

namespace QuanLyDiemSV
{
    public partial class UC_SinhVien : UserControl
    {
        // 1. Khai báo Context và BindingSource
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsSinhVien = new BindingSource();

        bool xuLyThem = false; // Cờ kiểm tra đang Thêm hay Sửa
        bool daTaiDuLieu = false;
        ErrorProvider errorProvider = new ErrorProvider();

        public UC_SinhVien()
        {
            InitializeComponent();
            this.Load += UC_SinhVien_Load;
            StyleDataGridView(dgvAdminSinhVien);


        }

        private void UC_SinhVien_Load(object sender, EventArgs e)
        {
            // 1. Tạm thời tắt các tính năng cập nhật layout để tăng tốc và tránh lỗi
            dgvAdminSinhVien.SuspendLayout();

            try
            {
                BatTatChucNang(false);
                KhoiTaoCboTimKiemSapXep();

                // 2. Nạp dữ liệu (nếu bạn có hàm load dữ liệu ở đây)
                // LoadDuLieuSinhVien(); 

                // 3. Gắn các ràng buộc kiểm tra lỗi mà tôi đã gửi trước đó
                RegisterValidations();
            }
            finally
            {
                // 4. Kích hoạt lại layout
                dgvAdminSinhVien.ResumeLayout();

                // ĐÂY LÀ DÒNG QUAN TRỌNG: Chỉ đặt Fill sau khi mọi thứ đã sẵn sàng
                dgvAdminSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        public async Task CapNhatDuLieuMoiNhat()
        {
            using (var freshContext = new QLDSVDbContext())
            {
                var oldLop = cboAdSV_TenLop.SelectedValue;

                cboAdSV_TenLop.DataSource = await freshContext.LopHanhChinh.AsNoTracking().ToListAsync();
                cboAdSV_TenLop.DisplayMember = "TenLop";
                cboAdSV_TenLop.ValueMember = "MaLop";

                if (oldLop != null) cboAdSV_TenLop.SelectedValue = oldLop;
            }

            // Ép xóa Cache và tải lại danh sách sinh viên
            context.ChangeTracker.Clear();
            LoadDuLieuSinhVien();
        }
        private void KhoiTaoCboTimKiemSapXep()
        {
            // 1. ComboBox Loại Tìm Kiếm (cboLoaiTK)
            cboAdTimKiem_SV.Items.Clear();
            cboAdTimKiem_SV.Items.AddRange(new string[] { "Mã Sinh Viên", "Họ Tên", "Giới Tính", "Số Điện Thoại" });
            cboAdTimKiem_SV.SelectedIndex = 1; // Mặc định tìm theo Họ Tên

            // 2. ComboBox Kiểu Sắp Xếp (comboBox2)
            cboKieuSX.Items.Clear();
            cboKieuSX.Items.AddRange(new string[] { "Mã Sinh Viên", "Họ Tên", "Ngày Sinh" });
            cboKieuSX.SelectedIndex = 0; // Mặc định sắp xếp theo Mã GV
        }

        #region 1. HÀM HỖ TRỢ & LOAD DỮ LIỆU (BINDING SOURCE)

        private void LoadComboBoxLop()
        {
            using (var freshContext = new QLDSVDbContext())
            {
                var dsLop = freshContext.LopHanhChinh.ToList();

                // 2. Ép ComboBox "quên" dữ liệu cũ đi để sẵn sàng nhận dữ liệu mới
                cboAdSV_TenLop.DataSource = null;

                // 3. Đổ dữ liệu mới vào
                cboAdSV_TenLop.DataSource = dsLop;
                cboAdSV_TenLop.DisplayMember = "TenLop";  // Đảm bảo tên cột khớp với CSDL của bạn
                cboAdSV_TenLop.ValueMember = "MaLop";
            }
        }
        bool dangTruyVan = false;
        public async Task LoadDuLieuSinhVien()
        {
            if(dangTruyVan) return; // Nếu đang truy vấn thì thôi (tránh gọi chồng chéo khi có nhiều sự kiện thay đổi tìm kiếm/sắp xếp)
            dangTruyVan = true;
            try
            {
                dgvAdminSinhVien.AutoGenerateColumns = false;

                // 1. Khởi tạo Query
                var query = context.SinhVien.AsQueryable();

                // =====================================
                // 2. XỬ LÝ TÌM KIẾM
                // =====================================
                string tuKhoa = txtAdTuKhoa_SV.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(tuKhoa) && cboAdTimKiem_SV.SelectedIndex != -1)
                {
                    string loaiTK = cboAdTimKiem_SV.SelectedItem.ToString();
                    switch (loaiTK)
                    {
                        case "Mã Sinh Viên":
                            query = query.Where(g => g.MaSV.ToLower().Contains(tuKhoa));
                            break;
                        case "Họ Tên":
                            query = query.Where(g => g.HoTen.ToLower().Contains(tuKhoa));
                            break;
                        case "Giới Tính":
                            query = query.Where(g => g.GioiTinh.ToLower() == tuKhoa);
                            break;
                        case "Số Điện Thoại":
                            query = query.Where(g => g.SDT.Contains(tuKhoa));
                            break;
                    }
                }

                // =====================================
                // 3. XỬ LÝ SẮP XẾP
                // =====================================
                bool isTang = radTang.Checked;
                if (cboKieuSX.SelectedIndex != -1)
                {
                    string kieuSX = cboKieuSX.SelectedItem.ToString();
                    switch (kieuSX)
                    {
                        case "Mã Sinh Viên":
                            query = isTang ? query.OrderBy(g => g.MaSV) : query.OrderByDescending(g => g.MaSV);
                            break;
                        case "Họ Tên":
                            query = isTang ? query.OrderBy(g => g.HoTen) : query.OrderByDescending(g => g.HoTen);
                            break;
                        case "Ngày Sinh":
                            query = isTang ? query.OrderBy(g => g.NgaySinh) : query.OrderByDescending(g => g.NgaySinh);
                            break;
                    }
                }

                // =====================================
                // 4. CẬP NHẬT DỮ LIỆU VÀO LƯỚI
                // =====================================


                var listSV = await query.ToListAsync();

                // Gán vào BindingSource
                bsSinhVien.DataSource = listSV;

                // Xóa các binding cũ
                txtAdMaSV.DataBindings.Clear();
                txtAdHoTenSV.DataBindings.Clear();
                dtpAdNamSinhSV.DataBindings.Clear();
                txtAdCCCDsv.DataBindings.Clear();
                txtAdSDT_SV.DataBindings.Clear();
                txtAdSV_Email.DataBindings.Clear();
                txtAdSV_DiaChi.DataBindings.Clear();
                cboAdSV_TenLop.DataBindings.Clear();

                // Tạo BINDING mới
                txtAdMaSV.DataBindings.Add("Text", bsSinhVien, "MaSV", true, DataSourceUpdateMode.OnPropertyChanged);
                txtAdHoTenSV.DataBindings.Add("Text", bsSinhVien, "HoTen", true, DataSourceUpdateMode.OnPropertyChanged);
                dtpAdNamSinhSV.DataBindings.Add("Value", bsSinhVien, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged);
                txtAdCCCDsv.DataBindings.Add("Text", bsSinhVien, "CCCD", true, DataSourceUpdateMode.OnPropertyChanged);
                txtAdSDT_SV.DataBindings.Add("Text", bsSinhVien, "SDT", true, DataSourceUpdateMode.OnPropertyChanged);
                txtAdSV_Email.DataBindings.Add("Text", bsSinhVien, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
                txtAdSV_DiaChi.DataBindings.Add("Text", bsSinhVien, "DiaChi", true, DataSourceUpdateMode.OnPropertyChanged);
                cboAdSV_TenLop.DataBindings.Add("SelectedValue", bsSinhVien, "MaLop", true, DataSourceUpdateMode.OnPropertyChanged);

                dgvAdminSinhVien.DataSource = bsSinhVien;

                if (dgvAdminSinhVien.Columns["NgaySinh"] != null)
                {
                    dgvAdminSinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                // FIX CHỐNG LỖI TRÀN BỘ NHỚ: Gỡ sự kiện cũ trước khi đăng ký mới (Vì hàm này bị gọi lại nhiều lần khi tìm kiếm)
                bsSinhVien.CurrentChanged -= BsSinhVien_CurrentChanged;
                bsSinhVien.CurrentChanged += BsSinhVien_CurrentChanged;
                BsSinhVien_CurrentChanged(null, null);
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

        // Sự kiện tự động chạy khi  click chuột vào lưới 
        private void BsSinhVien_CurrentChanged(object sender, EventArgs e)
        {
            if (bsSinhVien.Current == null) return;

            // Lấy sinh viên đang được chọn
            var currentSV = (SinhVien)bsSinhVien.Current;

            // 1. Xử lý RadioButton Giới tính (Binding RadioButton phức tạp nên làm thủ công ở đây)
            if (currentSV.GioiTinh == "Nam") radAdSV_Nam.Checked = true;
            else radAdSV_Nu.Checked = true;

            // 2. Truy vấn ngược lên để lấy Tên Ngành, Tên Khoa, Niên Khóa

            var lop = context.LopHanhChinh
                             .Include(l => l.MaNganhNavigation).ThenInclude(n => n.MaKhoaNavigation)
                             .FirstOrDefault(l => l.MaLop == currentSV.MaLop);

            if (lop != null)
            {
                txtAdSV_NienKhoa.Text = lop.NienKhoa;
                txtAdSV_ChuyenNganh.Text = lop.MaNganhNavigation?.TenNganh;
                txtAdSV_Khoa.Text = lop.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa;
            }
            else
            {
                // Nếu đang thêm mới hoặc không tìm thấy lớp thì xóa trắng
                txtAdSV_NienKhoa.Clear();
                txtAdSV_ChuyenNganh.Clear();
                txtAdSV_Khoa.Clear();
            }
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnAdLua_SV.Enabled = giaTri;
            btnAdLamLai_SV.Enabled = giaTri;
            btnAdThem_SV.Enabled = !giaTri;
            btnAdSua_SV.Enabled = !giaTri;
            btnAdXoa_SV.Enabled = !giaTri;

            // Mở khóa các ô nhập liệu
            txtAdMaSV.Enabled = giaTri;
            txtAdHoTenSV.Enabled = giaTri;
            dtpAdNamSinhSV.Enabled = giaTri;
            radAdSV_Nam.Enabled = giaTri;
            radAdSV_Nu.Enabled = giaTri;
            txtAdCCCDsv.Enabled = giaTri;
            txtAdSDT_SV.Enabled = giaTri;
            txtAdSV_Email.Enabled = giaTri;
            txtAdSV_DiaChi.Enabled = giaTri;
            cboAdSV_TenLop.Enabled = giaTri;
            txtAdSV_ChuyenNganh.Enabled = false; // Không cho sửa
            txtAdSV_Khoa.Enabled = false; // Không cho sửa
            txtAdSV_NienKhoa.Enabled = false; // Không cho sửa
        }

        #endregion

        #region 2. KIỂM TRA RÀNG BUỘC (VALIDATION) - PHẦN BẠN CẦN NHẤT

        private bool ValidateInput()
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtAdMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdMaSV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAdHoTenSV.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdHoTenSV.Focus();
                return false;
            }
            if (cboAdSV_TenLop.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAdSV_TenLop.Focus();
                return false;
            }

            // 2. Kiểm tra Tuổi (Phải đủ 18 tuổi)
            // Logic: Lấy năm hiện tại trừ năm sinh
            int tuoi = DateTime.Now.Year - dtpAdNamSinhSV.Value.Year;
            if (tuoi < 18)
            {
                MessageBox.Show($"Sinh viên chưa đủ 18 tuổi! (Tuổi hiện tại: {tuoi})", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpAdNamSinhSV.Focus();
                return false;
            }

            // 3. Kiểm tra CCCD (Phải là số và đủ 12 ký tự)
            string cccd = txtAdCCCDsv.Text.Trim();
            // Regex: ^\d{12}$ nghĩa là chuỗi phải chứa chính xác 12 ký tự số
            if (!Regex.IsMatch(cccd, @"^\d{12}$"))
            {
                MessageBox.Show("Căn cước công dân (CCCD) phải là số và đúng 12 chữ số!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdCCCDsv.Focus();
                return false;
            }

            // 4. Kiểm tra Số điện thoại (Phải là số, bắt đầu bằng 0, đủ 10 số)
            string sdt = txtAdSDT_SV.Text.Trim();
            // Regex: ^0\d{9}$ nghĩa là bắt đầu bằng 0 và theo sau là 9 chữ số
            if (!Regex.IsMatch(sdt, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (Phải bắt đầu bằng số 0 và đủ 10 số)", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSDT_SV.Focus();
                return false;
            }
            // 5. Kiểm tra email có rỗng không
            string email = txtAdSV_Email.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSV_Email.Focus();
                return false;
            }
            //6. Kiểm tra đúng định dạng email không?
            else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!\nVí dụ hợp lệ: giangvien@gmail.com", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSV_Email.Focus();
                return false;
            }



            return true; // Dữ liệu hợp lệ
        }
        private bool ValidateInput2()
        {
            errorProvider.Clear(); // Xóa tất cả lỗi cũ
            bool isValid = true;

            // 1. Kiểm tra Mã SV (3 chữ, 6 số)
            if (!IsValidMaSV(txtAdMaSV.Text))
            {
                errorProvider.SetError(txtAdMaSV, "Mã Sinh Viên phải gồm 3 chữ cái và 6 chữ số (VD: DTH235811)!");
                isValid = false;
            }

            // 2. Kiểm tra Họ tên (không để trống)
            if (string.IsNullOrWhiteSpace(txtAdHoTenSV.Text))
            {
                errorProvider.SetError(txtAdHoTenSV, "Họ tên không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Email (@student.edu.vn)
            if (!IsValidEmailSV(txtAdSV_Email.Text))
            {
                errorProvider.SetError(txtAdSV_Email, "Email phải có định dạng xxx@student.edu.vn!");
                isValid = false;
            }

            // 4. Kiểm tra CCCD (12 số)
            if (!IsValidCCCD(txtAdCCCDsv.Text))
            {
                errorProvider.SetError(txtAdCCCDsv, "CCCD phải bao gồm đúng 12 chữ số!");
                isValid = false;
            }

            // 5. Kiểm tra Số điện thoại (10 số)
            if (!IsValidSDT(txtAdSDT_SV.Text))
            {
                errorProvider.SetError(txtAdSDT_SV, "Số điện thoại phải có đúng 10 chữ số!");
                isValid = false;
            }

            return isValid;
        }

        #endregion

        #region 3. CÁC NÚT CHỨC NĂNG (CRUD)

        private void btnAdThem_SV_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            xuLyThem = true;
            BatTatChucNang(true);

            // Thêm một dòng trắng vào BindingSource
            bsSinhVien.AddNew();

            // Thiết lập giá trị mặc định
            dtpAdNamSinhSV.Value = DateTime.Now.AddYears(-18); // Để mặc định 18 tuổi
            radAdSV_Nam.Checked = true;
            cboAdSV_TenLop.SelectedIndex = -1;

            txtAdMaSV.Focus();
        }

        private void btnAdSua_SV_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (bsSinhVien.Current == null) return; // Nếu chưa chọn dòng nào thì thôi

            xuLyThem = false;
            BatTatChucNang(true);
            txtAdMaSV.Enabled = false; // Khi sửa KHÔNG ĐƯỢC sửa mã (Khóa chính)
        }

        private void btnAdXoa_SV_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (bsSinhVien.Current == null) return;
            var currentSV = (SinhVien)bsSinhVien.Current;

            if (MessageBox.Show($"Bạn có chắc chắn xóa sinh viên {currentSV.HoTen}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa trong CSDL
                    context.SinhVien.Remove(currentSV);
                    context.SaveChanges();

                    // Xóa trên giao diện
                    // bsSinhVien.RemoveCurrent();
                    LoadDuLieuSinhVien();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (Sinh viên này đã có điểm hoặc dữ liệu liên quan): " + ex.Message);
                }
            }
        }

       
        // Đã thêm từ khóa 'async' vào khai báo hàm
        private async void btnAdLua_SV_Click(object sender, EventArgs e)
        {
            errorProvider.Clear(); // Dọn dẹp lỗi cũ trước khi kiểm tra mới
            if (!ValidateInput2())
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ. Vui lòng kiểm tra các ô báo đỏ!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // -------------------------------------------------------

            try
            {
                // Lấy đối tượng đang thao tác từ BindingSource
                var sv = (SinhVien)bsSinhVien.Current;

                // Gán thủ công các giá trị không Binding được
                sv.GioiTinh = radAdSV_Nam.Checked ? "Nam" : "Nữ";
                sv.MaLop = cboAdSV_TenLop.SelectedValue.ToString(); // Đảm bảo lấy đúng mã lớp

                if (xuLyThem)
                {
                    // [TỐI ƯU 1]: Dùng await và AnyAsync thay vì Any để không đơ màn hình
                    bool isExist = await context.SinhVien.AnyAsync(s => s.MaSV == sv.MaSV);
                    if (isExist)
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAdMaSV.Focus();
                        return;
                    }

                    sv.TrangThai = 1; // Mặc định đang học
                    context.SinhVien.Add(sv); // Thêm vào Context
                }
                else
                {
                    context.SinhVien.Update(sv);
                }

                // [TỐI ƯU 2]: Dùng await và SaveChangesAsync thay vì SaveChanges để không đơ màn hình
                await context.SaveChangesAsync();
                context.SaveChanges();

                // [CẬP NHẬT TỪ BƯỚC TRƯỚC]: Mở lại cơ chế đổ dữ liệu tự động lên Textbox
                bsSinhVien.ResumeBinding();

                MessageBox.Show("Lưu dữ liệu thành công!");
                LoadDuLieuSinhVien(); // Tải lại để cập nhật thông tin phụ (Tên Khoa/Ngành)
                BatTatChucNang(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hệ thống: " + ex.Message);
            }
        }

        private void btnAdLamLai_SV_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            // 1. Nếu đang Thêm mới mà bấm Làm lại -> Hủy dòng trắng vừa tạo ra
            if (xuLyThem)
            {
                bsSinhVien.CancelEdit();
            }
            // 2. Nếu đang Sửa mà bấm Làm lại -> Phục hồi dữ liệu cũ từ SQL
            else
            {
                if (bsSinhVien.Current != null)
                {
                    var currentSV = (SinhVien)bsSinhVien.Current;

                    // Đảm bảo đối tượng này có Mã SV (đã tồn tại trong DB) thì mới Reload
                    if (!string.IsNullOrEmpty(currentSV.MaSV))
                    {
                        try
                        {
                            context.Entry(currentSV).Reload();
                        }
                        catch { } // Bỏ qua lỗi ngầm nếu entity bị mất tracking
                    }
                }
            }

            // 3. Đưa giao diện về trạng thái ban đầu
            xuLyThem = false; // Tắt trạng thái thêm
            BatTatChucNang(false); // Khóa các ô nhập liệu

            bsSinhVien.ResumeBinding();
            bsSinhVien.ResetBindings(false); // F5 lại lưới ngay lập tức
        }

        // --- SỰ KIỆN CLICK LƯỚI (ĐÃ BỎ CODE GÁN DỮ LIỆU VÌ BINDINGSOURCE ĐÃ LÀM THAY) ---
        private void dgvAdminSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        private void cboAdSV_TenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu ComboBox chưa có dữ liệu hoặc chưa chọn gì thì thoát
            if (cboAdSV_TenLop.SelectedValue == null) return;

            // Kiểm tra xem giá trị lấy ra có phải là ID hợp lệ không (tránh lỗi khi mới load form)
            if (cboAdSV_TenLop.SelectedValue is string maLop)
            {
                CapNhatThongTinLop(maLop);
            }
            // Trường hợp binding object, đôi khi SelectedValue chưa trả về string ngay
            else if (cboAdSV_TenLop.SelectedValue.ToString() != "QuanLyDiemSV.Data.LopHanhChinh")
            {
                CapNhatThongTinLop(cboAdSV_TenLop.SelectedValue.ToString());
            }
        }
        private void CapNhatThongTinLop(string maLop)
        {
            try
            {
                // Tra cứu thông tin Lớp -> Ngành -> Khoa
                var lop = context.LopHanhChinh
                                 .Include(l => l.MaNganhNavigation).ThenInclude(n => n.MaKhoaNavigation)
                                 .FirstOrDefault(l => l.MaLop == maLop);

                if (lop != null)
                {
                    txtAdSV_NienKhoa.Text = lop.NienKhoa;
                    txtAdSV_ChuyenNganh.Text = lop.MaNganhNavigation?.TenNganh;
                    txtAdSV_Khoa.Text = lop.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa;
                }
                else
                {
                    // Nếu không tìm thấy lớp (hiếm khi xảy ra)
                    txtAdSV_NienKhoa.Clear();
                    txtAdSV_ChuyenNganh.Clear();
                    txtAdSV_Khoa.Clear();
                }
            }
            catch { }
        }

        private async void btnAdTimKiem_SV_Click(object sender, EventArgs e)
        {
            await LoadDuLieuSinhVien();
        }

        private async void btnAdShowAll_SV_Click(object sender, EventArgs e)
        {
            txtAdTuKhoa_SV.Clear();
            cboAdTimKiem_SV.SelectedIndex = 1;
            cboKieuSX.SelectedIndex = 0;
            radTang.Checked = true;

            await LoadDuLieuSinhVien();
        }

        private async void cboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDuLieuSinhVien();
        }

        private async void radTang_CheckedChanged(object sender, EventArgs e)
        {
            if (radTang.Checked)
                await LoadDuLieuSinhVien();
        }

        private async void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiam.Checked)
                await LoadDuLieuSinhVien();
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
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        int rowCount = 0;
                        int duplicateCount = 0; // Đếm số lượng SV bị trùng mã

                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                firstRow = false;
                                continue; // Bỏ qua dòng tiêu đề
                            }

                            // 1. Lấy Mã SV (Cột 1)
                            string maSV = row.Cell(1).Value.ToString().Trim();

                            if (string.IsNullOrEmpty(maSV)) continue; // Bỏ qua dòng rỗng

                            // 2. Kiểm tra trùng lặp khóa chính (MaSV)
                            if (context.SinhVien.Any(s => s.MaSV == maSV))
                            {
                                duplicateCount++;
                                continue; // Đã tồn tại -> Bỏ qua không thêm dòng này
                            }

                            SinhVien sv = new SinhVien();
                            sv.MaSV = maSV;
                            sv.HoTen = row.Cell(2).Value.ToString().Trim();

                            // 3. Xử lý an toàn cho cột Ngày Sinh (Cột 3)
                            if (DateTime.TryParse(row.Cell(3).Value.ToString(), out DateTime ngaySinh))
                                sv.NgaySinh = ngaySinh;
                            else
                                sv.NgaySinh = DateTime.Now.AddYears(-18); // Gán tuổi mặc định nếu file Excel nhập sai

                            sv.GioiTinh = row.Cell(4).Value.ToString().Trim();
                            sv.DiaChi = row.Cell(5).Value.ToString().Trim();
                            sv.CCCD = row.Cell(6).Value.ToString().Trim();
                            sv.Email = row.Cell(7).Value.ToString().Trim();
                            sv.SDT = row.Cell(8).Value.ToString().Trim();
                            sv.MaLop = row.Cell(9).Value.ToString().Trim(); // Lưu ý: Cần đảm bảo Mã Lớp này đã tồn tại trong bảng LopHanhChinh

                            // 4. Xử lý trạng thái (Cột 10)
                            if (int.TryParse(row.Cell(10).Value.ToString(), out int trangThai))
                                sv.TrangThai = trangThai;
                            else
                                sv.TrangThai = 1;

                            context.SinhVien.Add(sv);
                            rowCount++;
                        }

                        context.SaveChanges(); // Lưu tất cả xuống SQL Server

                        // Hiển thị thông báo chi tiết
                        string msg = $"Đã nhập thành công {rowCount} sinh viên mới.";
                        if (duplicateCount > 0)
                            msg += $"\nĐã bỏ qua {duplicateCount} sinh viên bị trùng mã (MaSV).";

                        MessageBox.Show(msg, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại DataGridView để hiển thị dữ liệu mới
                        LoadDuLieuSinhVien();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nhập file: Vui lòng kiểm tra lại định dạng dữ liệu trong Excel.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu sinh viên ra Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            // Tên file có kèm ngày tháng năm hiện tại
            saveFileDialog.FileName = "DanhSachSinhVien_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    // Khởi tạo các cột bám sát theo CSDL
                    table.Columns.AddRange(new DataColumn[] {
                new DataColumn("Mã SV", typeof(string)),
                new DataColumn("Họ Tên", typeof(string)),
                new DataColumn("Ngày Sinh", typeof(DateTime)),
                new DataColumn("Giới Tính", typeof(string)),
                new DataColumn("Địa Chỉ", typeof(string)),
                new DataColumn("CCCD", typeof(string)),
                new DataColumn("Email", typeof(string)),
                new DataColumn("SĐT", typeof(string)),
                new DataColumn("Mã Lớp", typeof(string)),
                new DataColumn("Trạng Thái", typeof(int))
            });

                    // Lấy toàn bộ dữ liệu sinh viên từ DB
                    var danhSachSV = context.SinhVien.ToList();
                    foreach (var sv in danhSachSV)
                    {
                        // Truyền dữ liệu vào từng dòng
                        table.Rows.Add(sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.DiaChi, sv.CCCD, sv.Email, sv.SDT, sv.MaLop, sv.TrangThai ?? 1);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "SinhVien");
                        sheet.Columns().AdjustToContents(); // Căn chỉnh cột tự động cho đẹp
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
        // ===================================================================
        // HÀM BẮT PHÍM TẮT (HOTKEYS) CHO TOÀN BỘ MÀN HÌNH SINH VIÊN
        // ===================================================================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // =====================================================================
            // 1. PHÍM TẮT HỆ THỐNG: HOẠT ĐỘNG TOÀN CỤC (Kể cả khi đang gõ chữ)
            // =====================================================================

            // Ctrl + S: Lưu dữ liệu
            if (keyData == (Keys.Control | Keys.S))
            {
                // Lưu ý: Kiểm tra nút Lưu có đang hiện/bật không trước khi click
                if (btnAdLua_SV.Enabled)
                {
                    btnAdLua_SV.PerformClick();
                    return true;
                }
            }

            // F5: Làm lại / Tải lại dữ liệu (Thay cho phím R cũ)
            if (keyData == Keys.F5)
            {
                btnAdLamLai_SV.PerformClick();
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
            if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is System.Windows.Forms.ComboBox)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            // =====================================================================
            // 3. CÁC PHÍM TẮT ĐƠN: CHỈ HOẠT ĐỘNG KHI KHÔNG GÕ CHỮ
            // =====================================================================
            switch (keyData)
            {
                case Keys.C: // Thêm mới (Create)
                    btnAdThem_SV.PerformClick();
                    return true;

                case Keys.U: // Sửa (Update)
                    btnAdSua_SV.PerformClick();
                    return true;

                case Keys.D: // Xóa (Delete)
                    btnAdXoa_SV.PerformClick();
                    return true;

                case Keys.F: // Tìm kiếm (Find)
                             // Fix for CS0104: Explicitly specify the namespace for 'TextBox' and 'ComboBox' to resolve ambiguity.
                    if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is System.Windows.Forms.ComboBox)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    txtAdTuKhoa_SV.Focus();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnAdTimKiem_SV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdTimKiem_SV.PerformClick(); // Tự động "bấm" nút tìm kiếm
                e.Handled = true;
                e.SuppressKeyPress = true; // Tắt tiếng "ting" của Windows khi nhấn Enter
            }
        }
        // Kiểm tra định dạng CCCD (phải là 12 số)
        private bool IsValidCCCD(string cccd)
        {
            return Regex.IsMatch(cccd, @"^\d{12}$");
        }

        // Kiểm tra định dạng Số điện thoại (10 số)
        private bool IsValidSDT(string sdt)
        {
            return Regex.IsMatch(sdt, @"^\d{10}$");
        }

        // Kiểm tra định dạng Email
        private bool IsValidEmailSV(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@student\.edu\.vn$");
        }
        private bool IsValidMaSV(string maSV)
        {
            return Regex.IsMatch(maSV, @"^[a-zA-Z]{3}\d{6}$");
        }
        private void RegisterValidations()
        {
            // 1. Kiểm tra Mã Sinh Viên
            txtAdMaSV.Validating += (s, e) => {
                if (!string.IsNullOrEmpty(txtAdMaSV.Text) && !IsValidMaSV(txtAdMaSV.Text))
                    errorProvider.SetError(txtAdMaSV, "Mã Sinh Viên phải gồm 3 chữ cái và 6 chữ số (VD: DTH235811)!");
                else
                    errorProvider.SetError(txtAdMaSV, "");
            };

            // 2. Kiểm tra Email Sinh Viên
            txtAdSV_Email.Validating += (s, e) => {
                if (!string.IsNullOrEmpty(txtAdSV_Email.Text) && !IsValidEmailSV(txtAdSV_Email.Text))
                    errorProvider.SetError(txtAdSV_Email, "Email sinh viên phải có đuôi @student.edu.vn!");
                else
                    errorProvider.SetError(txtAdSV_Email, "");
            };
            // 1. Kiểm tra CCCD ngay khi rời ô
            txtAdCCCDsv.Validating += (s, e) => {
                if (!string.IsNullOrEmpty(txtAdCCCDsv.Text) && !IsValidCCCD(txtAdCCCDsv.Text))
                {
                    errorProvider.SetError(txtAdCCCDsv, "CCCD phải bao gồm đúng 12 chữ số!");
                    MessageBox.Show("Số CCCD không hợp lệ! Vui lòng nhập đúng 12 chữ số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // e.Cancel = true; // Mở dòng này nếu muốn ép người dùng ở lại ô đó cho đến khi sửa đúng
                }
                else
                {
                    errorProvider.SetError(txtAdCCCDsv, ""); // Xóa lỗi nếu đã sửa đúng
                }
            };

            // 2. Kiểm tra Số điện thoại
            txtAdSDT_SV.Validating += (s, e) => {
                if (!string.IsNullOrEmpty(txtAdSDT_SV.Text) && !IsValidSDT(txtAdSDT_SV.Text))
                {
                    errorProvider.SetError(txtAdSDT_SV, "Số điện thoại phải có đúng 10 chữ số!");
                }
                else
                {
                    errorProvider.SetError(txtAdSDT_SV, "");
                }
            };
        }
    }
}