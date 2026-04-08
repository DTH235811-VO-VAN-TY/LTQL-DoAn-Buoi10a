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
                MessageBox.Show("Vui lòng chọn một đơn khiếu nại để duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ======================================================================
            // 1. XỬ LÝ CHUẨN HÓA DẤU CHẤM/PHẨY (Phòng lỗi win tiếng Việt nhập 8.5 ra 85)
            // ======================================================================
            string strGK = txtDiemGKMoi.Text.Trim().Replace(',', '.');
            string strCK = txtDiemCKMoi.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(strGK, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal diemGKMoi) ||
                !decimal.TryParse(strCK, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal diemCKMoi))
            {
                MessageBox.Show("Vui lòng nhập điểm số hợp lệ (VD: 8.5 hoặc 8,5)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (diemGKMoi < 0 || diemGKMoi > 10 || diemCKMoi < 0 || diemCKMoi > 10)
            {
                MessageBox.Show("Điểm số phải nằm trong khoảng từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ======================================================================
                // 2. BÍ QUYẾT: DÙNG MỘT DBCONTEXT MỚI TOANH ĐỂ ÉP LƯU XUỐNG DATABASE
                // ======================================================================
                using (var dbUpdate = new QLDSVDbContext())
                {
                    // A. Lấy đơn khiếu nại
                    var don = dbUpdate.DonKhieuNai
                                      .Include(d => d.MaLHPNavigation) // Lấy LHP để lát lấy tên môn gửi thông báo
                                      .ThenInclude(l => l.MaMonNavigation)
                                      .FirstOrDefault(d => d.MaKN == maKNDangChon);

                    if (don == null) return;

                    // B. Lấy bảng điểm KetQuaHocTap tương ứng của sinh viên đó
                    var kq = dbUpdate.KetQuaHocTap.FirstOrDefault(k => k.MaSV == don.MaSV && k.MaLHP == don.MaLHP);

                    if (kq != null)
                    {
                        // Gán điểm mới
                        kq.DiemGK = diemGKMoi;
                        kq.DiemCK = diemCKMoi;

                        // TÍNH LẠI ĐIỂM TỔNG KẾT BẰNG HÀM CHUẨN (Đã xét cả thi lại, cải thiện)
                        kq.DiemTongKet = TinhDiemTongKetCuoiCung(diemGKMoi, diemCKMoi, kq.DiemThiLan1, kq.DiemThiLan2);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bảng điểm gốc của sinh viên này để cập nhật!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // C. Cập nhật thông tin đơn khiếu nại
                    don.TrangThai = 1; // 1 = Đã duyệt/Chấp nhận
                    don.PhanHoi = txtPhanHoi.Text.Trim();
                    don.DaXem = false;

                    // D. Tạo thông báo mới gửi cho sinh viên
                    string tenMon = don.MaLHPNavigation?.MaMonNavigation?.TenMon ?? "môn học";
                    ThongBao tbMoi = new ThongBao()
                    {
                        MaNguoiGui = Session.MaNguoiDung,
                        MaNguoiNhan = don.MaSV,
                        TieuDe = "Khiếu nại môn " + tenMon + " đã được duyệt",
                        NoiDung = $"Điểm của bạn đã được cập nhật lại. Phản hồi của GV: {don.PhanHoi}",
                        LoaiThongBao = "KHIEU_NAI",
                        ThamChieuID = don.MaKN.ToString(),
                        NgayGui = DateTime.Now,
                        DaDoc = false
                    };
                    dbUpdate.ThongBaos.Add(tbMoi);

                    // E. LƯU TẤT CẢ VÀO SQL SERVER
                    dbUpdate.SaveChanges();
                }

                MessageBox.Show("Đã chốt điểm mới và gửi phản hồi thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới lại danh sách trên giao diện
                LoadDanhSachDon();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
