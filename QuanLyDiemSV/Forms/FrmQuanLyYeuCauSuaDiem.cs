using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmQuanLyYeuCauSuaDiem : Form
    {
        private QLDSVDbContext _context = new QLDSVDbContext();

        public FrmQuanLyYeuCauSuaDiem()
        {
            InitializeComponent();
        }

        private void FrmQuanLyYeuCauSuaDiem_Load(object sender, EventArgs e)
        {
            LoadDanhSachDon();
        }

        private void LoadDanhSachDon()
        {
            var query = _context.YeuCauSuaDiem
                .Include(y => y.GiangVien)
                .Include(y => y.LopHocPhan).ThenInclude(l => l.MaMonNavigation)
                .Where(y => y.TrangThai == 0) // Chỉ lấy đơn chờ duyệt
                .OrderByDescending(y => y.NgayGui)
                .Select(y => new
                {
                    y.MaYC,
                    TenGV = y.GiangVien.HoTen,
                    MonHoc = y.LopHocPhan.MaMonNavigation.TenMon,
                    y.MaLHP,
                    y.LyDo,
                    y.NgayGui
                }).ToList();

            dgvYeuCau.DataSource = query;
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvYeuCau.CurrentRow == null) return;

            dynamic rowData = dgvYeuCau.CurrentRow.DataBoundItem;
            if (rowData == null) return;

            int maYC = rowData.MaYC;
            int maLHP = rowData.MaLHP;

            var confirm = MessageBox.Show("Xác nhận PHÊ DUYỆT yêu cầu này?\nLớp học phần này sẽ được MỞ KHÓA để giảng viên chỉnh sửa.", 
                                        "Xác nhận Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var yeuCau = _context.YeuCauSuaDiem.Find(maYC);
                var lhp = _context.LopHocPhan.Find(maLHP);

                if (yeuCau != null && lhp != null)
                {
                    yeuCau.TrangThai = 1; // Đã duyệt
                    yeuCau.PhanHoiAdmin = "Đã phê duyệt.";
                    
                    lhp.TrangThai = 1; // MỞ KHÓA LỚP

                    _context.NhatKyHoatDong.Add(new NhatKyHoatDong {
                        NguoiDung = Session.Username,
                        ThoiGian = DateTime.Now,
                        HanhDong = "PHÊ DUYỆT MỞ KHÓA ĐIỂM",
                        ChiTiet = $"Admin duyệt đơn {maYC}, mở khóa LHP {maLHP} cho GV {yeuCau.MaGV}"
                    });

                    _context.SaveChanges();
                    MessageBox.Show("Đã duyệt và mở khóa thành công!", "Thành công");
                    LoadDanhSachDon();
                }
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (dgvYeuCau.CurrentRow == null) return;

            dynamic rowData = dgvYeuCau.CurrentRow.DataBoundItem;
            if (rowData == null) return;

            int maYC = rowData.MaYC;

            string phanHoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập lý do từ chối đơn:", "Admin phản hồi", "Lý do không hợp lệ");
            if (string.IsNullOrEmpty(phanHoi)) return;

            var yeuCau = _context.YeuCauSuaDiem.Find(maYC);
            if (yeuCau != null)
            {
                yeuCau.TrangThai = 2; // Từ chối
                yeuCau.PhanHoiAdmin = phanHoi;
                _context.SaveChanges();
                MessageBox.Show("Đã từ chối đơn yêu cầu.");
                LoadDanhSachDon();
            }
        }
    }
}
