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
using QuanLyDiemSV.Data; // Đảm bảo namespace này đúng

namespace QuanLyDiemSV.Forms
{
    public partial class UC_GiangVien : UserControl
    {
        // Khởi tạo Context và BindingSource
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsGiangVien = new BindingSource();
        bool xuLyThem = false;

        public UC_GiangVien()
        {
            InitializeComponent();
            this.Load += UC_GiangVien_Load;
        }

        private void UC_GiangVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadCboKhoa();
            LoadCboHocVi();
            LoadData();
            KhoiTaoCboTimKiemSapXep();

        }
        private void KhoiTaoCboTimKiemSapXep()
        {
            // 1. ComboBox Loại Tìm Kiếm (cboLoaiTK)
            cboLoaiTK.Items.Clear();
            cboLoaiTK.Items.AddRange(new string[] { "Mã Giảng Viên", "Họ Tên", "Giới Tính", "Số Điện Thoại" });
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

        private void LoadData()
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
                        case "Số Điện Thoại":
                            query = query.Where(g => g.SDT.Contains(tuKhoa));
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
            xuLyThem = true;
            BatTatChucNang(true);

            // Xóa trắng để nhập mới
            txtMaGV.Clear();
            txtHoTenGV.Clear();
            txtEmail.Clear();
            txtSDT.Clear(); // SDT
            dtpNamSinhGV.Value = DateTime.Now;
            radNam.Checked = true;
            cboKhoa.SelectedIndex = -1;
            cboHocVi.SelectedIndex = 0;

            txtMaGV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (bsGiangVien.Current == null) return;

            xuLyThem = false;
            BatTatChucNang(true);
            txtMaGV.Enabled = false; // Không sửa khóa chính
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
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
            BatTatChucNang(false);
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
            if(radGiam.Checked)
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
    }
}