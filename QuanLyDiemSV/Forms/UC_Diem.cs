using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyDiemSV.Data;
using GUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;
using QuanLyDiemSV;

namespace GUI
{
    public partial class UC_Diem : UserControl
    {
        QLDSVDbContext context = new QLDSVDbContext();
        BindingSource bsDiem = new BindingSource();
        public event Action OnQuayLai;

        string currentMaSV = "";
        bool xuLyThem = false;
        bool daTaiDuLieu = false;
        public UC_Diem()
        {
            InitializeComponent();
            this.Load += UC_Diem_Load;
            this.VisibleChanged += UC_Diem_VisibleChanged;
        }

        private void UC_Diem_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            CauHinhCotGridDiem();
            bsDiem.CurrentChanged += BsDiem_CurrentChanged;
        }
        private void UC_Diem_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !daTaiDuLieu)
            {
                Cursor.Current = Cursors.WaitCursor;

                cboHocKy.SelectedIndexChanged -= cboHocKy_SelectedIndexChanged;
                cboHocKy.SelectedIndexChanged += cboHocKy_SelectedIndexChanged;
                LoadCboHocKy();

                daTaiDuLieu = true;
                Cursor.Current = Cursors.Default;
            }
        }

        #region 1. CẤU HÌNH & LOAD COMBOBOX

        private void CauHinhCotGridDiem()
        {
            dgvBangDiem.AutoGenerateColumns = false;
            dgvBangDiem.Columns.Clear();

            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "ID", Visible = false });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Môn", DataPropertyName = "MaMon", Width = 100 });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Môn", DataPropertyName = "TenMon", Width = 250 });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "TC", DataPropertyName = "SoTinChi", Width = 50 });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đ.Quá Trình", DataPropertyName = "DiemGK" });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đ.Cuối Kỳ", DataPropertyName = "DiemCK" });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "TK(10)", DataPropertyName = "DiemTongKet" });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "TK(CH)", DataPropertyName = "DiemChu" });
        }

        private void LoadCboHocKy()
        {
            try
            {
                var listHK = context.HocKy.OrderByDescending(x => x.TenHK).ToList();
                cboHocKy.DataSource = listHK;
                cboHocKy.DisplayMember = "TenHK";
                cboHocKy.ValueMember = "MaHK";

                if (listHK.Count > 0) cboHocKy.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadComboBoxMonHoc(string maHK)
        {
            try
            {
                var listLHP = context.LopHocPhan
                    .Where(x => x.MaHK == maHK)
                    .Join(context.MonHoc,
                          lhp => lhp.MaMon,
                          mh => mh.MaMon,
                          (lhp, mh) => new { lhp.MaLHP, mh.TenMon })
                    .ToList()
                    .GroupBy(x => x.TenMon)
                    .Select(g => new
                    {
                        MaLHP = g.First().MaLHP,
                        TenHienThi = g.Key
                    })
                    .OrderBy(x => x.TenHienThi)
                    .ToList();

                cboMaMon.DataSource = listLHP;
                cboMaMon.DisplayMember = "TenHienThi";
                cboMaMon.ValueMember = "MaLHP";
                cboMaMon.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message);
            }
        }

        #endregion

        #region 2. XỬ LÝ DỮ LIỆU & HIỂN THỊ

        public class DiemViewModel
        {
            public int ID { get; set; }
            public int MaLHP { get; set; }
            public string MaHK { get; set; }
            public string MaMon { get; set; }
            public string TenMon { get; set; }
            public int SoTinChi { get; set; }
            public decimal? DiemGK { get; set; }
            public decimal? DiemCK { get; set; }

            public decimal? DiemTongKet => (DiemGK.HasValue && DiemCK.HasValue) ? (DiemGK * 0.4m + DiemCK * 0.6m) : null;

            public double? DiemHe4
            {
                get
                {
                    if (DiemTongKet == null) return null;
                    float tk = (float)DiemTongKet;
                    if (tk >= 8.5) return 4.0;
                    if (tk >= 7.0) return 3.0;
                    if (tk >= 5.5) return 2.0;
                    if (tk >= 4.0) return 1.0;
                    return 0;
                }
            }

            public string DiemChu
            {
                get
                {
                    if (DiemTongKet == null) return "";
                    float tk = (float)DiemTongKet;
                    if (tk >= 8.5) return "A";
                    if (tk >= 7.0) return "B";
                    if (tk >= 5.5) return "C";
                    if (tk >= 4.0) return "D";
                    return "F";
                }
            }
        }

        public void LoadThongTinSinhVien(string maSV)
        {
            this.currentMaSV = maSV;

            var thongTinSV = (from sv in context.SinhVien
                              join lop in context.LopHanhChinh on sv.MaLop equals lop.MaLop
                              join nganh in context.Nganh on lop.MaNganh equals nganh.MaNganh
                              join khoa in context.Khoa on nganh.MaKhoa equals khoa.MaKhoa
                              join gv in context.GiangVien on lop.MaGVCN equals gv.MaGV into gvGroup
                              from gv in gvGroup.DefaultIfEmpty()
                              where sv.MaSV == maSV
                              select new
                              {
                                  sv.MaSV,
                                  sv.HoTen,
                                  lop.TenLop,
                                  nganh.TenNganh,
                                  khoa.TenKhoa,
                                  TenGVCN = (gv != null) ? gv.HoTen : "Chưa phân công"
                              }).FirstOrDefault();

            if (thongTinSV != null)
            {
                lblMaSV.Text = thongTinSV.MaSV;
                lblHoTen.Text = thongTinSV.HoTen;
                lblLop.Text = thongTinSV.TenLop;
                lblKhoa.Text = thongTinSV.TenKhoa;
                lblNganh.Text = thongTinSV.TenNganh;
                lblCVHT.Text = thongTinSV.TenGVCN;
            }
            LoadBangDiemSinhVien(maSV);
        }

        private void LoadBangDiemSinhVien(string maSV)
        {
            if (cboHocKy.SelectedValue == null) return;
            string maHK_DuocChon = cboHocKy.SelectedValue.ToString();

            var listDiemRaw = from kq in context.KetQuaHocTap
                              join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                              join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                              where kq.MaSV == maSV && lhp.MaHK == maHK_DuocChon
                              select new DiemViewModel
                              {
                                  ID = kq.MaKQ,
                                  MaLHP = kq.MaLHP,
                                  MaHK = lhp.MaHK,
                                  MaMon = mh.MaMon,
                                  TenMon = mh.TenMon,
                                  SoTinChi = mh.SoTinChi,
                                  DiemGK = kq.DiemGK,
                                  DiemCK = kq.DiemCK
                              };

            bsDiem.DataSource = listDiemRaw.ToList();
            dgvBangDiem.DataSource = bsDiem;

            txtDiemQT.DataBindings.Clear();
            txtDiemCK.DataBindings.Clear();
            txtSTC.DataBindings.Clear();
            txtTenMon.DataBindings.Clear();
            txtDiemThiLan1.DataBindings.Clear();
            txtDiemThiLan2.DataBindings.Clear();

            TinhTongKetHocKy(bsDiem.DataSource as List<DiemViewModel>);
        }

        private void BsDiem_CurrentChanged(object sender, EventArgs e)
        {
            if (bsDiem.Current == null || xuLyThem) return;

            var item = (DiemViewModel)bsDiem.Current;

            txtDiemQT.Text = item.DiemGK?.ToString();
            txtDiemCK.Text = item.DiemCK?.ToString();
            txtTenMon.Text = item.TenMon;
            txtSTC.Text = item.SoTinChi.ToString();

            txtDiemThiLan1.Text = "";
            txtDiemThiLan2.Text = "";
            txtGhichu.Text = "";

            if (!string.IsNullOrEmpty(item.MaHK))
            {
                cboHocKy.SelectedValue = item.MaHK;
            }

            if (item.MaLHP > 0)
            {
                cboMaMon.SelectedValue = item.MaLHP;
            }
        }

        private void TinhTongKetHocKy(List<DiemViewModel> list)
        {
            if (list == null || list.Count == 0)
            {
                lblSoMon.Text = "0"; lblSTCDat.Text = "0"; lblSTCTichLuy.Text = "0";
                lblDiemHe10.Text = "0"; lblDiemHe4.Text = "0"; lblXepLoaiHK.Text = "";
                return;
            }

            int soMon = list.Count;
            lblSoMon.Text = soMon.ToString();

            if (soMon < 5)
            {
                lblXepLoaiHK.Text = "Chưa đủ môn xếp loại";

                lblSTCDat.Text = list.Where(x => (x.DiemHe4 ?? 0) >= 1).Sum(x => x.SoTinChi).ToString();
                lblSTCTichLuy.Text = list.Sum(x => x.SoTinChi).ToString();

                double td = list.Where(x => x.DiemTongKet != null).Sum(x => (double)x.DiemTongKet * x.SoTinChi);
                double d4 = 0;

                if (td >= 8.5) d4 = 4.0;
                else if (td >= 7.0) d4 = 3.0;
                else if (td >= 5.5) d4 = 2.0;
                else if (td >= 4.0) d4 = 1.0;
                else d4 = 0.0;

                int tc = list.Sum(x => x.SoTinChi);
                lblDiemHe10.Text = tc > 0 ? Math.Round(td / tc, 2).ToString() : "0";
                lblDiemHe4.Text = tc > 0 ? Math.Round(d4, 2).ToString() : "0";

                return;
            }

            int tcDat = list.Where(x => (x.DiemHe4 ?? 0) >= 1).Sum(x => x.SoTinChi);
            int tcTichLuy = list.Sum(x => x.SoTinChi);

            double tongDiem = list.Where(x => x.DiemTongKet != null).Sum(x => (double)x.DiemTongKet * x.SoTinChi);
            double tongDiem4 = list.Where(x => x.DiemHe4 != null).Sum(x => (double)x.DiemHe4 * x.SoTinChi);

            double dtb10 = tcTichLuy > 0 ? tongDiem / tcTichLuy : 0;
            double dtb4 = tcTichLuy > 0 ? tongDiem4 / tcTichLuy : 0;

            lblSTCDat.Text = tcDat.ToString();
            lblSTCTichLuy.Text = tcTichLuy.ToString();
            lblDiemHe10.Text = Math.Round(dtb10, 2).ToString();
            lblDiemHe4.Text = Math.Round(dtb4, 2).ToString();

            if (dtb4 >= 3.6) lblXepLoaiHK.Text = "Xuất sắc";
            else if (dtb4 >= 3.2) lblXepLoaiHK.Text = "Giỏi";
            else if (dtb4 >= 2.5) lblXepLoaiHK.Text = "Khá";
            else if (dtb4 >= 2.0) lblXepLoaiHK.Text = "Trung bình";
            else lblXepLoaiHK.Text = "Yếu";
        }

        #endregion

        #region 3. CÁC NÚT CHỨC NĂNG

        private void btnAdThem_SV_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            cboMaMon.SelectedIndex = -1;
            txtTenMon.Clear();
            txtSTC.Clear();
            txtDiemQT.Clear();
            txtDiemCK.Clear();
            txtDiemThiLan1.Clear();
            txtDiemThiLan2.Clear();
            txtGhichu.Clear();

            cboMaMon.Focus();
        }

        private void btnAdSua_SV_Click(object sender, EventArgs e)
        {
            if (bsDiem.Current == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            cboMaMon.Enabled = false;
        }

        private void btnAdLua_SV_Click(object sender, EventArgs e)
        {
            if (cboMaMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!");
                return;
            }

            decimal? dGK = string.IsNullOrEmpty(txtDiemQT.Text) ? null : decimal.Parse(txtDiemQT.Text);
            decimal? dCK = string.IsNullOrEmpty(txtDiemCK.Text) ? null : decimal.Parse(txtDiemCK.Text);

            try
            {
                int maLHP = (int)cboMaMon.SelectedValue;

                if (xuLyThem)
                {
                    // =========================================================
                    // 1. LOGIC KIỂM TRA ĐIỀU KIỆN MÔN TIÊN QUYẾT (Từ bảng DieuKienMonHoc)
                    // =========================================================

                    // Lấy mã môn học của Lớp học phần đang chọn
                    var maMonDangChon = context.LopHocPhan
                                               .Where(x => x.MaLHP == maLHP)
                                               .Select(x => x.MaMon)
                                               .FirstOrDefault();

                    if (maMonDangChon != null)
                    {
                        // Truy xuất bảng DieuKienMonHoc để tìm các môn tiên quyết của môn này
                        var listMonTienQuyet = context.DieuKienMonHoc
                                                      .Where(dk => dk.MaMon == maMonDangChon)
                                                      .ToList();

                        foreach (var dk in listMonTienQuyet)
                        {
                            // Sinh viên "đã học" nghĩa là phải có dữ liệu trong bảng KetQuaHocTap với môn tiên quyết này
                            bool daHocMonTienQuyet = (from k in context.KetQuaHocTap
                                                      join lhp in context.LopHocPhan on k.MaLHP equals lhp.MaLHP
                                                      where k.MaSV == currentMaSV && lhp.MaMon == dk.MaMonTienQuyet
                                                      select k).Any();

                            if (!daHocMonTienQuyet)
                            {
                                // Lấy tên môn học tiên quyết để báo lỗi cho thân thiện
                                string tenMonTQ = context.MonHoc
                                                         .Where(m => m.MaMon == dk.MaMonTienQuyet)
                                                         .Select(m => m.TenMon)
                                                         .FirstOrDefault() ?? dk.MaMonTienQuyet;

                                MessageBox.Show($"Không thể nhập điểm!\n\nSinh viên chưa học môn tiên quyết: [{dk.MaMonTienQuyet}] - {tenMonTQ}.\nVui lòng nhập điểm môn tiên quyết trước.",
                                                "Cảnh báo học vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Bắt buộc dừng lại, không Insert vào DB
                            }
                        }
                    }

                    // =========================================================
                    // 2. KIỂM TRA TRÙNG LẶP ĐIỂM
                    // =========================================================
                    var check = context.KetQuaHocTap.FirstOrDefault(x => x.MaSV == currentMaSV && x.MaLHP == maLHP);
                    if (check != null)
                    {
                        MessageBox.Show("Sinh viên đã có điểm môn này trong học kỳ đang chọn!");
                        return;
                    }

                    KetQuaHocTap kq = new KetQuaHocTap();
                    kq.MaSV = currentMaSV;
                    kq.MaLHP = maLHP;
                    kq.DiemGK = dGK;
                    kq.DiemCK = dCK;
                    context.KetQuaHocTap.Add(kq);
                }
                else
                {
                    var viewItem = (DiemViewModel)bsDiem.Current;
                    var kq = context.KetQuaHocTap.Find(viewItem.ID);
                    if (kq != null)
                    {
                        kq.DiemGK = dGK;
                        kq.DiemCK = dCK;
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatTatChucNang(false);
                LoadBangDiemSinhVien(currentMaSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xuLyThem && cboMaMon.SelectedIndex != -1)
            {
                try
                {
                    int maLHP = (int)cboMaMon.SelectedValue;
                    var mon = (from lhp in context.LopHocPhan
                               join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                               where lhp.MaLHP == maLHP
                               select new { mh.TenMon, mh.SoTinChi }).FirstOrDefault();
                    if (mon != null)
                    {
                        txtTenMon.Text = mon.TenMon;
                        txtSTC.Text = mon.SoTinChi.ToString();
                    }
                }
                catch { }
            }
        }

        private void btnAdXoa_SV_Click(object sender, EventArgs e)
        {
            if (bsDiem.Current == null) return;
            if (MessageBox.Show("Xóa điểm môn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var item = (DiemViewModel)bsDiem.Current;
                    var kq = context.KetQuaHocTap.Find(item.ID);
                    if (kq != null)
                    {
                        context.KetQuaHocTap.Remove(kq);
                        context.SaveChanges();
                        LoadBangDiemSinhVien(currentMaSV);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnAdLamLai_SV_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(false);
            bsDiem.ResetBindings(false);
            BsDiem_CurrentChanged(null, null);
        }

        private void btnQuayLai_Click_1(object sender, EventArgs e) => OnQuayLai?.Invoke();

        private void BatTatChucNang(bool mo)
        {
            btnAdLua_SV.Enabled = mo;
            btnAdLamLai_SV.Enabled = mo;
            cboMaMon.Enabled = mo;
            cboHocKy.Enabled = !mo;
            txtDiemQT.Enabled = mo;
            txtDiemCK.Enabled = mo;
            txtTenMon.Enabled = mo;
            txtSTC.Enabled = mo;

            txtDiemThiLan1.Enabled = false;
            txtDiemThiLan2.Enabled = false;

            txtGhichu.Enabled = mo;

            btnAdThem_SV.Enabled = !mo;
            btnAdSua_SV.Enabled = !mo;
            btnAdXoa_SV.Enabled = !mo;

            if(Session.RoleID == 1)
            {
                txtDiemQT.Enabled = false;
                txtDiemCK.Enabled = false;
                txtDiemThiLan1.Enabled=false;
                txtDiemThiLan2.Enabled=false;
            }
        }
        #endregion

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHocKy.SelectedValue != null)
            {
                string maHK_DuocChon = cboHocKy.SelectedValue.ToString();
                LoadComboBoxMonHoc(maHK_DuocChon);

                if (!string.IsNullOrEmpty(currentMaSV))
                {
                    LoadBangDiemSinhVien(currentMaSV);
                }
            }
        }

        private void dgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (bsDiem.DataSource == null || ((List<DiemViewModel>)bsDiem.DataSource).Count == 0)
            {
                MessageBox.Show("Không có dữ liệu điểm để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenSV = lblHoTen.Text.Replace(" ", "_");
            string hocKy = cboHocKy.Text.Replace(" ", "_");
            string defaultFileName = $"Diem_{tenSV}_{hocKy}.xlsx";

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = defaultFileName })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("BangDiem");

                            worksheet.Cell(1, 1).Value = "BẢNG ĐIỂM SINH VIÊN";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 14;

                            worksheet.Cell(2, 1).Value = "Mã SV: " + lblMaSV.Text;
                            worksheet.Cell(2, 2).Value = "Họ tên: " + lblHoTen.Text;
                            worksheet.Cell(3, 1).Value = "Lớp: " + lblLop.Text;
                            worksheet.Cell(3, 2).Value = "Học kỳ: " + cboHocKy.Text;

                            int startRow = 5;
                            worksheet.Cell(startRow, 1).Value = "STT";
                            worksheet.Cell(startRow, 2).Value = "Mã Môn";
                            worksheet.Cell(startRow, 3).Value = "Tên Môn";
                            worksheet.Cell(startRow, 4).Value = "Tín Chỉ";
                            worksheet.Cell(startRow, 5).Value = "Điểm Quá Trình";
                            worksheet.Cell(startRow, 6).Value = "Điểm Cuối Kỳ";
                            worksheet.Cell(startRow, 7).Value = "Tổng Kết (10)";
                            worksheet.Cell(startRow, 8).Value = "Điểm Chữ";

                            worksheet.Range(startRow, 1, startRow, 8).Style.Font.Bold = true;
                            worksheet.Range(startRow, 1, startRow, 8).Style.Fill.BackgroundColor = XLColor.LightGray;

                            var listDiem = (List<DiemViewModel>)bsDiem.DataSource;
                            int row = startRow + 1;
                            int stt = 1;

                            foreach (var diem in listDiem)
                            {
                                worksheet.Cell(row, 1).Value = stt++;
                                worksheet.Cell(row, 2).Value = diem.MaMon;
                                worksheet.Cell(row, 3).Value = diem.TenMon;
                                worksheet.Cell(row, 4).Value = diem.SoTinChi;
                                worksheet.Cell(row, 5).Value = diem.DiemGK?.ToString();
                                worksheet.Cell(row, 6).Value = diem.DiemCK?.ToString();

                                worksheet.Cell(row, 7).Value = diem.DiemTongKet != null ? Math.Round((decimal)diem.DiemTongKet, 1).ToString() : "";
                                worksheet.Cell(row, 8).Value = diem.DiemChu;

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

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên ở màn hình chính trước khi nhập điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHK = cboHocKy.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maHK)) return;

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", Title = "Chọn file Excel Bảng Điểm" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook(ofd.FileName))
                        {
                            var worksheet = workbook.Worksheet(1);
                            var rows = worksheet.RangeUsed().RowsUsed();

                            int rowCount = 0;
                            int skippedCount = 0; // Đếm số môn bị bỏ qua do chưa học tiên quyết

                            foreach (var row in rows)
                            {
                                string maMon = row.Cell(2).Value.ToString().Trim();

                                if (string.IsNullOrEmpty(maMon) || maMon == "Mã Môn" || maMon.Contains("Mã SV") || maMon.Contains("Họ tên"))
                                    continue;

                                decimal? diemGK = null;
                                decimal? diemCK = null;

                                if (decimal.TryParse(row.Cell(5).Value.ToString(), out decimal gk)) diemGK = gk;
                                if (decimal.TryParse(row.Cell(6).Value.ToString(), out decimal ck)) diemCK = ck;

                                var lhp = context.LopHocPhan.FirstOrDefault(x => x.MaMon == maMon && x.MaHK == maHK);

                                if (lhp != null)
                                {
                                    // =========================================================
                                    // KIỂM TRA ĐIỀU KIỆN MÔN TIÊN QUYẾT KHI NHẬP TỪ EXCEL
                                    // =========================================================
                                    var listMonTienQuyet = context.DieuKienMonHoc.Where(dk => dk.MaMon == maMon).ToList();
                                    bool duDieuKienTienQuyet = true;

                                    foreach (var dk in listMonTienQuyet)
                                    {
                                        bool daHocMonTienQuyet = (from k in context.KetQuaHocTap
                                                                  join lhpsv in context.LopHocPhan on k.MaLHP equals lhpsv.MaLHP
                                                                  where k.MaSV == currentMaSV && lhpsv.MaMon == dk.MaMonTienQuyet
                                                                  select k).Any();
                                        if (!daHocMonTienQuyet)
                                        {
                                            duDieuKienTienQuyet = false;
                                            break;
                                        }
                                    }

                                    // Nếu môn này có môn tiên quyết mà sinh viên chưa học -> Bỏ qua dòng này trên Excel
                                    if (!duDieuKienTienQuyet)
                                    {
                                        skippedCount++;
                                        continue;
                                    }

                                    // =========================================================

                                    var kq = context.KetQuaHocTap.FirstOrDefault(x => x.MaSV == currentMaSV && x.MaLHP == lhp.MaLHP);

                                    if (kq != null)
                                    {
                                        if (diemGK.HasValue) kq.DiemGK = diemGK;
                                        if (diemCK.HasValue) kq.DiemCK = diemCK;
                                        context.KetQuaHocTap.Update(kq);
                                    }
                                    else
                                    {
                                        KetQuaHocTap newKq = new KetQuaHocTap();
                                        newKq.MaSV = currentMaSV;
                                        newKq.MaLHP = lhp.MaLHP;
                                        newKq.DiemGK = diemGK;
                                        newKq.DiemCK = diemCK;
                                        context.KetQuaHocTap.Add(newKq);
                                    }
                                    rowCount++;
                                }
                            }

                            context.SaveChanges();
                            LoadBangDiemSinhVien(currentMaSV);

                            string thongBao = $"Đã cập nhật điểm thành công cho {rowCount} môn học!";
                            if (skippedCount > 0)
                            {
                                thongBao += $"\n\nBỏ qua {skippedCount} môn học vì sinh viên chưa hoàn thành môn tiên quyết của các môn đó.";
                            }

                            MessageBox.Show(thongBao, "Hoàn tất import Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập file: Vui lòng đảm bảo bạn đang nhập đúng file Excel mẫu đã xuất ra.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}