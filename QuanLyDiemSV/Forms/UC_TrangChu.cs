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
            comboBox1.SelectedIndexChanged += (s, ev) => VeCacBieuDoThongKe();

            // 2. GỌI HÀM VẼ 3 BIỂU ĐỒ
            VeCacBieuDoThongKe();
        }
        private void LoadComboBoxHocKy()
        {
            try
            {
                using (var db = new QLDSVDbContext())
                {
                    var listHK = db.HocKy.OrderByDescending(h => h.MaHK).ToList();

                    // SỬA TẠI ĐÂY: Gán "0" (chuỗi) thay vì số 0
                    listHK.Insert(0, new HocKy { MaHK = "0", TenHK = "--- Tất cả các kỳ ---" });

                    comboBox1.DataSource = listHK;
                    comboBox1.DisplayMember = "TenHK";
                    comboBox1.ValueMember = "MaHK";
                }
            }
            catch { }
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
        //private void ThucHienThongKe()
        //{
        //    if (comboBox1.SelectedValue == null) return;

        //    // Lấy MaHK dưới dạng chuỗi
        //    string selectedMaHK = comboBox1.SelectedValue.ToString();
        //    flpThongKe.Controls.Clear();

        //    using (var db = new QLDSVDbContext())
        //    {
        //        var query = db.KetQuaHocTap.AsNoTracking();

        //        // So sánh chuỗi "0" với chuỗi "0"
        //        if (selectedMaHK != "0")
        //        {
        //            // So sánh MaHK (String) với selectedMaHK (String)
        //            query = query.Where(k => k.MaLHPNavigation.MaHK == selectedMaHK);
        //        }

        //        var data = query.Select(k => new { k.DiemTongKet }).ToList();

        //        // Xử lý điểm (decimal?) và so sánh với literal decimal (m)
        //        int gioi = data.Count(d => (d.DiemTongKet ?? 0m) >= 8.0m);
        //        int kha = data.Count(d => (d.DiemTongKet ?? 0m) >= 6.5m && (d.DiemTongKet ?? 0m) < 8.0m);
        //        int trungBinh = data.Count(d => (d.DiemTongKet ?? 0m) >= 5.0m && (d.DiemTongKet ?? 0m) < 6.5m);
        //        int yeu = data.Count(d => (d.DiemTongKet ?? 0m) < 5.0m);

        //        // Vẽ biểu đồ học lực (ép kiểu sang double vì Chart yêu cầu double)
        //        Chart chartHocLuc = GenerateBarChart("Phân loại học lực",
        //            new string[] { "Giỏi", "Khá", "Trung bình", "Yêu" },
        //            new double[] { (double)gioi, (double)kha, (double)trungBinh, (double)yeu });

        //        flpThongKe.Controls.Add(WrapChartInModernCard(chartHocLuc));

        //        // Tỷ lệ Đạt/Rớt
        //        int dat = data.Count(d => (d.DiemTongKet ?? 0m) >= 5.0m);
        //        int rot = data.Count(d => (d.DiemTongKet ?? 0m) < 5.0m);

        //        Chart chartTiLe = GeneratePieChart("Tỷ lệ Đạt/Rớt",
        //            new string[] { "Đạt", "Rớt" },
        //            new double[] { (double)dat, (double)rot });

        //        flpThongKe.Controls.Add(WrapChartInModernCard(chartTiLe));
        //    }
        //}


        // =========================================================
        // HÀM CHÍNH: TẢI DỮ LIỆU VÀ VẼ TẤT CẢ BIỂU ĐỒ
        // =========================================================
        //private void VeCacBieuDoThongKe()
        //{
        //    using (var context = new QLDSVDbContext())
        //    {
        //        // BƯỚC A: LẤY TOÀN BỘ DỮ LIỆU LÊN RAM ĐỂ XỬ LÝ (Tránh lỗi EF Core)
        //        var listSV = context.SinhVien
        //                            .Include(s => s.MaLopNavigation)
        //                            .ThenInclude(l => l.MaNganhNavigation)
        //                            .ToList();

        //        var listDiem = context.KetQuaHocTap.Where(k => k.DiemTongKet != null).ToList();

        //        // Tính ĐTB cho từng sinh viên
        //        var svDiemTB = listSV.Select(s => new
        //        {
        //            MaSV = s.MaSV,
        //            MaKhoa = s.MaLopNavigation?.MaNganhNavigation?.MaKhoa?.Trim() ?? "Khác",
        //            TenLop = s.MaLopNavigation?.TenLop?.Trim() ?? "Khác",
        //            DTB = listDiem.Where(d => d.MaSV == s.MaSV).Any()
        //                  ? listDiem.Where(d => d.MaSV == s.MaSV).Average(d => (double)d.DiemTongKet)
        //                  : 0.0
        //        }).ToList();

        //        // ==========================================================
        //        // BƯỚC B: VẼ BIỂU ĐỒ 1 - SỐ LƯỢNG SV THEO KHOA (BIỂU ĐỒ CỘT)
        //        // ==========================================================
        //        var dataBieuDo1 = svDiemTB.GroupBy(x => x.MaKhoa)
        //                                  .Select(g => new { Khoa = g.Key, SoLuong = g.Count() }).ToList();

        //        Chart chart1 = TaoKhungBieuDo("SỐ LƯỢNG SINH VIÊN TỪNG KHOA", SeriesChartType.Column, 500, 380);
        //        Series s1 = chart1.Series[0];
        //        s1.Color = Color.FromArgb(52, 152, 219); // Xanh dương

        //        if (dataBieuDo1.Count == 0)
        //        {
        //            s1.Points.AddXY("Chưa có dữ liệu", 0);
        //        }
        //        else
        //        {
        //            foreach (var item in dataBieuDo1) s1.Points.AddXY(item.Khoa, item.SoLuong);
        //        }
        //        flpThongKe.Controls.Add(WrapChartInModernCard(chart1));


        //        // ==========================================================
        //        // BƯỚC C: VẼ BIỂU ĐỒ 2 - TỶ LỆ SV GIỎI/XUẤT SẮC (BIỂU ĐỒ TRÒN)
        //        // ==========================================================
        //        var svGioi = svDiemTB.Where(x => x.DTB >= 8.0).ToList();
        //        var dataBieuDo2 = svGioi.GroupBy(x => x.MaKhoa)
        //                                .Select(g => new { Khoa = g.Key, SoLuong = g.Count() }).ToList();

        //        Chart chart2 = TaoKhungBieuDo("PHÂN BỔ SINH VIÊN GIỎI/XUẤT SẮC", SeriesChartType.Doughnut, 500, 380);
        //        Series s2 = chart2.Series[0];

        //        // FIX LỖI CRASH Ở ĐÂY: Nếu rỗng thì vẽ một vòng tròn xám
        //        if (dataBieuDo2.Count == 0)
        //        {
        //            int pt = s2.Points.AddXY("Chưa có dữ liệu", 1);
        //            s2.Points[pt].Color = Color.FromArgb(230, 230, 230); // Xám nhạt
        //            s2.Points[pt].IsValueShownAsLabel = false; // Tắt con số 1 đi
        //        }
        //        else
        //        {
        //            foreach (var item in dataBieuDo2)
        //            {
        //                int pt = s2.Points.AddXY(item.Khoa, item.SoLuong);
        //                s2.Points[pt].Label = $"{item.Khoa}\n({item.SoLuong})";
        //            }
        //        }

        //        // Ẩn trục tọa độ cho biểu đồ tròn để nhìn sạch hơn
        //        chart2.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
        //        chart2.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
        //        flpThongKe.Controls.Add(WrapChartInModernCard(chart2));


        //        // ==========================================================
        //        // BƯỚC D: VẼ BIỂU ĐỒ 3 - LỚP CÓ TỶ LỆ GIỎI > 80%
        //        // ==========================================================
        //        var dataBieuDo3 = svDiemTB.GroupBy(x => x.TenLop)
        //                                  .Select(g => new
        //                                  {
        //                                      TenLop = g.Key,
        //                                      TongSV = g.Count(),
        //                                      SVGioi = g.Count(x => x.DTB >= 8.0),
        //                                      TyLeGioi = g.Count() > 0 ? (double)g.Count(x => x.DTB >= 8.0) / g.Count() * 100 : 0
        //                                  })
        //                                  .Where(x => x.TyLeGioi >= 80)
        //                                  .OrderByDescending(x => x.TyLeGioi)
        //                                  .ToList();

        //        Chart chart3 = TaoKhungBieuDo("LỚP CÓ TỶ LỆ SV GIỎI > 80%", SeriesChartType.Bar, 1060, 350);
        //        Series s3 = chart3.Series[0];
        //        s3.Color = Color.FromArgb(46, 204, 113); // Xanh lá

        //        if (dataBieuDo3.Count == 0)
        //        {
        //            s3.Points.AddXY("Chưa có dữ liệu", 0);
        //            chart3.Titles[0].Text += "\n(Chưa có lớp nào đạt tiêu chí này)";
        //            chart3.Titles[0].ForeColor = Color.Gray;
        //        }
        //        else
        //        {
        //            foreach (var item in dataBieuDo3)
        //            {
        //                s3.Points.AddXY(item.TenLop, Math.Round(item.TyLeGioi, 1));
        //            }
        //        }
        //        flpThongKe.Controls.Add(WrapChartInModernCard(chart3));
        //    }
        //}
        private void VeCacBieuDoThongKe()
        {
            // 1. LẤY GIÁ TRỊ LỌC TRỰC TIẾP TỪ GIAO DIỆN
            string selectedMaHK = "0";
            if (comboBox1.SelectedValue != null)
            {
                selectedMaHK = comboBox1.SelectedValue.ToString();
            }

            // Xóa các biểu đồ cũ trong Panel trước khi vẽ mới để tránh chồng lấn
            flpThongKe.Controls.Clear();

            using (var context = new QLDSVDbContext())
            {
                // BƯỚC A: LẤY DỮ LIỆU SINH VIÊN
                var listSV = context.SinhVien
                                    .Include(s => s.MaLopNavigation)
                                    .ThenInclude(l => l.MaNganhNavigation)
                                    .ToList();

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

                Chart chart1 = TaoKhungBieuDo("SỐ LƯỢNG SINH VIÊN TỪNG KHOA", SeriesChartType.Column, 500, 380);
                Series s1 = chart1.Series[0];
                s1.Color = Color.FromArgb(52, 152, 219);

                if (dataBieuDo1.Count == 0) s1.Points.AddXY("Chưa có dữ liệu", 0);
                else foreach (var item in dataBieuDo1) s1.Points.AddXY(item.Khoa, item.SoLuong);

                flpThongKe.Controls.Add(WrapChartInModernCard(chart1));

                // ==========================================================
                // BIỂU ĐỒ 2: PHÂN BỔ SV GIỎI/XUẤT SẮC (SỬA LỖI DECIMAL)
                // ==========================================================
                // Lưu ý dùng 8.0 (double) vì DTB ở trên ta đã ép kiểu về double
                var svGioi = svDiemTB.Where(x => x.DTB >= 8.0).ToList();
                var dataBieuDo2 = svGioi.GroupBy(x => x.MaKhoa)
                                        .Select(g => new { Khoa = g.Key, SoLuong = g.Count() }).ToList();

                Chart chart2 = TaoKhungBieuDo("PHÂN BỔ SINH VIÊN GIỎI/XUẤT SẮC", SeriesChartType.Doughnut, 500, 380);
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

                Chart chart3 = TaoKhungBieuDo("LỚP CÓ TỶ LỆ SV GIỎI > 80%", SeriesChartType.Bar, 1060, 350);
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
        //private Chart GeneratePieChart(string title, string[] labels, double[] values)
        //{
        //    Chart chart = new Chart { Size = new Size(500, 350) };
        //    ChartArea chartArea = new ChartArea();
        //    chart.ChartAreas.Add(chartArea);

        //    Series series = new Series { ChartType = SeriesChartType.Pie };
        //    for (int i = 0; i < labels.Length; i++)
        //    {
        //        series.Points.AddXY(labels[i], values[i]);
        //    }

        //    chart.Series.Add(series);
        //    chart.Titles.Add(title);
        //    chart.Legends.Add(new Legend("Default"));
        //    return chart;
        //}
        //private Chart GenerateBarChart(string title, string[] labels, double[] values)
        //{
        //    Chart chart = new Chart { Size = new Size(500, 350) };
        //    ChartArea chartArea = new ChartArea();
        //    chart.ChartAreas.Add(chartArea);

        //    Series series = new Series { ChartType = SeriesChartType.Column, Name = "SoLuong" };
        //    for (int i = 0; i < labels.Length; i++)
        //    {
        //        int idx = series.Points.AddXY(labels[i], values[i]);
        //        if (labels[i] == "Giỏi") series.Points[idx].Color = Color.LimeGreen;
        //        if (labels[i] == "Yếu") series.Points[idx].Color = Color.Crimson;
        //    }

        //    chart.Series.Add(series);
        //    chart.Titles.Add(title);
        //    return chart;
        //}
    }
}