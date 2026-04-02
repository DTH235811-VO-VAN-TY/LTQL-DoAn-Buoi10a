using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmQuanLyKhieuNai : Form
    {
        QLDSVDbContext context = new QLDSVDbContext();
        int maKNDangChon = -1; // Lưu lại mã đơn đang được click
        int maLHPDangChon = -1;
        string maSVDangChon = "";
        public FrmQuanLyKhieuNai()
        {
            InitializeComponent();
        }

        private void FrmQuanLyKhieuNai_Load(object sender, EventArgs e)
        {
            LoadDanhSachDon();
        }
        private void LoadDanhSachDon()
        {
            // Lấy các đơn có trạng thái = 0 (Chờ xử lý) thuộc về Giảng viên đang đăng nhập
            var listDon = context.DonKhieuNai
                .Include(d => d.MaSVNavigation)
                .Include(d => d.MaLHPNavigation).ThenInclude(l => l.MaMonNavigation)
                .Where(d => d.TrangThai == 0 && d.MaLHPNavigation.MaGV == Session.MaNguoiDung) // Giả sử LopHocPhan có MaGV
                .Select(d => new
                {
                    MaKN = d.MaKN,
                    MaSV = d.MaSV,
                    HoTen = d.MaSVNavigation.HoTen,
                    MonHoc = d.MaLHPNavigation.MaMonNavigation.TenMon,
                    LyDo = d.LyDo,
                    NgayGui = d.NgayGui,
                    MaLHP = d.MaLHP // Ẩn cột này đi trên Grid, chỉ dùng để truy xuất
                }).ToList();

            dgvKhieuNai.AutoGenerateColumns = false;

            dgvKhieuNai.DataSource = listDon;

            // Xóa trắng khu vực nhập liệu
            ResetForm();
        }

        private void dgvKhieuNai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhieuNai.Rows[e.RowIndex];

                // BƯỚC NGOẶT: Lấy đối tượng dữ liệu thật đang được bind ngầm ở dòng này (dùng dynamic để đọc)
                dynamic data = row.DataBoundItem;
                if (data == null) return;

                // Trích xuất dữ liệu thẳng từ Database object, không phụ thuộc vào tên cột trên giao diện nữa
                maKNDangChon = data.MaKN;
                maSVDangChon = data.MaSV;
                maLHPDangChon = data.MaLHP;

                // Cập nhật lên các Label
                lblSinhVien.Text = $"SV: {data.HoTen} ({maSVDangChon})";
                lblMonHoc.Text = $"Môn: {data.MonHoc}";
                lblLyDo.Text = $"Lý do SV gửi: {data.LyDo}";

                // Load điểm hiện tại của SV này lên
                var diem = context.KetQuaHocTap.FirstOrDefault(k => k.MaSV == maSVDangChon && k.MaLHP == maLHPDangChon);
                if (diem != null)
                {
                    txtDiemGTCu.Text = diem.DiemGK.ToString();
                    txtDiemCKCu.Text = diem.DiemCK.ToString();

                    // Gán sẵn điểm cũ sang ô điểm mới cho GV dễ sửa
                    txtDiemGKMoi.Text = diem.DiemGK.ToString();
                    txtDiemCKMoi.Text = diem.DiemCK.ToString();
                }
            }
        }

        // =========================================================
        // 3. XỬ LÝ NÚT DUYỆT (CHẤP NHẬN SỬA ĐIỂM)
        // =========================================================
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (maKNDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn một đơn khiếu nại trên lưới trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtPhanHoi.Text.Trim()))
            {
                MessageBox.Show("Vui lòng ghi lời phản hồi cho Sinh viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BƯỚC NGOẶT ĐỂ HẾT LỖI: Chuyển đổi toàn bộ double sang decimal
            if (!decimal.TryParse(txtDiemGKMoi.Text, out decimal diemGK_Moi) || !decimal.TryParse(txtDiemCKMoi.Text, out decimal diemCK_Moi))
            {
                MessageBox.Show("Điểm mới nhập vào không hợp lệ! Vui lòng nhập số hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // A. Cập nhật lại điểm trong bảng KetQuaHocTap
                var diemHT = context.KetQuaHocTap.FirstOrDefault(k => k.MaSV == maSVDangChon && k.MaLHP == maLHPDangChon);
                if (diemHT != null)
                {
                    diemHT.DiemGK = diemGK_Moi;
                    diemHT.DiemCK = diemCK_Moi;

                    // BỔ SUNG DÒNG NÀY: Tính toán lại Điểm Tổng Kết ngay lập tức và làm tròn 1 chữ số.
                    // Lưu ý: Tôi đang để tạm tỷ lệ 40% GK - 60% CK. Bạn hãy chỉnh lại hệ số 0.4 và 0.6 cho khớp với quy chế học vụ thực tế nhé!
                    diemHT.DiemTongKet = Math.Round((diemGK_Moi * 0.4m) + (diemCK_Moi * 0.6m), 1);
                }

                // B. Chuyển trạng thái Đơn thành Đã Duyệt
                var don = context.DonKhieuNai.FirstOrDefault(d => d.MaKN == maKNDangChon);
                if (don != null)
                {
                    don.TrangThai = 1; // Đã duyệt
                    don.PhanHoi = txtPhanHoi.Text.Trim();
                    don.DaXem = false;
                }

                // C. BƯỚC THÊM MỚI: TẠO THÔNG BÁO CHO SINH VIÊN
                ThongBao tbMoi = new ThongBao()
                {
                    MaNguoiGui = Session.MaNguoiDung, // Lấy ID giảng viên đang đăng nhập
                    MaNguoiNhan = maSVDangChon,       // Mã SV "DTH235801"
                    TieuDe = "Kết quả khiếu nại môn: " + lblMonHoc.Text.Replace("Môn: ", ""),
                    NoiDung = txtPhanHoi.Text.Trim(),
                    LoaiThongBao = "KHIEU_NAI",
                    ThamChieuID = maKNDangChon.ToString(),
                    NgayGui = DateTime.Now,
                    DaDoc = false
                };
                context.ThongBaos.Add(tbMoi); // Lưu vào bảng ThongBao

                context.SaveChanges();
                MessageBox.Show("Đã duyệt đơn, cập nhật điểm và gửi thông báo cho SV thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.ToString(), "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (maKNDangChon == -1) return;

            if (string.IsNullOrEmpty(txtPhanHoi.Text.Trim()))
            {
                MessageBox.Show("Vui lòng giải thích lý do từ chối cho Sinh viên hiểu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var don = context.DonKhieuNai.FirstOrDefault(d => d.MaKN == maKNDangChon);
            if (don != null)
            {
                don.TrangThai = 2; // Từ chối
                don.PhanHoi = txtPhanHoi.Text.Trim();
                don.DaXem = false;

                // TẠO THÔNG BÁO TỪ CHỐI
            ThongBao tbMoi = new ThongBao()
            {
                MaNguoiGui = Session.MaNguoiDung,
                MaNguoiNhan = maSVDangChon,
                TieuDe = "Từ chối khiếu nại môn: " + lblMonHoc.Text.Replace("Môn: ", ""),
                NoiDung = txtPhanHoi.Text.Trim(),
                LoaiThongBao = "KHIEU_NAI",
                ThamChieuID = maKNDangChon.ToString(),
                NgayGui = DateTime.Now,
                DaDoc = false
            };
                context.ThongBaos.Add(tbMoi);

                context.SaveChanges();
                MessageBox.Show("Đã từ chối đơn khiếu nại và gửi thông báo!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDon();
            }
        }

        private void ResetForm()
        {
            maKNDangChon = -1;
            lblSinhVien.Text = "SV: ";
            lblMonHoc.Text = "Môn: ";
            lblLyDo.Text = "Lý do: ";
            txtDiemGTCu.Clear(); txtDiemCKCu.Clear();
            txtDiemGKMoi.Clear(); txtDiemCKMoi.Clear();
            txtPhanHoi.Clear();
            }
    }
}
