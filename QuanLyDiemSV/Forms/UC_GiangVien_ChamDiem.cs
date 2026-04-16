using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_GiangVien_ChamDiem : UserControl
    {
        // Khai báo Context dùng riêng cho việc nhập điểm để theo dõi thay đổi
        QLDSVDbContext dbChamDiem;
        BindingSource bsChamDiem = new BindingSource();
        int currentLHP = 0; // Lưu tạm mã LHP đang chấm
        string currentMaGV = ""; //Lưu mã giáo viên đang đăng nhập
        ErrorProvider errorProvider = new ErrorProvider();
        bool dangCapNhatUI = false;
        bool dangTruyVan = false;
        public UC_GiangVien_ChamDiem()
        {
            InitializeComponent();
            // Đăng ký các sự kiện cho DataGridView
            DgvDSSV.CellFormatting += DgvDSSV_CellFormatting;
            DgvDSSV.CellValueChanged += DgvDSSV_CellValueChanged;
            DgvDSSV.CellValidating += DgvDSSV_CellValidating;
            DgvDSSV.DataError += DgvDSSV_DataError;
            StyleDataGridView(DgvDSSV);
            StyleButtons();

            // TỰ ĐỘNG LIÊN KẾT CÁC NÚT TÌM KIẾM, SẮP XẾP BẰNG CODE
            btnTimKiem.Click += BtnTimKiem_Click;
            btnHienTatCa.Click += BtnHienTatCa_Click;
            cboKieuSX.SelectedIndexChanged += CboKieuSX_SelectedIndexChanged;
            radTang.CheckedChanged += RadTang_CheckedChanged;
            radGiam.CheckedChanged += RadGiam_CheckedChanged;


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // =====================================================================
            // 1. PHÍM TẮT HỆ THỐNG: HOẠT ĐỘNG TOÀN CỤC (Kể cả khi đang gõ chữ)
            // =====================================================================

            // Ctrl + S: Lưu dữ liệu
            if (keyData == (Keys.Control | Keys.S))
            {            
                    btnLuuBangDiem.PerformClick();
                    return true;
                
            }

            // Enter: Tìm kiếm khi đang đứng ở ô Từ khóa
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl == txtTimKiem)
                {
                    btnLoc.PerformClick();
                    return true;
                }
            }

            // =====================================================================
            // 2. KHÓA AN TOÀN: Chặn phím tắt đơn khi người dùng đang nhập liệu
            // (Để tránh việc gõ chữ 'C' trong tên mà lại nhảy sang lệnh Thêm mới)
            // =====================================================================
            if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is System.Windows.Forms.ComboBox)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            // =====================================================================
            // 3. CÁC PHÍM TẮT ĐƠN: CHỈ HOẠT ĐỘNG KHI KHÔNG GÕ CHỮ
            // =====================================================================
            switch (keyData)
            {
                case Keys.F: // Tìm kiếm (Find)
                    if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is System.Windows.Forms.ComboBox)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    txtTimKiem.Focus();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void LoadCboHocKy()
        {
            using (var context = new QLDSVDbContext())
            {
                var listHK = context.HocKy.OrderByDescending(x => x.TenHK).ToList();

                // Chèn thêm mục "Tất cả" vào vị trí đầu tiên
                listHK.Insert(0, new HocKy { MaHK = "ALL", TenHK = "-- Tất cả học kỳ --" });

                cboHocKy.DataSource = listHK;
                cboHocKy.DisplayMember = "TenHK";
                cboHocKy.ValueMember = "MaHK";
            }
        }
        // Hàm tạo dữ liệu cho các ComboBox Tìm kiếm / Sắp xếp
        private void KhoiTaoCboTimKiemSapXep()
        {
            if (cboLoaiTK.Items.Count == 0)
            {
                cboLoaiTK.Items.AddRange(new string[] { "Mã SV", "Họ Tên" });
                cboLoaiTK.SelectedIndex = 1; // Mặc định tìm theo Tên

                cboKieuSX.Items.AddRange(new string[] { "Mã SV", "Họ Tên", "Điểm Tổng Kết" });
                cboKieuSX.SelectedIndex = 0; // Mặc định sắp xếp theo Mã SV

                dangCapNhatUI = false;
            }
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            cboHocKy.SelectedIndex = 0; // Về "Tất cả"
            txtTimKiem.Clear();
            if (!string.IsNullOrEmpty(currentMaGV))
            {
                LoadDanhSachLopCuaToiAsync
                    (currentMaGV);
            }
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
        private void StyleButtons()
        {
            // Bảng màu Material Design cực đẹp
            Color primaryColor = Color.FromArgb(52, 152, 219);   // Xanh dương (Tìm kiếm, Lọc)
            Color successColor = Color.FromArgb(46, 204, 113);   // Xanh lá (Lưu, Xuất Excel, In)
            Color dangerColor = Color.FromArgb(231, 76, 60);     // Đỏ (Quay lại)
            Color secondaryColor = Color.FromArgb(149, 165, 166); // Xám (Tải lại, Hiện tất cả)

            // Hàm nội bộ để áp dụng giao diện nhanh cho 1 nút
            void ApplyStyle(Button btn, Color bgColor)
            {
                if (btn == null) return;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = bgColor;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;

                // Hiệu ứng Hover (Sáng lên khi rê chuột)
                btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(bgColor);
                btn.MouseLeave += (s, e) => btn.BackColor = bgColor;
            }

            // 1. Áp dụng cho màn hình chọn Lớp
            ApplyStyle(btnLoc, primaryColor);
            ApplyStyle(btnTaiLai, secondaryColor);
            ApplyStyle(btnInDanhSach, successColor);

            // 2. Áp dụng cho màn hình chấm điểm
            ApplyStyle(btnTimKiem, primaryColor);
            ApplyStyle(btnHienTatCa, secondaryColor);
            ApplyStyle(btnLuuBangDiem, successColor);
            ApplyStyle(btnQuayLaiLop, dangerColor);
            ApplyStyle(btnXuatExcel, primaryColor); // Hoặc successColor tùy bạn
        }

        // Hàm này bốc "Họ Tên" từ bảng SinhVien hiển thị lên lưới
        private void DgvDSSV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvDSSV.Columns[e.ColumnIndex].Name == "HoTen" && e.RowIndex >= 0)
            {
                var kq = DgvDSSV.Rows[e.RowIndex].DataBoundItem as KetQuaHocTap;
                if (kq != null && kq.MaSVNavigation != null)
                {
                    e.Value = kq.MaSVNavigation.HoTen;
                    e.FormattingApplied = true;
                }
            }
        }
        private void DgvDSSV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // Tắt bảng lỗi tiếng Anh
                                      // Báo đỏ nhưng không nhốt chuột. Lưới sẽ tự động xóa chữ 'a' và trả về số cũ.
            DgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Dữ liệu nhập vào sai định dạng (không phải là số)!";
        }
        private void DgvDSSV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = DgvDSSV.Columns[e.ColumnIndex].Name;
            if (colName == "DiemGK" || colName == "DiemCK" || colName == "DiemThiLan1" || colName == "DiemThiLan2")
            {
                string newValue = e.FormattedValue.ToString();

                // 1. Cho phép xóa trắng ô điểm
                if (string.IsNullOrWhiteSpace(newValue))
                {
                    DgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
                    return;
                }

                // ====================================================================
                // 2. KIỂM TRA ĐỊNH DẠNG SỐ VÀ KHOẢNG ĐIỂM [0 - 10]
                // ====================================================================
                if (!double.TryParse(newValue, out double diem))
                {
                    DgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Lỗi: Điểm bắt buộc phải là con số!";
                    return; // Thoát ngay, để lại icon đỏ
                }
                else if (diem < 0 || diem > 10)
                {
                    DgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Lỗi: Điểm phải nằm trong khoảng từ 0 đến 10!";
                    return; // Thoát ngay, để lại icon đỏ
                }

                // ====================================================================
                // 3. KIỂM TRA MÔN TIÊN QUYẾT (Ngay khi vừa nhập xong)
                // ====================================================================
                string maSV = DgvDSSV.Rows[e.RowIndex].Cells["MaSV"].Value?.ToString();
                var lhpHienTai = dbChamDiem.LopHocPhan.FirstOrDefault(x => x.MaLHP == currentLHP);

                if (lhpHienTai != null)
                {
                    var listTienQuyet = dbChamDiem.DieuKienMonHoc.Where(dk => dk.MaMon == lhpHienTai.MaMon).ToList();
                    foreach (var dk in listTienQuyet)
                    {
                        bool daQuaMonTQ = (from k in dbChamDiem.KetQuaHocTap
                                           join lhp in dbChamDiem.LopHocPhan on k.MaLHP equals lhp.MaLHP
                                           where k.MaSV == maSV && lhp.MaMon == dk.MaMonTienQuyet && k.DiemTongKet != null
                                           select k).Any();

                        if (!daQuaMonTQ)
                        {
                            string tenMonTQ = dbChamDiem.MonHoc.Where(m => m.MaMon == dk.MaMonTienQuyet).Select(m => m.TenMon).FirstOrDefault() ?? dk.MaMonTienQuyet;

                            // Gắn thẳng icon đỏ vào ô kèm lời nhắn, KHÔNG DÙNG MessageBox nữa
                            DgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = $"Chưa đủ điều kiện: Thiếu điểm tổng kết môn {tenMonTQ}!";
                            return; // Thoát ngay, để lại icon đỏ
                        }
                    }
                }

                // ====================================================================
                // 4. VƯỢT QUA TẤT CẢ BÀI KIỂM TRA -> XÓA SẠCH ICON LỖI
                // ====================================================================
                DgvDSSV.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
            }
        }
        private bool IsGridHopLe()
        {
            foreach (DataGridViewRow row in DgvDSSV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!string.IsNullOrEmpty(cell.ErrorText))
                    {
                        return false; // Tìm thấy ít nhất 1 lỗi
                    }
                }
            }
            return true;
        }
        //Xác nhận mật khẩu trước khi cho phép nhập điểm
        // Xác nhận mật khẩu trước khi cho phép nhập điểm
        private bool XacNhanMatKhau(string maGV)
        {
            // 1. Tự động vẽ một Form nhỏ bằng code
            Form prompt = new Form()
            {
                Width = 400,
                Height = 220,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Xác nhận bảo mật",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = "Để đảm bảo an toàn, vui lòng nhập lại mật khẩu của bạn trước khi chốt điểm:" };
            TextBox txtPassword = new TextBox() { Left = 20, Top = 60, Width = 340, UseSystemPasswordChar = true, Font = new Font("Segoe UI", 12) };
            Button confirmation = new Button() { Text = "Xác nhận", Left = 170, Width = 90, Top = 120, DialogResult = DialogResult.OK, BackColor = Color.DodgerBlue, ForeColor = Color.White };
            Button cancel = new Button() { Text = "Hủy", Left = 270, Width = 90, Top = 120, DialogResult = DialogResult.Cancel };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(txtPassword);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation; // Bấm Enter là xác nhận
            prompt.CancelButton = cancel;       // Bấm Esc là hủy

            // 2. Hiển thị hộp thoại và kiểm tra kết quả
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                string matKhauNhapVao = txtPassword.Text;

                using (var db = new QLDSVDbContext())
                {
                    // BƯỚC A: Lấy thông tin tài khoản từ CSDL dựa vào Mã GV (Username)
                    var tk = db.UserAccount.FirstOrDefault(t => t.Username == maGV);

                    // BƯỚC B: Sử dụng hàm Verify của BCrypt để kiểm tra
                    if (tk != null)
                    {
                        // Đối số 1: Mật khẩu thô vừa gõ
                        // Đối số 2: Mật khẩu đã mã hóa lưu trong DB
                        bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(matKhauNhapVao, tk.PasswordHash);

                        if (isPasswordMatch)
                        {
                            return true; // Mật khẩu hoàn toàn khớp
                        }
                    }
                }
            }

            return false; // Sai mật khẩu hoặc bấm Hủy
        }

        // Hàm phụ trợ lấy số trực tiếp từ ô lưới
        private decimal? LayDiemTuLuoi(object cellValue)
        {
            if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal diem))
                return diem;
            return null; // Nếu ô trống hoặc nhập chữ thì trả về null
        }

        // Hàm tính điểm tổng kết chuẩn 6.0
        // Hàm tính điểm tổng kết chuẩn (Đã khóa chặt logic)
        private decimal? TinhDiemTongKetCuoiCung(decimal? diemGK, decimal? diemCK, decimal? diemThiL1, decimal? diemThiL2)
        {
            if (!diemCK.HasValue) return null; // Chưa có CK thì để trống

            decimal gk = diemGK ?? 0m;
            decimal tkChinhThuc = Math.Round((gk * 0.4m) + (diemCK.Value * 0.6m), 1);

            // Xác định điểm thi lại (Ưu tiên Lần 2)
            decimal? diemThiLai = diemThiL2.HasValue ? diemThiL2 : diemThiL1;

            // Không thi lại -> Trả về điểm gốc
            if (!diemThiLai.HasValue) return tkChinhThuc;

            // Tính nháp điểm thi lại
            decimal tkThiLai = Math.Round((gk * 0.4m) + (diemThiLai.Value * 0.6m), 1);

            // --- BẮT CHẶT QUY CHẾ ---
            if (tkChinhThuc < 5.0m)
            {
                // 1. RỚT -> THI LẠI: Tối đa chỉ được 6.0
                if (tkThiLai > 6.0m)
                {
                    return 6.0m; // Chốt hạ ở 6.0
                }
                return tkThiLai; // Dưới 5 thì lấy đúng điểm đó
            }
            else
            {
                // 2. ĐẬU -> THI CẢI THIỆN: Lấy điểm cao nhất, không giới hạn
                if (tkThiLai > tkChinhThuc) return tkThiLai;
                return tkChinhThuc;
            }
        }

        // Sự kiện tự động nhảy điểm khi gõ xong
        // Sự kiện tự động nhảy điểm khi gõ xong
        private void DgvDSSV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string colName = DgvDSSV.Columns[e.ColumnIndex].Name;

                // Chỉ chạy tính toán khi 1 trong 4 ô điểm này bị thay đổi
                if (colName == "DiemGK" || colName == "DiemCK" || colName == "DiemThiLan1" || colName == "DiemThiLan2")
                {
                    var kq = DgvDSSV.Rows[e.RowIndex].DataBoundItem as KetQuaHocTap;
                    if (kq != null)
                    {
                        // --- ĐIỂM MẤU CHỐT: LẤY SỐ TƯƠI MỚI NHẤT TRỰC TIẾP TỪ GIAO DIỆN LƯỚI ---
                        decimal? diemGK = LayDiemTuLuoi(DgvDSSV.Rows[e.RowIndex].Cells["DiemGK"].Value);
                        decimal? diemCK = LayDiemTuLuoi(DgvDSSV.Rows[e.RowIndex].Cells["DiemCK"].Value);
                        decimal? diemL1 = LayDiemTuLuoi(DgvDSSV.Rows[e.RowIndex].Cells["DiemThiLan1"].Value);
                        decimal? diemL2 = LayDiemTuLuoi(DgvDSSV.Rows[e.RowIndex].Cells["DiemThiLan2"].Value);

                        // 1. Chạy hàm tính toán với bộ số mới nhất
                        kq.DiemTongKet = TinhDiemTongKetCuoiCung(diemGK, diemCK, diemL1, diemL2);

                        // 2. Ép lưới cập nhật hiển thị ngay lập tức
                        if (DgvDSSV.Columns.Contains("DiemTongKet"))
                        {
                            DgvDSSV.Rows[e.RowIndex].Cells["DiemTongKet"].Value = kq.DiemTongKet;
                        }
                    }
                }
            }
        }
        private async void btnLuuBangDiem_Click(object sender, EventArgs e)
        {
            // =========================================================
            // BƯỚC 1: CHỐT DỮ LIỆU & KIỂM TRA
            // =========================================================
            DgvDSSV.EndEdit();
            bsChamDiem.EndEdit();

            // Khóa giao diện
            btnLuuBangDiem.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            // Dùng try-finally để ĐẢM BẢO luôn luôn mở khóa nút bấm dù có lỗi hay return sớm
            try
            {
                if (!IsGridHopLe())
                {
                    MessageBox.Show("Không thể lưu! Có dữ liệu điểm không hợp lệ (bị báo đỏ trên lưới).\nVui lòng kiểm tra lại khoảng điểm từ 0-10 hoặc các ký tự lạ.",
                                    "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!dbChamDiem.ChangeTracker.HasChanges())
                {
                    MessageBox.Show("Chưa có sự thay đổi điểm nào để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // =========================================================
                // BƯỚC 2: KIỂM TRA MÔN TIÊN QUYẾT (ĐÃ TỐI ƯU HÓA SIÊU TỐC)
                // =========================================================
                var lhpHienTai = dbChamDiem.LopHocPhan.FirstOrDefault(x => x.MaLHP == currentLHP);
                if (lhpHienTai == null) return;

                var listTienQuyet = dbChamDiem.DieuKienMonHoc.Where(x => x.MaMon == lhpHienTai.MaMon).ToList();
                var danhSachSV = bsChamDiem.List.OfType<KetQuaHocTap>().ToList();

                if (listTienQuyet.Count > 0)
                {
                    // BÍ QUYẾT: Lấy danh sách ID để truy vấn gom cụm (Bulk Query) 1 LẦN DUY NHẤT
                    var danhSachMaSV = danhSachSV.Select(s => s.MaSV).ToList();
                    var danhSachMaMonTQ = listTienQuyet.Select(d => d.MaMonTienQuyet).ToList();

                    // Kéo tất cả lịch sử đậu môn tiên quyết của các sinh viên này LÊN RAM
                    var dataTienQuyetDaQua = await (from k in dbChamDiem.KetQuaHocTap
                                                    join lhp in dbChamDiem.LopHocPhan on k.MaLHP equals lhp.MaLHP
                                                    where danhSachMaSV.Contains(k.MaSV)
                                                       && danhSachMaMonTQ.Contains(lhp.MaMon)
                                                       && k.DiemTongKet != null
                                                    select new { k.MaSV, lhp.MaMon }).ToListAsync();

                    foreach (var kq in danhSachSV)
                    {
                        if (kq.DiemGK != null || kq.DiemCK != null || kq.DiemThiLan1 != null || kq.DiemThiLan2 != null)
                        {
                            foreach (var dk in listTienQuyet)
                            {
                                // KIỂM TRA TRÊN RAM: Tốc độ tính bằng mili-giây, không bị nghẽn UI
                                bool daQuaMonTQ = dataTienQuyetDaQua.Any(d => d.MaSV == kq.MaSV && d.MaMon == dk.MaMonTienQuyet);

                                if (!daQuaMonTQ)
                                {
                                    string tenMonTQ = dbChamDiem.MonHoc.Where(m => m.MaMon == dk.MaMonTienQuyet).Select(m => m.TenMon).FirstOrDefault() ?? dk.MaMonTienQuyet;
                                    MessageBox.Show($"HỆ THỐNG TỪ CHỐI LƯU!\n\nSinh viên [{kq.MaSV}] chưa có Điểm Tổng Kết của môn tiên quyết: {tenMonTQ}.\n\nVui lòng xóa trắng các điểm vừa nhập của sinh viên này để tiếp tục lưu bảng điểm.",
                                                    "Cảnh báo Học vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    foreach (DataGridViewRow row in DgvDSSV.Rows)
                                    {
                                        if (row.Cells["MaSV"].Value?.ToString() == kq.MaSV)
                                        {
                                            row.Selected = true;
                                            DgvDSSV.FirstDisplayedScrollingRowIndex = row.Index;
                                            break;
                                        }
                                    }
                                    return; // Thoát ngang, hàm finally sẽ lo việc mở khóa nút bấm
                                }
                            }
                        }
                    }
                }

                // =========================================================
                // BƯỚC 3: TÍNH ĐIỂM TỔNG KẾT
                // =========================================================
                foreach (var kq in danhSachSV)
                {
                    kq.DiemTongKet = TinhDiemTongKetCuoiCung(kq.DiemGK, kq.DiemCK, kq.DiemThiLan1, kq.DiemThiLan2);
                }

                // =========================================================
                // BƯỚC 4: XÁC THỰC & NHẬT KÝ HOẠT ĐỘNG
                // =========================================================
                if (!XacNhanMatKhau(currentMaGV))
                {
                    MessageBox.Show("Mật khẩu không chính xác hoặc bạn đã hủy thao tác.\nBảng điểm hiện tại chưa được lưu xuống hệ thống!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var changedEntries = dbChamDiem.ChangeTracker.Entries<KetQuaHocTap>()
                    .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added)
                    .ToList();

                int soLuongSVNhapMoi = 0;
                List<string> chiTietSuaDiem = new List<string>();

                foreach (var entry in changedEntries)
                {
                    string maSV = entry.Entity.MaSV;
                    bool chuaCoDiem = (entry.OriginalValues["DiemGK"] == null && entry.OriginalValues["DiemCK"] == null);

                    if (chuaCoDiem)
                    {
                        soLuongSVNhapMoi++;
                    }
                    else
                    {
                        List<string> thayDoi = new List<string>();
                        foreach (var prop in entry.OriginalValues.Properties)
                        {
                            if (prop.Name.Contains("Diem"))
                            {
                                var cu = entry.OriginalValues[prop]?.ToString();
                                var moi = entry.CurrentValues[prop]?.ToString();
                                if (cu != moi)
                                {
                                    thayDoi.Add($"{prop.Name}: {cu ?? "Trống"} -> {moi ?? "Trống"}");
                                }
                            }
                        }

                        if (thayDoi.Count > 0)
                        {
                            chiTietSuaDiem.Add($"SV {maSV}: " + string.Join(", ", thayDoi));
                        }
                    }
                }

                List<NhatKyHoatDong> danhSachLog = new List<NhatKyHoatDong>();

                if (soLuongSVNhapMoi > 0)
                {
                    danhSachLog.Add(new NhatKyHoatDong { NguoiDung = currentMaGV, ThoiGian = DateTime.Now, HanhDong = "Nhập điểm mới", ChiTiet = $"Đã nhập điểm mới cho {soLuongSVNhapMoi} sinh viên thuộc LHP: {currentLHP}." });
                }

                if (chiTietSuaDiem.Count > 0)
                {
                    danhSachLog.Add(new NhatKyHoatDong { NguoiDung = currentMaGV, ThoiGian = DateTime.Now, HanhDong = "Chỉnh sửa điểm", ChiTiet = $"Mã LHP: {currentLHP}\r\n" + string.Join("\r\n", chiTietSuaDiem) });
                }

                if (danhSachLog.Count > 0) dbChamDiem.NhatKyHoatDong.AddRange(danhSachLog);

                // =========================================================
                // BƯỚC 5: LƯU XUỐNG DATABASE
                // =========================================================
                await dbChamDiem.SaveChangesAsync();
                MessageBox.Show("Đã lưu và chốt bảng điểm thành công!", "Bảo mật & Học vụ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DgvDSSV.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // =========================================================
                // MỞ KHÓA GIAO DIỆN (LUÔN CHẠY DÙ CÓ LỖI HAY RETURN SỚM)
                // =========================================================
                btnLuuBangDiem.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnQuayLaiLop_Click(object sender, EventArgs e)
        {
            pnlDanhSachSV.Visible = false;
            flpDanhSachLop.Visible = true;
            panel1.Visible = true;
        }
        // Hàm này có nhiệm vụ tạo ra 1 "Thẻ" (GroupBox) chứa thông tin lớp học phần
        // Bạn sẽ gọi hàm này trong vòng lặp khi lấy dữ liệu từ CSDL
        private void TaoCardLopHocPhan(int maLHP, string tenMon, string hocKy, string phongHoc, int siSo)
        {
            // 1. Tạo GroupBox bên ngoài (Tăng kích thước lên cho thoáng)
            GroupBox gb = new GroupBox();
            gb.Text = $"Mã LHP: {maLHP} - {tenMon}";
            gb.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            gb.Size = new Size(385, 200); // Tăng chiều cao và chiều rộng
            gb.BackColor = Color.White;
            gb.ForeColor = Color.FromArgb(41, 128, 185); // Màu xanh dương hiện đại
            gb.Margin = new Padding(15);

            // 2. Tạo Label Học Kỳ (Thay cho Lớp Hành Chính)
            Label lblHocKy = new Label();
            lblHocKy.Text = $"{hocKy}";
            lblHocKy.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblHocKy.ForeColor = Color.Black;
            lblHocKy.Location = new Point(20, 45); // Tọa độ Y=45
            lblHocKy.AutoSize = true;

            gb.Controls.Add(lblHocKy);

            // 3. Tạo Label Phòng Học
            Label lblPhongHoc = new Label();
            lblPhongHoc.Text = $"Phòng học: {phongHoc}";
            lblPhongHoc.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblPhongHoc.ForeColor = Color.Black;
            lblPhongHoc.Location = new Point(20, 80); // Dãn cách xuống Y=80
            lblPhongHoc.AutoSize = true;
            gb.Controls.Add(lblPhongHoc);

            // 4. Tạo Label Sĩ số
            Label lblSiSo = new Label();
            lblSiSo.Text = $"Sĩ số: {siSo} Sinh viên";
            lblSiSo.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblSiSo.ForeColor = Color.Black;
            lblSiSo.Location = new Point(20, 115); // Dãn cách xuống Y=115
            lblSiSo.AutoSize = true;
            gb.Controls.Add(lblSiSo);

            // 5. Tạo Nút "Nhập Điểm" 
            Button btnNhapDiem = new Button();
            btnNhapDiem.Text = "Nhập Điểm";
            btnNhapDiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhapDiem.BackColor = Color.FromArgb(46, 204, 113); // Màu xanh lá
            btnNhapDiem.ForeColor = Color.White;
            btnNhapDiem.FlatStyle = FlatStyle.Flat;
            btnNhapDiem.FlatAppearance.BorderSize = 0;
            btnNhapDiem.Size = new Size(130, 40); // Nút to hơn dễ click
            btnNhapDiem.Location = new Point(230, 145); // Đặt ở góc dưới bên phải
            btnNhapDiem.Cursor = Cursors.Hand;

            // HIỆU ỨNG UX: Đổi màu khi rê chuột vào nút
            btnNhapDiem.MouseEnter += (s, e) => btnNhapDiem.BackColor = Color.FromArgb(39, 174, 96);
            btnNhapDiem.MouseLeave += (s, e) => btnNhapDiem.BackColor = Color.FromArgb(46, 204, 113);

            // Lưu Mã Lớp vào Tag để gọi dữ liệu
            btnNhapDiem.Tag = maLHP;
            btnNhapDiem.Click += BtnNhapDiem_Click;

            gb.Controls.Add(btnNhapDiem);
            flpDanhSachLop.Controls.Add(gb);
        }
        public async Task LoadDanhSachLopCuaToiAsync(string maGVDangNhap)
        {
            // Lưu lại mã GV để dùng cho các nút Lọc / Cbo Changed
            currentMaGV = maGVDangNhap;
            flpDanhSachLop.Controls.Clear();

            using (var context = new QuanLyDiemSV.Data.QLDSVDbContext())
            {
                // 1. Kéo dữ liệu cơ bản của GV đó lên
                var query = context.LopHocPhan
                                   .Include(l => l.MaMonNavigation)
                                   .Include(l => l.MaHKNavigation)
                                   .Where(l => l.MaGV == currentMaGV && l.TrangThai == 1)
                                   .AsQueryable();

                // 2. LỌC THEO HỌC KỲ (Nếu người dùng chọn khác "Tất cả")
                if (cboHocKy.SelectedValue != null && cboHocKy.SelectedValue.ToString() != "ALL")
                {
                    string maHK = cboHocKy.SelectedValue.ToString();
                    query = query.Where(l => l.MaHK == maHK);
                }

                // 3. TÌM KIẾM THEO TỪ KHÓA (Tìm trên Tên môn, Mã LHP, hoặc Phòng học)
                string tuKhoa = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(l => l.MaLHP.ToString().Contains(tuKhoa) ||
                                             (l.MaMonNavigation != null && l.MaMonNavigation.TenMon.ToLower().Contains(tuKhoa)) ||
                                             l.TenLopHP.ToLower().Contains(tuKhoa) ||
                                             l.PhongHoc.ToLower().Contains(tuKhoa));
                }

                var danhSachLop = await query.ToListAsync();

                if (danhSachLop.Count == 0)
                {
                    Label lblTrong = new Label();
                    lblTrong.Text = "Không tìm thấy lớp học phần nào phù hợp với điều kiện tìm kiếm.";
                    lblTrong.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                    lblTrong.AutoSize = true;
                    lblTrong.ForeColor = Color.Gray;
                    lblTrong.Margin = new Padding(20);
                    flpDanhSachLop.Controls.Add(lblTrong);
                    return;
                }

                // 4. Vẽ Card cho những lớp thỏa mãn
                foreach (var lhp in danhSachLop)
                {
                    int maLopHP = lhp.MaLHP;
                    string tenMon = lhp.MaMonNavigation != null ? lhp.MaMonNavigation.TenMon : "Chưa rõ môn";
                    string hocKy = string.IsNullOrEmpty(lhp.MaHK) ? "Chưa xác định" : lhp.MaHKNavigation?.TenHK ?? lhp.MaHK;
                    string phongHoc = string.IsNullOrEmpty(lhp.PhongHoc) ? "Chưa sắp xếp" : lhp.PhongHoc;
                    int siSo = lhp.SiSoToiDa ?? 0;

                    TaoCardLopHocPhan(maLopHP, tenMon, hocKy, phongHoc, siSo);
                }
            }
        }

        // Sự kiện khi Giảng viên bấm nút "Nhập Điểm" trên bất kỳ Card nào
        // Sự kiện khi Giảng viên bấm nút "Nhập Điểm" trên bất kỳ Card nào
        private void BtnNhapDiem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                currentLHP = (int)btn.Tag; // Lấy mã lớp học phần từ nút

                // Khởi tạo một Context MỚI để bắt đầu phiên theo dõi điểm
                dbChamDiem = new QLDSVDbContext();

                // TÍNH NĂNG MỚI: HIỂN THỊ TÊN LỚP LÊN GROUPBOX ĐỂ GV DỄ NHÌN
                var lhp = dbChamDiem.LopHocPhan.FirstOrDefault(x => x.MaLHP == currentLHP);
                if (lhp != null)
                {
                    groupBox1.Text = $"Danh Sách Sinh Viên - Môn: {lhp.TenLopHP} (Mã LHP: {lhp.MaLHP})";
                    groupBox1.ForeColor = Color.MediumBlue; // Cho chữ màu xanh dương nổi bật
                }

                // Khởi tạo ComboBox Tìm kiếm/Sắp xếp
                KhoiTaoCboTimKiemSapXep();

                // Tải danh sách có áp dụng Lọc/Sắp xếp
                LoadDanhSachSinhVienLop();

                // Hiện màn hình danh sách lên
                pnlDanhSachSV.BringToFront();
                pnlDanhSachSV.Visible = true;
            }
            panel1.Visible = false;
            flpDanhSachLop.Visible = false;
        }

        private void UC_GiangVien_ChamDiem_Load(object sender, EventArgs e)
        {
            LoadCboHocKy();
            flpDanhSachLop.Controls.Clear();

            // Cập nhật lại dữ liệu test (Học Kỳ và Phòng Học)
            TaoCardLopHocPhan(101, "Cơ sở dữ liệu", "HK1_2025_2026", "Phòng A1", 45);
            TaoCardLopHocPhan(102, "Lập trình Windows", "HK1_2025_2026", "Phòng A2", 42);
            TaoCardLopHocPhan(103, "Cấu trúc dữ liệu", "HK1_2025_2026", "Phòng B1", 50);
            TaoCardLopHocPhan(104, "Trí tuệ nhân tạo", "HK2_2025_2026", "Phòng B2", 30);
            TaoCardLopHocPhan(105, "Mạng máy tính", "HK2_2025_2026", "Phòng C1", 40);
        }
        // ==============================================================
        // HÀM TẢI DỮ LIỆU KÈM LỌC VÀ SẮP XẾP
        // ==============================================================
        private async void LoadDanhSachSinhVienLop()
        {
            // 1. Ổ KHÓA BẢO VỆ: Nếu đang truy vấn dở dang thì chặn lại ngay lập tức
            if (currentLHP == 0 || dbChamDiem == null || dangTruyVan) return;

            dangTruyVan = true; // Khóa cửa lại, không cho luồng khác chạy vào
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var query = dbChamDiem.KetQuaHocTap
                                      .Include(kq => kq.MaSVNavigation)
                                      .Where(kq => kq.MaLHP == currentLHP)
                                      .AsQueryable();

                string tuKhoa = txtTuKhoa.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa) && cboLoaiTK.SelectedIndex != -1)
                {
                    string loaiTK = cboLoaiTK.SelectedItem.ToString();
                    if (loaiTK == "Mã SV")
                        query = query.Where(q => q.MaSV.ToLower().Contains(tuKhoa));
                    else if (loaiTK == "Họ Tên")
                        query = query.Where(q => q.MaSVNavigation.HoTen.ToLower().Contains(tuKhoa));
                }

                bool isTang = radTang.Checked;
                if (cboKieuSX.SelectedIndex != -1)
                {
                    string kieuSX = cboKieuSX.SelectedItem.ToString();
                    switch (kieuSX)
                    {
                        case "Mã SV":
                            query = isTang ? query.OrderBy(q => q.MaSV) : query.OrderByDescending(q => q.MaSV);
                            break;
                        case "Họ Tên":
                            query = isTang ? query.OrderBy(q => q.MaSVNavigation.HoTen) : query.OrderByDescending(q => q.MaSVNavigation.HoTen);
                            break;
                        case "Điểm Tổng Kết":
                            query = isTang ? query.OrderBy(q => q.DiemTongKet) : query.OrderByDescending(q => q.DiemTongKet);
                            break;
                    }
                }

                // Đẩy công việc lấy dữ liệu sang luồng ngầm (Async)
                var dsSinhVien = await query.ToListAsync();

                lblSoLuongSV.Text = $"Số lượng: {dsSinhVien.Count} sinh viên";

                bsChamDiem.DataSource = dsSinhVien;
                DgvDSSV.AutoGenerateColumns = false;
                DgvDSSV.DataSource = bsChamDiem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 2. MỞ KHÓA BẢO VỆ: Dù code chạy thành công hay văng lỗi cũng phải mở khóa
                dangTruyVan = false;
                Cursor.Current = Cursors.Default;
            }
        }

        // ==============================================================
        // CÁC SỰ KIỆN NÚT BẤM (Đã được liên kết ở Constructor)
        // ==============================================================
        private void BtnTimKiem_Click(object sender, EventArgs e) => LoadDanhSachSinhVienLop();

        private void BtnHienTatCa_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            cboLoaiTK.SelectedIndex = 1;
            cboKieuSX.SelectedIndex = 0;
            radTang.Checked = true;

            dangCapNhatUI = false;
            LoadDanhSachSinhVienLop();

        }

        private void CboKieuSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangCapNhatUI) LoadDanhSachSinhVienLop();
        }

        private void RadTang_CheckedChanged(object sender, EventArgs e)
        {
            if (!dangCapNhatUI && radTang.Checked) LoadDanhSachSinhVienLop();
        }

        private void RadGiam_CheckedChanged(object sender, EventArgs e)
        {
            if (!dangCapNhatUI && radGiam.Checked) LoadDanhSachSinhVienLop();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentMaGV))
            {
                LoadDanhSachLopCuaToiAsync(currentMaGV);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentMaGV))
            {
                LoadDanhSachLopCuaToiAsync(currentMaGV);
            }
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaGV)) return;

            // Nếu không có lớp nào hiển thị trên FlowLayoutPanel
            if (flpDanhSachLop.Controls.Count == 0 || (flpDanhSachLop.Controls.Count == 1 && flpDanhSachLop.Controls[0] is Label))
            {
                MessageBox.Show("Không có lớp học phần nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachLopGiangDay.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var context = new QLDSVDbContext())
                        {
                            // Lấy lại danh sách theo đúng điều kiện đang lọc
                            var query = context.LopHocPhan.Include(l => l.MaMonNavigation).Include(l => l.MaHKNavigation)
                                               .Where(l => l.MaGV == currentMaGV && l.TrangThai == 1).AsQueryable();

                            if (cboHocKy.SelectedValue != null && cboHocKy.SelectedValue.ToString() != "ALL")
                                query = query.Where(l => l.MaHK == cboHocKy.SelectedValue.ToString());

                            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
                            if (!string.IsNullOrEmpty(tuKhoa))
                            {
                                query = query.Where(l => l.MaLHP.ToString().Contains(tuKhoa) ||
                                                         (l.MaMonNavigation != null && l.MaMonNavigation.TenMon.ToLower().Contains(tuKhoa)) ||
                                                         l.TenLopHP.ToLower().Contains(tuKhoa) || l.PhongHoc.ToLower().Contains(tuKhoa));
                            }

                            var dsLop = query.ToList();

                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                var worksheet = workbook.Worksheets.Add("LichGiangDay");
                                worksheet.Cell(1, 1).Value = "DANH SÁCH LỚP HỌC PHẦN ĐƯỢC PHÂN CÔNG";
                                worksheet.Cell(1, 1).Style.Font.Bold = true;
                                worksheet.Cell(1, 1).Style.Font.FontSize = 14;

                                int startRow = 3;
                                worksheet.Cell(startRow, 1).Value = "STT";
                                worksheet.Cell(startRow, 2).Value = "Mã LHP";
                                worksheet.Cell(startRow, 3).Value = "Tên Môn";
                                worksheet.Cell(startRow, 4).Value = "Nhóm/Tên Lớp HP";
                                worksheet.Cell(startRow, 5).Value = "Học Kỳ";
                                worksheet.Cell(startRow, 6).Value = "Phòng Học";
                                worksheet.Cell(startRow, 7).Value = "Sĩ Số";

                                worksheet.Range(startRow, 1, startRow, 7).Style.Font.Bold = true;
                                worksheet.Range(startRow, 1, startRow, 7).Style.Fill.BackgroundColor = XLColor.LightGray;

                                int row = startRow + 1;
                                int stt = 1;
                                foreach (var lhp in dsLop)
                                {
                                    worksheet.Cell(row, 1).Value = stt++;
                                    worksheet.Cell(row, 2).Value = lhp.MaLHP;
                                    worksheet.Cell(row, 3).Value = lhp.MaMonNavigation?.TenMon ?? "";
                                    worksheet.Cell(row, 4).Value = lhp.TenLopHP;
                                    worksheet.Cell(row, 5).Value = lhp.MaHKNavigation?.TenHK ?? lhp.MaHK;
                                    worksheet.Cell(row, 6).Value = lhp.PhongHoc;
                                    worksheet.Cell(row, 7).Value = lhp.SiSoToiDa;
                                    row++;
                                }
                                worksheet.Columns().AdjustToContents();
                                workbook.SaveAs(sfd.FileName);
                                MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (currentLHP == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học phần ở bên trái để xuất bảng điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"BangDiem_LHP_{currentLHP}.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Bảng Điểm");

                        // 1. Tạo Tiêu Đề
                        worksheet.Cell(1, 1).Value = "Mã SV";
                        worksheet.Cell(1, 2).Value = "Họ Tên";
                        worksheet.Cell(1, 3).Value = "Điểm Quá Trình";
                        worksheet.Cell(1, 4).Value = "Điểm Cuối Kỳ";
                        worksheet.Cell(1, 5).Value = "Điểm Lần 1 (Thi Lại)";
                        worksheet.Cell(1, 6).Value = "Điểm Lần 2 (Cải Thiện)";

                        var header = worksheet.Range("A1:F1");
                        header.Style.Font.Bold = true;
                        header.Style.Fill.BackgroundColor = XLColor.LightGray;

                        // 2. Đổ dữ liệu sinh viên trong lớp ra file
                        var dsSV = dbChamDiem.KetQuaHocTap
                                             .Include(k => k.MaSVNavigation)
                                             .Where(k => k.MaLHP == currentLHP)
                                             .ToList();
                        int row = 2;
                        foreach (var sv in dsSV)
                        {
                            worksheet.Cell(row, 1).Value = sv.MaSV;
                            worksheet.Cell(row, 2).Value = sv.MaSVNavigation.HoTen;
                            worksheet.Cell(row, 3).Value = sv.DiemGK;
                            worksheet.Cell(row, 4).Value = sv.DiemCK;
                            worksheet.Cell(row, 5).Value = sv.DiemThiLan1;
                            worksheet.Cell(row, 6).Value = sv.DiemThiLan2;
                            row++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất file Excel mẫu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        // Hàm hỗ trợ 1: Chuyển đổi thành decimal?
        private decimal? ParseDiemImport(string val)
        {
            if (string.IsNullOrWhiteSpace(val)) return null;
            if (decimal.TryParse(val, out decimal diem)) return diem;
            return -1m; // Chữ 'm' đại diện cho kiểu decimal
        }

        // Hàm hỗ trợ 2: Kiểm tra hợp lệ bằng decimal?
        private bool KiemTraHopLeImport(decimal? diem)
        {
            if (!diem.HasValue) return true;
            return diem.Value >= 0m && diem.Value <= 10m;
        }
        private async void btnNhapExcel_Click(object sender, EventArgs e)
        {
            if (currentLHP == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp học phần trước khi import điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", Title = "Chọn file bảng điểm đã nhập" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int soDongThanhCong = 0;
                    List<string> dsLoi = new List<string>();

                    using (var workbook = new XLWorkbook(ofd.FileName))
                    {
                        var worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Bỏ qua dòng Tiêu đề (Header)

                        // Lấy thông tin lớp và môn tiên quyết để kiểm tra
                        var lhpHienTai = await dbChamDiem.LopHocPhan.FirstOrDefaultAsync(x => x.MaLHP == currentLHP);
                        var listTienQuyet = await dbChamDiem.DieuKienMonHoc.Where(dk => dk.MaMon == lhpHienTai.MaMon).ToListAsync();

                        foreach (var row in rows)
                        {
                            string maSV = row.Cell(1).GetString().Trim();
                            if (string.IsNullOrEmpty(maSV)) continue;

                            var kqHocTap = bsChamDiem.List.OfType<KetQuaHocTap>().FirstOrDefault(k => k.MaSV == maSV);
                            if (kqHocTap == null)
                            {
                                dsLoi.Add($"- Dòng {row.RowNumber()}: SV [{maSV}] không có danh sách lớp này.");
                                continue;
                            }

                            // SỬA LỖI CS0266: Đổi double? thành decimal?
                            decimal? diemQT = ParseDiemImport(row.Cell(3).GetString());
                            decimal? diemCK = ParseDiemImport(row.Cell(4).GetString());
                            decimal? diemL1 = ParseDiemImport(row.Cell(5).GetString());
                            decimal? diemL2 = ParseDiemImport(row.Cell(6).GetString());

                            if (!KiemTraHopLeImport(diemQT) || !KiemTraHopLeImport(diemCK) || !KiemTraHopLeImport(diemL1) || !KiemTraHopLeImport(diemL2))
                            {
                                dsLoi.Add($"- Dòng {row.RowNumber()}: SV [{maSV}] điểm chứa chữ cái hoặc ngoài khoảng 0-10.");
                                continue;
                            }

                            if (diemQT != null || diemCK != null || diemL1 != null || diemL2 != null)
                            {
                                bool duDieuKien = true;
                                foreach (var dk in listTienQuyet)
                                {
                                    // SỬA LỖI CS8602: Thêm dấu ? an toàn vào k.MaLHPNavigation?.MaMon
                                    bool daQua = await dbChamDiem.KetQuaHocTap.AnyAsync(k => k.MaSV == maSV && k.MaLHPNavigation != null && k.MaLHPNavigation.MaMon == dk.MaMonTienQuyet && k.DiemTongKet != null);
                                    if (!daQua)
                                    {
                                        dsLoi.Add($"- Dòng {row.RowNumber()}: SV [{maSV}] CHƯA qua môn tiên quyết.");
                                        duDieuKien = false;
                                        break;
                                    }
                                }
                                if (!duDieuKien) continue;
                            }

                            kqHocTap.DiemGK = diemQT;
                            kqHocTap.DiemCK = diemCK;
                            kqHocTap.DiemThiLan1 = diemL1;
                            kqHocTap.DiemThiLan2 = diemL2;

                            soDongThanhCong++;
                        }

                        // Làm mới lưới DataGridView để GV nhìn thấy ngay số điểm vừa Import
                        bsChamDiem.ResetBindings(false);

                        // 6. Báo cáo tổng kết mượt mà
                        string thongBao = $"Đã nạp thành công điểm cho {soDongThanhCong} sinh viên lên lưới.\n\n*** LƯU Ý: Bạn cần bấm nút LƯU BẢNG ĐIỂM để xác nhận chốt điểm xuống cơ sở dữ liệu. ***\n";
                        if (dsLoi.Count > 0)
                        {
                            thongBao += $"\nCó {dsLoi.Count} dòng dữ liệu bị bỏ qua vì vi phạm quy chế:\n" + string.Join("\n", dsLoi.Take(10));
                            if (dsLoi.Count > 10) thongBao += "\n...(và một số lỗi khác)";

                            MessageBox.Show(thongBao, "Kết quả nạp Excel (Có cảnh báo)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(thongBao, "Import Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xử lý file Excel: Hãy đảm bảo bạn đã đóng file Excel trước khi Import.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
