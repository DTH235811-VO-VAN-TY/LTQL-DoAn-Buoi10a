using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyDiemSV.Data;
using GUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;

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
                LoadCboHocKy(); // Chỉ cần gọi Load Học Kỳ, nó sẽ tự kéo theo Load Điểm

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

                // Mặc định chọn học kỳ mới nhất
                if (listHK.Count > 0) cboHocKy.SelectedIndex = 0;
            }
            catch { }
        }

        // Sự kiện: Khi chọn Học kỳ -> Load lại danh sách Môn học tương ứng

        private void LoadComboBoxMonHoc(string maHK)
        {
            try
            {
                // Lọc Lớp học phần theo Học kỳ đã chọn
                var listLHP = context.LopHocPhan
                    .Where(x => x.MaHK == maHK) // Chỉ lấy môn thuộc học kỳ này
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

            // Join thêm bảng GiangVien để lấy tên GVCN
            var thongTinSV = (from sv in context.SinhVien
                              join lop in context.LopHanhChinh on sv.MaLop equals lop.MaLop
                              join nganh in context.Nganh on lop.MaNganh equals nganh.MaNganh
                              join khoa in context.Khoa on nganh.MaKhoa equals khoa.MaKhoa
                              // Left Join Giáo viên (đề phòng lớp chưa có GVCN thì không bị lỗi)
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

                // Hiển thị tên GVCN (dùng label lblCVHT có sẵn trên giao diện)
                lblCVHT.Text = thongTinSV.TenGVCN;
            }
            LoadBangDiemSinhVien(maSV);
        }

        private void LoadBangDiemSinhVien(string maSV)
        {
            // 1. Lấy mã học kỳ đang được chọn trên ComboBox
            if (cboHocKy.SelectedValue == null) return;
            string maHK_DuocChon = cboHocKy.SelectedValue.ToString();

            // 2. Lấy điểm của sinh viên NHƯNG CHỈ TRONG HỌC KỲ ĐÓ
            var listDiemRaw = from kq in context.KetQuaHocTap
                              join lhp in context.LopHocPhan on kq.MaLHP equals lhp.MaLHP
                              join mh in context.MonHoc on lhp.MaMon equals mh.MaMon
                              where kq.MaSV == maSV && lhp.MaHK == maHK_DuocChon // <--- Thêm điều kiện lọc ở đây
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

            // Xóa bỏ binding tự động
            txtDiemQT.DataBindings.Clear();
            txtDiemCK.DataBindings.Clear();
            txtSTC.DataBindings.Clear();
            txtTenMon.DataBindings.Clear();
            txtDiemThiLan1.DataBindings.Clear();
            txtDiemThiLan2.DataBindings.Clear();

            // Cập nhật thống kê điểm (Bây giờ nó sẽ tính chuẩn xác cho riêng học kỳ này)
            TinhTongKetHocKy(bsDiem.DataSource as List<DiemViewModel>);
        }

        private void BsDiem_CurrentChanged(object sender, EventArgs e)
        {
            if (bsDiem.Current == null || xuLyThem) return;

            var item = (DiemViewModel)bsDiem.Current;

            // 1. ĐỔ DỮ LIỆU LÊN CÁC TEXTBOX
            txtDiemQT.Text = item.DiemGK?.ToString();
            txtDiemCK.Text = item.DiemCK?.ToString();
            txtTenMon.Text = item.TenMon;
            txtSTC.Text = item.SoTinChi.ToString();

            // Reset các ô trống
            txtDiemThiLan1.Text = "";
            txtDiemThiLan2.Text = "";
            txtGhichu.Text = "";

            // 2. XỬ LÝ COMBOBOX: Đảm bảo môn học không bị trống
            if (!string.IsNullOrEmpty(item.MaHK))
            {
                // Ép cboHocKy nhảy về học kỳ của điểm này
                // (Hành động này sẽ tự động kích hoạt hàm LoadComboBoxMonHoc để nạp danh sách môn mới)
                cboHocKy.SelectedValue = item.MaHK;
            }

            // Sau khi danh sách môn đã được nạp chuẩn, ta mới gán mã Lớp học phần
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

            // --- YÊU CẦU: CHỈ XẾP LOẠI KHI CÓ ĐỦ 5 MÔN TRỞ LÊN ---
            if (soMon < 5)
            {
                lblXepLoaiHK.Text = "Chưa đủ môn xếp loại";

                // Vẫn tính toán các chỉ số khác cho sinh viên xem
                lblSTCDat.Text = list.Where(x => (x.DiemHe4 ?? 0) >= 1).Sum(x => x.SoTinChi).ToString();
                lblSTCTichLuy.Text = list.Sum(x => x.SoTinChi).ToString();

                double td = list.Where(x => x.DiemTongKet != null).Sum(x => (double)x.DiemTongKet * x.SoTinChi);
                double d4 = 0;

                if (td >= 8.5) d4 = 4.0;       // A (Giỏi/Xuất sắc)
                else if (td >= 7.0) d4 = 3.0;  // B (Khá)
                else if (td >= 5.5) d4 = 2.0;  // C (Trung bình)
                else if (td >= 4.0) d4 = 1.0;  // D (Trung bình yếu)
                else d4 = 0.0;

                int tc = list.Sum(x => x.SoTinChi);
                lblDiemHe10.Text = tc > 0 ? Math.Round(td / tc, 2).ToString() : "0";
                lblDiemHe4.Text = tc > 0 ? Math.Round(d4, 2).ToString() : "0";

                return; // Dừng, không xếp loại
            }

            // Nếu đủ 5 môn thì tính tiếp
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
                    var check = context.KetQuaHocTap.FirstOrDefault(x => x.MaSV == currentMaSV && x.MaLHP == maLHP);
                    if (check != null)
                    {
                        MessageBox.Show("Sinh viên đã có điểm môn này!");
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
                MessageBox.Show("Lưu thành công!");
                BatTatChucNang(false);
                LoadBangDiemSinhVien(currentMaSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
            cboHocKy.Enabled = !mo; // Khi đang thêm/sửa thì khóa chọn học kỳ lại cho an toàn
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
        }
        #endregion

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra an toàn: Đảm bảo Học kỳ đã được chọn và có giá trị
            if (cboHocKy.SelectedValue != null)
            {
                // Lấy mã học kỳ đang được chọn
                string maHK_DuocChon = cboHocKy.SelectedValue.ToString();

                // 1. Gọi hàm nạp danh sách Môn học (để combo môn học hiển thị đúng)
                LoadComboBoxMonHoc(maHK_DuocChon);

                // 2. GỌI LẠI HÀM LOAD ĐIỂM: Để lưới cập nhật lại các môn của học kỳ này
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
            // 1. Kiểm tra xem có dữ liệu không
            if (bsDiem.DataSource == null || ((List<DiemViewModel>)bsDiem.DataSource).Count == 0)
            {
                MessageBox.Show("Không có dữ liệu điểm để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tạo tên file mặc định: VD: Diem_Vo_Van_Ty_Hoc_ky_1.xlsx
            string tenSV = lblHoTen.Text.Replace(" ", "_"); // Xóa khoảng trắng để tên file không bị lỗi
            string hocKy = cboHocKy.Text.Replace(" ", "_");
            string defaultFileName = $"Diem_{tenSV}_{hocKy}.xlsx";

            // 3. Mở hộp thoại lưu file
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = defaultFileName })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("BangDiem");

                            // --- TẠO PHẦN THÔNG TIN SINH VIÊN (HEADER) ---
                            worksheet.Cell(1, 1).Value = "BẢNG ĐIỂM SINH VIÊN";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 14;

                            worksheet.Cell(2, 1).Value = "Mã SV: " + lblMaSV.Text;
                            worksheet.Cell(2, 2).Value = "Họ tên: " + lblHoTen.Text;
                            worksheet.Cell(3, 1).Value = "Lớp: " + lblLop.Text;
                            worksheet.Cell(3, 2).Value = "Học kỳ: " + cboHocKy.Text;

                            // --- TẠO TIÊU ĐỀ CÁC CỘT (Bắt đầu từ dòng 5) ---
                            int startRow = 5;
                            worksheet.Cell(startRow, 1).Value = "STT";
                            worksheet.Cell(startRow, 2).Value = "Mã Môn";
                            worksheet.Cell(startRow, 3).Value = "Tên Môn";
                            worksheet.Cell(startRow, 4).Value = "Tín Chỉ";
                            worksheet.Cell(startRow, 5).Value = "Điểm Quá Trình";
                            worksheet.Cell(startRow, 6).Value = "Điểm Cuối Kỳ";
                            worksheet.Cell(startRow, 7).Value = "Tổng Kết (10)";
                            worksheet.Cell(startRow, 8).Value = "Điểm Chữ";

                            // Bôi đậm dòng tiêu đề
                            worksheet.Range(startRow, 1, startRow, 8).Style.Font.Bold = true;
                            worksheet.Range(startRow, 1, startRow, 8).Style.Fill.BackgroundColor = XLColor.LightGray;

                            // --- ĐỔ DỮ LIỆU ĐIỂM VÀO ---
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

                                // Ép kiểu làm tròn điểm tổng kết
                                worksheet.Cell(row, 7).Value = diem.DiemTongKet != null ? Math.Round((decimal)diem.DiemTongKet, 1).ToString() : "";
                                worksheet.Cell(row, 8).Value = diem.DiemChu;

                                row++;
                            }

                            // Căn chỉnh tự động cột cho đẹp
                            worksheet.Columns().AdjustToContents();

                            // Lưu và báo thành công
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

                            foreach (var row in rows)
                            {
                                // Lấy Mã Môn ở cột số 2 (Dựa theo đúng cấu trúc file đã xuất ra)
                                string maMon = row.Cell(2).Value.ToString().Trim();

                                // Bỏ qua nếu là các dòng header, tiêu đề hoặc rỗng
                                if (string.IsNullOrEmpty(maMon) || maMon == "Mã Môn" || maMon.Contains("Mã SV") || maMon.Contains("Họ tên"))
                                    continue;

                                // Đọc Điểm Quá Trình (Cột 5) và Điểm Cuối Kỳ (Cột 6)
                                decimal? diemGK = null;
                                decimal? diemCK = null;

                                if (decimal.TryParse(row.Cell(5).Value.ToString(), out decimal gk)) diemGK = gk;
                                if (decimal.TryParse(row.Cell(6).Value.ToString(), out decimal ck)) diemCK = ck;

                                // 1. Tìm Lớp Học Phần tương ứng với Mã Môn và Học Kỳ này
                                var lhp = context.LopHocPhan.FirstOrDefault(x => x.MaMon == maMon && x.MaHK == maHK);

                                if (lhp != null)
                                {
                                    // 2. Tìm xem sinh viên đã có dòng Kết Quả cho Lớp Học Phần này chưa
                                    var kq = context.KetQuaHocTap.FirstOrDefault(x => x.MaSV == currentMaSV && x.MaLHP == lhp.MaLHP);

                                    if (kq != null)
                                    {
                                        // Đã có môn này -> Cập nhật điểm
                                        if (diemGK.HasValue) kq.DiemGK = diemGK;
                                        if (diemCK.HasValue) kq.DiemCK = diemCK;
                                        context.KetQuaHocTap.Update(kq);
                                    }
                                    else
                                    {
                                        // Chưa có -> Thêm mới dòng kết quả
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

                            // Lưu thay đổi và load lại lưới
                            context.SaveChanges();
                            LoadBangDiemSinhVien(currentMaSV);

                            MessageBox.Show($"Đã cập nhật điểm thành công cho {rowCount} môn học!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
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