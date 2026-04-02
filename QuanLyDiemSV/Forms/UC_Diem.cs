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
using Microsoft.EntityFrameworkCore;

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
            StyleDataGridView(dgvBangDiem);
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
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đ.Thi lần 1", DataPropertyName = "DiemThiLan1" });
            dgvBangDiem.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đ.Thi lần 2", DataPropertyName = "DiemThiLan2" });
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
            public decimal? DiemThiLan1 { get; set; }
            public decimal? DiemThiLan2 { get; set; }

            // Thuộc tính này sẽ lấy trực tiếp con số đã tính toán & lưu từ DB lên
            public decimal? DiemTongKet { get; set; }

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
            LoadDanhSachMonHocHopLe();
        }

        private void LoadBangDiemSinhVien(string maSV)
        {
            if (cboHocKy.SelectedValue == null) return;
            string maHK_DuocChon = cboHocKy.SelectedValue.ToString();

            // 1. Truy vấn lấy dữ liệu từ DB (Bao gồm cả điểm thi lại và điểm tổng kết mới)
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
                                  DiemCK = kq.DiemCK,
                                  DiemThiLan1 = kq.DiemThiLan1,
                                  DiemThiLan2 = kq.DiemThiLan2,
                                  DiemTongKet = kq.DiemTongKet
                              };

            // 2. Gán dữ liệu vào BindingSource và Lưới
            var dataList = listDiemRaw.ToList();
            bsDiem.DataSource = dataList;
            dgvBangDiem.DataSource = bsDiem;

            // 3. Xóa các DataBinding cũ (nếu có) để tránh lỗi xung đột khi gán lại giá trị
            txtDiemQT.DataBindings.Clear();
            txtDiemCK.DataBindings.Clear();
            txtSTC.DataBindings.Clear();
            txtTenMon.DataBindings.Clear();
            txtDiemThiLan1.DataBindings.Clear();
            txtDiemThiLan2.DataBindings.Clear();

            // 4. Tính toán phần thống kê phía trên của Form (Số môn, Tín chỉ đạt, ĐTB...)
            TinhTongKetHocKy(dataList);
        }
        // HÀM LỌC MÔN HỌC "BỌC THÉP" 3 ĐIỀU KIỆN
        private void LoadDanhSachMonHocHopLe()
        {
            if (!daTaiDuLieu || cboHocKy.SelectedValue == null || string.IsNullOrEmpty(currentMaSV))
            {
                cboMaMon.DataSource = null;
                return;
            }

            string maHK = cboHocKy.SelectedValue.ToString();

            // LOGIC MỚI: Chỉ lấy môn học nằm trong bảng KetQuaHocTap của sinh viên này, và Lớp đó phải đang MỞ
            var listMon = (from kq in context.KetQuaHocTap
                           join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                           join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                           where kq.MaSV == currentMaSV
                                 && lhp.MaHK == maHK
                                 && lhp.TrangThai == 1
                           select mh).Distinct().ToList();

            cboMaMon.DataSource = null;

            if (listMon.Count > 0)
            {
                cboMaMon.DataSource = listMon;
                cboMaMon.DisplayMember = "TenMon";
                cboMaMon.ValueMember = "MaMon";
                cboMaMon.SelectedIndex = -1; // Trống ô cho người dùng tự chọn
            }
        }

        private void BsDiem_CurrentChanged(object sender, EventArgs e)
        {
            if (bsDiem.Current == null || xuLyThem) return;

            var item = (DiemViewModel)bsDiem.Current;

            txtDiemQT.Text = item.DiemGK?.ToString();
            txtDiemCK.Text = item.DiemCK?.ToString();
            txtDiemThiLan1.Text = item.DiemThiLan1?.ToString();
            txtDiemThiLan2.Text = item.DiemThiLan2?.ToString();
            txtTenMon.Text = item.TenMon;
            txtSTC.Text = item.SoTinChi.ToString();
            txtGhichu.Text = "";

            // Tránh tình trạng gán lại Học kỳ gây lặp (Loop) sự kiện
            if (!string.IsNullOrEmpty(item.MaHK) && cboHocKy.SelectedValue?.ToString() != item.MaHK)
            {
                cboHocKy.SelectedValue = item.MaHK;
            }

            // SỬA Ở ĐÂY: Gán giá trị là Mã Môn (kiểu chuỗi) thay vì Mã Lớp Học Phần (kiểu số)
            if (!string.IsNullOrEmpty(item.MaMon))
            {
                cboMaMon.SelectedValue = item.MaMon;
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

            // =========================================================
            // 0. LẤY DỮ LIỆU TỪ GIAO DIỆN VÀ ÉP KIỂU CHUẨN XÁC
            // =========================================================
            decimal? dGK = string.IsNullOrEmpty(txtDiemQT.Text) ? null : decimal.Parse(txtDiemQT.Text);
            decimal? dCK = string.IsNullOrEmpty(txtDiemCK.Text) ? null : decimal.Parse(txtDiemCK.Text);
            decimal? dThiL1 = string.IsNullOrEmpty(txtDiemThiLan1.Text) ? null : decimal.Parse(txtDiemThiLan1.Text);
            decimal? dThiL2 = string.IsNullOrEmpty(txtDiemThiLan2.Text) ? null : decimal.Parse(txtDiemThiLan2.Text);

            // Bắt lỗi: Có điểm Thi Lại nhưng lại bỏ trống Cuối Kỳ
            if ((dThiL1.HasValue || dThiL2.HasValue) && !dCK.HasValue)
            {
                MessageBox.Show("Sinh viên phải có điểm thi Cuối Kỳ (chính thức) trước khi nhập điểm thi lại/cải thiện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính điểm tổng kết
            double diemTongKet = TinhDiemTongKetCuoiCung((double)(dGK ?? 0), (double?)dCK, (double?)dThiL1, (double?)dThiL2);

            try
            {
                // =========================================================
                // LẤY ĐÚNG MÃ LỚP HỌC PHẦN MÀ SINH VIÊN ĐANG ĐĂNG KÝ
                // =========================================================
                string maMon = cboMaMon.SelectedValue.ToString();
                string maHK = cboHocKy.SelectedValue.ToString();

                var lhpDangKy = (from l in context.LopHocPhan
                                 join k in context.KetQuaHocTap on l.MaLHP equals k.MaLHP
                                 where k.MaSV == currentMaSV && l.MaMon == maMon && l.MaHK == maHK
                                 select l).FirstOrDefault();

                if (lhpDangKy == null)
                {
                    MessageBox.Show("Không tìm thấy lớp học phần sinh viên đã đăng ký cho môn này!");
                    return;
                }

                int maLHP = lhpDangKy.MaLHP;

                if (xuLyThem)
                {
                    // ==========================================================
                    // LOGIC CHO TRƯỜNG HỢP: THÊM MỚI
                    // ==========================================================
                    var maMonDangChon = context.LopHocPhan.Where(x => x.MaLHP == maLHP).Select(x => x.MaMon).FirstOrDefault();

                    if (maMonDangChon != null)
                    {
                        var listMonTienQuyet = context.DieuKienMonHoc.Where(dk => dk.MaMon == maMonDangChon).ToList();

                        foreach (var dk in listMonTienQuyet)
                        {
                            bool daHocMonTienQuyet = (from k in context.KetQuaHocTap
                                                      join lhp in context.LopHocPhan on k.MaLHP equals lhp.MaLHP
                                                      where k.MaSV == currentMaSV && lhp.MaMon == dk.MaMonTienQuyet
                                                      select k).Any();

                            if (!daHocMonTienQuyet)
                            {
                                string tenMonTQ = context.MonHoc.Where(m => m.MaMon == dk.MaMonTienQuyet).Select(m => m.TenMon).FirstOrDefault() ?? dk.MaMonTienQuyet;
                                MessageBox.Show($"Không thể nhập điểm!\n\nSinh viên chưa học môn tiên quyết: [{dk.MaMonTienQuyet}] - {tenMonTQ}.\nVui lòng nhập điểm môn tiên quyết trước.", "Cảnh báo học vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    var check = context.KetQuaHocTap.FirstOrDefault(x => x.MaSV == currentMaSV && x.MaLHP == maLHP);

                    if (check != null)
                    {
                        if (check.DiemGK != null || check.DiemCK != null || check.DiemTongKet != null)
                        {
                            MessageBox.Show("Sinh viên đã có điểm môn này! Vui lòng dùng chức năng 'Sửa' nếu muốn cập nhật điểm.", "Đã có điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        check.DiemGK = dGK;
                        check.DiemCK = dCK;
                        check.DiemThiLan1 = dThiL1;
                        check.DiemThiLan2 = dThiL2;
                        check.DiemTongKet = (decimal?)diemTongKet;
                        context.KetQuaHocTap.Update(check);
                    }
                    else
                    {
                        KetQuaHocTap kq = new KetQuaHocTap();
                        kq.MaSV = currentMaSV;
                        kq.MaLHP = maLHP;
                        kq.DiemGK = dGK;
                        kq.DiemCK = dCK;
                        kq.DiemThiLan1 = dThiL1;
                        kq.DiemThiLan2 = dThiL2;
                        kq.DiemTongKet = (decimal?)diemTongKet;
                        context.KetQuaHocTap.Add(kq);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Thêm thành công!\nĐiểm tổng kết được hệ thống tính toán là: {diemTongKet}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BatTatChucNang(false);
                    LoadBangDiemSinhVien(currentMaSV);
                }
                else
                {
                    // ==========================================================
                    // LOGIC CHO TRƯỜNG HỢP: SỬA ĐIỂM BỊ THIẾU ĐÃ ĐƯỢC THÊM VÀO
                    // ==========================================================
                    var kqSua = context.KetQuaHocTap.FirstOrDefault(x => x.MaSV == currentMaSV && x.MaLHP == maLHP);
                    if (kqSua != null)
                    {
                        kqSua.DiemGK = dGK;
                        kqSua.DiemCK = dCK;
                        kqSua.DiemThiLan1 = dThiL1;
                        kqSua.DiemThiLan2 = dThiL2;
                        kqSua.DiemTongKet = (decimal?)diemTongKet;

                        context.KetQuaHocTap.Update(kqSua);
                        context.SaveChanges();

                        MessageBox.Show($"Cập nhật điểm thành công!\nĐiểm tổng kết hệ thống tính toán lại là: {diemTongKet}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BatTatChucNang(false);
                        LoadBangDiemSinhVien(currentMaSV);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ tự động điền khi đang ở chế độ Thêm mới (xuLyThem = true) và có chọn dữ liệu
            if (xuLyThem && cboMaMon.SelectedIndex != -1 && cboMaMon.SelectedValue != null)
            {
                try
                {
                    // Lấy mã môn học dạng chuỗi từ ComboBox (VD: "COS106")
                    string maMonDangChon = cboMaMon.SelectedValue.ToString();

                    // Tìm kiếm môn học đó trong CSDL
                    var mon = context.MonHoc.FirstOrDefault(x => x.MaMon == maMonDangChon);

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

            txtDiemThiLan1.Enabled = mo;
            txtDiemThiLan2.Enabled = mo;

            txtGhichu.Enabled = mo;

            btnAdThem_SV.Enabled = !mo;
            btnAdSua_SV.Enabled = !mo;
            btnAdXoa_SV.Enabled = !mo;

            if (Session.RoleID == 1)
            {
                txtDiemQT.Enabled = false;
                txtDiemCK.Enabled = false;
                txtDiemThiLan1.Enabled = false;
                txtDiemThiLan2.Enabled = false;
            }
        }
        #endregion

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHocKy.SelectedValue != null)
            {
                LoadDanhSachMonHocHopLe();
                if (!String.IsNullOrEmpty(currentMaSV))
                {
                    LoadBangDiemSinhVien(currentMaSV);
                }
            }
        }
      

        private void dgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !xuLyThem)
            {
                BsDiem_CurrentChanged(null, null);
            }
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
        // HÀM TÍNH ĐIỂM TỔNG KẾT THEO QUY CHẾ THI LẠI / CẢI THIỆN
        private double TinhDiemTongKetCuoiCung(double diemQT, double? diemCK, double? diemThiL1, double? diemThiL2)
        {
            // 1. Chưa có điểm thi cuối kỳ (lần chính thức) thì chưa có tổng kết
            if (!diemCK.HasValue) return 0;

            // 2. Tính điểm tổng kết chính thức (Lần 1)
            double tkChinhThuc = Math.Round((diemQT * 0.4) + (diemCK.Value * 0.6), 1);

            // 3. Nếu không thi lại/cải thiện, điểm cuối cùng là điểm chính thức
            if (!diemThiL1.HasValue && !diemThiL2.HasValue)
                return tkChinhThuc;

            // 4. Nếu có thi lại, xác định điểm thi lại mới nhất (Lần 2 đè Lần 1)
            double? diemThiLai = diemThiL2.HasValue ? diemThiL2 : diemThiL1;
            if (!diemThiLai.HasValue) return tkChinhThuc;

            // Tính nháp điểm tổng kết của lần thi lại
            double tkThiLai = Math.Round((diemQT * 0.4) + (diemThiLai.Value * 0.6), 1);

            // 5. ÁP DỤNG QUY CHẾ:
            if (tkChinhThuc < 5.0)
            {
                // TH rớt: Điểm tổng kết thi lại tối đa chỉ được 6.0
                return tkThiLai > 6.0 ? 6.0 : tkThiLai;
            }
            else
            {
                // TH cải thiện: Lấy điểm thi lại * 0.6 + QT * 0.4 (Không giới hạn)
                return tkThiLai;
            }
        }
    }
}