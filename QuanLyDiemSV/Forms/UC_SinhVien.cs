using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDiemSV.Data; // Đảm bảo namespace này đúng với project của bạn
//using DAL.Models; // Namespace chứa các Class Entity (SinhVien, LopHanhChinh...)

namespace QuanLyDiemSV
{
    public partial class UC_SinhVien : UserControl
    {
        // Khởi tạo ngữ cảnh Database trực tiếp (Theo cách làm của PDF hướng dẫn)
        QLDSVDbContext context = new QLDSVDbContext();
        bool xulyThem = false;

        public UC_SinhVien()
        {
            InitializeComponent();
            // Đăng ký sự kiện Load (Dù bạn đã có trong Designer, viết ở đây cho chắc chắn)
            this.Load += UC_SinhVien_Load;
        }

        // Sự kiện khi UserControl được mở lên
        private void UC_SinhVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxLop(); // Tải danh sách Lớp
            LoadDataGrid();    // Tải danh sách Sinh viên
            BatTatChucNang(false); // Khóa các nút chức năng ban đầu
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnAdLua_SV.Enabled = giaTri;

            // Các ô nhập liệu
            txtAdMaSV.Enabled = giaTri;
            txtAdHoTenSV.Enabled = giaTri;
            txtAdSDT_SV.Enabled = giaTri;
            txtAdCCCDsv.Enabled = giaTri;
            txtAdSV_DiaChi.Enabled = giaTri;
            txtAdSV_Email.Enabled = giaTri;

            // Các ô này chỉ để hiển thị thông tin phụ, nên khóa lại (readonly)
            // Hoặc mở ra nếu bạn muốn cho nhập tay (tùy logic)
            txtAdSV_Khoa.Enabled = false;
            txtAdSV_NienKhoa.Enabled = false;
            txtAdSV_ChuyenNganh.Enabled = false;

            cboAdSV_TenLop.Enabled = giaTri; // ComboBox Lớp

            // Đảo ngược trạng thái cho các nút thao tác
            btnAdLamLai_SV.Enabled = giaTri; // Khi đang nhập thì nút Làm lại sáng
            btnAdThem_SV.Enabled = !giaTri;
            btnAdSua_SV.Enabled = !giaTri;
            btnAdXoa_SV.Enabled = !giaTri;
        }

        #region 1. CÁC HÀM HỖ TRỢ (HELPER) - ĐÃ BỎ COMMENT VÀ SỬA LẠI

        // Hàm tải danh sách Lớp Học vào ComboBox
        private void LoadComboBoxLop()
        {
            try
            {
                // Lấy danh sách lớp trực tiếp từ Context
                // Lưu ý: Tên bảng trong context của bạn có thể là LopHanhChinh hoặc LopHanhChinhs (có s)
                // Hãy gõ context. và xem gợi ý của Visual Studio
                var listLop = context.LopHanhChinh.ToList();

                cboAdSV_TenLop.DataSource = listLop;
                cboAdSV_TenLop.DisplayMember = "TenLop"; // Hiển thị Tên Lớp lên màn hình
                cboAdSV_TenLop.ValueMember = "MaLop";    // Giá trị ngầm là Mã Lớp
                cboAdSV_TenLop.SelectedIndex = -1;       // Mặc định không chọn gì cả
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Lớp: " + ex.Message);
            }
        }

        // Hàm tải dữ liệu lên DataGridView
        private void LoadDataGrid()
        {
            try
            {
                // Sử dụng LINQ để lấy dữ liệu hiển thị (Kết hợp bảng SinhVien, Lop, Nganh, Khoa)
                var query = from sv in context.SinhVien
                            join lop in context.LopHanhChinh on sv.MaLop equals lop.MaLop
                            join nganh in context.Nganh on lop.MaNganh equals nganh.MaNganh
                            join khoa in context.Khoa on nganh.MaKhoa equals khoa.MaKhoa
                            select new
                            {
                                MaSV = sv.MaSV,
                                HoTen = sv.HoTen,
                                NgaySinh = sv.NgaySinh,
                                GioiTinh = sv.GioiTinh,
                                CCCD = sv.CCCD,
                                Email = sv.Email,
                                SDT = sv.SDT,
                                DiaChi = sv.DiaChi,
                                MaLop = sv.MaLop,      // Mã lớp (để bind giá trị)
                                TenLop = lop.TenLop,   // Tên lớp (để hiển thị)
                                TenKhoa = khoa.TenKhoa,
                                TenNganh = nganh.TenNganh,
                                NienKhoa = lop.NienKhoa,
                                TrangThai = sv.TrangThai == 1 ? "Đang học" : "Đã nghỉ"
                            };

                // Đổ dữ liệu vào Grid
                dgvAdminSinhVien.DataSource = query.ToList();

                // Thiết lập tiêu đề cột (Nếu cột đã được tạo sẵn trong Designer thì đoạn này sẽ map dữ liệu vào)
                // Nếu bạn dùng AutoGenerateColumns = true thì nó tự sinh cột.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Sinh viên: " + ex.Message);
            }
        }

        // Hàm xóa trắng các ô nhập liệu (Làm mới)
        private void ResetInput()
        {
            txtAdMaSV.Clear();
            txtAdHoTenSV.Clear();
            dtpAdNamSinhSV.Value = DateTime.Now;
            radAdSV_Nam.Checked = true;

            cboAdSV_TenLop.SelectedIndex = -1;

            txtAdSV_Khoa.Clear();
            txtAdSV_ChuyenNganh.Clear();
            txtAdSV_NienKhoa.Clear();

            txtAdCCCDsv.Clear();
            txtAdSDT_SV.Clear();
            txtAdSV_Email.Clear();
            txtAdSV_DiaChi.Clear();
        }

        #endregion

        #region 2. XỬ LÝ SỰ KIỆN NÚT BẤM (EVENTS)

        // Nút THÊM
        private void btnAdThem_SV_Click(object sender, EventArgs e)
        {
            xulyThem = true;          // Đánh dấu là đang Thêm
            ResetInput();             // Xóa trắng ô nhập
            BatTatChucNang(true);     // Mở khóa nhập liệu
            txtAdMaSV.Focus();        // Đưa con trỏ vào ô Mã SV
        }

        // Nút SỬA
        private void btnAdSua_SV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            xulyThem = false;         // Đánh dấu là đang Sửa
            BatTatChucNang(true);     // Mở khóa nhập liệu
            txtAdMaSV.Enabled = false;// Không cho sửa Mã SV (Khóa chính)
        }

        // Nút XÓA
        private void btnAdXoa_SV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdMaSV.Text))
            {
                MessageBox.Show("Chưa chọn sinh viên cần xóa!");
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa sinh viên {txtAdHoTenSV.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Tìm sinh viên cần xóa
                    var sv = context.SinhVien.Find(txtAdMaSV.Text);
                    if (sv != null)
                    {
                        context.SinhVien.Remove(sv);
                        context.SaveChanges(); // Lưu thay đổi vào DB
                        MessageBox.Show("Đã xóa thành công!");

                        LoadDataGrid(); // Tải lại danh sách
                        ResetInput();
                        BatTatChucNang(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (có thể do ràng buộc dữ liệu điểm số): " + ex.Message);
                }
            }
        }

        // Nút LÀM LẠI
        private void btnAdLamLai_SV_Click(object sender, EventArgs e)
        {
            ResetInput(); // Chỉ xóa trắng form để nhập lại
        }

        // Nút LƯU
        private void btnAdLua_SV_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(txtAdMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAdHoTenSV.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboAdSV_TenLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (xulyThem) // --- LOGIC THÊM MỚI ---
                {
                    // Kiểm tra trùng mã trong DB
                    var checkSV = context.SinhVien.Find(txtAdMaSV.Text);
                    if (checkSV != null)
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo đối tượng SinhVien mới
                    SinhVien sv = new SinhVien();
                    sv.MaSV = txtAdMaSV.Text.Trim();
                    sv.HoTen = txtAdHoTenSV.Text.Trim();
                    sv.NgaySinh = dtpAdNamSinhSV.Value;
                    sv.GioiTinh = radAdSV_Nam.Checked ? "Nam" : "Nữ";
                    sv.CCCD = txtAdCCCDsv.Text.Trim();
                    sv.SDT = txtAdSDT_SV.Text.Trim();
                    sv.Email = txtAdSV_Email.Text.Trim();
                    sv.DiaChi = txtAdSV_DiaChi.Text.Trim();
                    sv.MaLop = cboAdSV_TenLop.SelectedValue.ToString(); // Lấy Mã lớp từ ComboBox
                    sv.TrangThai = 1;

                    context.SinhVien.Add(sv); // Thêm vào Context
                    context.SaveChanges();    // Lưu vào SQL

                    MessageBox.Show("Thêm sinh viên thành công!");
                }
                else // --- LOGIC CẬP NHẬT (SỬA) ---
                {
                    // Tìm sinh viên cũ theo Mã
                    var sv = context.SinhVien.Find(txtAdMaSV.Text);

                    if (sv != null)
                    {
                        // Cập nhật thông tin mới
                        sv.HoTen = txtAdHoTenSV.Text.Trim();
                        sv.NgaySinh = dtpAdNamSinhSV.Value;
                        sv.GioiTinh = radAdSV_Nam.Checked ? "Nam" : "Nữ";
                        sv.CCCD = txtAdCCCDsv.Text.Trim();
                        sv.SDT = txtAdSDT_SV.Text.Trim();
                        sv.Email = txtAdSV_Email.Text.Trim();
                        sv.DiaChi = txtAdSV_DiaChi.Text.Trim();
                        sv.MaLop = cboAdSV_TenLop.SelectedValue.ToString(); // Cập nhật cả lớp nếu chuyển lớp

                        context.SinhVien.Update(sv);
                        context.SaveChanges();

                        MessageBox.Show("Cập nhật thành công!");
                    }
                }

                // Sau khi Lưu xong
                LoadDataGrid();        // Tải lại lưới
                BatTatChucNang(false); // Khóa lại
                ResetInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        // Sự kiện CLICK vào lưới -> Đổ dữ liệu lên ô nhập
        private void dgvAdminSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ chạy khi click vào dòng dữ liệu (RowIndex >= 0) và không đang ở chế độ Thêm/Sửa
            // (Nếu nút Thêm đang SÁNG nghĩa là đang ở chế độ XEM -> Cho phép click)
            if (e.RowIndex >= 0 && btnAdThem_SV.Enabled == true)
            {
                DataGridViewRow row = dgvAdminSinhVien.Rows[e.RowIndex];

                txtAdMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                txtAdHoTenSV.Text = row.Cells["HoTen"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ns))
                    dtpAdNamSinhSV.Value = ns;

                string gt = row.Cells["GioiTinh"].Value?.ToString();
                radAdSV_Nam.Checked = (gt == "Nam");
                radAdSV_Nu.Checked = (gt != "Nam");

                txtAdCCCDsv.Text = row.Cells["CCCD"].Value?.ToString();
                txtAdSDT_SV.Text = row.Cells["SDT"].Value?.ToString();
                txtAdSV_Email.Text = row.Cells["Email"].Value?.ToString();
                txtAdSV_DiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

                // Các ô thông tin phụ (Readonly)
                txtAdSV_NienKhoa.Text = row.Cells["NienKhoa"].Value?.ToString();
                txtAdSV_Khoa.Text = row.Cells["TenKhoa"].Value?.ToString();
                txtAdSV_ChuyenNganh.Text = row.Cells["TenNganh"].Value?.ToString();

                // Tự động chọn đúng Lớp trong ComboBox
                string maLop = row.Cells["MaLop"].Value?.ToString();
                if (!string.IsNullOrEmpty(maLop))
                {
                    cboAdSV_TenLop.SelectedValue = maLop;
                }
            }
        }
        #endregion
    }
}