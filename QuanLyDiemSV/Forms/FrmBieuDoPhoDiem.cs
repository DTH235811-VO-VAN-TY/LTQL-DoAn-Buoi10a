using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmBieuDoPhoDiem : Form
    {
        private int _maLHP;
        private QLDSVDbContext _context = new QLDSVDbContext();

        public FrmBieuDoPhoDiem(int maLHP)
        {
            InitializeComponent();
            _maLHP = maLHP;
        }

        private void FrmBieuDoPhoDiem_Load(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            var lhp = _context.LopHocPhan.Find(_maLHP);
            if (lhp != null)
            {
                this.Text = $"Biểu đồ phổ điểm - {lhp.TenLopHP}";
            }

            var diemLop = _context.KetQuaHocTap.Where(x => x.MaLHP == _maLHP && x.DiemTongKet != null).ToList();
            if(!diemLop.Any()) 
            {
                MessageBox.Show("Lớp học phần này chưa có dữ liệu điểm để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return; 
            }

            int a = 0, b = 0, c = 0, d = 0, f = 0;
            foreach (var kq in diemLop)
            {
                var xl = DiemService.XepLoaiHe10(kq.DiemTongKet.Value);
                if (xl == "Xuất sắc" || xl == "Giỏi") a++;
                else if (xl == "Khá") b++;
                else if (xl == "Trung bình") c++;
                else if (xl == "Yếu") d++;
                else f++;
            }

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            ChartArea chA = new ChartArea("MainArea");
            chA.BackColor = Color.WhiteSmoke;
            chart.ChartAreas.Add(chA);
            
            // THÊM CHÚ GIẢI (LEGEND)
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 10);
            legend.Title = "Chú giải loại điểm";
            legend.TitleFont = new Font("Segoe UI", 11, FontStyle.Bold);
            chart.Legends.Add(legend);

            Series s = new Series("PhoDiem");
            s.ChartType = SeriesChartType.Pie;
            s.IsValueShownAsLabel = true;
            s.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            s["PieLabelStyle"] = "Outside"; // Đưa nhãn ra ngoài để đỡ rối
            s.Legend = "MainLegend";

            if (a > 0) 
            { 
                var p = s.Points.Add(a);
                p.AxisLabel = $"{Math.Round((double)a/diemLop.Count*100, 1)}%";
                p.LegendText = $"A (Giỏi/Xuất Sắc): {a} SV";
                p.Color = Color.LightSeaGreen; 
            }
            if (b > 0) 
            {
                var p = s.Points.Add(b);
                p.AxisLabel = $"{Math.Round((double)b / diemLop.Count * 100, 1)}%";
                p.LegendText = $"B (Khá): {b} SV";
                p.Color = Color.CornflowerBlue; 
            }
            if (c > 0) 
            {
                var p = s.Points.Add(c);
                p.AxisLabel = $"{Math.Round((double)c / diemLop.Count * 100, 1)}%";
                p.LegendText = $"C (Trung bình): {c} SV";
                p.Color = Color.Gold; 
            }
            if (d > 0) 
            {
                var p = s.Points.Add(d);
                p.AxisLabel = $"{Math.Round((double)d / diemLop.Count * 100, 1)}%";
                p.LegendText = $"D (Yếu/Trung bình yếu): {d} SV";
                p.Color = Color.Orange; 
            }
            if (f > 0) 
            {
                var p = s.Points.Add(f);
                p.AxisLabel = $"{Math.Round((double)f / diemLop.Count * 100, 1)}%";
                p.LegendText = $"F (Kém/Rớt): {f} SV";
                p.Color = Color.IndianRed; 
            }

            chart.Series.Add(s);

            Title title = new Title("PHỔ ĐIỂM KẾT QUẢ HỌC TẬP TỔNG KẾT", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.Black);
            chart.Titles.Add(title);

            this.Controls.Add(chart);
        }
    }
}
