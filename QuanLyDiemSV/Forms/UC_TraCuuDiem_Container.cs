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
using System.Threading.Tasks;

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

            // =======================================================
            // BƯỚC 1: KHÓA GIAO DIỆN NẾU NGƯỜI DÙNG LÀ SINH VIÊN
            // =======================================================
            if (Session.RoleID == 3) // 3 là Role của Sinh viên
            {
                txtTuKhoa.Text = Session.MaNguoiDung; // Tự động điền Mã SV của người đang đăng nhập

                txtTuKhoa.Enabled = false; // Khóa ô nhập từ khóa
                cboKhoa.Enabled = false;   // Khóa ô chọn Khoa
                cboLop.Enabled = false;    // Khóa ô chọn Lớp
            }
            else if (Session.RoleID == 2)
            {
                cboKhoa.Enabled = false;
            }

            // PHÂN QUYỀN: Chỉ Admin mới thấy 2 nút báo cáo đặc biệt
            if (Session.RoleID != 1)
            {
                btnBaoCaoSVHB.Visible = false;
                btnBaoCaoSVTN.Visible = false;
            }
            // =======================================================

            //LoadDanhSachSinhVien();

            //// Gán sự kiện sau khi load dữ liệu xong để tránh trigger sớm
            //cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            //cboLop.SelectedIndexChanged += (s, ev) => LoadDanhSachSinhVien();
            //cboLoaiSX.SelectedIndexChanged += (s, ev) => LoadDanhSachSinhVien();
            //radTang.CheckedChanged += (s, ev) => LoadDanhSachSinhVien();
            //radGiam.CheckedChanged += (s, ev) => LoadDanhSachSinhVien();

            dgvDanhSachSV.EnableHeadersVisualStyles = false;
            dgvDanhSachSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDanhSachSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public async Task CapNhatDuLieuMoiNhat()
        {
            using (var freshContext = new QLDSVDbContext())
            {
                var oldKhoa = cboKhoa.SelectedValue;

                var listKhoa = await freshContext.Khoa.AsNoTracking().ToListAsync();
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
            await LoadDanhSachSinhVien();
        }


        private void InitChiTietView()
        {
            if (ucChiTiet == null)
            {
                ucChiTiet = new UC_TraCuu_ChiTiet();
                ucChiTiet.Dock = DockStyle.Fill;
                ucChiTiet.Visible = false;
                ucChiTiet.Visible = false;
                ucChiTiet.QuayLaiTraCuulicked += UcChiTiet_QuayLaiClicked;
                this.Controls.Add(ucChiTiet);
                ucChiTiet.BringToFront();
            }
        }
        
        // Cập nhật lại danh sách sinh viên bên chi tiết (nếu đang hở)
        public async Task CapNhatDuLieuChiTietNeuDangHienAsync()
        {
            if (ucChiTiet != null && ucChiTiet.Visible)
            {
                await ucChiTiet.CapNhatDuLieuMoiNhat();
            }
        }

        private void LoadComboBoxKhoa()
        {
            try
            {
                var listKhoa = context.Khoa.ToList();

                // PHÂN QUYỀN: NẾU LÀ GIẢNG VIÊN THÌ CHỈ TẢI ĐÚNG KHOA CỦA GIẢNG VIÊN ĐÓ
                if (Session.RoleID == 2)
                {
                    var gv = context.GiangVien.FirstOrDefault(g => g.MaGV == Session.MaNguoiDung);
                    if (gv != null)
                    {
                        // Giữ lại duy nhất Khoa mà Giảng viên đang trực thuộc
                        listKhoa = listKhoa.Where(k => k.MaKhoa == gv.MaKhoa).ToList();
                    }
                }
                else if (Session.RoleID == 1) // Nếu là Admin thì mới được quyền xem "Tất cả Khoa"
                {
                    listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "--- Tất cả Khoa ---" });
                }

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

        private async void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue == null) return;

            // 1. KIỂM TRA Ổ KHÓA: Nếu luồng khác đang dùng context thì chặn lại
            if (dangTruyVan) return;
            dangTruyVan = true; // Đóng cửa

            try
            {
                if (cboKhoa.SelectedValue is string maKhoa)
                {
                    List<LopHanhChinh> listLop;

                    // 2. ĐỔI .ToList() ĐỒNG BỘ THÀNH .ToListAsync() BẤT ĐỒNG BỘ
                    if (maKhoa == "ALL")
                    {
                        listLop = await context.LopHanhChinh.ToListAsync();
                    }
                    else
                    {
                        listLop = await context.LopHanhChinh
                                         .Include(l => l.MaNganhNavigation)
                                         .Where(l => l.MaNganhNavigation.MaKhoa == maKhoa)
                                         .ToListAsync();
                    }

                    listLop.Insert(0, new LopHanhChinh { MaLop = "ALL", TenLop = "--- Tất cả Lớp ---" });

                    // 3. GỠ SỰ KIỆN CỦA LỚP RA (Để khi gán DataSource nó không tự động chạy LoadDanhSachSinhVien)
                    cboLop.SelectedIndexChanged -= cboLop_SelectedIndexChanged;

                    cboLop.DataSource = null;
                    cboLop.DisplayMember = "TenLop";
                    cboLop.ValueMember = "MaLop";
                    cboLop.DataSource = listLop;
                    cboLop.SelectedIndex = 0;

                    // 4. Gắn sự kiện lại bình thường
                    cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
                }
            }
            catch { }
            finally
            {
                dangTruyVan = false; // Xử lý xong -> Mở cửa
            }

            // 5. Lúc này mới an toàn để gọi hàm Load lưới
            await LoadDanhSachSinhVien();
        }
        bool dangTruyVan = false;
        private async Task LoadDanhSachSinhVien()
        {
            if (dangTruyVan) return; // Tránh gọi chồng chéo nếu người dùng thay đổi filter quá nhanh
            dangTruyVan = true;

            try
            {
                string maKhoa = cboKhoa.SelectedValue?.ToString();
                string maLop = cboLop.SelectedValue?.ToString();
                string tuKhoa = txtTuKhoa.Text.Trim().ToLower();



                // 1. Lọc danh sách sinh viên theo các ComboBox và Textbox tìm kiếm
                var querySV = context.SinhVien
                    .Include(s => s.MaLopNavigation)
                    .ThenInclude(l => l.MaNganhNavigation)
                    .ThenInclude(n => n.MaKhoaNavigation)
                    .AsQueryable();

                if (Session.RoleID == 3)
                {
                    // Nếu là sinh viên: BỎ QUA mọi điều kiện lọc, ép cứng truy vấn chỉ lấy mã SV này
                    string maSVDangNhap = Session.MaNguoiDung.ToLower();
                    querySV = querySV.Where(s => s.MaSV.ToLower() == maSVDangNhap);
                }
                else if (Session.RoleID == 2)
                {
                    // FIX LAG: Chuyển sang FirstOrDefaultAsync
                    var gv = await context.GiangVien.AsNoTracking().FirstOrDefaultAsync(g => g.MaGV == Session.MaNguoiDung);
                    if (gv != null)
                    {
                        querySV = querySV.Where(s => s.MaLopNavigation.MaNganhNavigation.MaKhoa == gv.MaKhoa);
                    }

                    // Vẫn cho phép Giảng viên tìm kiếm theo Lớp và Từ khóa trong phạm vi Khoa của mình
                    if (!string.IsNullOrEmpty(maLop) && maLop != "ALL")
                        querySV = querySV.Where(s => s.MaLop == maLop);

                    if (!string.IsNullOrEmpty(tuKhoa))
                        querySV = querySV.Where(s => s.MaSV.ToLower().Contains(tuKhoa) || s.HoTen.ToLower().Contains(tuKhoa));
                }
                else
                {
                    if (!string.IsNullOrEmpty(maKhoa) && maKhoa != "ALL")
                        querySV = querySV.Where(s => s.MaLopNavigation.MaNganhNavigation.MaKhoa == maKhoa);

                    if (!string.IsNullOrEmpty(maLop) && maLop != "ALL")
                        querySV = querySV.Where(s => s.MaLop == maLop);

                    if (!string.IsNullOrEmpty(tuKhoa))
                        querySV = querySV.Where(s => s.MaSV.ToLower().Contains(tuKhoa) || s.HoTen.ToLower().Contains(tuKhoa));
                }


                var listSV = await querySV.ToListAsync();

                // Nếu không có SV nào thì làm rỗng lưới và thoát
                if (listSV.Count == 0)
                {
                    dgvDanhSachSV.DataSource = null;
                    return;
                }

                // 2. Lấy TOÀN BỘ ĐIỂM của các sinh viên này từ CSDL (Chỉ lấy môn đã có DiemTongKet)
                var maSVs = listSV.Select(s => s.MaSV).ToList();
                var listDiemQuery = from kq in context.KetQuaHocTap.AsNoTracking()
                                    join lhp in context.LopHocPhan.AsNoTracking() on kq.MaLHP equals lhp.MaLHP
                                    join mh in context.MonHoc.AsNoTracking() on lhp.MaMon equals mh.MaMon
                                    where maSVs.Contains(kq.MaSV) && kq.DiemTongKet != null
                                    select new
                                    {
                                        kq.MaSV,
                                        DiemTongKet = kq.DiemTongKet.Value,
                                        mh.SoTinChi
                                    };

                var listDiem = await listDiemQuery.ToListAsync();

                // 3. Tính toán Điểm Trung Bình Hệ 10 tích lũy cho từng sinh viên
                var listResult = new List<dynamic>();

                foreach (var sv in listSV)
                {
                    var diemCuaSV = listDiem.Where(d => d.MaSV == sv.MaSV).ToList();

                    double tongDiem10 = 0;
                    int tongTinChi = 0;

                    foreach (var d in diemCuaSV)
                    {
                        tongDiem10 += (double)d.DiemTongKet * d.SoTinChi;
                        tongTinChi += d.SoTinChi;
                    }

                    // Trung bình = Tổng (Điểm * Tín chỉ) / Tổng tín chỉ
                    double dtb10 = tongTinChi > 0 ? Math.Round(tongDiem10 / tongTinChi, 2) : 0;

                    listResult.Add(new
                    {
                        MaSV = sv.MaSV,
                        HoTen = sv.HoTen,
                        TenLop = sv.MaLopNavigation?.TenLop,
                        TenKhoa = sv.MaLopNavigation?.MaNganhNavigation?.MaKhoaNavigation?.TenKhoa,
                        DiemTrungBinh = dtb10,
                        SoTinChi = tongTinChi
                    });
                }

                // 4. Xử lý logic sắp xếp (Theo Mã SV hoặc Theo Điểm)
                string kieuSapXep = cboLoaiSX.SelectedItem?.ToString();
                if (kieuSapXep == "Điểm Tích Lũy")
                {
                    if (radTang.Checked) listResult = listResult.OrderBy(x => x.DiemTrungBinh).ToList();
                    else listResult = listResult.OrderByDescending(x => x.DiemTrungBinh).ToList();
                }
                else // Mặc định sắp xếp theo Mã SV
                {
                    if (radTang.Checked) listResult = listResult.OrderBy(x => x.MaSV).ToList();
                    else listResult = listResult.OrderByDescending(x => x.MaSV).ToList();
                }

                // 5. Đổ dữ liệu lên DataGridView
                dgvDanhSachSV.AutoGenerateColumns = false;
                dgvDanhSachSV.DataSource = listResult;
            }
            catch
            {

            }
            finally
            {
                dangTruyVan = false;
            }
        }

        private async void btnXemChitiet_Click(object sender, EventArgs e)
        {
            await XemChiTietSinhVienAsync();
        }

        private async void dgvDanhSachSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (dgvDanhSachSV.Columns[e.ColumnIndex].Name == "ThaoTac" || dgvDanhSachSV.Columns[e.ColumnIndex].Name == "btnXemChiTiet"))
            {
                await XemChiTietSinhVienAsync();
            }
        }

        private async Task XemChiTietSinhVienAsync()
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

            try
            {
                this.Cursor = Cursors.WaitCursor;
                await ucChiTiet.LoadDuLieuChiTietAsync(maSV);
                
                ucChiTiet.Visible = true;
                ucChiTiet.BringToFront();

                groupBox1.Visible = false;
                groupBox2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết sinh viên: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UcChiTiet_QuayLaiClicked(object sender, EventArgs e)
        {
            ucChiTiet.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
        }

        private async void btnTimKiem_Click(object sender, EventArgs e) { await LoadDanhSachSinhVien(); }
        private async void btnReset_Click(object sender, EventArgs e)
        {
            cboKhoa.SelectedIndex = 0;
            txtTuKhoa.Clear();
            await LoadDanhSachSinhVien();
        }

        private async void radTang_CheckedChanged(object sender, EventArgs e)
        {
            await LoadDanhSachSinhVien();
        }

        private async void radGiam_CheckedChanged(object sender, EventArgs e)
        {
            await LoadDanhSachSinhVien();
        }

        private async void cboLoaiSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDanhSachSinhVien();
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
                            // var listData = (List<SinhVienTraCuuDTO>)dgvDanhSachSV.DataSource;
                            // Đổ dữ liệu trực tiếp từ DataGridView
                            int row = 2;
                            for (int i = 0; i < dgvDanhSachSV.Rows.Count; i++)
                            {
                                var gridRow = dgvDanhSachSV.Rows[i];
                                worksheet.Cell(row, 1).Value = gridRow.Cells["MaSV"].Value?.ToString();
                                worksheet.Cell(row, 2).Value = gridRow.Cells["HoTen"].Value?.ToString();
                                worksheet.Cell(row, 3).Value = gridRow.Cells["TenLop"].Value?.ToString();
                                worksheet.Cell(row, 4).Value = gridRow.Cells["TenKhoa"].Value?.ToString();
                                worksheet.Cell(row, 5).Value = gridRow.Cells["DiemTrungBinh"].Value?.ToString();
                                // Lưu ý: Tên cột tín chỉ của bạn trong lưới là SoTinChi, không phải TinChiTichLuy
                                worksheet.Cell(row, 6).Value = gridRow.Cells["SoTinChi"].Value?.ToString();
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
                        // var listData = (List<SinhVienTraCuuDTO>)dgvDanhSachSV.DataSource;
                        // 4.2 Đổ dữ liệu sinh viên vào bảng trực tiếp từ lưới
                        int stt = 1;
                        for (int i = 0; i < dgvDanhSachSV.Rows.Count; i++)
                        {
                            var gridRow = dgvDanhSachSV.Rows[i];

                            AddCellToTable(table, stt.ToString(), fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, gridRow.Cells["MaSV"].Value?.ToString() ?? "", fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, gridRow.Cells["HoTen"].Value?.ToString() ?? "", fontNormal, Element.ALIGN_LEFT);
                            AddCellToTable(table, gridRow.Cells["TenLop"].Value?.ToString() ?? "", fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, gridRow.Cells["DiemTrungBinh"].Value?.ToString() ?? "", fontNormal, Element.ALIGN_CENTER);
                            AddCellToTable(table, gridRow.Cells["SoTinChi"].Value?.ToString() ?? "", fontNormal, Element.ALIGN_CENTER);

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

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trên lưới để in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin Khoa và Lớp đang lọc để truyền sang Form Báo cáo
            string maKhoa = cboKhoa.SelectedValue?.ToString() ?? "ALL";
            string maLop = cboLop.SelectedValue?.ToString() ?? "ALL";

            // Bạn cần tạo một Form mới chứa ReportViewer (VD: FrmBaoCaoDanhSachSV) 
            // Form này sẽ nhận mã Khoa, Lớp để tự động truy vấn và in ra danh sách
            Reports.FrmBaoCaoDanhSachSV frm = new Reports.FrmBaoCaoDanhSachSV(maKhoa, maLop, 0); // 0 = Tất cả
            frm.ShowDialog();
        }

        private void btnBaoCaoSVTN_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trên lưới để in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKhoa = cboKhoa.SelectedValue?.ToString() ?? "ALL";
            string maLop = cboLop.SelectedValue?.ToString() ?? "ALL";

            Reports.FrmBaoCaoDanhSachSV frm = new Reports.FrmBaoCaoDanhSachSV(maKhoa, maLop, 1); // 1 = Tốt nghiệp
            frm.ShowDialog();
        }

        private void btnBaoCaoSVHB_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trên lưới để in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKhoa = cboKhoa.SelectedValue?.ToString() ?? "ALL";
            string maLop = cboLop.SelectedValue?.ToString() ?? "ALL";

            Reports.FrmBaoCaoDanhSachSV frm = new Reports.FrmBaoCaoDanhSachSV(maKhoa, maLop, 2); // 2 = Học bổng
            frm.ShowDialog();
        }

        private async void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDanhSachSinhVien();
        }
    }
}