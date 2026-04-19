using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyDiemSV.Data;
using QuanLyDiemSV.DTO;

namespace QuanLyDiemSV.Reports
{
    public partial class FrmBaoCaoDanhSachSV : Form
    {
        private string _maKhoa;
        private string _maLop;
        private int _loaiBaoCao;

        // loaiBaoCao: 0 = Tất cả, 1 = Tốt nghiệp, 2 = Học bổng
        public FrmBaoCaoDanhSachSV(string maKhoa, string maLop, int loaiBaoCao = 0)
        {
            InitializeComponent();
            _maKhoa = maKhoa;
            _maLop = maLop;
            _loaiBaoCao = loaiBaoCao;
        }

        private void FrmBaoCaoDanhSachSV_Load(object sender, EventArgs e)
        {
            if (_loaiBaoCao == 1) this.Text = "Báo Cáo Danh Sách Sinh Viên Đủ Điều Kiện Tốt Nghiệp";
            else if (_loaiBaoCao == 2) this.Text = "Báo Cáo Danh Sách Sinh Viên Nhận Học Bổng";

            // Chỉ hiển thị bộ lọc Học Kỳ khi là báo cáo Học Bổng
            label4.Visible = (_loaiBaoCao == 2);
            cboHocKy.Visible = (_loaiBaoCao == 2);

            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            cboLop.SelectedIndexChanged += (s, ev) => LoadDuLieuBaoCao();
            cboLoaiSX.SelectedIndexChanged += (s, ev) => LoadDuLieuBaoCao();
            radTang.CheckedChanged += (s, ev) => LoadDuLieuBaoCao();
            radGiam.CheckedChanged += (s, ev) => LoadDuLieuBaoCao();
            
            LoadComboBoxKhoa();
            if (_loaiBaoCao == 2) LoadComboBoxHocKy();
            
            LoadDuLieuBaoCao();
        }

        private void LoadComboBoxHocKy()
        {
            using (var context = new QLDSVDbContext())
            {
                var listHocKy = context.HocKy.ToList();
                listHocKy.Insert(0, new HocKy { MaHK = "ALL", TenHK = "--- Tất cả Học Kỳ ---" });

                cboHocKy.SelectedIndexChanged -= cboHocKy_SelectedIndexChanged;
                cboHocKy.DataSource = listHocKy;
                cboHocKy.DisplayMember = "TenHK";
                cboHocKy.ValueMember = "MaHK";
                cboHocKy.SelectedIndex = 0;
                cboHocKy.SelectedIndexChanged += cboHocKy_SelectedIndexChanged;
            }
        }
        private void LoadComboBoxKhoa()
        {
            using (var context = new QLDSVDbContext())
            {
                var listKhoa = context.Khoa.ToList();
                listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "--- Tất cả Khoa ---" });

                cboKhoa.DataSource = listKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";

                // Khởi tạo các item cho cboSapXep (nếu bạn chưa thêm trong giao diện)
                cboLoaiSX.Items.Clear();
                cboLoaiSX.Items.AddRange(new string[] { "Mã Sinh Viên", "Họ Tên", "Điểm Tích Lũy" });
                cboLoaiSX.SelectedIndex = 0;
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue == null) return;
            string maKhoa = cboKhoa.SelectedValue.ToString();

            using (var context = new QLDSVDbContext())
            {
                var listLop = new List<LopHanhChinh>();
                if (maKhoa == "ALL")
                {
                    listLop = context.LopHanhChinh.ToList();
                }
                else
                {
                    listLop = context.LopHanhChinh.Include(l => l.MaNganhNavigation)
                                     .Where(l => l.MaNganhNavigation.MaKhoa == maKhoa).ToList();
                }

                listLop.Insert(0, new LopHanhChinh { MaLop = "ALL", TenLop = "--- Tất cả Lớp ---" });

                // Tạm tắt event để không bị load data 2 lần khi đổi nguồn
                cboLop.SelectedIndexChanged -= (s, ev) => LoadDuLieuBaoCao();

                cboLop.DataSource = listLop;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.SelectedIndex = 0;

                cboLop.SelectedIndexChanged += (s, ev) => LoadDuLieuBaoCao();
            }
            LoadDuLieuBaoCao(); // Tự động load lại báo cáo khi đổi Khoa
        }
        private void LoadDuLieuBaoCao()
        {
            // Tránh lỗi null khi form vừa khởi tạo mà control chưa kịp load xong
            if (cboKhoa.SelectedValue == null || cboLop.SelectedValue == null) return;

            string maKhoa = cboKhoa.SelectedValue.ToString();
            string maLop = cboLop.SelectedValue.ToString();
            string kieuSapXep = cboLoaiSX.SelectedItem?.ToString() ?? "Mã Sinh Viên";
            bool isTang = radTang.Checked;

            using (var context = new QLDSVDbContext())
            {
                // 1. Lọc theo Khoa và Lớp
                var querySV = context.SinhVien
                    .Include(s => s.MaLopNavigation).ThenInclude(l => l.MaNganhNavigation).ThenInclude(n => n.MaKhoaNavigation)
                    .AsQueryable();

                if (maKhoa != "ALL") querySV = querySV.Where(s => s.MaLopNavigation.MaNganhNavigation.MaKhoa == maKhoa);
                if (maLop != "ALL") querySV = querySV.Where(s => s.MaLop == maLop);

                var listSV = querySV.ToList();

                // 2. Lấy dữ liệu điểm và khung chương trình
                var maSVs = listSV.Select(s => s.MaSV).ToList();
                var queryDiem = (from kq in context.KetQuaHocTap.AsNoTracking()
                                join lhp in context.LopHocPhan.AsNoTracking() on kq.MaLHP equals lhp.MaLHP
                                join mh in context.MonHoc.AsNoTracking() on lhp.MaMon equals mh.MaMon
                                where maSVs.Contains(kq.MaSV) && kq.DiemTongKet != null
                                select new { kq.MaSV, DiemTongKet = kq.DiemTongKet.Value, kq.DiemCK, mh.SoTinChi, mh.MaMon, lhp.MaHK }).AsQueryable();

                // Nếu là báo cáo học bổng và có chọn học kỳ, lọc điểm theo học kỳ đó
                if (_loaiBaoCao == 2 && cboHocKy.SelectedValue != null)
                {
                    string maHK = cboHocKy.SelectedValue.ToString();
                    if (maHK != "ALL")
                    {
                        queryDiem = queryDiem.Where(d => d.MaHK == maHK);
                    }
                }

                var listDiem = queryDiem.ToList();

                var khungCTList = context.KhungChuongTrinh.AsNoTracking().Include(k => k.MaMonNavigation).ToList();

                // 3. Tính toán và lưu vào một List Tạm thời (Sử dụng class DTO bạn đã tạo) để chuẩn bị sắp xếp
                List<SinhVienBaoCaoDTO> listTemp = new List<SinhVienBaoCaoDTO>();
                foreach (var sv in listSV)
                {
                    var diemCuaSV = listDiem.Where(d => d.MaSV == sv.MaSV).ToList();
                    double tongDiem10 = 0;
                    double tongDiem4 = 0;
                    int tongTinChi = 0;
                    int tongTCDaDat = 0;

                    foreach (var d in diemCuaSV)
                    {
                        tongDiem10 += (double)d.DiemTongKet * d.SoTinChi;
                        tongTinChi += d.SoTinChi;

                        // Tính điểm hệ 4 để xét tốt nghiệp
                        double d10 = (double)d.DiemTongKet;
                        double d4 = 0;
                        if (d10 >= 8.5) d4 = 4.0;
                        else if (d10 >= 8.0) d4 = 3.5;
                        else if (d10 >= 7.0) d4 = 3.0;
                        else if (d10 >= 6.5) d4 = 2.5;
                        else if (d10 >= 5.5) d4 = 2.0;
                        else if (d10 >= 5.0) d4 = 1.5;
                        else if (d10 >= 4.0) d4 = 1.0;

                        tongDiem4 += d4 * d.SoTinChi;
                        if (d10 >= 4.0) tongTCDaDat += d.SoTinChi;
                    }

                    double gpa4 = tongTinChi > 0 ? Math.Round(tongDiem4 / tongTinChi, 2) : 0;
                    double diemTB10 = tongTinChi > 0 ? Math.Round(tongDiem10 / tongTinChi, 2) : 0;

                    // BỘ LỌC ĐIỀU KIỆN
                    if (_loaiBaoCao == 1) // TỐT NGHIỆP
                    {
                        string maNganh = sv.MaLopNavigation?.MaNganh;
                        var khungSV = khungCTList.Where(k => k.MaNganh == maNganh).ToList();

                        if (khungSV.Count == 0) continue; // Nếu chưa có Khung CT, không thể xét tốt nghiệp

                        bool duDieuKien = true;
                        if (gpa4 < 2.0) duDieuKien = false; // ĐK 1: GPA >= 2.0

                        var dsMonBB = khungSV.Where(k => k.LoaiMon == "Bắt buộc").Select(k => k.MaMon).ToList();

                        // ĐK 2: Không có môn BB bị F
                        if (diemCuaSV.Any(d => dsMonBB.Contains(d.MaMon) && d.DiemTongKet < (decimal)4.0))
                            duDieuKien = false;

                        // ĐK 3: Hoàn thành đủ môn BB
                        var dsMonDaDat = diemCuaSV.Where(d => d.DiemTongKet >= (decimal)4.0).Select(d => d.MaMon).Distinct().ToList();
                        if (dsMonBB.Any(m => !dsMonDaDat.Contains(m)))
                            duDieuKien = false;

                        // ĐK 4: Đủ tín chỉ (Yêu cầu 160 TC)
                        if (tongTCDaDat < 160)
                            duDieuKien = false;

                        if (!duDieuKien) continue; // Bỏ qua SV này
                    }
                    else if (_loaiBaoCao == 2) // HỌC BỔNG
                    {
                        if (diemTB10 < 8.0) continue; // ĐK 1: Điểm tổng kết >= 8.0

                        // ĐK 2: Không có môn nào thi dưới 5
                        if (diemCuaSV.Any(d => d.DiemCK == null || d.DiemCK < 5))
                            continue;

                        // ĐK 3: Tổng số tín chỉ trong kỳ phải >= 15
                        if (tongTinChi < 15)
                            continue;
                    }

                    listTemp.Add(new SinhVienBaoCaoDTO
                    {
                        MaSV = sv.MaSV,
                        HoTen = sv.HoTen,
                        TenLop = sv.MaLopNavigation?.TenLop ?? "",
                        TenKhoa = sv.MaLopNavigation?.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa ?? "",
                        DiemTrungBinh = diemTB10,
                        SoTinChi = tongTinChi
                    });
                }

                // 4. TIẾN HÀNH SẮP XẾP VỚI LINQ
                if (kieuSapXep == "Điểm Tích Lũy")
                {
                    listTemp = isTang ? listTemp.OrderBy(x => x.DiemTrungBinh).ToList() : listTemp.OrderByDescending(x => x.DiemTrungBinh).ToList();
                }
                else if (kieuSapXep == "Họ Tên")
                {
                    listTemp = isTang ? listTemp.OrderBy(x => x.HoTen).ToList() : listTemp.OrderByDescending(x => x.HoTen).ToList();
                }
                else // Sắp xếp theo Mã Sinh Viên
                {
                    listTemp = isTang ? listTemp.OrderBy(x => x.MaSV).ToList() : listTemp.OrderByDescending(x => x.MaSV).ToList();
                }

                // 5. Đổ dữ liệu đã sắp xếp vào DataTable (.xsd) của Report
                DS_DanhSachSV.DanhSachSVDataTable dt = new DS_DanhSachSV.DanhSachSVDataTable();
                int stt = 1;
                foreach (var item in listTemp)
                {
                    dt.AddDanhSachSVRow(
                        stt++.ToString(),
                        item.MaSV,
                        item.HoTen,
                        item.TenLop,
                        item.TenKhoa,
                        item.DiemTrungBinh.ToString(),
                        item.SoTinChi.ToString()
                    );
                }

                // 6. CẤU HÌNH REPORT VIEWER
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSetDanhSachSV";
                reportDataSource.Value = dt;

                reportViewer1.LocalReport.ReportPath = "Reports/rptDanhSachSV.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Truyền Parameter
                string tenKhoaHienThi = cboKhoa.Text;
                string tenLopHienThi = cboLop.Text;

                ReportParameter[] prm = new ReportParameter[2];
                prm[0] = new ReportParameter("prmKhoa", tenKhoaHienThi);
                prm[1] = new ReportParameter("prmLop", tenLopHienThi);
                reportViewer1.LocalReport.SetParameters(prm);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                reportViewer1.RefreshReport();
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDuLieuBaoCao();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboKhoa.SelectedIndex = 0; // Về "Tất cả Khoa"
            LoadDuLieuBaoCao();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDuLieuBaoCao();
        }
    }
}
