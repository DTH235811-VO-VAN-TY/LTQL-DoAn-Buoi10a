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

namespace QuanLyDiemSV
{
    public partial class UC_SinhVien : UserControl
    {
        // 1. Khai báo Context và BindingSource
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsSinhVien = new BindingSource();

        bool xuLyThem = false; // Cờ kiểm tra đang Thêm hay Sửa

        public UC_SinhVien()
        {
            InitializeComponent();
            this.Load += UC_SinhVien_Load;
        }

        private void UC_SinhVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBoxLop();
            LoadDuLieuSinhVien(); // Hàm quan trọng nhất để Binding
            KhoiTaoCboTimKiemSapXep();
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
            // Tải danh sách Lớp vào ComboBox
            var listLop = context.LopHanhChinh.ToList();
            cboAdSV_TenLop.DataSource = listLop;
            cboAdSV_TenLop.DisplayMember = "TenLop";
            cboAdSV_TenLop.ValueMember = "MaLop";
            cboAdSV_TenLop.SelectedIndex = -1;
        }

        private void LoadDuLieuSinhVien()
        {
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

               
                var listSV = query.ToList();

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

        #endregion

        #region 3. CÁC NÚT CHỨC NĂNG (CRUD)

        private void btnAdThem_SV_Click(object sender, EventArgs e)
        {
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
            if (bsSinhVien.Current == null) return; // Nếu chưa chọn dòng nào thì thôi

            xuLyThem = false;
            BatTatChucNang(true);
            txtAdMaSV.Enabled = false; // Khi sửa KHÔNG ĐƯỢC sửa mã (Khóa chính)
        }

        private void btnAdXoa_SV_Click(object sender, EventArgs e)
        {
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
                    bsSinhVien.RemoveCurrent();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (Sinh viên này đã có điểm hoặc dữ liệu liên quan): " + ex.Message);
                }
            }
        }

        private void btnAdLua_SV_Click(object sender, EventArgs e)
        {
            // --- QUAN TRỌNG: GỌI HÀM KIỂM TRA RÀNG BUỘC TẠI ĐÂY ---
            if (!ValidateInput()) return; // Nếu dữ liệu sai, dừng lại không lưu
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
                    // Kiểm tra trùng Mã SV trong Database
                    if (context.SinhVien.Any(s => s.MaSV == sv.MaSV))
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
                    // Nếu sửa: Entity Framework tự biết đối tượng này đã thay đổi
                    // thông qua BindingSource, chỉ cần Update trạng thái
                    context.SinhVien.Update(sv);
                }

                context.SaveChanges(); // Lưu xuống SQL

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
            bsSinhVien.CancelEdit(); // Hủy bỏ các thay đổi tạm thời trên BindingSource
            BatTatChucNang(false);
            LoadDuLieuSinhVien(); // Tải lại dữ liệu gốc
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

        private void btnAdTimKiem_SV_Click(object sender, EventArgs e)
        {
            LoadDuLieuSinhVien();
        }

        private void btnAdShowAll_SV_Click(object sender, EventArgs e)
        {
            txtAdTuKhoa_SV.Clear();
            cboAdTimKiem_SV.SelectedIndex = 1;
            cboKieuSX.SelectedIndex = 0;
            radTang.Checked = true;

            LoadDuLieuSinhVien();
        }

        private void cboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDuLieuSinhVien();
        }

        private void radTang_CheckedChanged(object sender, EventArgs e)
        {
            if (radTang.Checked)
                LoadDuLieuSinhVien();
        }

        private void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiam.Checked)
                LoadDuLieuSinhVien();
        }
    }
}