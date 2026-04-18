using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_ThongKe : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        Button btnThongKeNoMon;

        public UC_ThongKe()
        {
            InitializeComponent();
            this.Load += UC_ThongKe_Load;
            
            // Khởi tạo nút phân tích nợ môn
            btnThongKeNoMon = new Button();
            btnThongKeNoMon.Text = "Phân Tích Nợ Môn";
            btnThongKeNoMon.Size = new Size(180, 40);
            btnThongKeNoMon.Location = new Point(10, 250); 
            btnThongKeNoMon.BackColor = Color.MediumVioletRed;
            btnThongKeNoMon.ForeColor = Color.White;
            btnThongKeNoMon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThongKeNoMon.Visible = false; // Chỉ hiện cho Admin
            btnThongKeNoMon.Click += BtnThongKeNoMon_Click;
            panel5.Controls.Add(btnThongKeNoMon);

            StyleDataGridView(dgvThongKe);
            StyleButtons();
        }

        private void BtnThongKeNoMon_Click(object sender, EventArgs e)
        {
            using (FrmThongKeNoMon frm = new FrmThongKeNoMon())
            {
                frm.ShowDialog();
            }
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            
            if (Session.RoleID == 1) // Là Admin
            {
                btnThongKeNoMon.Visible = true;
            }

            btnThongKe.PerformClick();// Tự động chạy thống kê khi vừa mở form
            StyleCacPanel();

        }
        private void StyleCacPanel()
        {
            // 1. Panel Tổng Sinh Viên (Màu xanh lam nhạt - Primary)
            panel1.BackColor = Color.FromArgb(52, 152, 219);
            label2.ForeColor = Color.White;     // Chữ "Tổng Số SV"
            lblTongSV.ForeColor = Color.White;  // Con số
            lblTongSV.Font = new Font("Segoe UI", 22F, FontStyle.Bold);

            // 2. Panel Sinh Viên Giỏi (Màu xanh lá cây - Success)
            panel2.BackColor = Color.FromArgb(46, 204, 113);
            label5.ForeColor = Color.White;
            lblSVGioi.ForeColor = Color.White;
            lblSVGioi.Font = new Font("Segoe UI", 22F, FontStyle.Bold);

            // 3. Panel Sinh Viên Rớt (Màu đỏ san hô - Danger)
            panel3.BackColor = Color.FromArgb(231, 76, 60);
            label8.ForeColor = Color.White;
            lblSVRot.ForeColor = Color.White;
            lblSVRot.Font = new Font("Segoe UI", 22F, FontStyle.Bold);

            // 4. Panel Tỷ lệ đạt (Màu tím nhạt - Info)
            panel4.BackColor = Color.FromArgb(243, 156, 18);
            label11.ForeColor = Color.White;
            lblTyLeDat.ForeColor = Color.White;
            lblTyLeDat.Font = new Font("Segoe UI", 22F, FontStyle.Bold);

            // 5. Panel Sinh viên xuất sắc (Màu cam - Info)
            panel6.BackColor = Color.FromArgb(155, 89, 182);
            label13.ForeColor = Color.White;
            lblSVXuatSac.ForeColor = Color.White;
            lblSVXuatSac.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        }
        private void StyleDataGridView(DataGridView dgv)
        {
            try
            {
                // 0. Bật Double Buffering để chống giật lag khi cuộn chuột
                typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
                dgv, new object[] { true });

                // 1. TẮT Visual Styles mặc định của Windows
                dgv.EnableHeadersVisualStyles = false;

                // --- FIX LỖI CRASH: Chặn resizing header khi đang ở chế độ Fill ---
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                // 2. CHỈNH HEADER (Tiêu đề cột)
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); // Xanh dương
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersHeight = 45;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                // 3. CHỈNH DÒNG XEN KẼ (Zebra striping)
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250); // Xám nhạt
                dgv.RowsDefaultCellStyle.BackColor = Color.White;

                // 4. CHỈNH FONT CHỮ VÀ CHIỀU CAO DÒNG
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgv.RowTemplate.Height = 40; // Dòng cao thoáng dễ click

                // 5. CHỈNH DÒNG KHI ĐƯỢC CHỌN (Highlight)
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 230, 241); // Xanh lơ nhạt
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                // 6. CHỈNH VIỀN Ô PHÂN CÁCH (Bảng nét đơn)
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgv.GridColor = Color.FromArgb(200, 200, 200); // Màu đường kẻ xám vừa
            }
            catch { } // Bỏ qua lỗi ngầm nếu có
        }
        private void StyleButtons()
        {
            // Bảng màu Material Design cực đẹp
            Color primaryColor = Color.FromArgb(52, 152, 219);   // Xanh dương (Tìm kiếm, Lọc)
            Color successColor = Color.FromArgb(46, 204, 113);   // Xanh lá (Lưu, Xuất Excel, In)
            Color dangerColor = Color.FromArgb(231, 76, 60);     // Đỏ (Quay lại)
            Color secondaryColor = Color.FromArgb(149, 165, 166); // Xám (Tải lại, Hiện tất cả)

            // Hàm nội bộ để áp dụng giao diện nhanh cho 1 nút
            void ApplyStyle(Button btn, Color bgColor)
            {
                if (btn == null) return;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = bgColor;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;

                // Hiệu ứng Hover (Sáng lên khi rê chuột)
                btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(bgColor);
                btn.MouseLeave += (s, e) => btn.BackColor = bgColor;
            }

            // 1. Áp dụng cho màn hình chọn Lớp
            ApplyStyle(btnThongKe, primaryColor);
            ApplyStyle(btnLamMoi, secondaryColor);
            ApplyStyle(btnXuatExcel, successColor);

        }
        private void LoadComboBoxes()
        {
            // 1. Load Khoa
            var listKhoa = context.Khoa.ToList();
            listKhoa.Insert(0, new Khoa { MaKhoa = "ALL", TenKhoa = "-- Tất cả Khoa --" });
            cboKhoa.DataSource = listKhoa;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";

            // 2. Load Lớp
            var listLop = context.LopHanhChinh.ToList();
            listLop.Insert(0, new LopHanhChinh { MaLop = "ALL", TenLop = "-- Tất cả Lớp --" });
            cboLop.DataSource = listLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            // 3. Load Học Kỳ
            var listHK = context.HocKy.ToList();
            listHK.Insert(0, new HocKy { MaHK = "ALL", TenHK = "-- Tích lũy toàn khóa --" });
            cboHocKy.DataSource = listHK;
            cboHocKy.DisplayMember = "TenHK";
            cboHocKy.ValueMember = "MaHK";

            // 4. Load Điều Kiện Lọc
            var listDieuKien = new List<dynamic>
            {
                new { Value = "ALL", Text = "-- Tất cả sinh viên --" },
                new { Value = "HOCBONG", Text = "Sinh viên có điểm học tập cao nhất (Top 5)" },
                new { Value = "CANHBAO", Text = "Cảnh báo học vụ (GPA Hệ 4 < 2.0)" }
            };
            cboDieuKien.DataSource = listDieuKien;
            cboDieuKien.DisplayMember = "Text";
            cboDieuKien.ValueMember = "Value";
        }

        bool dangTruyVan = false;
        private async void btnThongKe_Click(object sender, EventArgs e)
        {
            if(dangTruyVan) return; // Ngăn chặn việc bấm liên tục khi đang truy vấn
            dangTruyVan = true;

            try
            {
                string maKhoa = cboKhoa.SelectedValue?.ToString();
                string maLop = cboLop.SelectedValue?.ToString();
                string maHK = cboHocKy.SelectedValue?.ToString();
                string dieuKien = cboDieuKien.SelectedValue?.ToString();

                // 1. Lọc danh sách sinh viên ban đầu
                var querySV = context.SinhVien
                                     .Include(s => s.MaLopNavigation)
                                     .ThenInclude(l => l.MaNganhNavigation)
                                     .AsQueryable();

                if (maKhoa != "ALL" && !string.IsNullOrEmpty(maKhoa))
                    querySV = querySV.Where(s => s.MaLopNavigation.MaNganhNavigation.MaKhoa == maKhoa);

                if (maLop != "ALL" && !string.IsNullOrEmpty(maLop))
                    querySV = querySV.Where(s => s.MaLop == maLop);

                var listSV = await querySV.ToListAsync();
                var listResult = new List<ThongKeDTO>();

                // Đặt thời gian chờ tối đa lên 120 giây (2 phút) để SQL xử lý thoải mái
                context.Database.SetCommandTimeout(120);

                // 2. [TỐI ƯU TỐC ĐỘ]: Lấy trước toàn bộ điểm đã có của trường lên RAM 1 lần duy nhất (Rất nhanh do không có điều kiện phức tạp IN)
                var maSVs = listSV.Select(s => s.MaSV).ToList();
                var allDiemFull = await (from kq in context.KetQuaHocTap
                               join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                               join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                               where kq.DiemTongKet != null
                               select new { kq.MaSV, DiemTK = kq.DiemTongKet.Value, mh.SoTinChi, lhp.MaHK, lhp.MaMon }).ToListAsync();

                // Lọc trên RAM thay vì bắt SQL phải thực thi lệnh IN (...) với hàng nghìn sinh viên (gây lỗi Timeout)
                var maSVsHash = new HashSet<string>(maSVs);
                var allDiem = allDiemFull.Where(x => maSVsHash.Contains(x.MaSV)).ToList();

                // 3. Tính điểm cho từng sinh viên
                foreach (var sv in listSV)
                {
                    // Rút trích điểm chỉ của riêng sinh viên này
                    var diemCuaSV = allDiem.Where(d => d.MaSV == sv.MaSV).ToList();

                    // Nếu có chọn Học Kỳ, lọc bỏ các môn học kỳ khác đi
                    if (maHK != "ALL" && !string.IsNullOrEmpty(maHK))
                    {
                        diemCuaSV = diemCuaSV.Where(d => d.MaHK == maHK).ToList();
                    }

                    // QUY CHẾ: Sinh viên học lại (Nhiều lần trong cùng 1 môn học) -> Lấy điểm môn học có kết quả cao nhất
                    var cacMonDaHoc = diemCuaSV.GroupBy(x => x.MaMon).Select(g => new
                    {
                        SoTinChi = g.First().SoTinChi,
                        DiemTK_He10 = g.Max(x => x.DiemTK)
                    }).ToList();

                    decimal diemThongKe = 0;
                    decimal diemThongKeHe4 = 0;

                    if (cacMonDaHoc.Count > 0)
                    {
                        // Tính ĐTB Hệ 10
                        decimal tongDiem10 = cacMonDaHoc.Sum(x => x.DiemTK_He10 * x.SoTinChi);
                        int tongTC = cacMonDaHoc.Sum(x => x.SoTinChi);
                        diemThongKe = Math.Round(tongDiem10 / tongTC, 2);

                        // Tính ĐTB Hệ 4
                        decimal tongDiem4 = cacMonDaHoc.Sum(x => DiemService.QuyDoiHe4(x.DiemTK_He10) * x.SoTinChi);
                        diemThongKeHe4 = Math.Round(tongDiem4 / tongTC, 2);
                    }

                    // --- XỬ LÝ LỌC HỌC BỔNG ---
                    bool coMonRot = cacMonDaHoc.Any(x => x.DiemTK_He10 < 4.0m);
                    if (dieuKien == "HOCBONG")
                    {
                        if (coMonRot || diemThongKe < 7.0m || cacMonDaHoc.Count == 0)
                            continue;
                    }
                    else if (dieuKien == "CANHBAO")
                    {
                        // CẢNH BÁO HỌC VỤ: Lấy sinh viên có GPA Hệ 4 dưới 2.0
                        if (diemThongKeHe4 >= 2.0m || cacMonDaHoc.Count == 0)
                            continue;
                    }

                    listResult.Add(new ThongKeDTO
                    {
                        MaSV = sv.MaSV,
                        HoTen = sv.HoTen,
                        TenLop = sv.MaLopNavigation?.TenLop,
                        DiemTK = diemThongKe,
                        XepLoai = XepLoaiHe10(diemThongKe)
                    });
                }

                // 4. Sắp xếp giảm dần theo điểm
                listResult = listResult.OrderByDescending(x => x.DiemTK).ToList();

                // CHỐT HỌC BỔNG: Chỉ lấy đúng 5 người đứng đầu danh sách
                if (dieuKien == "HOCBONG")
                {
                    listResult = listResult.Take(5).ToList();
                }

                // Đánh số STT cho đẹp
                for (int i = 0; i < listResult.Count; i++) listResult[i].STT = i + 1;

                // 5. Đổ dữ liệu lên Lưới (Grid)
                dgvThongKe.AutoGenerateColumns = false;
                dgvThongKe.DataSource = listResult;

                // 6. Cập nhật 4 thẻ KPI
                int tongSV = listResult.Count;
                int svGioi = listResult.Count(x => x.DiemTK >= 8.0m);
                int svRot = listResult.Count(x => x.DiemTK < 4.0m);
                int svXuatSac = listResult.Count(x => x.XepLoai == "Xuất sắc");
                lblSVXuatSac.Text = svXuatSac.ToString();
                lblTongSV.Text = tongSV.ToString();
                lblSVGioi.Text = svGioi.ToString();
                lblSVRot.Text = svRot.ToString();

                if (tongSV > 0)
                {
                    decimal tyLe = ((decimal)(tongSV - svRot) / tongSV) * 100m;
                    lblTyLeDat.Text = Math.Round(tyLe, 1).ToString() + "%";
                }
                else
                {
                    lblTyLeDat.Text = "0%";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dangTruyVan = false;
            }
        }
        private string XepLoaiHe10(decimal diem10)
        {
            if (diem10 >= 9.0m) return "Xuất sắc";
            if (diem10 >= 8.0m) return "Giỏi";
            if (diem10 >= 7.0m) return "Khá";
            if (diem10 >= 5.0m) return "Trung bình";
            if (diem10 >= 4.0m) return "Yếu"; // Yếu nhưng vẫn qua môn (Điểm D)
            return "Kém (Rớt)";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            if (cboHocKy.Items.Count > 0) cboHocKy.SelectedIndex = 0;
            if (cboDieuKien.Items.Count > 0) cboDieuKien.SelectedIndex = 0;

            btnThongKe.PerformClick();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem lưới có dữ liệu không
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "ThongKe_KetQuaHocTap.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("ThongKe");

                            // 1. Tiêu đề bảng biểu
                            worksheet.Cell(1, 1).Value = "BẢNG THỐNG KÊ KẾT QUẢ HỌC TẬP";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 14;

                            // 2. Thông tin điều kiện lọc
                            worksheet.Cell(2, 1).Value = "Khoa: " + cboKhoa.Text;
                            worksheet.Cell(2, 3).Value = "Lớp: " + cboLop.Text;
                            worksheet.Cell(3, 1).Value = "Học kỳ: " + cboHocKy.Text;
                            worksheet.Cell(3, 3).Value = "Điều kiện: " + cboDieuKien.Text;

                            // 3. In Tiêu đề cột (Header của DataGridView)
                            int startRow = 5;
                            for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                            {
                                worksheet.Cell(startRow, i + 1).Value = dgvThongKe.Columns[i].HeaderText;
                                worksheet.Cell(startRow, i + 1).Style.Font.Bold = true;
                                worksheet.Cell(startRow, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                            }

                            // 4. Đổ dữ liệu từ lưới vào Excel
                            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                                {
                                    var cellValue = dgvThongKe.Rows[i].Cells[j].Value;
                                    worksheet.Cell(startRow + 1 + i, j + 1).Value = cellValue != null ? cellValue.ToString() : "";
                                }
                            }

                            // Căn chỉnh độ rộng cột tự động cho đẹp
                            worksheet.Columns().AdjustToContents();

                            // Lưu file
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file: File có thể đang được mở bởi phần mềm khác.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
    public class ThongKeDTO
    {
        public int STT { get; set; }
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string TenLop { get; set; }
        public decimal DiemTK { get; set; }
        public string XepLoai { get; set; }
    }
}
