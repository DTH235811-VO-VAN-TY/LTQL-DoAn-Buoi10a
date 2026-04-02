using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmKhieuNaiDiem : Form
    {
        QLDSVDbContext context = new QLDSVDbContext();
        string maSV;

        // Constructor nhận mã Sinh viên từ màn hình chi tiết truyền sang
        public FrmKhieuNaiDiem(string maSinhVien)
        {
            InitializeComponent();
            this.maSV = maSinhVien;
            this.Load += FrmKhieuNaiDiem_Load;

            // Gắn sự kiện khi chọn môn

        }

        private void FrmKhieuNaiDiem_Load(object sender, EventArgs e)
        {
            // 1. Load thông tin Sinh viên
            var sv = context.SinhVien.FirstOrDefault(x => x.MaSV == maSV);
            if (sv != null)
            {
                lblThongTinSV.Text = $"Sinh viên: {sv.MaSV} - {sv.HoTen}";
            }

            // 2. Load danh sách môn học ĐÃ CÓ ĐIỂM của sinh viên này
            var listMon = (from kq in context.KetQuaHocTap
                           join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                           join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                           where kq.MaSV == maSV && kq.DiemTongKet != null // Chỉ khiếu nại môn đã có tổng kết
                           select new
                           {
                               MaLHP = lhp.MaLHP,
                               // GỘP MÃ MÔN VÀ TÊN MÔN VÀO MỘT BIẾN MỚI
                               TenHienThi = mh.MaMon + " - " + mh.TenMon
                           }).ToList();
            // Tạm tắt sự kiện để không bị lỗi lúc gán DataSource
            cboMonHoc.SelectedIndexChanged -= cboMonHoc_SelectedIndexChanged;

            cboMonHoc.DataSource = listMon;
            // HIỂN THỊ CÁI TÊN ĐÃ ĐƯỢC GỘP LÊN GIAO DIỆN
            cboMonHoc.DisplayMember = "TenHienThi";
            cboMonHoc.ValueMember = "MaLHP";
            cboMonHoc.SelectedIndex = -1; // Để trống lúc đầu

            // Bật lại sự kiện
            cboMonHoc.SelectedIndexChanged += cboMonHoc_SelectedIndexChanged;

            // Xóa trắng các label lúc mới mở Form
            ResetLabels();
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Nếu chưa chọn gì, hoặc dữ liệu đang load dở (chưa ép được về kiểu int) thì thoát ngay để chống lỗi
            if (cboMonHoc.SelectedValue == null || !(cboMonHoc.SelectedValue is int))
            {
                // Reset lại các label cho sạch sẽ khi không có môn nào được chọn
                lblDiemQT.Text = "Điểm Quá Trình:";
                lblDiemCK.Text = "Điểm Cuối Kỳ:";
                lblDiemTK.Text = "Điểm Tổng Kết:";
                return;
            }

            // 2. Lúc này chắc chắn nó là số rồi thì mới ép kiểu
            int maLHP = (int)cboMonHoc.SelectedValue;

            // Truy vấn lấy chi tiết Môn Học, Giảng viên và Điểm số
            var info = (from kq in context.KetQuaHocTap
                        join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                        join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                        // Kết nối lấy tên Giảng viên
                        join gv in context.GiangVien on lhp.MaGV equals gv.MaGV into gvGroup
                        from gv in gvGroup.DefaultIfEmpty()
                        where kq.MaSV == maSV && kq.MaLHP == maLHP
                        select new
                        {
                            MaMon = mh.MaMon,
                            SoTinChi = mh.SoTinChi,
                            Khoa = gv != null ? gv.MaKhoa : "Chưa phân công",
                            TenGV = gv != null ? gv.HoTen : "Chưa phân công",
                            DiemQT = kq.DiemGK,
                            DiemCK = kq.DiemCK,
                            DiemTongKet = kq.DiemTongKet
                        }).FirstOrDefault();

            if (info != null)
            {
                // THÊM TIÊU ĐỀ RÕ RÀNG VÀO TRƯỚC DỮ LIỆU
                lblMaMon.Text = $"Mã môn: {info.MaMon}";
                lblSoTtinChi.Text = $"Số tín chỉ: {info.SoTinChi}";

                // Vì label của bạn tên là lblKhoa, nhưng mình đang truy vấn Giảng Viên, 
                lblKhoa.Text = $"Khoa: {info.Khoa}"; // Hiển thị tên Khoa, nếu chưa phân công thì sẽ hiển thị "Chưa phân công"
                // nên mình đổi chữ hiển thị thành Giảng viên cho hợp lý nhé!
                lblGiangVien.Text = $"Giảng viên: {info.TenGV}";

                // Xử lý điểm (nếu null thì báo "Chưa có")
                string diemQT = info.DiemQT.HasValue ? info.DiemQT.Value.ToString() : "Chưa có";
                string diemCK = info.DiemCK.HasValue ? info.DiemCK.Value.ToString() : "Chưa có";
                string diemTK = info.DiemTongKet.HasValue ? info.DiemTongKet.Value.ToString() : "Chưa có";

                lblDiemQT.Text = $"Điểm quá trình: {diemQT}";
                lblDiemCK.Text = $"Điểm cuối kỳ: {diemCK}";
                lblDiemTK.Text = $"Điểm tổng kết: {diemTK}";
            }
        }
        private void ResetLabels()
        {
            // Đặt lại text mặc định khi chưa chọn môn nào hoặc lúc mới load Form
            lblMaMon.Text = "Mã môn: ...";
            lblSoTtinChi.Text = "Số tín chỉ: ...";
            lblKhoa.Text = "Giảng viên: ...";
            lblDiemQT.Text = "Điểm quá trình: ...";
            lblDiemCK.Text = "Điểm cuối kỳ: ...";
            lblDiemTK.Text = "Điểm tổng kết: ...";
        }

        private void btnGuiThieuNai_Click(object sender, EventArgs e)
        {
            if (cboMonHoc.SelectedIndex < 0 || cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học cần khiếu nại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string lyDo = txtLyDo.Text.Trim();
            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do khiếu nại rõ ràng để Giảng viên xem xét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return;
            }

            try
            {
                int maLHP = (int)cboMonHoc.SelectedValue;

                // Kiểm tra xem môn này đã có đơn khiếu nại đang chờ xử lý chưa (Tránh spam đơn)
                bool daCoDon = context.DonKhieuNai.Any(k => k.MaSV == maSV && k.MaLHP == maLHP && k.TrangThai == 0);
                if (daCoDon)
                {
                    MessageBox.Show("Môn học này đang có đơn khiếu nại chờ xử lý. Vui lòng không gửi trùng lặp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo đơn mới
                DonKhieuNai donMoi = new DonKhieuNai();
                donMoi.MaSV = maSV;
                donMoi.MaLHP = maLHP;
                donMoi.LyDo = lyDo;
                donMoi.NgayGui = DateTime.Now;
                donMoi.TrangThai = 0; // 0 = Chờ xử lý

                context.DonKhieuNai.Add(donMoi);
                context.SaveChanges();

                MessageBox.Show("Gửi đơn khiếu nại thành công! Giảng viên sẽ kiểm tra và phản hồi sớm nhất.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi đơn: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
