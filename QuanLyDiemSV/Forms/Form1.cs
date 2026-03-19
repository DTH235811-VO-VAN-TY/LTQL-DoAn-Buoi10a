using System;
using System.Drawing;
using System.Windows.Forms;
using GUI; // Namespace của UC_Diem
using QuanLyDiemSV.Forms; // Namespace của UC_Container

namespace QuanLyDiemSV
{
    public partial class Form1 : Form
    {
        Color normalColor = Color.FromArgb(52, 73, 94);
        Color activeColor = Color.DodgerBlue;
        private Button currentButton;

        public Form1()
        {
            InitializeComponent();
            // uC_TraCuuDiem_Container1.AddTraCuuDiemClicked += UC_TraCuuDiem_Container1_AddTraCuuDiemClicked;
            uC_TraCuu_ChiTiet1.QuayLaiTraCuulicked += (s, e) =>
            {
                uC_TraCuuDiem_Container1.BringToFront();
            };

            // --- SỬA LỖI Ở ĐÂY: KẾT NỐI 2 FORM CON ---
            // Phần này phải viết trong Constructor (sau InitializeComponent)

            // 1. Khi bấm "Nhập điểm" ở Container -> Chuyển dữ liệu sang uC_Diem1
            uC_QuanLyDiem_Container1.OnChuyenManHinhNhapDiem += (maSV) =>
            {
                // Truyền mã SV sang
                uC_Diem1.LoadThongTinSinhVien(maSV);

                // Hiển thị uC_Diem1 lên
                uC_Diem1.Visible = true;
                uC_Diem1.BringToFront();

                // Ẩn Container đi (nếu muốn)
                uC_QuanLyDiem_Container1.Visible = false;
            };

            // 2. Khi bấm "Quay lại" ở uC_Diem1 -> Hiện lại Container
            uC_Diem1.OnQuayLai += () =>
            {
                uC_QuanLyDiem_Container1.Visible = true;
                uC_QuanLyDiem_Container1.BringToFront();
                uC_Diem1.Visible = false;
            };
        }

        private void UC_TraCuuDiem_Container1_AddTraCuuDiemClicked(object? sender, EventArgs e)
        {
            //
            uC_TraCuu_ChiTiet1.BringToFront();
        }

        // --- CÁC NÚT MENU ---

        private void btnDiemSV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // Mặc định hiện Container trước, ẩn Diem đi
            uC_QuanLyDiem_Container1.Visible = true;
            uC_QuanLyDiem_Container1.BringToFront();
            uC_QuanLyDiem_Container1.CapNhatDuLieuMoiNhat();
            uC_Diem1.Visible = false;
        }

        // ... Các nút khác giữ nguyên code BringToFront của bạn ...
        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_SinhVien1.BringToFront();
            uC_SinhVien1.CapNhatDuLieuMoiNhat();
            //  uC_SinhVien1.LoadDuLieuSinhVien();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_MonHoc1.BringToFront();
        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_GiangVien1.BringToFront();
            // uC_GiangVien1.LoadData();
        }

        private void btnLopHanhChinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_LopHanhChinh1.BringToFront();
            uC_LopHanhChinh1.CapNhatDuLieuMoiNhat();
        }

        private void btnLopHocPhan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_LopHocPhan1.BringToFront();
            uC_LopHocPhan1.CapNhatDuLieuMoiNhat();
        }

        // --- XỬ LÝ MÀU SẮC ---
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = activeColor;
                    // CHỈ đổi sang màu xanh (activeColor) nếu nút đó KHÔNG PHẢI là nút Đăng xuất
                    if (currentButton.Text != "Đăng xuất")
                    {
                        currentButton.BackColor = activeColor;
                    }
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                // Trả về màu mặc định(normalColor), nhưng BỎ QUA nút Đăng xuất
                if (previousBtn.GetType() == typeof(Button) && previousBtn.Text != "Đăng xuất")
                {
                    previousBtn.BackColor = normalColor;
                }
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_TaiKhoan1.BringToFront();
        }

        private void btnTraCuuDiem_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_TraCuuDiem_Container1.BringToFront();
            uC_TraCuuDiem_Container1.CapNhatDuLieuMoiNhat();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị Vai trò
            string tenVaiTro = Session.RoleID == 1 ? "Admin" : Session.RoleID == 2 ? "Giảng viên" : "Sinh viên";
            lblVaiTro.Text = $"Vai trò: {tenVaiTro}";

            // 2. Tìm Họ Tên thực tế từ Database dựa vào Mã người dùng đang đăng nhập
            string hoTenHienThi = Session.Username; // Mặc định dùng Username (Dành cho Admin)

            try
            {
                using (var db = new QuanLyDiemSV.Data.QLDSVDbContext())
                {
                    if (Session.RoleID == 2) // Nếu là Giảng viên
                    {
                        var gv = db.GiangVien.FirstOrDefault(x => x.MaGV == Session.MaNguoiDung);
                        if (gv != null) hoTenHienThi = gv.HoTen; // Lấy tên GV
                    }
                    else if (Session.RoleID == 3) // Nếu là Sinh viên
                    {
                        var sv = db.SinhVien.FirstOrDefault(x => x.MaSV == Session.MaNguoiDung);
                        if (sv != null) hoTenHienThi = sv.HoTen; // Lấy tên SV
                    }
                }
            }
            catch { }

            // Gán Họ Tên vào Label
            lblTenNguoiDung.Text = hoTenHienThi;

            // 3. Xử lý phân quyền 
            PhanQuyenTruyCap();

            // 4. Nếu là Sinh viên thì tự động chuyển sang tab Tra Cứu 
            if (Session.RoleID == 3)
            {
                btnTraCuuDiem.PerformClick();
            }
        }
        private void PhanQuyenTruyCap()
        {
            // MẶC ĐỊNH: Ẩn tất cả các module quản lý, chỉ để lại Trang chủ và Tài khoản
            btnSinhVien.Visible = false;
            btnGiangVien.Visible = false;
            btnLopHanhChinh.Visible = false;
            btnLopHocPhan.Visible = false;
            btnMonHoc.Visible = false;
            btnDiemSV.Visible = false;
            btnTraCuuDiem.Visible = false;
            btnTaiKhoan.Visible = false;
            // btnThongKe.Visible = false; // Nếu bạn có nút thống kê

            switch (Session.RoleID)
            {
                case 1: // ADMIN - Mở tất cả
                    btnSinhVien.Visible = true;
                    btnGiangVien.Visible = true;
                    btnLopHanhChinh.Visible = true;
                    btnLopHocPhan.Visible = true;
                    btnMonHoc.Visible = true;
                    btnDiemSV.Visible = true; // Vẫn cho vào form Nhập điểm (sẽ khóa nút bên trong sau)
                    btnTraCuuDiem.Visible = true;
                    btnTaiKhoan.Visible = true;
                    break;

                case 2: // GIẢNG VIÊN - Chỉ Mở Nhập điểm, Tra cứu, Thống kê
                    btnDiemSV.Visible = true;
                    btnTraCuuDiem.Visible = true;
                    // btnThongKe.Visible = true; 
                    break;

                case 3: // SINH VIÊN - Chỉ Mở Tra cứu
                    btnTraCuuDiem.Visible = true;
                    break;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa sạch dữ liệu phiên làm việc cũ
                Session.UserID = 0;
                Session.Username = null;
                Session.RoleID = 0;
                Session.MaNguoiDung = null;

                // Khởi động lại toàn bộ ứng dụng (Quay về FrmLogin như lúc mới bật app)
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
}