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
using Microsoft.Reporting.WinForms;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Reports
{
    public partial class FrmInBangDiem : Form
    {
        private string maSV;

        // Constructor nhận Mã SV từ màn hình trước truyền sang
        public FrmInBangDiem(string maSinhVien)
        {
            InitializeComponent();
            this.maSV = maSinhVien;
            this.Load += FrmInBangDiem_Load;
        }

        private void FrmInBangDiem_Load(object sender, EventArgs e)
        {
            using (var context = new QLDSVDbContext())
            {
                // 1. Lấy thông tin Sinh viên (Gửi vào Parameters)
                var sv = context.SinhVien
                                .Include(s => s.MaLopNavigation)
                                .ThenInclude(l => l.MaNganhNavigation)
                                .ThenInclude(n => n.MaKhoaNavigation)
                                .FirstOrDefault(s => s.MaSV == maSV);

                if (sv == null) return;

                // 2. Lấy dữ liệu Điểm (Gửi vào DataSet)
                var listDiem = (from kq in context.KetQuaHocTap
                                join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                                join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                                join hk in context.HocKy on lhp.MaHK equals hk.MaHK
                                where kq.MaSV == maSV && kq.DiemTongKet != null
                                orderby hk.TenHK, mh.TenMon
                                select new
                                {
                                    HocKy = hk.TenHK,
                                    MaMon = mh.MaMon,
                                    TenMon = mh.TenMon,
                                    SoTC = mh.SoTinChi,
                                    DiemQT = kq.DiemGK,
                                    DiemThi = kq.DiemCK,
                                    DiemTongKet = kq.DiemTongKet,
                                }).ToList();
                // 1. Chỉ lấy những môn đã có điểm tổng kết để tính tích lũy
                var diemDaCoKetQua = listDiem.Where(x => x.DiemTongKet != null).ToList();

                // 2. Tính toán giá trị tích lũy (Ép kiểu double cho chắc chắn)
                double tongDiemHe10 = diemDaCoKetQua.Sum(x => (double)x.DiemTongKet * x.SoTC);
                int tongSoTC = diemDaCoKetQua.Sum(x => x.SoTC);

                double dtbTichLuy = tongSoTC > 0 ? Math.Round(tongDiemHe10 / tongSoTC, 2) : 0;

                ReportParameter[] param = new ReportParameter[]
                {
                    new ReportParameter("pMaSV", sv.MaSV),
                    new ReportParameter("pHoTen", sv.HoTen),
                    new ReportParameter("pLop", sv.MaLopNavigation?.TenLop ?? ""),
                    new ReportParameter("pKhoa", sv.MaLopNavigation?.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa ?? ""),
                    new ReportParameter("pNganh", sv.MaLopNavigation?.MaNganhNavigation?.TenNganh ?? ""),
                    new ReportParameter("pCVHT", sv.MaLopNavigation?.MaGVCN ?? "Chưa phân công"),
                    new ReportParameter("pTongDTB", dtbTichLuy.ToString()),
                    new ReportParameter("pTongSTC", tongSoTC.ToString())
                };

               

                // Tạo DataTable ảo và đổ dữ liệu vào
                DataTable dtDiem = new DataTable();
                dtDiem.Columns.Add("STT", typeof(int));
                dtDiem.Columns.Add("HocKy", typeof(string));
                dtDiem.Columns.Add("MaMon", typeof(string));
                dtDiem.Columns.Add("TenMon", typeof(string));
                dtDiem.Columns.Add("SoTC", typeof(int)); // <--- Ép kiểu Int
                dtDiem.Columns.Add("DiemQT", typeof(string)); // (Hoặc double tuỳ bạn)
                dtDiem.Columns.Add("DiemThi", typeof(string));
                dtDiem.Columns.Add("DiemTongKet", typeof(double)); // <--- Ép kiểu Double

                int stt = 1;
                foreach (var item in listDiem)
                {
                    dtDiem.Rows.Add(stt++, item.HocKy, item.MaMon, item.TenMon, item.SoTC,
                                    item.DiemQT, item.DiemThi, Math.Round((decimal)item.DiemTongKet, 1));
                }

                // 3. Đưa dữ liệu lên Report Viewer
                reportViewer1.LocalReport.ReportPath = "Reports/rptBangDiem.rdlc"; // Chỉnh lại đường dẫn cho đúng thư mục của bạn
                reportViewer1.LocalReport.SetParameters(param);

                ReportDataSource rds = new ReportDataSource("DataSetDiem", dtDiem); // Tên "DataSetDiem" phải khớp với bước thiết kế table
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
        }
    }
}
