using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmThongBaoSinhVien : Form
    {
        QLDSVDbContext db = new QLDSVDbContext();

        public FrmThongBaoSinhVien()
        {
            InitializeComponent();

            // Đăng ký sự kiện in đậm dòng chưa đọc
            dgvThongBao.CellFormatting += dgvThongBao_CellFormatting;
        }

        private void FrmThongBaoSinhVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachThongBao();
        }

        private void LoadDanhSachThongBao()
        {
            // Lưu ý: Đảm bảo Session.MaNguoiDung lúc SV đăng nhập đang lưu chuỗi "DTH235801"
            string maSV = Session.MaNguoiDung;

            var dsThongBao = db.ThongBaos
                               .Where(t => t.MaNguoiNhan == maSV)
                               .OrderByDescending(t => t.NgayGui)
                               .Select(t => new
                               {
                                   MaThongBao = t.MaThongBao,
                                   //MaNguoiGui = t.MaNguoiGui,
                                   //MaNguoiNhan = t.MaNguoiNhan,
                                   TieuDe = t.TieuDe,
                                   NoiDung = t.NoiDung,
                                   NgayGui = t.NgayGui,
                                   // Cột này lúc trước bạn bị thiếu
                                   DaDoc = t.DaDoc,
                                   ThamChieuID = t.ThamChieuID,

                                   NguoiGui = db.GiangVien.Where(gv => gv.MaGV == t.MaNguoiGui).Select(gv => gv.HoTen).FirstOrDefault() ?? t.MaNguoiGui,

                                   // TÌM TÊN NGƯỜI NHẬN: Đối chiếu MaNguoiNhan với bảng SinhVien
                                   NguoiNhan = db.SinhVien.Where(sv => sv.MaSV == t.MaNguoiNhan).Select(sv => sv.HoTen).FirstOrDefault() ?? t.MaNguoiNhan
                               })
                               .ToList();

            // Chặn GridView tự động đẻ thêm cột dư thừa
            dgvThongBao.AutoGenerateColumns = false;
            dgvThongBao.DataSource = dsThongBao;
        }

        private void dgvThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThongBao.Rows[e.RowIndex];

                // Hiển thị nội dung chi tiết
                rtbNoiDungChiTiet.Text = row.Cells["NoiDung"].Value?.ToString();

                // Lấy thông tin ID và trạng thái đọc
                int maTB = Convert.ToInt32(row.Cells["MaThongBao"].Value);
                bool daDoc = Convert.ToBoolean(row.Cells["DaDoc"].Value);

                if (!daDoc)
                {
                    DanhDauDaDoc(maTB);
                    row.Cells["DaDoc"].Value = true; // Cập nhật lại UI
                }
            }
        }

        private void DanhDauDaDoc(int maThongBao)
        {
            var thongBao = db.ThongBaos.FirstOrDefault(t => t.MaThongBao == maThongBao);
            if (thongBao != null)
            {
                thongBao.DaDoc = true;
                db.SaveChanges();
            }
        }

        // HÀM MỚI: Tự động in đậm (Bold) các thông báo chưa đọc
        private void dgvThongBao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThongBao.Rows[e.RowIndex];

                // Kiểm tra nếu giá trị DaDoc là false (Chưa đọc)
                if (row.Cells["DaDoc"].Value != null && (bool)row.Cells["DaDoc"].Value == false)
                {
                    // Chữ in đậm và tô màu đen đậm
                    e.CellStyle.Font = new Font(dgvThongBao.Font, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.Black;
                }
                else
                {
                    // Chữ thường mờ hơn cho thông báo đã đọc
                    e.CellStyle.Font = new Font(dgvThongBao.Font, FontStyle.Regular);
                    e.CellStyle.ForeColor = Color.DimGray;
                }
            }
        }
    }
}