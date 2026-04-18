using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_QuanLyYeuCauSuaDiem : UserControl
    {
        private QLDSVDbContext _context;

        public UC_QuanLyYeuCauSuaDiem()
        {
            InitializeComponent();
            _context = new QLDSVDbContext();
        }

        private void UC_QuanLyYeuCauSuaDiem_Load(object sender, EventArgs e)
        {
            LoadDanhSachYeuCau();
        }

        private void LoadDanhSachYeuCau()
        {
            var query = _context.YeuCauSuaDiem
                .Include(y => y.GiangVien)
                .Include(y => y.LopHocPhan)
                .ThenInclude(l => l.MaMonNavigation)
                .Where(y => y.TrangThai == 0) // Chỉ lấy đơn chưa duyệt
                .OrderByDescending(y => y.NgayGui)
                .Select(y => new
                {
                    y.MaYC,
                    TenGV = y.GiangVien.HoTen,
                    TenMon = y.LopHocPhan.MaMonNavigation.TenMon,
                    y.MaLHP,
                    y.LyDo,
                    y.NgayGui
                }).ToList();

            dgvYeuCau.DataSource = query;
        }

        private async void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvYeuCau.CurrentRow == null) return;

            dynamic rowData = dgvYeuCau.CurrentRow.DataBoundItem;
            if (rowData == null) return;

            int maYC = rowData.MaYC;
            int maLHP = rowData.MaLHP;

            var confirm = MessageBox.Show("Xác nhận PHÊ DUYỆT yêu cầu này?\nLớp học phần này sẽ được MỞ KHÓA để giảng viên chỉnh sửa.", 
                                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (var db = new QLDSVDbContext())
                {
                    var yeuCau = db.YeuCauSuaDiem.Find(maYC);
                    var lhp = db.LopHocPhan.Find(maLHP);

                    if (yeuCau != null && lhp != null)
                    {
                        // 1. Cập nhật đơn
                        yeuCau.TrangThai = 1; // Đã duyệt
                        yeuCau.PhanHoiAdmin = "Đã phê duyệt. Lớp học đã được mở khóa.";

                        // 2. Mở khóa lớp học phần
                        lhp.TrangThai = 1; // 1: Đang nhập liệu (Mở khóa)

                        // 3. Ghi log
                        db.NhatKyHoatDong.Add(new NhatKyHoatDong
                        {
                            NguoiDung = Session.Username,
                            ThoiGian = DateTime.Now,
                            HanhDong = "PHÊ DUYỆT SỬA ĐIỂM",
                            ChiTiet = $"Admin đã duyệt đơn {maYC} và mở khóa sửa điểm cho LHP {maLHP}"
                        });

                        await db.SaveChangesAsync();
                        MessageBox.Show("Đã duyệt yêu cầu và MỞ KHÓA lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachYeuCau();
                    }
                }
            }
        }

        private async void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (dgvYeuCau.CurrentRow == null) return;

            dynamic rowData = dgvYeuCau.CurrentRow.DataBoundItem;
            if (rowData == null) return;

            int maYC = rowData.MaYC;
            
            string phanHoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập lý do từ chối:", "Từ chối yêu cầu", "Lý do không hợp lệ");
            if (string.IsNullOrEmpty(phanHoi)) return;

            using (var db = new QLDSVDbContext())
            {
                var yeuCau = db.YeuCauSuaDiem.Find(maYC);
                if (yeuCau != null)
                {
                    yeuCau.TrangThai = 2; // Từ chối
                    yeuCau.PhanHoiAdmin = phanHoi;

                    await db.SaveChangesAsync();
                    MessageBox.Show("Đã từ chối đơn yêu cầu sửa điểm.", "Thông báo");
                    LoadDanhSachYeuCau();
                }
            }
        }
    }
}
