using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;
using QuanLyDiemSV.DTO;
using GUI;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_TraCuuDiem_Container : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        UC_TraCuu_ChiTiet ucChiTiet;

        public UC_TraCuuDiem_Container()
        {
            InitializeComponent();
            this.Load += UC_TraCuuDiem_Container_Load;
           
           
        }

        private void UC_TraCuuDiem_Container_Load(object sender, EventArgs e)
        {
            InitChiTietView();
            LoadComboBoxKhoa();
            LoadDanhSachSinhVien();

            // Gán sự kiện sau khi load dữ liệu xong để tránh trigger sớm
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            cboLop.SelectedIndexChanged += (s, ev) => LoadDanhSachSinhVien();
            cboLoaiSX.SelectedIndexChanged += (s, ev) => LoadDanhSachSinhVien();
            radTang.CheckedChanged += (s, ev) => LoadDanhSachSinhVien();
            radGiam.CheckedChanged += (s, ev) => LoadDanhSachSinhVien();
        }
        
        public void CapNhatDuLieuMoiNhat()
        {
            using (var freshContext = new QLDSVDbContext())
            {
                var oldKhoa = cboKhoa.SelectedValue;

                var listKhoa = freshContext.Khoa.AsNoTracking().ToList();
                listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "--- Tất cả Khoa ---" });

                // Tạm thời gỡ sự kiện SelectedIndexChanged để không bị load data 2 lần
                cboKhoa.SelectedIndexChanged -= cboKhoa_SelectedIndexChanged;

                cboKhoa.DataSource = listKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";

                if (oldKhoa != null) cboKhoa.SelectedValue = oldKhoa;

                // Gắn sự kiện lại
                cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            }

            // Tải lại lưới
            context.ChangeTracker.Clear();
            LoadDanhSachSinhVien();
        }


        private void InitChiTietView()
        {
            if (ucChiTiet == null)
            {
                ucChiTiet = new UC_TraCuu_ChiTiet();
                ucChiTiet.Dock = DockStyle.Fill;
                ucChiTiet.Visible = false;
                ucChiTiet.QuayLaiTraCuulicked += UcChiTiet_QuayLaiClicked;
                this.Controls.Add(ucChiTiet);
                ucChiTiet.BringToFront();
            }
        }

        private void LoadComboBoxKhoa()
        {
            try
            {
                var listKhoa = context.Khoa.ToList();
                listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "--- Tất cả Khoa ---" });
                cboKhoa.DataSource = listKhoa;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
                cboKhoa.SelectedIndex = 0;

                cboLoaiSX.Items.Clear();
                cboLoaiSX.Items.AddRange(new string[] { "Mã Sinh Viên", "Họ Tên", "Điểm Tích Lũy" });
                cboLoaiSX.SelectedIndex = 0;
            }
            catch { }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue == null) return;
            // Kiểm tra an toàn xem giá trị có phải chuỗi ID không
            if (cboKhoa.SelectedValue is string maKhoa)
            {
                List<LopHanhChinh> listLop;
                if (maKhoa == "ALL")
                {
                    listLop = context.LopHanhChinh.ToList();
                }
                else
                {
                    listLop = context.LopHanhChinh
                                     .Include(l => l.MaNganhNavigation)
                                     .Where(l => l.MaNganhNavigation.MaKhoa == maKhoa)
                                     .ToList();
                }

                listLop.Insert(0, new LopHanhChinh { MaLop = "ALL", TenLop = "--- Tất cả Lớp ---" });

                cboLop.DataSource = null;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = listLop;
                cboLop.SelectedIndex = 0;

                LoadDanhSachSinhVien();
            }
        }

        private void LoadDanhSachSinhVien()
        {
            // Bỏ qua lỗi lúc đang thiết kế giao diện (Design Mode)
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            try
            {
                var query = context.SinhVien.AsNoTracking()
                    .Include(s => s.MaLopNavigation).ThenInclude(l => l.MaNganhNavigation).ThenInclude(n => n.MaKhoaNavigation)
                    .Include(s => s.KetQuaHocTap).ThenInclude(k => k.MaLHPNavigation).ThenInclude(h => h.MaMonNavigation)
                    .AsQueryable();

                // ==========================================================
                // 1. LỌC THEO PHÂN QUYỀN VÀ TÌM KIẾM
                // ==========================================================
                if (Session.RoleID == 3) // Nếu là Sinh viên
                {
                    // Lấy mã người dùng an toàn, cắt bỏ mọi khoảng trắng
                    string maSVLog = Session.MaNguoiDung;

                    query = query.Where(s => s.MaSV == maSVLog);

                    txtTuKhoa.Visible = false; // Ẩn thanh tìm kiếm

                }
                else // Nếu là Admin hoặc Giảng Viên
                {
                    // Lọc theo Khoa
                    if (cboKhoa.SelectedValue is string maKhoa && maKhoa != "ALL")
                    {
                        query = query.Where(s => s.MaLopNavigation != null &&
                                                 s.MaLopNavigation.MaNganhNavigation != null &&
                                                 s.MaLopNavigation.MaNganhNavigation.MaKhoa == maKhoa);
                    }

                    // Lọc theo Lớp
                    if (cboLop.SelectedValue is string maLop && maLop != "ALL")
                    {
                        query = query.Where(s => s.MaLop == maLop);
                    }

                    // Tìm kiếm theo từ khóa
                    string tuKhoa = txtTuKhoa.Text.Trim();
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        query = query.Where(s => s.MaSV.Contains(tuKhoa) || s.HoTen.Contains(tuKhoa));
                    }
                }

                // ==========================================================
                // 2. LẤY DỮ LIỆU TỪ SQL SERVER LÊN RAM
                // ==========================================================
                var rawList = query.ToList();

                // ==========================================================
                // 3. MAP DỮ LIỆU ĐỂ HIỂN THỊ LÊN LƯỚI
                // ==========================================================
                var listHienThi = rawList.Select(s => new
                {
                    // Các tên biến bên trái (MaSV, HoTen,...) PHẢI KHỚP TUYỆT ĐỐI với DataPropertyName của cột trong DataGridView
                    MaSV = s.MaSV,
                    HoTen = s.HoTen,
                    TenLop = s.MaLopNavigation?.TenLop ?? "Chưa xếp lớp",
                    TenKhoa = s.MaLopNavigation?.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa ?? "Chưa có",

                    // Tính Điểm trung bình hệ 10
                    DiemTrungBinh = s.KetQuaHocTap.Any()
                        ? Math.Round((double)s.KetQuaHocTap.Average(k => (k.DiemGK * 0.4m + k.DiemCK * 0.6m) ?? 0), 2)
                        : 0,

                    // Tính số tín chỉ đã đạt (Điểm tổng kết >= 4.0)
                    SoTinChi = s.KetQuaHocTap
                        .Where(k => (k.DiemGK * 0.4m + k.DiemCK * 0.6m) >= 4)
                        .Sum(k => k.MaLHPNavigation?.MaMonNavigation?.SoTinChi ?? 0)
                }).ToList();

                // ==========================================================
                // 4. SẮP XẾP DỮ LIỆU (Dành cho Admin/Giảng viên)
                // ==========================================================
                if (Session.RoleID != 3 && listHienThi.Count > 0)
                {
                    bool tangDan = radTang.Checked;
                    if (cboLoaiSX.SelectedIndex == 0) // Giả sử Index 0 là Sắp xếp theo Tên
                    {
                        listHienThi = tangDan ? listHienThi.OrderBy(x => x.HoTen).ToList() : listHienThi.OrderByDescending(x => x.HoTen).ToList();
                    }
                    else if (cboLoaiSX.SelectedIndex == 1) // Giả sử Index 1 là Sắp xếp theo Điểm
                    {
                        listHienThi = tangDan ? listHienThi.OrderBy(x => x.DiemTrungBinh).ToList() : listHienThi.OrderByDescending(x => x.DiemTrungBinh).ToList();
                    }
                }
                // ==========================================================
                // 5. GÁN DỮ LIỆU VÀO DATAGRIDVIEW
                // ==========================================================
                dgvDanhSachSV.DataSource = null; // Xóa sạch bộ nhớ tạm của DataGridView để ép tải lại
                dgvDanhSachSV.AutoGenerateColumns = false; // Ngăn DataGridView tự động vẽ thêm cột thừa
                dgvDanhSachSV.DataSource = listHienThi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Cảnh báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemChitiet_Click(object sender, EventArgs e)
        {
            XemChiTietSinhVien();
        }

        private void dgvDanhSachSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (dgvDanhSachSV.Columns[e.ColumnIndex].Name == "ThaoTac" || dgvDanhSachSV.Columns[e.ColumnIndex].Name == "btnXemChiTiet"))
            {
                XemChiTietSinhVien();
            }
        }

        private void XemChiTietSinhVien()
        {
            if (dgvDanhSachSV.CurrentRow == null || dgvDanhSachSV.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cellValue = dgvDanhSachSV.CurrentRow.Cells["MaSV"].Value;
            if (cellValue == null) return;

            string maSV = cellValue.ToString();
            if (ucChiTiet == null) InitChiTietView();

            ucChiTiet.LoadDuLieuChiTiet(maSV);
            ucChiTiet.Visible = true;
            ucChiTiet.BringToFront();

            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void UcChiTiet_QuayLaiClicked(object sender, EventArgs e)
        {
            ucChiTiet.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e) { LoadDanhSachSinhVien(); }
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboKhoa.SelectedIndex = 0;
            txtTuKhoa.Clear();
            LoadDanhSachSinhVien();
        }

        private void radTang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radGiam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboLoaiSX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "TraCuuDiemSinhVien.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("TraCuuDiem");

                            // Tạo Header
                            worksheet.Cell(1, 1).Value = "Mã SV";
                            worksheet.Cell(1, 2).Value = "Họ Tên";
                            worksheet.Cell(1, 3).Value = "Lớp";
                            worksheet.Cell(1, 4).Value = "Khoa";
                            worksheet.Cell(1, 5).Value = "ĐTB Tích Lũy";
                            worksheet.Cell(1, 6).Value = "STC Tích Lũy";

                            // Bôi đậm Header
                            worksheet.Range("A1:F1").Style.Font.Bold = true;
                            worksheet.Range("A1:F1").Style.Fill.BackgroundColor = XLColor.LightGray;

                            // Đổ dữ liệu từ danh sách đang hiển thị (đã được lọc)
                            var listData = (List<SinhVienTraCuuDTO>)dgvDanhSachSV.DataSource;
                            int row = 2;
                            foreach (var sv in listData)
                            {
                                worksheet.Cell(row, 1).Value = sv.MaSV;
                                worksheet.Cell(row, 2).Value = sv.HoTen;
                                worksheet.Cell(row, 3).Value = sv.TenLop;
                                worksheet.Cell(row, 4).Value = sv.TenKhoa;
                                worksheet.Cell(row, 5).Value = sv.DiemTrungBinh;
                                worksheet.Cell(row, 6).Value = sv.TinChiTichLuy;
                                row++;
                            }

                            worksheet.Columns().AdjustToContents();
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

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files|*.pdf", FileName = "BaoCaoDiem_In.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. Cấu hình Font Tiếng Việt (Arial) để PDF không bị lỗi font
                        string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\arial.ttf";
                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font fontItalic = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.ITALIC);

                        // 2. Khởi tạo Document PDF (Khổ A4 xoay ngang: PageSize.A4.Rotate())
                        Document pdfDoc = new Document(PageSize.A4.Rotate(), 30f, 30f, 40f, 40f);
                        PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                        pdfDoc.Open();

                        // --- 3. VIẾT PHẦN HEADER (TIÊU ĐỀ BÁO CÁO) ---
                        Paragraph p1 = new Paragraph("BỘ GIÁO DỤC VÀ ĐÀO TẠO\nTRƯỜNG ĐẠI HỌC ...", fontHeader);
                        p1.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(p1);

                        pdfDoc.Add(new Paragraph("\n")); // Dòng trống

                        Paragraph p2 = new Paragraph("BẢNG TỔNG KẾT ĐIỂM SINH VIÊN", fontTitle);
                        p2.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(p2);

                        // Lấy thông tin lọc hiện tại
                        string tenKhoa = cboKhoa.SelectedIndex > 0 ? cboKhoa.Text : "Tất cả các Khoa";
                        string tenLop = cboLop.SelectedIndex > 0 ? cboLop.Text : "Tất cả các Lớp";

                        Paragraph p3 = new Paragraph($"Khoa: {tenKhoa}  |  Lớp: {tenLop}", fontItalic);
                        p3.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(p3);

                        pdfDoc.Add(new Paragraph("\n\n")); // Dòng trống cách bảng

                        // --- 4. TẠO BẢNG DỮ LIỆU ---
                        PdfPTable table = new PdfPTable(6); // 6 cột
                        table.WidthPercentage = 100;
                        // Chỉnh tỷ lệ độ rộng các cột (STT nhỏ, Tên SV rộng hơn, v.v...)
                        table.SetWidths(new float[] { 1f, 2.5f, 4.5f, 2.5f, 2f, 2f });

                        // 4.1 Tạo Tiêu đề các cột
                        string[] headers = { "STT", "Mã Sinh Viên", "Họ và Tên", "Lớp", "ĐTB Tích Lũy", "Tín Chỉ Đạt" };
                        foreach (string header in headers)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, fontHeader));
                            cell.BackgroundColor = new BaseColor(173, 216, 230); // Màu xanh dương nhạt
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.MinimumHeight = 35f; // Chiều cao hàng tiêu đề
                            table.AddCell(cell);
                        }

                        // 4.2 Đổ dữ liệu sinh viên vào bảng
                        var listData = (List<SinhVienTraCuuDTO>)dgvDanhSachSV.DataSource;
                        int stt = 1;
                        foreach (var sv in listData)
                        {
                            AddCellToTable(table, stt.ToString(), fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, sv.MaSV, fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, sv.HoTen, fontNormal, Element.ALIGN_LEFT); // Tên canh trái
                            AddCellToTable(table, sv.TenLop, fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, sv.DiemTrungBinh.ToString(), fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, sv.TinChiTichLuy.ToString(), fontNormal, Element.ALIGN_CENTER);
                            stt++;
                        }

                        pdfDoc.Add(table);
                        pdfDoc.Close();

                        MessageBox.Show("Xuất file PDF thành công! Hãy mở file lên để xem và in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file: " + ex.Message + "\n(Vui lòng đảm bảo file PDF bạn định lưu không bị mở bởi phần mềm khác)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void AddCellToTable(PdfPTable table, string text, iTextSharp.text.Font font, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.MinimumHeight = 25f; // Khoảng cách dòng dữ liệu

            // Cách lề trái/phải một chút cho chữ đỡ bị dính vào viền kẻ
            cell.PaddingLeft = 5f;
            cell.PaddingRight = 5f;

            table.AddCell(cell);
        }
    }
}