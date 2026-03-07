using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;
using QuanLyDiemSV.DTO;


namespace QuanLyDiemSV.Forms
{
    public partial class UC_TraCuu_ChiTiet : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        public event EventHandler QuayLaiTraCuulicked;

        public UC_TraCuu_ChiTiet()
        {
            InitializeComponent();
        }

        public void LoadDuLieuChiTiet(string maSV)
        {
            // Load thông tin sinh viên
            var sv = context.SinhVien
                .Include(s => s.MaLopNavigation).ThenInclude(l => l.MaNganhNavigation).ThenInclude(n => n.MaKhoaNavigation)
                .FirstOrDefault(s => s.MaSV == maSV);

            if (sv != null)
            {
                lblMaSV.Text = sv.MaSV;
                lblHoTen.Text = sv.HoTen;
                lblLop.Text = sv.MaLopNavigation?.TenLop;
                lblNganh.Text = sv.MaLopNavigation?.MaNganhNavigation?.TenNganh;
                lblKhoa.Text = sv.MaLopNavigation?.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa;

            }

            LoadDiemVaTaoGiaoDien(maSV);
        }

        private void LoadDiemVaTaoGiaoDien(string maSV)
        {
            flowLayoutPanel1.Controls.Clear();

            // 1. Lấy dữ liệu thô
            var listDiemRaw = (from kq in context.KetQuaHocTap
                               join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                               join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                               join hk in context.HocKy on lhp.MaHK equals hk.MaHK
                               where kq.MaSV == maSV
                               select new
                               {
                                   hk.MaHK,
                                   hk.TenHK,
                                   mh.MaMon,
                                   mh.TenMon,
                                   SoTinChi = mh.SoTinChi,
                                   DiemQT = kq.DiemGK ?? 0,
                                   DiemThi = kq.DiemCK ?? 0
                               }).ToList();

            if (listDiemRaw.Count == 0) return;

            // 2. Tính toán điểm
            var listDiemProcessed = listDiemRaw.Select(x =>
            {
                decimal tongKet10 = (x.DiemQT * 0.3m) + (x.DiemThi * 0.7m);
                tongKet10 = Math.Round(tongKet10, 1);

                return new DiemChiTietDTO
                {
                    // STT sẽ gán sau khi Group
                    MaHK = x.MaHK,
                    TenHK = x.TenHK,
                    MaMon = x.MaMon,
                    TenMon = x.TenMon,
                    SoTinChi = x.SoTinChi,
                    DiemQT = x.DiemQT,
                    DiemThi = x.DiemThi,
                    DiemTongKet = tongKet10,
                    DiemHe4 = QuyDoiHe4((double)tongKet10),
                    DiemChu = QuyDoiDiemChu((double)tongKet10)
                };
            }).ToList();

            // 3. Gom nhóm theo Học kỳ
            var groups = listDiemProcessed.GroupBy(x => new { x.MaHK, x.TenHK }).OrderBy(g => g.Key.MaHK);

            foreach (var group in groups)
            {
                // Đánh số STT lại cho từng nhóm
                int stt = 1;
                var listGroup = group.ToList();
                listGroup.ForEach(x => x.STT = stt++);

                // --- TẠO GIAO DIỆN HỌC KỲ ---
                GroupBox gbHocKy = new GroupBox();
                gbHocKy.Text = group.Key.TenHK;
                gbHocKy.Width = flowLayoutPanel1.Width - 40;
                gbHocKy.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                gbHocKy.ForeColor = Color.Blue;

                DataGridView dgv = new DataGridView();
                dgv.BackgroundColor = Color.White;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.RowHeadersVisible = false;
                dgv.Dock = DockStyle.Top;
                dgv.DataSource = listGroup;

                // --- ĐỊNH DẠNG CỘT TIẾNG VIỆT ---
                dgv.AutoGenerateColumns = false;
                ThemCotThuCong(dgv);
                //  DinhDangCotDataGridView(dgv);


                int gridHeight = (listGroup.Count * 30) + 40;
                dgv.Height = gridHeight;

                // Tính toán tổng kết HK
                TinhTongKetHocKy(listGroup, out double dtb10, out double dtb4, out int tcDat, out string xepLoai);

                // Logic: Chỉ xếp loại nếu >= 5 môn
                string strXepLoai = (listGroup.Count >= 5) ? xepLoai : "Chưa đủ môn xếp loại";

                Label lblTongKet = new Label();
                lblTongKet.Text = $"Điểm trung bình học kỳ (Hệ 10): {dtb10}\n" +
                                  $"Điểm trung bình học kỳ (Hệ 4):  {dtb4}\n" +
                                  $"Số tín chỉ đạt được trong HK:   {tcDat}\n" +
                                  $"Phân loại điểm trung bình HK:   {strXepLoai}";
                lblTongKet.Dock = DockStyle.Bottom;
                lblTongKet.ForeColor = Color.Black;
                lblTongKet.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                lblTongKet.AutoSize = false;
                lblTongKet.Height = 100;
                lblTongKet.Padding = new Padding(10, 10, 0, 0);

                gbHocKy.Controls.Add(lblTongKet);
                gbHocKy.Controls.Add(dgv);
                gbHocKy.Height = gridHeight + 130;
                flowLayoutPanel1.Controls.Add(gbHocKy);
            }

            // --- 4. TẠO GROUPBOX TỔNG KẾT TOÀN KHÓA (MỚI) ---
            ThemGroupTongKetToanKhoa(listDiemProcessed);
        }


        private void ThemCotThuCong(DataGridView dgv)
        {
            dgv.Columns.Clear();

            // Helper function để thêm cột nhanh
            void AddCol(string dataPropertyName, string headerText, int width = 0)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = dataPropertyName; // Tên biến trong DTO
                col.HeaderText = headerText;             // Tên hiển thị Tiếng Việt
                if (width > 0) col.Width = width;
                dgv.Columns.Add(col);
            }

            // Chỉ thêm những cột mình muốn hiển thị
            AddCol("STT", "STT", 50);
            AddCol("MaMon", "Mã MH");
            AddCol("TenMon", "Tên Môn Học");
            AddCol("SoTinChi", "Số TC");
            AddCol("DiemQT", "Điểm QT");
            AddCol("DiemThi", "Điểm Thi");
            AddCol("DiemTongKet", "TK (10)");
            AddCol("DiemHe4", "TK (4)");
            AddCol("DiemChu", "Điểm Chữ");
        }

        private void ThemGroupTongKetToanKhoa(List<DiemChiTietDTO> allDiem)
        {
            // Tính toán toàn khóa
            double tongDiem10 = 0;
            double tongDiem4 = 0;
            int tongTinChiDaHoc = 0;
            int tongTinChiDat = 0;

            foreach (var item in allDiem)
            {
                if (item.DiemTongKet != null)
                {
                    double d10 = (double)item.DiemTongKet;
                    double d4 = (double)item.DiemHe4;
                    int tc = item.SoTinChi;

                    tongDiem10 += d10 * tc;
                    tongDiem4 += d4 * tc;
                    tongTinChiDaHoc += tc;

                    if (d10 >= 4.0) tongTinChiDat += tc;
                }
            }

            double tk10 = tongTinChiDaHoc > 0 ? Math.Round(tongDiem10 / tongTinChiDaHoc, 2) : 0;
            double tk4 = tongTinChiDaHoc > 0 ? Math.Round(tongDiem4 / tongTinChiDaHoc, 2) : 0;

            // Xếp loại toàn khóa
            string xepLoai;
            if (tk4 >= 3.6) xepLoai = "Xuất sắc";
            else if (tk4 >= 3.2) xepLoai = "Giỏi";
            else if (tk4 >= 2.5) xepLoai = "Khá";
            else if (tk4 >= 2.0) xepLoai = "Trung bình";
            else xepLoai = "Yếu";

            // Tạo GroupBox Tổng kết
            GroupBox gbTongKet = new GroupBox();
            gbTongKet.Text = "TỔNG KẾT TOÀN KHÓA";
            gbTongKet.Width = flowLayoutPanel1.Width - 40;
            gbTongKet.Height = 160; // Cao hơn xíu
            gbTongKet.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular); // Chữ to hơn
            gbTongKet.ForeColor = Color.DarkRed; // Màu đỏ cho nổi bật

            Label lblNoiDung = new Label();
            lblNoiDung.Text = $"Điểm TB tích lũy (Hệ 10):   {tk10}\n" +
                              $"Điểm TB tích lũy (Hệ 4):    {tk4}\n" +
                              $"Tổng số tín chỉ đã học:     {tongTinChiDaHoc}\n" +
                              $"Tổng số tín chỉ ĐẠT:        {tongTinChiDat}\n" +
                              $"Xếp loại toàn khóa:         {xepLoai}";

            lblNoiDung.Dock = DockStyle.Fill;
            lblNoiDung.Padding = new Padding(10, 10, 0, 0);
            lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
            lblNoiDung.ForeColor = Color.Black;

            gbTongKet.Controls.Add(lblNoiDung);
            flowLayoutPanel1.Controls.Add(gbTongKet);
        }

        // --- CÁC HÀM HỖ TRỢ TÍNH TOÁN ---
        private decimal QuyDoiHe4(double diem10)
        {
            if (diem10 >= 8.5) return 4.0m;
            if (diem10 >= 7.0) return 3.0m;
            if (diem10 >= 5.5) return 2.0m;
            if (diem10 >= 4.0) return 1.0m;
            return 0.0m;
        }

        private string QuyDoiDiemChu(double diem10)
        {
            if (diem10 >= 8.5) return "A";
            if (diem10 >= 7.0) return "B";
            if (diem10 >= 5.5) return "C";
            if (diem10 >= 4.0) return "D";
            return "F";
        }

        private void TinhTongKetHocKy(List<DiemChiTietDTO> list, out double dtb10, out double dtb4, out int tcDat, out string xepLoai)
        {
            double tongDiem10 = 0;
            double tongDiem4 = 0;
            int tongTinChi = 0;
            tcDat = 0;

            foreach (var item in list)
            {
                if (item.DiemTongKet != null)
                {
                    double d10 = (double)item.DiemTongKet;
                    double d4 = (double)item.DiemHe4;
                    int tc = item.SoTinChi;

                    tongDiem10 += d10 * tc;
                    tongDiem4 += d4 * tc;
                    tongTinChi += tc;

                    if (d10 >= 4.0) tcDat += tc;
                }
            }

            dtb10 = tongTinChi > 0 ? Math.Round(tongDiem10 / tongTinChi, 2) : 0;
            dtb4 = tongTinChi > 0 ? Math.Round(tongDiem4 / tongTinChi, 2) : 0;

            if (dtb4 >= 3.6) xepLoai = "Xuất sắc";
            else if (dtb4 >= 3.2) xepLoai = "Giỏi";
            else if (dtb4 >= 2.5) xepLoai = "Khá";
            else if (dtb4 >= 2.0) xepLoai = "Trung bình";
            else xepLoai = "Yếu";
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            QuayLaiTraCuulicked?.Invoke(this, EventArgs.Empty);
        }

        // ==========================================
        // 1. XUẤT FILE EXCEL
        // ==========================================
        private void btnXuat_Click(object sender, EventArgs e)
        {
            string maSV = lblMaSV.Text;
            if (string.IsNullOrEmpty(maSV) || maSV == "...")
            {
                MessageBox.Show("Không có dữ liệu sinh viên để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"BangDiem_{maSV}.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("BangDiemChiTiet");

                            // --- HEADER ---
                            ws.Cell("A1").Value = "BỘ GIÁO DỤC VÀ ĐÀO TẠO";
                            ws.Cell("A2").Value = "TRƯỜNG ĐẠI HỌC ...";
                            ws.Range("A1:C2").Style.Font.Bold = true;
                            ws.Range("A1:C2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell("A4").Value = "BẢNG ĐIỂM CHI TIẾT SINH VIÊN";
                            ws.Range("A4:I4").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            // --- THÔNG TIN SINH VIÊN ---
                            ws.Cell("B6").Value = "Mã SV:"; ws.Cell("C6").Value = lblMaSV.Text;
                            ws.Cell("B7").Value = "Họ Tên:"; ws.Cell("C7").Value = lblHoTen.Text;
                            ws.Cell("B8").Value = "Lớp:"; ws.Cell("C8").Value = lblLop.Text;
                            ws.Cell("F6").Value = "Khoa:"; ws.Cell("G6").Value = lblKhoa.Text;
                            ws.Cell("F7").Value = "Ngành:"; ws.Cell("G7").Value = lblNganh.Text;
                            ws.Range("B6:B8").Style.Font.Bold = true;
                            ws.Range("F6:F7").Style.Font.Bold = true;

                            // --- LẤY DỮ LIỆU ---
                            var listDiemRaw = (from kq in context.KetQuaHocTap
                                               join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                                               join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                                               join hk in context.HocKy on lhp.MaHK equals hk.MaHK
                                               where kq.MaSV == maSV
                                               select new { hk.MaHK, hk.TenHK, mh.MaMon, mh.TenMon, mh.SoTinChi, DiemQT = kq.DiemGK ?? 0, DiemThi = kq.DiemCK ?? 0 }).ToList();

                            var listDiemProcessed = listDiemRaw.Select(x => {
                                decimal tk10 = Math.Round((x.DiemQT * 0.3m) + (x.DiemThi * 0.7m), 1);
                                return new DiemChiTietDTO { MaHK = x.MaHK, TenHK = x.TenHK, MaMon = x.MaMon, TenMon = x.TenMon, SoTinChi = x.SoTinChi, DiemQT = x.DiemQT, DiemThi = x.DiemThi, DiemTongKet = tk10, DiemHe4 = QuyDoiHe4((double)tk10), DiemChu = QuyDoiDiemChu((double)tk10) };
                            }).ToList();

                            int currentRow = 10;
                            var groups = listDiemProcessed.GroupBy(x => new { x.MaHK, x.TenHK }).OrderBy(g => g.Key.MaHK);

                            // --- IN TỪNG HỌC KỲ ---
                            foreach (var group in groups)
                            {
                                ws.Cell(currentRow, 1).Value = group.Key.TenHK;
                                ws.Range(currentRow, 1, currentRow, 9).Merge().Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.LightGray);
                                currentRow++;

                                // Tiêu đề cột
                                string[] headers = { "STT", "Mã Môn", "Tên Môn", "TC", "Đ.QT", "Đ.Thi", "TK(10)", "TK(4)", "Chữ" };
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    ws.Cell(currentRow, i + 1).Value = headers[i];
                                    ws.Cell(currentRow, i + 1).Style.Font.Bold = true;
                                    ws.Cell(currentRow, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                }
                                currentRow++;

                                int stt = 1;
                                var listGroup = group.ToList();
                                foreach (var d in listGroup)
                                {
                                    ws.Cell(currentRow, 1).Value = stt++;
                                    ws.Cell(currentRow, 2).Value = d.MaMon;
                                    ws.Cell(currentRow, 3).Value = d.TenMon;
                                    ws.Cell(currentRow, 4).Value = d.SoTinChi;
                                    ws.Cell(currentRow, 5).Value = d.DiemQT;
                                    ws.Cell(currentRow, 6).Value = d.DiemThi;
                                    ws.Cell(currentRow, 7).Value = d.DiemTongKet;
                                    ws.Cell(currentRow, 8).Value = d.DiemHe4;
                                    ws.Cell(currentRow, 9).Value = d.DiemChu;
                                    ws.Range(currentRow, 1, currentRow, 9).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                    currentRow++;
                                }

                                TinhTongKetHocKy(listGroup, out double dtb10, out double dtb4, out int tcDat, out string xepLoai);
                                ws.Cell(currentRow, 3).Value = $"ĐTB Học kỳ (10): {dtb10}   |   ĐTB (4): {dtb4}   |   STC Đạt: {tcDat}";
                                ws.Range(currentRow, 3, currentRow, 9).Merge().Style.Font.Italic = true;
                                currentRow += 2; // Cách ra 1 dòng
                            }

                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // 2. IN BẢNG ĐIỂM RA PDF
        // ==========================================
        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            string maSV = lblMaSV.Text;
            if (string.IsNullOrEmpty(maSV) || maSV == "...")
            {
                MessageBox.Show("Không có dữ liệu sinh viên để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files|*.pdf", FileName = $"InBangDiem_{maSV}.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\arial.ttf";
                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font fontItalic = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.ITALIC);

                        // Khởi tạo Document PDF (Khổ A4 Dọc)
                        Document pdfDoc = new Document(PageSize.A4, 30f, 30f, 40f, 40f);
                        PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                        pdfDoc.Open();

                        // --- HEADER ---
                        Paragraph p1 = new Paragraph("BỘ GIÁO DỤC VÀ ĐÀO TẠO\nTRƯỜNG ĐẠI HỌC ...", fontHeader);
                        p1.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(p1);
                        pdfDoc.Add(new Paragraph("\n"));

                        Paragraph p2 = new Paragraph("BẢNG ĐIỂM CHI TIẾT SINH VIÊN", fontTitle);
                        p2.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(p2);
                        pdfDoc.Add(new Paragraph("\n"));

                        // --- THÔNG TIN SINH VIÊN ---
                        PdfPTable infoTable = new PdfPTable(2);
                        infoTable.WidthPercentage = 100;
                        infoTable.DefaultCell.Border = 0;
                        infoTable.AddCell(new Phrase($"Mã SV: {lblMaSV.Text}", fontNormal));
                        infoTable.AddCell(new Phrase($"Khoa: {lblKhoa.Text}", fontNormal));
                        infoTable.AddCell(new Phrase($"Họ và Tên: {lblHoTen.Text}", fontNormal));
                        infoTable.AddCell(new Phrase($"Ngành: {lblNganh.Text}", fontNormal));
                        infoTable.AddCell(new Phrase($"Lớp: {lblLop.Text}", fontNormal));
                        infoTable.AddCell(new Phrase($"Cố vấn HT: {lblCVHT.Text}", fontNormal));
                        pdfDoc.Add(infoTable);
                        pdfDoc.Add(new Paragraph("\n"));

                        // --- LẤY DỮ LIỆU ---
                        var listDiemRaw = (from kq in context.KetQuaHocTap
                                           join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                                           join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                                           join hk in context.HocKy on lhp.MaHK equals hk.MaHK
                                           where kq.MaSV == maSV
                                           select new { hk.MaHK, hk.TenHK, mh.MaMon, mh.TenMon, mh.SoTinChi, DiemQT = kq.DiemGK ?? 0, DiemThi = kq.DiemCK ?? 0 }).ToList();

                        var listDiemProcessed = listDiemRaw.Select(x => {
                            decimal tk10 = Math.Round((x.DiemQT * 0.3m) + (x.DiemThi * 0.7m), 1);
                            return new DiemChiTietDTO { MaHK = x.MaHK, TenHK = x.TenHK, MaMon = x.MaMon, TenMon = x.TenMon, SoTinChi = x.SoTinChi, DiemQT = x.DiemQT, DiemThi = x.DiemThi, DiemTongKet = tk10, DiemHe4 = QuyDoiHe4((double)tk10), DiemChu = QuyDoiDiemChu((double)tk10) };
                        }).ToList();

                        var groups = listDiemProcessed.GroupBy(x => new { x.MaHK, x.TenHK }).OrderBy(g => g.Key.MaHK);

                        // --- TẠO BẢNG ĐIỂM ---
                        PdfPTable table = new PdfPTable(9); // 9 cột
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 1f, 2f, 5f, 1f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f });

                        string[] headers = { "STT", "Mã Môn", "Tên Môn", "TC", "Đ.QT", "Đ.Thi", "TK(10)", "TK(4)", "Chữ" };
                        foreach (string header in headers)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, fontHeader));
                            cell.BackgroundColor = new BaseColor(230, 230, 230);
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell);
                        }

                        // --- IN TỪNG HỌC KỲ VÀO BẢNG ---
                        foreach (var group in groups)
                        {
                            // Dòng tên học kỳ
                            PdfPCell hkCell = new PdfPCell(new Phrase(group.Key.TenHK, fontHeader));
                            hkCell.Colspan = 9;
                            hkCell.BackgroundColor = new BaseColor(245, 245, 245);
                            table.AddCell(hkCell);

                            int stt = 1;
                            var listGroup = group.ToList();
                            foreach (var d in listGroup)
                            {
                                AddCellToPdfTable(table, stt++.ToString(), fontNormal, Element.ALIGN_CENTER);
                                AddCellToPdfTable(table, d.MaMon, fontNormal, Element.ALIGN_CENTER);
                                AddCellToPdfTable(table, d.TenMon, fontNormal, Element.ALIGN_LEFT);
                                AddCellToPdfTable(table, d.SoTinChi.ToString(), fontNormal, Element.ALIGN_CENTER);
                                AddCellToPdfTable(table, d.DiemQT.ToString(), fontNormal, Element.ALIGN_CENTER);
                                AddCellToPdfTable(table, d.DiemThi.ToString(), fontNormal, Element.ALIGN_CENTER);
                                AddCellToPdfTable(table, d.DiemTongKet.ToString(), fontNormal, Element.ALIGN_CENTER);
                                AddCellToPdfTable(table, d.DiemHe4.ToString(), fontNormal, Element.ALIGN_CENTER);
                                AddCellToPdfTable(table, d.DiemChu, fontNormal, Element.ALIGN_CENTER);
                            }

                            // Dòng tổng kết học kỳ
                            TinhTongKetHocKy(listGroup, out double dtb10, out double dtb4, out int tcDat, out string xepLoai);
                            PdfPCell sumCell = new PdfPCell(new Phrase($"ĐTB Học kỳ (Hệ 10): {dtb10}   |   ĐTB (Hệ 4): {dtb4}   |   STC Đạt: {tcDat}", fontItalic));
                            sumCell.Colspan = 9;
                            sumCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            table.AddCell(sumCell);
                        }

                        pdfDoc.Add(table);
                        pdfDoc.Close();

                        MessageBox.Show("Đã xuất bảng điểm PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Hàm hỗ trợ vẽ ô PDF
        private void AddCellToPdfTable(PdfPTable table, string text, iTextSharp.text.Font font, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.PaddingBottom = 5f;
            table.AddCell(cell);
        }
    }
}