using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmThongKeNoMon : Form
    {
        private QLDSVDbContext _context = new QLDSVDbContext();

        public FrmThongKeNoMon()
        {
            InitializeComponent();
        }

        private async void FrmThongKeNoMon_Load(object sender, EventArgs e)
        {
            await LoadDuLieu();
        }

        private async Task LoadDuLieu()
        {
            try
            {
                // Lấy tất cả kết quả học tập có điểm
                var ketQua = await _context.KetQuaHocTap
                    .Include(k => k.MaLHPNavigation)
                    .ThenInclude(l => l.MaMonNavigation)
                    .Where(k => k.DiemTongKet != null)
                    .ToListAsync();

                // Gom nhóm theo mã môn và tên môn
                var thongKeMon = ketQua
                    .GroupBy(k => new { k.MaLHPNavigation.MaMon, k.MaLHPNavigation.MaMonNavigation.TenMon })
                    .Select(g => new
                    {
                        g.Key.MaMon,
                        g.Key.TenMon,
                        TongSV = g.Count(),
                        SoSVRot = g.Count(x => x.DiemTongKet < 4.0m)
                    })
                    .Where(x => x.TongSV > 0)
                    .Select(x => new
                    {
                        x.MaMon,
                        x.TenMon,
                        x.TongSV,
                        x.SoSVRot,
                        TyLeRot = Math.Round((decimal)x.SoSVRot / x.TongSV * 100m, 2)
                    })
                    .OrderByDescending(x => x.TyLeRot)
                    .ToList();

                dgvNoMon.DataSource = thongKeMon;
                VeBieuDo(thongKeMon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void VeBieuDo(dynamic data)
        {
            // Lấy Top 10 môn có tỉ lệ rớt cao nhất để vẽ
            var top10 = ((System.Collections.IEnumerable)data).Cast<dynamic>().Take(10).ToList();

            chartNoMon.Series.Clear();
            Series series = new Series("Tỉ Lệ Trượt (%)");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Color = Color.IndianRed;
            series.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            foreach (var item in top10)
            {
                DataPoint p = new DataPoint();
                p.SetValueY((double)item.TyLeRot);
                p.AxisLabel = item.TenMon;
                series.Points.Add(p);
            }

            chartNoMon.Series.Add(series);
            chartNoMon.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartNoMon.ChartAreas[0].AxisX.Interval = 1;
            chartNoMon.Titles.Clear();
            chartNoMon.Titles.Add(new Title("TOP 10 MÔN HỌC CÓ TỈ LỆ TRƯỢT CAO NHẤT", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.Black));
        }
    }
}
