using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyDiemSV.Data; // Namespace chứa Context
using BCrypt.Net; // Thư viện mã hóa mật khẩu
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore; // Cho Include

namespace QuanLyDiemSV.Forms
{
    public partial class UC_TaiKhoan : UserControl
    {
        // 1. Khởi tạo Context và BindingSource
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsTaiKhoan = new BindingSource();
        bool xuLyThem = false;
        ErrorProvider errorProvider = new ErrorProvider();

        // Class phụ để đổ dữ liệu vào ComboBox Trạng thái
        public class TrangThaiItem
        {
            public bool Value { get; set; }
            public string Text { get; set; }
        }

        public UC_TaiKhoan()
        {
            InitializeComponent();
            this.Load += UC_TaiKhoan_Load;
            StyleDataGridView(dataGridView1);
            
            // Đăng ký sự kiện lọc cho cboLocKhoa
            cboLocKhoa.SelectedIndexChanged += (s, e) => { if (cboLocKhoa.Focused) LoadData(); };

            // FIX: Cho phép bấm Làm lại/Thêm/Sửa/Xoa mà không bị chặn bởi Validate
            btnLamLai.CausesValidation = false;
            btnThem.CausesValidation = false;
            btnSua.CausesValidation = false;
            btnXoa.CausesValidation = false;
            btnTimKiem.CausesValidation = false;
            btnShowAll.CausesValidation = false;
        }
        private void RegisterValidations()
        {
            txtTenDangNhap.Validating += (s, e) =>
            {
                if (!txtTenDangNhap.Enabled) { errorProvider.SetError(txtTenDangNhap, ""); return; }

                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                {
                    // e.Cancel = true; // Bỏ Cancel để có thể nhấn nút Làm lại thoải mái
                    errorProvider.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống!");
                }
                else if(xuLyThem && context.UserAccount.Any(x => x.Username == txtTenDangNhap.Text.Trim()))
                {
                    errorProvider.SetError(txtTenDangNhap, "Tên đăng nhập này đã tồn tại!");
                }
                else
                {
                    errorProvider.SetError(txtTenDangNhap, "");
                }
            };
            txtMatKhau.Validating += (s, e) =>
            {
                if (!txtMatKhau.Enabled) { errorProvider.SetError(txtMatKhau, ""); return; }

                if (xuLyThem && string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    errorProvider.SetError(txtMatKhau, "Mật khẩu không được để trống khi tạo tài khoản mới!");
                }
                else
                {
                    errorProvider.SetError(txtMatKhau, "");
                }
            };
            cboQuyenHan.Validating += (s, e) =>
            {
                if (!cboQuyenHan.Enabled) { errorProvider.SetError(cboQuyenHan, ""); return; }

                if (cboQuyenHan.SelectedValue == null)
                {
                    errorProvider.SetError(cboQuyenHan, "Vui lòng chọn quyền hạn cho tài khoản!");
                }
                else
                {
                    errorProvider.SetError(cboQuyenHan, "");
                }
            };
            cboTrangThai.Validating += (s, e) =>
            {
                if (!cboTrangThai.Enabled) { errorProvider.SetError(cboTrangThai, ""); return; }

                if (cboTrangThai.SelectedValue == null)
                {
                    errorProvider.SetError(cboTrangThai, "Vui lòng chọn trạng thái cho tài khoản!");
                }
                else
                {
                    errorProvider.SetError(cboTrangThai, "");
                }
            };
        }
        private string MaHoaMatKhau(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
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
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

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

        private void UC_TaiKhoan_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBoxData(); // Load quyền và trạng thái
            KhoiTaoCboTimKiemSapXep();
            LoadData();         // Load danh sách tài khoản
            RegisterValidations(); // Đăng ký các sự kiện kiểm tra nhập liệu
        }
        private void KhoiTaoCboTimKiemSapXep()
        {
            // Nạp mục cho ComboBox Tìm Kiếm
            cboLoaiTK.Items.Clear();
            cboLoaiTK.Items.AddRange(new string[] { "Tên đăng nhập", "Mã ID" });
            cboLoaiTK.SelectedIndex = 0;

            // Nạp mục cho ComboBox Sắp Xếp
            cboKieuSX.Items.Clear();
            cboKieuSX.Items.AddRange(new string[] { "Tên đăng nhập", "Ngày tạo", "Trạng thái" });
            cboKieuSX.SelectedIndex = 0;

            radTang.Checked = true; // Mặc định chọn Tăng dần
        }

        #region 1. HÀM HỖ TRỢ & LOAD DỮ LIỆU

        private void BatTatChucNang(bool giaTri)
        {
            // Nút Lưu/Hủy
            btnLuu.Enabled = giaTri;
            btnLamLai.Enabled = giaTri;

            // Ô nhập liệu
            txtUserID.Enabled = false; // ID tự tăng nên luôn khóa
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;
            cboTrangThai.Enabled = giaTri;
            cbKhoa.Enabled = giaTri;
            dtpNgayTao.Enabled = false; // Ngày tạo tự động lấy ngày hiện tại

            // Nút chức năng
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnShowAll.Enabled = !giaTri;
        }

        private void LoadComboBoxData()
        {
            try
            {
                // 1. Load Danh sách Quyền (Role)
                var listRole = context.Role.ToList(); // Giả sử bảng tên là Role
                cboQuyenHan.DataSource = listRole;
                cboQuyenHan.DisplayMember = "RoleName"; // Tên cột hiển thị (VD: Admin)
                cboQuyenHan.ValueMember = "RoleID";     // Giá trị (VD: ADMIN)
                cboQuyenHan.SelectedIndex = -1;

                var listKhoa = context.Khoa.ToList();
                cbKhoa.DataSource = new List<Khoa>(listKhoa);
                cbKhoa.DisplayMember = "TenKhoa";
                cbKhoa.ValueMember = "MaKhoa";
                cbKhoa.SelectedIndex = -1;

                // 3. Load ComboBox Lọc Khoa (Ở panel tìm kiếm)
                var listLocKhoa = new List<object>();
                listLocKhoa.Add(new { MaKhoa = "ALL", TenKhoa = "-- Tất cả khoa --" });
                foreach (var k in listKhoa) listLocKhoa.Add(new { k.MaKhoa, k.TenKhoa });

                cboLocKhoa.DataSource = listLocKhoa;
                cboLocKhoa.DisplayMember = "TenKhoa";
                cboLocKhoa.ValueMember = "MaKhoa";
                cboLocKhoa.SelectedIndex = 0; // Mặc định là Tất cả khoa

                // 2. Load Trạng thái (Hoạt động / Khóa)
                List<TrangThaiItem> listTrangThai = new List<TrangThaiItem>()
                {
                    new TrangThaiItem { Value = true, Text = "Hoạt động" },
                    new TrangThaiItem { Value = false, Text = "Đã khóa" }
                };
                cboTrangThai.DataSource = listTrangThai;
                cboTrangThai.DisplayMember = "Text";
                cboTrangThai.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                // 1. Khởi tạo truy vấn gốc (Include các bảng liên quan để lọc theo khoa)
                var query = context.UserAccount
                    .Include(u => u.GiangVien)
                    .Include(u => u.SinhVien).ThenInclude(s => s.MaLopNavigation).ThenInclude(l => l.MaNganhNavigation)
                    .AsQueryable();

                // ==========================================
                // 1.5 XỬ LÝ LỌC THEO KHOA
                // ==========================================
                if (cboLocKhoa.SelectedValue != null && cboLocKhoa.SelectedValue.ToString() != "ALL")
                {
                    string maKhoa = cboLocKhoa.SelectedValue.ToString();
                    query = query.Where(u =>
                        (u.GiangVien.Any(gv => gv.MaKhoa == maKhoa)) ||
                        (u.SinhVien.Any(sv => sv.MaLopNavigation.MaNganhNavigation.MaKhoa == maKhoa))
                    );
                }

                // ==========================================
                // 2. XỬ LÝ TÌM KIẾM
                // ==========================================
                string tuKhoa = txtTuKhoaTK.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa) && cboLoaiTK.SelectedIndex != -1)
                {
                    string loaiTK = cboLoaiTK.SelectedItem.ToString();
                    if (loaiTK == "Tên đăng nhập")
                    {
                        query = query.Where(u => u.Username.ToLower().Contains(tuKhoa));
                    }
                    else if (loaiTK == "Mã ID")
                    {
                        // Kiểm tra nếu người dùng nhập số thì mới tìm theo ID
                        if (int.TryParse(tuKhoa, out int id))
                        {
                            query = query.Where(u => u.UserID == id);
                        }
                    }
                }

                // ==========================================
                // 3. XỬ LÝ SẮP XẾP
                // ==========================================
                bool isTang = radTang.Checked;
                if (cboKieuSX.SelectedIndex != -1)
                {
                    string kieuSX = cboKieuSX.SelectedItem.ToString();
                    if (kieuSX == "Tên đăng nhập")
                    {
                        query = isTang ? query.OrderBy(u => u.Username) : query.OrderByDescending(u => u.Username);
                    }
                    else if (kieuSX == "Ngày tạo")
                    {
                        query = isTang ? query.OrderBy(u => u.NgayTao) : query.OrderByDescending(u => u.NgayTao);
                    }
                    else if (kieuSX == "Trạng thái")
                    {
                        // true (Hoạt động) xếp trước, false (Đã khóa) xếp sau hoặc ngược lại
                        query = isTang ? query.OrderByDescending(u => u.IsActive) : query.OrderBy(u => u.IsActive);
                    }
                }

                // 4. Lấy dữ liệu và Binding
                var listTK =  query.ToList();
                bsTaiKhoan.DataSource = listTK;

                // Xóa các Binding cũ
                txtUserID.DataBindings.Clear();
                txtTenDangNhap.DataBindings.Clear();
                dtpNgayTao.DataBindings.Clear();
                cboQuyenHan.DataBindings.Clear();
                cboTrangThai.DataBindings.Clear();
                txtMatKhau.DataBindings.Clear();

                // Tạo Binding mới
                txtUserID.DataBindings.Add("Text", bsTaiKhoan, "UserID", true, DataSourceUpdateMode.Never);
                txtTenDangNhap.DataBindings.Add("Text", bsTaiKhoan, "Username", true, DataSourceUpdateMode.Never);
                dtpNgayTao.DataBindings.Add("Value", bsTaiKhoan, "NgayTao", true, DataSourceUpdateMode.Never);
                cboQuyenHan.DataBindings.Add("SelectedValue", bsTaiKhoan, "RoleID", true, DataSourceUpdateMode.Never);
                cboTrangThai.DataBindings.Add("SelectedValue", bsTaiKhoan, "IsActive", true, DataSourceUpdateMode.Never);

                // Đăng ký sự kiện (Làm rỗng ô mật khẩu khi chọn dòng)
                bsTaiKhoan.CurrentChanged -= BsTaiKhoan_CurrentChanged;
                bsTaiKhoan.CurrentChanged += BsTaiKhoan_CurrentChanged;
                BsTaiKhoan_CurrentChanged(null, null);

                // Hiển thị lên lưới
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = bsTaiKhoan;

                if (dataGridView1.Columns["PasswordHash"] != null)
                {
                    dataGridView1.Columns["PasswordHash"].Visible = false; // Ẩn cột mật khẩu mã hóa
                }
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi lúc form mới load
            }
        }

        #endregion

        #region 2. XỬ LÝ NÚT BẤM (CRUD)

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider.Clear(); // Xóa hết lỗi cũ trước khi thêm mới
            xuLyThem = true;
            BatTatChucNang(true);

            // Xóa trắng ô nhập
            txtUserID.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0; // Mặc định là Hoạt động
            dtpNgayTao.Value = DateTime.Now;

            txtTenDangNhap.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            errorProvider.Clear(); // Xóa hết lỗi cũ trước khi sửa
            if (bsTaiKhoan.Current == null) return;

            xuLyThem = false;
            BatTatChucNang(true);

            txtTenDangNhap.Enabled = false; // Không cho sửa Tên đăng nhập (Khóa)
            txtMatKhau.Clear();             // Xóa ô mật khẩu để người dùng nhập mới nếu muốn đổi
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            errorProvider.Clear(); // Xóa hết lỗi cũ trước khi xóa
            if (bsTaiKhoan.Current == null) return;
            var acc = (UserAccount)bsTaiKhoan.Current;

            if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {acc.Username}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    context.UserAccount.Remove(acc);
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
            errorProvider.Clear(); // Xóa hết lỗi cũ trước khi lưu
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập!");
                return;
            }
            if (cboQuyenHan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng phân quyền cho tài khoản!");
                return;
            }

            // 2. Kiểm tra Mật khẩu
            if (xuLyThem && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản mới!");
                return;
            }
            int selectedRoleID = Convert.ToInt32(cboQuyenHan.SelectedValue);
            try
            {
                if (xuLyThem) // --- THÊM MỚI ---
                {
                    // Check trùng tên đăng nhập
                    if (context.UserAccount.Any(x => x.Username == txtTenDangNhap.Text.Trim()))
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại!");
                        return;
                    }

                    // 1. TẠO TÀI KHOẢN MỚI
                    UserAccount newUser = new UserAccount();
                    newUser.Username = txtTenDangNhap.Text.Trim(); // Lấy Tên đăng nhập (Nên là Mã SV/Mã GV)
                    newUser.PasswordHash = MaHoaMatKhau(txtMatKhau.Text); // (Nếu có mã hóa thì mã hóa ở đây)
                    newUser.RoleID = (int)cboQuyenHan.SelectedValue;
                    newUser.IsActive = (bool)cboTrangThai.SelectedValue;
                    newUser.NgayTao = DateTime.Now;

                    // Thêm vào DB và Lưu lần 1 để EF Core tự động sinh ra UserID mới
                    context.UserAccount.Add(newUser);
                    context.SaveChanges();

                    // 2. LOGIC TỰ ĐỘNG LIÊN KẾT BẰNG USERID VỪA TẠO
                    string maNguoiDung = newUser.Username; // Lấy Tên đăng nhập để đi tìm người

                    if (newUser.RoleID == 3) // NẾU LÀ TÀI KHOẢN SINH VIÊN
                    {
                        // Dò tìm sinh viên có Mã SV khớp với Username
                        var sv = context.SinhVien.FirstOrDefault(x => x.MaSV == maNguoiDung);
                        if (sv != null)
                        {
                            sv.UserID = newUser.UserID; // Gắn ID mới vào sinh viên
                            context.SinhVien.Update(sv);
                        }
                        else
                        {
                            MessageBox.Show($"Tạo tài khoản thành công, nhưng không tìm thấy Sinh viên nào có mã '{maNguoiDung}' để liên kết!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (newUser.RoleID == 2) // NẾU LÀ TÀI KHOẢN GIẢNG VIÊN
                    {
                        // Dò tìm giảng viên có Mã GV khớp với Username
                        var gv = context.GiangVien.FirstOrDefault(x => x.MaGV == maNguoiDung);
                        if (gv != null)
                        {
                            gv.UserID = newUser.UserID; // Gắn ID mới vào giảng viên
                            newUser.MaGV = gv.MaGV; // Cập nhật luôn cột MaGV bên bảng UserAccount cho đồng bộ

                            context.GiangVien.Update(gv);
                            context.UserAccount.Update(newUser); // Cập nhật lại newUser vì vừa thêm MaGV
                        }
                        else
                        {
                            MessageBox.Show($"Tạo tài khoản thành công, nhưng không tìm thấy Giảng viên nào có mã '{maNguoiDung}' để liên kết!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Lưu lần 2 để chốt sự thay đổi khóa ngoại ở bảng SinhVien/GiangVien
                    context.SaveChanges();
                    MessageBox.Show("Thêm tài khoản và liên kết dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // --- SỬA ---
                {
                    // Lấy ID từ BindingSource (Vì UserID là khóa chính int)
                    var currentAcc = (UserAccount)bsTaiKhoan.Current;
                    var acc = context.UserAccount.Find(currentAcc.UserID);

                    if (acc != null)
                    {
                        // SỬA LỖI Ở ĐÂY: Dùng biến selectedRoleID đã lấy đúng Value ở phía trên
                        acc.RoleID = selectedRoleID;

                        acc.IsActive = (bool)cboTrangThai.SelectedValue;

                        // Chỉ cập nhật mật khẩu nếu người dùng có nhập vào ô Textbox
                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            acc.PasswordHash = MaHoaMatKhau(txtMatKhau.Text);
                        }
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
            xuLyThem = false;
            errorProvider.Clear(); // Xóa hết lỗi cũ trước khi làm lại
            BatTatChucNang(false);
            bsTaiKhoan.ResetBindings(false); // Reset lại giá trị cũ
            txtMatKhau.Clear();
        }

        // Nút thêm nhanh Quyền hạn (Giả sử bạn có Form Role)
        private void btnThemQuyenHan_Click(object sender, EventArgs e)
        {
            FrmRole frm = new FrmRole();
            frm.ShowDialog();
            LoadComboBoxData();
        }

        #endregion

        // Sự kiện click nút Tìm kiếm (Optional)
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Viết code lọc bsTaiKhoan ở đây
            // Ví dụ: bsTaiKhoan.DataSource = context.UserAccount.Where(...).ToList();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        // Sự kiện này chạy mỗi khi bạn chọn một dòng khác trên lưới
        private void BsTaiKhoan_CurrentChanged(object sender, EventArgs e)
        {
            // Ép ô mật khẩu phải rỗng, bất kể có binding hay không
            txtMatKhau.Text = "";
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm LoadData() vì logic tìm kiếm đã được viết bên trong đó
        }

        private void btnShowAll_Click_1(object sender, EventArgs e)
        {
            // Reset các giá trị lọc về mặc định
            txtTuKhoaTK.Clear();
            cboLoaiTK.SelectedIndex = 0;
            cboLocKhoa.SelectedIndex = 0;
            cboKieuSX.SelectedIndex = 0;
            radTang.Checked = true;

            LoadData(); // Load lại toàn bộ tài khoản
        }

        private void cboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKieuSX.Focused) LoadData(); // Tự động sắp xếp khi chọn combobox
        }

        private void radTang_CheckedChanged(object sender, EventArgs e)
        {
            if (radTang.Checked) LoadData(); // Tự động sắp xếp lại khi nhấn Tăng
        }

        private void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            if (radGiam.Checked) LoadData(); // Tự động sắp xếp lại khi nhấn Giảm
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tên cột trạng thái của bạn trong file Designer là IsActive
            if (dataGridView1.Columns[e.ColumnIndex].Name == "IsActive" && e.Value != null)
            {
                string val = e.Value.ToString().ToLower();
                if (val == "true" || val == "1")
                {
                    e.Value = "Hoạt động";
                    e.CellStyle.ForeColor = Color.MediumSeaGreen;
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                else
                {
                    e.Value = "Đã khóa";
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                e.FormattingApplied = true;
            }
            // 2. THÊM MỚI: Xử lý cột Quyền Hạn (RoleID)
            if (dataGridView1.Columns[e.ColumnIndex].Name == "RoleID" && e.Value != null)
            {
                string role = e.Value.ToString();
                if (role == "1")
                {
                    e.Value = "Admin";
                    e.CellStyle.ForeColor = Color.Crimson; // Admin cho màu đỏ nổi bật
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                else if (role == "2")
                {
                    e.Value = "Giảng viên";
                    e.CellStyle.ForeColor = Color.MediumSeaGreen; // GV màu xanh lá
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                else if (role == "3")
                {
                    e.Value = "Sinh viên";
                    e.CellStyle.ForeColor = Color.DarkBlue; // SV màu xanh dương
                }
                e.FormattingApplied = true;
            }
        }
        // ==============================================================
        // HÀM CẬP NHẬT DỮ LIỆU MỚI NHẤT (Chuẩn hóa cho toàn hệ thống)
        // ==============================================================
        public void CapNhatDuLieuMoiNhat()
        {
            try
            {
                context = new QLDSVDbContext();
                LoadData();
                LoadComboBoxData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật tài khoản: " + ex.Message);
            }
        }
    }
}