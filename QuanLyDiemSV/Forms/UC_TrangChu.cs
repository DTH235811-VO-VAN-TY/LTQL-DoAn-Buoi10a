using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_TrangChu : UserControl
    {

        private FlowLayoutPanel flpThongKe;

        public UC_TrangChu()
        {
            InitializeComponent();
            this.Load += UC_TrangChu_Load;
        }

        private void UC_TrangChu_Load(object sender, EventArgs e)
        {
            // BƯỚC 1: Dừng ngay lập tức nếu đang mở ở chế độ Design (Ngăn lỗi IUIService)
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }
            if (Session.RoleID != 1) return;
            // 1. TẠO FLOWLAYOUTPANEL BẰNG CODE ĐỂ CHỨA CÁC BIỂU ĐỒ
            flpThongKe = new FlowLayoutPanel();
            flpThongKe.Dock = DockStyle.Fill;
            flpThongKe.AutoScroll = true; // Bật thanh cuộn nếu nhiều biểu đồ
            flpThongKe.Padding = new Padding(20);

            // DÙNG MÀU XÁM NHẠT ĐỂ LÀM NỔI BẬT CÁC THẺ BIỂU ĐỒ MÀU TRẮNG
            flpThongKe.BackColor = Color.FromArgb(240, 242, 245);
            flpThongKe.BringToFront();
            grbThongKe.Controls.Add(flpThongKe);


            LoadComboBoxHocKy();

            // Gắn sự kiện cho cboNienKhoa nếu có trên Form
            var cboNienKhoa = this.Controls.Find("cboNienKhoa", true).FirstOrDefault() as ComboBox;
            if (cboNienKhoa != null)
            {
                cboNienKhoa.SelectedIndexChanged += (s, ev) => VeCacBieuDoThongKe();
            }

            // Gắn sự kiện cho dtpLocNam nếu có trên Form
            var dtpLocNam = this.Controls.Find("dtpLocNam", true).FirstOrDefault() as DateTimePicker;
            if (dtpLocNam != null)
            {
                dtpLocNam.Format = DateTimePickerFormat.Custom;
                dtpLocNam.CustomFormat = "yyyy"; // Chỉ hiện năm
                dtpLocNam.ShowUpDown = true;     // Hiện nút tăng giảm thay vì lịch
                
                dtpLocNam.ValueChanged += (s, ev) => 
                {
                    LoadComboBoxHocKy(dtpLocNam.Value.Year);
                };
            }

            // 2. GỌI HÀM VẼ CÁC BIỂU ĐỒ
            VeCacBieuDoThongKe();
        }
        private void LoadComboBoxHocKy(int? yearFilter = null)
        {
            try
            {
                // Hủy đăng ký sự kiện tạm thời để tránh lỗi đệ quy khi gán lại DataSource
                comboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;

                using (var db = new QLDSVDbContext())
                {
                    var query = db.HocKy.AsQueryable();

                    if (yearFilter.HasValue)
                    {
                        // Lọc các học kỳ có NamHocBatDau bằng với năm được chọn
                        query = query.Where(h => h.NamHocBatDau == yearFilter.Value);
                    }

                    var listHK = query.OrderByDescending(h => h.MaHK).ToList();

                    // Gán "0" (chuỗi) thay vì số 0
                    listHK.Insert(0, new HocKy { MaHK = "0", TenHK = "--- Tất cả các kỳ ---" });

                    comboBox1.DataSource = listHK;
                    comboBox1.DisplayMember = "TenHK";
                    comboBox1.ValueMember = "MaHK";
                }

                // Đăng ký lại sự kiện và gọi vẽ biểu đồ
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                VeCacBieuDoThongKe();
            }
            catch { }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeCacBieuDoThongKe();
        }
        private void LoadThongKeTheoBoLoc()
        {
            if (comboBox1.SelectedValue == null) return;

            // Xóa các biểu đồ cũ trong GroupBox trước khi vẽ cái mới
            grbThongKe.Controls.Clear();

            // Nếu bạn có FlowLayoutPanel bên trong grbThongKe thì xóa nó thay vì xóa grb
            // if (flpThongKe != null) flpThongKe.Controls.Clear();

            string selectedMaHK = comboBox1.SelectedValue.ToString();

            using (var db = new QLDSVDbContext())
            {
                // 1. Lấy dữ liệu thô từ bảng Kết quả học tập
                var query = db.KetQuaHocTap.AsNoTracking();

                // 2. Nếu chọn một kỳ cụ thể (khác "0") thì lọc lại
                if (selectedMaHK != "0")
                {
                    query = query.Where(k => k.MaLHPNavigation.MaHK == selectedMaHK);
                }

                // 3. Lấy dữ liệu về bộ nhớ
                var filteredData = query.ToList();

                // 4. GỌI HÀM CỦA TỶ: Truyền danh sách đã lọc vào để vẽ lại biểu đồ
                // (Giả sử hàm VeCacBieuDoThongKe của bạn nhận tham số là List<KetQuaHocTap>)
                VeCacBieuDoThongKe();
            }
        }
        private void VeCacBieuDoThongKe()
        {
            // 1. LẤY GIÁ TRỊ LỌC TRỰC TIẾP TỪ GIAO DIỆN
            string selectedMaHK = "0";
            if (comboBox1.SelectedValue != null)
            {
                selectedMaHK = comboBox1.SelectedValue.ToString();
            }

            string selectedNienKhoa = "ALL";
            var controlNienKhoa = this.Controls.Find("cboNienKhoa", true).FirstOrDefault() as ComboBox;
            if (controlNienKhoa != null && controlNienKhoa.SelectedValue != null)
            {
                selectedNienKhoa = controlNienKhoa.SelectedValue.ToString();
            }
            else if (controlNienKhoa != null && controlNienKhoa.SelectedItem != null)
            {
                // Phòng trường hợp cboNienKhoa không binding DataSource mà add tay Items
                selectedNienKhoa = controlNienKhoa.SelectedItem.ToString(); 
            }

            // Xóa các biểu đồ cũ trong Panel trước khi vẽ mới để tránh chồng lấn
            flpThongKe.Controls.Clear();

            using (var context = new QLDSVDbContext())
            {
                // BƯỚC A: LẤY DỮ LIỆU SINH VIÊN VÀ LỌC THEO NIÊN KHÓA (nếu có)
                var querySV = context.SinhVien
                                     .Include(s => s.MaLopNavigation)
                                     .ThenInclude(l => l.MaNganhNavigation)
                                     .AsQueryable();

                if (selectedNienKhoa != "ALL" && !string.IsNullOrEmpty(selectedNienKhoa) && selectedNienKhoa != "--- Tất cả niên khóa ---")
                {
                    querySV = querySV.Where(s => s.MaLopNavigation.NienKhoa == selectedNienKhoa);
                }

                var listSV = querySV.ToList();

                // BƯỚC B: TRUY VẤN ĐIỂM CÓ LỌC THEO HỌC KỲ
                var queryDiem = context.KetQuaHocTap.AsNoTracking().Where(k => k.DiemTongKet != null);

                if (selectedMaHK != "0")
                {
                    // Lọc theo MaHK của Lớp học phần
                    queryDiem = queryDiem.Where(k => k.MaLHPNavigation.MaHK == selectedMaHK);
                }

                var listDiem = queryDiem.ToList();

                // TÍNH ĐIỂM TRUNG BÌNH (ÉP KIỂU SANG DOUBLE ĐỂ XỬ LÝ)
                var svDiemTB = listSV.Select(s => new
                {
                    MaSV = s.MaSV,
                    MaKhoa = s.MaLopNavigation?.MaNganhNavigation?.MaKhoa?.Trim() ?? "Khác",
                    TenLop = s.MaLopNavigation?.TenLop?.Trim() ?? "Khác",
                    DTB = listDiem.Where(d => d.MaSV == s.MaSV).Any()
                          ? listDiem.Where(d => d.MaSV == s.MaSV).Average(d => (double)d.DiemTongKet!)
                          : 0.0
                }).ToList();

                // ==========================================================
                // BIỂU ĐỒ 1: SỐ LƯỢNG SV THEO KHOA
                // ==========================================================
                var dataBieuDo1 = svDiemTB.GroupBy(x => x.MaKhoa)
                                          .Select(g => new { Khoa = g.Key, SoLuong = g.Count() }).ToList();

                Chart chart1 = TaoKhungBieuDo("SỐ LƯỢNG SINH VIÊN TỪNG KHOA", SeriesChartType.Column, 730, 380);
                Series s1 = chart1.Series[0];
                s1.Color = Color.FromArgb(52, 152, 219);

                if (dataBieuDo1.Count == 0) s1.Points.AddXY("Chưa có dữ liệu", 0);
                else foreach (var item in dataBieuDo1) s1.Points.AddXY(item.Khoa, item.SoLuong);

                flpThongKe.Controls.Add(WrapChartInModernCard(chart1));

                // ==========================================================
                // BIỂU ĐỒ 2: PHÂN BỔ SV GIỎI/XUẤT SẮC
                // ==========================================================
                var svGioi = svDiemTB.Where(x => x.DTB >= 8.0).ToList();
                var dataBieuDo2 = svGioi.GroupBy(x => x.MaKhoa)
                                        .Select(g => new { Khoa = g.Key, SoLuong = g.Count() }).ToList();

                Chart chart2 = TaoKhungBieuDo("PHÂN BỔ SINH VIÊN GIỎI/XUẤT SẮC", SeriesChartType.Doughnut, 730, 380);
                Series s2 = chart2.Series[0];

                if (dataBieuDo2.Count == 0)
                {
                    int pt = s2.Points.AddXY("Chưa có dữ liệu", 1);
                    s2.Points[pt].Color = Color.FromArgb(230, 230, 230);
                    s2.Points[pt].IsValueShownAsLabel = false;
                }
                else
                {
                    foreach (var item in dataBieuDo2)
                    {
                        int pt = s2.Points.AddXY(item.Khoa, item.SoLuong);
                        s2.Points[pt].Label = $"{item.Khoa}\n({item.SoLuong})";
                    }
                }
                chart2.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                chart2.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
                flpThongKe.Controls.Add(WrapChartInModernCard(chart2));

                // ==========================================================
                // BIỂU ĐỒ 3: LỚP CÓ TỶ LỆ GIỎI > 80%
                // ==========================================================
                var dataBieuDo3 = svDiemTB.GroupBy(x => x.TenLop)
                                          .Select(g => new
                                          {
                                              TenLop = g.Key,
                                              TyLeGioi = g.Count() > 0 ? (double)g.Count(x => x.DTB >= 8.0) / g.Count() * 100 : 0
                                          })
                                          .Where(x => x.TyLeGioi >= 80)
                                          .OrderByDescending(x => x.TyLeGioi)
                                          .ToList();

                Chart chart3 = TaoKhungBieuDo("LỚP CÓ TỶ LỆ SV GIỎI > 80%", SeriesChartType.Bar, 730, 380);
                Series s3 = chart3.Series[0];
                s3.Color = Color.FromArgb(46, 204, 113);

                if (dataBieuDo3.Count == 0)
                {
                    s3.Points.AddXY("Chưa có dữ liệu", 0);
                    chart3.Titles[0].Text += "\n(Chưa có lớp nào đạt tiêu chí này)";
                }
                else
                {
                    foreach (var item in dataBieuDo3) s3.Points.AddXY(item.TenLop, Math.Round(item.TyLeGioi, 1));
                }
                flpThongKe.Controls.Add(WrapChartInModernCard(chart3));

                // ==========================================================
                // BIỂU ĐỒ 4: TỶ LỆ KẾT QUẢ ĐẠT / KHÔNG ĐẠT (Pie Chart)
                // ==========================================================
                int soLgDat = svDiemTB.Count(x => x.DTB >= 5.0 && listDiem.Any(d => d.MaSV == x.MaSV)); // Có điểm và >= 5
                int soLgRot = svDiemTB.Count(x => x.DTB < 5.0 && listDiem.Any(d => d.MaSV == x.MaSV));

                Chart chart4 = TaoKhungBieuDo("TỶ LỆ ĐẠT / KHÔNG ĐẠT", SeriesChartType.Pie, 730, 380);
                Series s4 = chart4.Series[0];

                if (soLgDat == 0 && soLgRot == 0)
                {
                    int pt = s4.Points.AddXY("Chưa có dữ liệu", 1);
                    s4.Points[pt].Color = Color.FromArgb(230, 230, 230);
                    s4.Points[pt].IsValueShownAsLabel = false;
                }
                else
                {
                    if (soLgDat > 0)
                    {
                        int ptDat = s4.Points.AddXY("Đạt", soLgDat);
                        s4.Points[ptDat].Color = Color.FromArgb(46, 204, 113); // Xanh lá
                    }
                    if (soLgRot > 0)
                    {
                        int ptRot = s4.Points.AddXY("Không đạt", soLgRot);
                        s4.Points[ptRot].Color = Color.FromArgb(231, 76, 60); // Đỏ
                    }
                }
                chart4.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                chart4.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
                flpThongKe.Controls.Add(WrapChartInModernCard(chart4));

                // ==========================================================
                // BIỂU ĐỒ 5: PHÂN BỐ XẾP LOẠI HỌC LỰC (Column Chart)
                // ==========================================================
                int xuatSac = svDiemTB.Count(x => x.DTB >= 9.0 && listDiem.Any(d => d.MaSV == x.MaSV));
                int gioi = svDiemTB.Count(x => x.DTB >= 8.0 && x.DTB < 9.0 && listDiem.Any(d => d.MaSV == x.MaSV));
                int kha = svDiemTB.Count(x => x.DTB >= 6.5 && x.DTB < 8.0 && listDiem.Any(d => d.MaSV == x.MaSV));
                int trungBinh = svDiemTB.Count(x => x.DTB >= 5.0 && x.DTB < 6.5 && listDiem.Any(d => d.MaSV == x.MaSV));
                int yeu = svDiemTB.Count(x => x.DTB < 5.0 && listDiem.Any(d => d.MaSV == x.MaSV));

                Chart chart5 = TaoKhungBieuDo("THỐNG KÊ XẾP LOẠI HỌC LỰC", SeriesChartType.Column, 730, 380);
                Series s5 = chart5.Series[0];
                
                // Màu sắc cho từng cột
                int pXS = s5.Points.AddXY("Xuất sắc", xuatSac); s5.Points[pXS].Color = Color.FromArgb(155, 89, 182); // Tím
                int pG = s5.Points.AddXY("Giỏi", gioi); s5.Points[pG].Color = Color.FromArgb(52, 152, 219); // Xanh dương
                int pK = s5.Points.AddXY("Khá", kha); s5.Points[pK].Color = Color.FromArgb(241, 196, 15); // Vàng
                int pTB = s5.Points.AddXY("Trung bình", trungBinh); s5.Points[pTB].Color = Color.FromArgb(230, 126, 34); // Cam
                int pY = s5.Points.AddXY("Yếu/Kém", yeu); s5.Points[pY].Color = Color.FromArgb(231, 76, 60); // Đỏ

                flpThongKe.Controls.Add(WrapChartInModernCard(chart5));
            }
        }

        // =========================================================
        // HÀM BỔ TRỢ 1: TẠO KHUNG BIỂU ĐỒ
        // =========================================================
        private Chart TaoKhungBieuDo(string tieuDe, SeriesChartType kieuBieuDo, int chieuRong, int chieuCao)
        {
            Chart chart = new Chart();
            ((System.ComponentModel.ISupportInitialize)(chart)).BeginInit();
            chart.Size = new Size(chieuRong, chieuCao);
            chart.BackColor = Color.White;

            ChartArea area = new ChartArea();
            area.AxisX.MajorGrid.Enabled = false; // Tắt lưới dọc
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230); // Lưới ngang nhạt

            // Nếu là biểu đồ cột/thanh ngang thì không cho chữ ở trục X bị cắt
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            chart.ChartAreas.Add(area);

            Title title = new Title(tieuDe);
            title.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(44, 62, 80);
            chart.Titles.Add(title);

            Series series = new Series("DataSeries");
            series.ChartType = kieuBieuDo;
            series.IsValueShownAsLabel = true; // Hiện con số trên đỉnh cột/mảnh ghép
            series.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Cấu hình Legend (Chú thích) cho biểu đồ tròn
            if (kieuBieuDo == SeriesChartType.Pie || kieuBieuDo == SeriesChartType.Doughnut)
            {
                Legend legend = new Legend();
                legend.Alignment = StringAlignment.Center;
                legend.Docking = Docking.Bottom;
                legend.Font = new Font("Segoe UI", 10F);
                chart.Legends.Add(legend);
            }

            chart.Series.Add(series);
            ((System.ComponentModel.ISupportInitialize)(chart)).EndInit();
            return chart;
        }

        // ==============================================================
        // HÀM BỔ TRỢ 2: TẠO VÁCH NGĂN (CARD) CHUYÊN NGHIỆP
        // ==============================================================
        private Panel WrapChartInModernCard(Chart chart)
        {
            // Xóa Margin của Chart để nó khít vào trong Card
            chart.Margin = new Padding(0);

            // 1. Tạo Hộp chứa (Panel Thẻ)
            Panel pnlCard = new Panel();

            // Tính toán kích thước Thẻ: Kích thước Chart + 30px đệm (15px mỗi bên)
            pnlCard.Size = new Size(chart.Width + 30, chart.Height + 30);
            pnlCard.BackColor = Color.White;
            pnlCard.Padding = new Padding(15);

            // ĐÂY LÀ VÁCH NGĂN: Margin 15px sẽ đẩy các thẻ cách xa nhau ra
            pnlCard.Margin = new Padding(15);

            // Vẽ đường viền tinh tế bao quanh Thẻ
            pnlCard.Paint += (s, e) =>
            {
                Color borderColor = Color.FromArgb(220, 220, 225);
                ControlPaint.DrawBorder(e.Graphics, pnlCard.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
            };

            // Gắn Chart vào Thẻ
            pnlCard.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;

            return pnlCard;
        }
    }
}