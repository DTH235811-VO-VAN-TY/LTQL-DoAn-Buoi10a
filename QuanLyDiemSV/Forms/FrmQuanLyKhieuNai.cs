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
        // Hàm tính điểm chuẩn copy từ màn hình Chấm Điểm
        private decimal? TinhDiemTongKetCuoiCung(decimal? diemGK, decimal? diemCK, decimal? diemThiL1, decimal? diemThiL2)
        {
            if (!diemCK.HasValue) return null;

            decimal gk = diemGK ?? 0m;
            decimal tkChinhThuc = Math.Round((gk * 0.4m) + (diemCK.Value * 0.6m), 1);

            decimal? diemThiLai = diemThiL2.HasValue ? diemThiL2 : diemThiL1;

            if (!diemThiLai.HasValue) return tkChinhThuc;

            decimal tkThiLai = Math.Round((gk * 0.4m) + (diemThiLai.Value * 0.6m), 1);

            if (tkChinhThuc < 5.0m)
            {
                // Rớt -> Thi lại: Tối đa 6.0
                if (tkThiLai >= 5.0m) return 6.0m;
                return tkThiLai;
            }
            else
            {
                // Đậu -> Thi cải thiện: Lấy điểm cao nhất, không giới hạn
                if (tkThiLai > tkChinhThuc) return tkThiLai;
                return tkChinhThuc;
            }
        }

        // =========================================================
        // 3. XỬ LÝ NÚT DUYỆT (CHẤP NHẬN SỬA ĐIỂM)
        // =========================================================
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (maKNDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn một đơn khiếu nại để duyệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Kiểm tra tính hợp lệ của điểm mới do GV nhập vào
            if (!decimal.TryParse(txtDiemGKMoi.Text, out decimal diemGKMoi) || diemGKMoi < 0 || diemGKMoi > 10 ||
                !decimal.TryParse(txtDiemCKMoi.Text, out decimal diemCKMoi) || diemCKMoi < 0 || diemCKMoi > 10)
            {
                MessageBox.Show("Điểm mới không hợp lệ! Vui lòng nhập số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Tìm Đơn khiếu nại VÀ Kết quả học tập của sinh viên đó
            var don = context.DonKhieuNai.FirstOrDefault(d => d.MaKN == maKNDangChon);
            var ketQua = context.KetQuaHocTap.FirstOrDefault(k => k.MaSV == maSVDangChon && k.MaLHP == maLHPDangChon);

            if (don != null && ketQua != null)
            {
                string diemGKCu = ketQua.DiemGK?.ToString() ?? "Trống";
                string diemCKCu = ketQua.DiemCK?.ToString() ?? "Trống";
                // ==========================================
                // BƯỚC QUAN TRỌNG: CẬP NHẬT ĐIỂM VÀO BẢNG ĐIỂM
                // ==========================================
                ketQua.DiemGK = diemGKMoi;
                ketQua.DiemCK = diemCKMoi;

                // Tự động tính lại Điểm Tổng Kết (Áp dụng đúng quy chế 40/60 và có xét thi lại như đã làm)
                decimal? diemThiLai = ketQua.DiemThiLan2 ?? ketQua.DiemThiLan1;
                decimal tkChinhThuc = Math.Round((diemGKMoi * 0.4m) + (diemCKMoi * 0.6m), 1);

                if (diemThiLai.HasValue)
                {
                    decimal tkThiLai = Math.Round((diemGKMoi * 0.4m) + (diemThiLai.Value * 0.6m), 1);
                    if (tkChinhThuc < 5.0m)
                    {
                        ketQua.DiemTongKet = tkThiLai >= 5.0m ? 6.0m : tkThiLai; // Khống chế 6.0 nếu rớt
                    }
                    else
                    {
                        ketQua.DiemTongKet = tkThiLai > tkChinhThuc ? tkThiLai : tkChinhThuc; // Cải thiện
                    }
                }
                else
                {
                    ketQua.DiemTongKet = tkChinhThuc;
                }

                // ==========================================
                // CẬP NHẬT TRẠNG THÁI ĐƠN KHIẾU NẠI
                // ==========================================
                don.TrangThai = 1; // 1 = Đã Duyệt
                don.PhanHoi = txtPhanHoi.Text.Trim();
                don.DaXem = false;

                // ==========================================
                // GỬI THÔNG BÁO CHO SINH VIÊN
                // ==========================================
                ThongBao tbMoi = new ThongBao()
                {
                    MaNguoiGui = Session.MaNguoiDung,
                    MaNguoiNhan = maSVDangChon,
                    TieuDe = "Đã duyệt khiếu nại môn: " + lblMonHoc.Text.Replace("Môn: ", ""),
                    NoiDung = $"Khiếu nại của bạn đã được chấp nhận. Điểm mới đã được cập nhật thành công (GK: {diemGKMoi}, CK: {diemCKMoi}).\nPhản hồi từ GV: " + txtPhanHoi.Text.Trim(),
                    LoaiThongBao = "KHIEU_NAI",
                    ThamChieuID = maKNDangChon.ToString(),
                    NgayGui = DateTime.Now,
                    DaDoc = false
                };
                context.ThongBaos.Add(tbMoi);

                // ==========================================
                // BƯỚC 6: GHI NHẬT KÝ HOẠT ĐỘNG (AUDIT TRAIL)
                // ==========================================
                NhatKyHoatDong log = new NhatKyHoatDong()
                {
                    NguoiDung = Session.MaNguoiDung, // Mã GV đang thao tác
                    ThoiGian = DateTime.Now,
                    HanhDong = "Chỉnh sửa điểm (Duyệt khiếu nại)",
                    ChiTiet = $"Mã LHP: {maLHPDangChon}\r\nSV {maSVDangChon}: DiemGK: {diemGKCu} -> {diemGKMoi}, DiemCK: {diemCKCu} -> {diemCKMoi}"
                };
                context.NhatKyHoatDong.Add(log);

                // Lưu tất cả thay đổi xuống DB cùng một lúc
                context.SaveChanges();
                MessageBox.Show("Đã cập nhật điểm mới và gửi thông báo thành công cho sinh viên!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset giao diện và load lại danh sách
                ResetForm();
                LoadDanhSachDon();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra: Không tìm thấy kết quả học tập của sinh viên này trong CSDL!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
