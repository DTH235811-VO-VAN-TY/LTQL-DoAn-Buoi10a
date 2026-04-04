using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_NhatKyHoatDong : UserControl
    {
        public UC_NhatKyHoatDong()
        {
            InitializeComponent();
            this.Load += UC_NhatKyHoatDong_Load;

            // Đăng ký sự kiện nút bấm
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamLai.Click += BtnLamLai_Click;

            // Chạy hàm làm đẹp DataGridView quen thuộc của Tỷ
            StyleDataGridView(dgvNhatKyHoatDong);
        }

        private void UC_NhatKyHoatDong_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            KhoiTaoBoLoc();
            CauHinhCotGrid(); // Vẽ cột cho DataGridView bằng code
            LoadData();
        }

        // ==============================================================
        // 1. KHỞI TẠO DỮ LIỆU TÌM KIẾM
        // ==============================================================
        private void KhoiTaoBoLoc()
        {
            // Khởi tạo danh sách Hành động
            cboHanhDong.Items.Clear();
            cboHanhDong.Items.AddRange(new string[] { "--- Tất cả ---", "Nhập điểm mới", "Chỉnh sửa điểm" });
            cboHanhDong.SelectedIndex = 0;

            // Khởi tạo ngày tháng: Xem mặc định từ mùng 1 đầu tháng đến ngày hôm nay
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now.Date;
        }

        private void CauHinhCotGrid()
        {
            // 1. XÓA SẠCH CÁC CỘT CŨ (do lỡ tạo ngoài Designer hoặc do WinForms tự sinh)
            dgvNhatKyHoatDong.Columns.Clear();

            // 2. KHÓA CHỨC NĂNG TỰ ĐỘNG ĐẺ CỘT
            dgvNhatKyHoatDong.AutoGenerateColumns = false;

            // 3. TẠO LẠI CÁC CỘT CHUẨN
            dgvNhatKyHoatDong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaLog", HeaderText = "ID", Width = 60 });
            dgvNhatKyHoatDong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NguoiDung", HeaderText = "Người Dùng", Width = 150 });

            var colThoiGian = new DataGridViewTextBoxColumn { DataPropertyName = "ThoiGian", HeaderText = "Thời Gian", Width = 180 };
            colThoiGian.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvNhatKyHoatDong.Columns.Add(colThoiGian);

            dgvNhatKyHoatDong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HanhDong", HeaderText = "Hành Động", Width = 150 });

            // Ẩn nội dung dài bằng cách Fix cứng Width thay vì AutoSize Fill
            dgvNhatKyHoatDong.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ChiTiet", HeaderText = "Nội dung tóm tắt", Width = 300 });

            // 4. TẠO CỘT NÚT BẤM "XEM CHI TIẾT"
            DataGridViewButtonColumn btnXem = new DataGridViewButtonColumn();
            btnXem.Name = "XemChiTiet";
            btnXem.HeaderText = "Thao Tác";
            btnXem.Text = "Xem chi tiết";
            btnXem.UseColumnTextForButtonValue = true; // Bật cờ này thì chữ "Xem chi tiết" mới hiện lên nút
            btnXem.Width = 120;
            dgvNhatKyHoatDong.Columns.Add(btnXem);

            // Gắn sự kiện Click cho nút trên lưới (Tháo ra trước khi gắn để chống lỗi click đúp)
            dgvNhatKyHoatDong.CellClick -= DgvNhatKyHoatDong_CellClick;
            dgvNhatKyHoatDong.CellClick += DgvNhatKyHoatDong_CellClick;
        }
        private void DgvNhatKyHoatDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo click đúng cột nút bấm và không click vào tiêu đề
            if (e.RowIndex >= 0 && dgvNhatKyHoatDong.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                string hanhDong = dgvNhatKyHoatDong.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                string chiTiet = dgvNhatKyHoatDong.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";

                // Tự động "vẽ" một Form để hiển thị giống màn hình xác nhận mật khẩu
                Form frmDetail = new Form()
                {
                    Text = "Chi tiết " + hanhDong,
                    Width = 600,
                    Height = 400,
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                TextBox txtDetail = new TextBox()
                {
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Text = chiTiet,
                    Font = new Font("Segoe UI", 11),
                    ScrollBars = ScrollBars.Vertical,
                    Padding = new Padding(10)
                };

                frmDetail.Controls.Add(txtDetail);
                frmDetail.ShowDialog();
            }
        }

        // ==============================================================
        // 2. TRUY VẤN VÀ LỌC DỮ LIỆU
        // ==============================================================
        private void LoadData()
        {
            try
            {
                using (var db = new QLDSVDbContext())
                {
                    var query = db.NhatKyHoatDong.AsNoTracking().AsQueryable();

                    // Lọc 1: Theo Tên / Mã GV
                    string nguoiDung = txtTenNguoiDung.Text.Trim().ToLower();
                    if (!string.IsNullOrEmpty(nguoiDung))
                    {
                        query = query.Where(x => x.NguoiDung.ToLower().Contains(nguoiDung));
                    }

                    // Lọc 2: Theo Hành động
                    if (cboHanhDong.SelectedIndex > 0) // Loại trừ "--- Tất cả ---"
                    {
                        string hanhDong = cboHanhDong.SelectedItem.ToString();
                        query = query.Where(x => x.HanhDong == hanhDong);
                    }

                    // Lọc 3: Theo Khoảng thời gian
                    // Lưu ý: db lưu Giờ Phút Giây, nên "Đến Ngày" phải cộng thêm 1 ngày rồi trừ đi 1 giây để lấy đến tận 23:59:59 đêm
                    DateTime tuNgay = dtpTuNgay.Value.Date;
                    DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

                    query = query.Where(x => x.ThoiGian >= tuNgay && x.ThoiGian <= denNgay);

                    // Sắp xếp: Thời gian mới nhất hiện lên trên cùng
                    query = query.OrderByDescending(x => x.ThoiGian);

                    // Nạp vào lưới
                    var listLog = query.ToList();
                    dgvNhatKyHoatDong.DataSource = listLog;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhật ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // 3. SỰ KIỆN NÚT BẤM
        // ==============================================================
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            // Bắt lỗi ràng buộc ngày tháng
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Lỗi: 'Đến ngày' phải lớn hơn hoặc bằng 'Từ ngày'!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Chặn lại, không cho tìm kiếm
            }
            LoadData();
        }

        private void BtnLamLai_Click(object sender, EventArgs e)
        {
            txtTenNguoiDung.Clear();
            KhoiTaoBoLoc(); // Gọi lại hàm này để đưa Ngày và ComboBox về mặc định
            LoadData();
        }

        // ==============================================================
        // 4. LÀM ĐẸP GIAO DIỆN LƯỚI
        // ==============================================================
        private void StyleDataGridView(DataGridView dgv)
        {
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
                dgv, new object[] { true });

                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersHeight = 45;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
                dgv.RowsDefaultCellStyle.BackColor = Color.White;

                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                dgv.RowTemplate.Height = 40;

                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 230, 241);
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgv.GridColor = Color.FromArgb(200, 200, 200);

                // --- TÍNH NĂNG MỚI ĐỂ HIỂN THỊ LOG DÀI ---
                // Cho phép văn bản tự động xuống dòng trong ô nếu chuỗi chi tiết quá dài
                dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // Tự động giãn chiều cao của dòng để vừa khít với nội dung văn bản
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch { }
        }
    }
}