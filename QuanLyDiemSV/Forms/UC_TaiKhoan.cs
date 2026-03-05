using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyDiemSV.Data; // Namespace chứa Context
using BCrypt.Net; // Thư viện mã hóa mật khẩu

namespace QuanLyDiemSV.Forms
{
    public partial class UC_TaiKhoan : UserControl
    {
        // 1. Khởi tạo Context và BindingSource
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsTaiKhoan = new BindingSource();
        bool xuLyThem = false;

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
        }

        private void UC_TaiKhoan_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBoxData(); // Load quyền và trạng thái
            KhoiTaoCboTimKiemSapXep();
            LoadData();         // Load danh sách tài khoản
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
                cbKhoa.DataSource = listKhoa;
                cbKhoa.DisplayMember = "TenKhoa";
                cbKhoa.ValueMember = "MaKhoa";
                cbKhoa.SelectedIndex = -1;

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
                // 1. Khởi tạo truy vấn gốc
                var query = context.UserAccount.AsQueryable();

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
                var listTK = query.ToList();
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
            if (bsTaiKhoan.Current == null) return;

            xuLyThem = false;
            BatTatChucNang(true);

            txtTenDangNhap.Enabled = false; // Không cho sửa Tên đăng nhập (Khóa)
            txtMatKhau.Clear();             // Xóa ô mật khẩu để người dùng nhập mới nếu muốn đổi
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
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

                    UserAccount acc = new UserAccount();
                    acc.Username = txtTenDangNhap.Text.Trim();

                    // Mã hóa mật khẩu
                    acc.PasswordHash = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);

                    acc.RoleID = selectedRoleID;
                    acc.IsActive = (bool)cboTrangThai.SelectedValue;
                    acc.NgayTao = DateTime.Now;

                    context.UserAccount.Add(acc);
                }
                else // --- SỬA ---
                {
                    // Lấy ID từ BindingSource (Vì UserID là khóa chính int)
                    var currentAcc = (UserAccount)bsTaiKhoan.Current;
                    var acc = context.UserAccount.Find(currentAcc.UserID);

                    if (acc != null)
                    {
                        acc.RoleID = cboQuyenHan.SelectedIndex;
                        acc.IsActive = (bool)cboTrangThai.SelectedValue;

                        // Chỉ cập nhật mật khẩu nếu người dùng có nhập vào ô Textbox
                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            acc.PasswordHash = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);
                        }
                        // Nếu để trống thì giữ nguyên mật khẩu cũ

                        context.UserAccount.Update(acc);
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
    }
}