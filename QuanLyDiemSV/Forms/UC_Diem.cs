using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;
using QuanLyDiemSV.DTO;

namespace GUI
{
    public partial class UC_Diem : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();

        // Khai báo sự kiện để báo cho Form Cha biết
        public event EventHandler OnBackClicked;

        // Biến lưu trạng thái
        string currentMaSV = "";
        int currentMaKQ = 0;
        bool xuLyThem = false;

        public UC_Diem()
        {
            InitializeComponent();
            this.Load += UC_Diem_Load;

        }

        private void UC_Diem_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadComboBoxMonHoc();
        }

        // Hàm này được Form Cha gọi để truyền Mã SV vào
        public void LoadThongTinSinhVien(string maSV)
        {
            currentMaSV = maSV;

            // 1. Lấy thông tin sinh viên + Lớp + Ngành + Khoa
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
                // lblCVHT.Text = ... (Nếu có logic lấy cố vấn)

                // 2. Tải bảng điểm của sinh viên này
                LoadBangDiemSinhVien(maSV);
            }
        }

        private void LoadBangDiemSinhVien(string maSV)
        {
            try
            {
                var query = from kq in context.KetQuaHocTap
                            join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                            join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                            where kq.MaSV == maSV
                            select new KetQuaHocTapViewModel
                            {
                                MaKQ = kq.MaKQ,
                                MaMon = mh.MaMon,
                                TenMon = mh.TenMon,
                                SoTinChi = mh.SoTinChi,
                                DiemCC = kq.DiemCC,
                                DiemGK = kq.DiemGK,
                                DiemThiLan1 = kq.DiemCK,
                                DiemTongKet = kq.DiemTongKet,
                                DiemChu = kq.DiemChu
                            };

                dgvBangDiem.DataSource = query.ToList();
                SetHeaderBangDiem();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải điểm: " + ex.Message); }
        }

        private void LoadComboBoxMonHoc()
        {
            try
            {
                // Khởi tạo context mới để đảm bảo lấy dữ liệu mới nhất từ DB
                using (var newContext = new QLDSVDbContext())
                {
                    var listLHP = from lhp in newContext.LopHocPhan
                                  join mh in newContext.MonHoc on lhp.MaMon equals mh.MaMon
                                  select new
                                  {
                                      MaLHP = lhp.MaLHP,
                                      HienThi = $"{mh.TenMon} ({lhp.MaLHP})"
                                  };

                    cboMaMon.DataSource = listLHP.ToList();
                    cboMaMon.DisplayMember = "HienThi";
                    cboMaMon.ValueMember = "MaLHP";
                    cboMaMon.SelectedIndex = -1; // Mặc định không chọn
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message);
            }
        }

        private void SetHeaderBangDiem()
        {
            if (dgvBangDiem.Columns["MaMon"] != null) dgvBangDiem.Columns["MaMon"].HeaderText = "Mã Môn";
            if (dgvBangDiem.Columns["TenMon"] != null) dgvBangDiem.Columns["TenMon"].HeaderText = "Tên Môn";
            if (dgvBangDiem.Columns["SoTinChi"] != null) dgvBangDiem.Columns["SoTinChi"].HeaderText = "TC";
            if (dgvBangDiem.Columns["DiemCC"] != null) dgvBangDiem.Columns["DiemCC"].HeaderText = "CC";
            if (dgvBangDiem.Columns["DiemGK"] != null) dgvBangDiem.Columns["DiemGK"].HeaderText = "GK";
            if (dgvBangDiem.Columns["DiemThiLan1"] != null) dgvBangDiem.Columns["DiemThiLan1"].HeaderText = "Thi L1";
            if (dgvBangDiem.Columns["MaKQ"] != null) dgvBangDiem.Columns["MaKQ"].Visible = false;
        }

        // --- CÁC SỰ KIỆN NÚT BẤM ---

        // Nút QUAY LẠI
        private void button5_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện để Form Cha biết mà ẩn Form này đi
            OnBackClicked?.Invoke(this, EventArgs.Empty);
        }

        // Nút THÊM


        private void dgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnAdThem_SV.Enabled)
            {
                DataGridViewRow row = dgvBangDiem.Rows[e.RowIndex];
                currentMaKQ = Convert.ToInt32(row.Cells["MaKQ"].Value);
                txtTenMon.Text = row.Cells["TenMon"].Value?.ToString();
                txtSTC.Text = row.Cells["SoTinChi"].Value?.ToString();
                txtDiemQT.Text = row.Cells["DiemGK"].Value?.ToString();
                txtDiemCK.Text = row.Cells["DiemThiLan1"].Value?.ToString();
            }
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnAdLua_SV.Enabled = giaTri;
            btnAdLamLai_SV.Enabled = giaTri;
            btnAdThem_SV.Enabled = !giaTri;
            btnAdSua_SV.Enabled = !giaTri;
            btnAdXoa_SV.Enabled = !giaTri;

            cboMaMon.Enabled = giaTri;
            txtDiemQT.Enabled = giaTri;
            txtDiemCK.Enabled = giaTri;
        }

        private void ResetInput()
        {
            cboMaMon.SelectedIndex = -1;
            txtTenMon.Clear(); txtSTC.Clear(); txtDiemQT.Clear(); txtDiemCK.Clear();
            currentMaKQ = 0;
        }

        private void btnAdThem_SV_Click(object sender, EventArgs e)
        {
            LoadComboBoxMonHoc();
            xuLyThem = true;
            ResetInput();
            BatTatChucNang(true);
        }

        // Nút SỬA
        private void btnAdSua_SV_Click(object sender, EventArgs e)
        {
            if (currentMaKQ == 0) { MessageBox.Show("Chọn điểm cần sửa!"); return; }
            xuLyThem = false;
            BatTatChucNang(true);
            cboMaMon.Enabled = false; // Khi sửa không cho đổi môn
        }

        // Nút XÓA
        private void btnAdXoa_SV_Click(object sender, EventArgs e)
        {
            if (currentMaKQ == 0) return;
            if (MessageBox.Show("Xóa điểm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var kq = context.KetQuaHocTap.Find(currentMaKQ);
                if (kq != null) { context.KetQuaHocTap.Remove(kq); context.SaveChanges(); }
                LoadBangDiemSinhVien(currentMaSV);
                ResetInput();
            }
        }

        // Nút LƯU
        private void btnAdLua_SV_Click(object sender, EventArgs e)
        {
            if (cboMaMon.SelectedIndex == -1) { MessageBox.Show("Chưa chọn môn!"); return; }

            decimal dGK = 0, dCK = 0;
            decimal.TryParse(txtDiemQT.Text, out dGK);
            decimal.TryParse(txtDiemCK.Text, out dCK);

            if (xuLyThem)
            {
                KetQuaHocTap kq = new KetQuaHocTap();
                kq.MaSV = currentMaSV;
                kq.MaLHP = (int)cboMaMon.SelectedValue;
                kq.DiemGK = dGK;
                kq.DiemCK = dCK;
                context.KetQuaHocTap.Add(kq);
            }
            else
            {
                var kq = context.KetQuaHocTap.Find(currentMaKQ);
                if (kq != null) { kq.DiemGK = dGK; kq.DiemCK = dCK; context.KetQuaHocTap.Update(kq); }
            }
            context.SaveChanges();
            MessageBox.Show("Lưu thành công!");
            LoadBangDiemSinhVien(currentMaSV);
            BatTatChucNang(false);
            ResetInput();
        }

        private void btnAdLamLai_SV_Click(object sender, EventArgs e)
        {
            ResetInput();
            BatTatChucNang(false);
        }
    }
}