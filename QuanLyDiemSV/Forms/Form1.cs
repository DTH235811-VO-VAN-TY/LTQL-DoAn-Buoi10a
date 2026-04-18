using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using GUI; // Namespace của UC_Diem
using QuanLyDiemSV.Data;
using QuanLyDiemSV.Forms; // Namespace của UC_Container


namespace QuanLyDiemSV
{
    public partial class Form1 : Form
    {
        Color normalColor = Color.FromArgb(52, 73, 94);
        Color activeColor = Color.DodgerBlue;
        private Button currentButton;
        private System.Windows.Forms.Timer timerThongBao;


        public Form1()
        {
            InitializeComponent();
            // uC_TraCuuDiem_Container1.AddTraCuuDiemClicked += UC_TraCuuDiem_Container1_AddTraCuuDiemClicked;
            uC_TraCuu_ChiTiet1.QuayLaiTraCuulicked += (s, e) =>
            {
                uC_TraCuuDiem_Container1.BringToFront();
            };
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

        private async void btnDiemSV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // Mặc định hiện Container trước, ẩn Diem đi
            uC_QuanLyDiem_Container1.Visible = true;
            uC_QuanLyDiem_Container1.BringToFront();
            uC_QuanLyDiem_Container1.CapNhatDuLieuMoiNhat();
            uC_Diem1.Visible = false;
        }

        // ... Các nút khác giữ nguyên code BringToFront của bạn ...
        private async void btnSinhVien_Click(object sender, EventArgs e)
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

        private async void btnLopHanhChinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_LopHanhChinh1.BringToFront();
            uC_LopHanhChinh1.CapNhatDuLieuMoiNhat();
        }

        private async void btnLopHocPhan_Click(object sender, EventArgs e)
        {
            if (Session.RoleID == 1)
            {
                ActivateButton(sender);
                uC_LopHocPhan1.BringToFront();
                uC_LopHocPhan1.CapNhatDuLieuMoiNhatAsync();
            }
            else if (Session.RoleID == 2)
            {
                ActivateButton(sender);
                uC_GiangVien_ChamDiem1.BringToFront();
                //uC_GiangVien_ChamDiem1.CapNhatDuLieuMoiNhat();
                uC_GiangVien_ChamDiem1.LoadDanhSachLopCuaToiAsync(Session.MaNguoiDung);
            }

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

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_CaiDat1.BringToFront();
        }

        private async void btnTraCuuDiem_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_TraCuuDiem_Container1.BringToFront();
            await uC_TraCuuDiem_Container1.CapNhatDuLieuMoiNhat();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị Vai trò
            string tenVaiTro = Session.RoleID == 1 ? "Admin" : Session.RoleID == 2 ? "Giảng viên" : "Sinh viên";
            lblVaiTro.Text = $"Vai trò: {tenVaiTro}";

            // 2. Tìm Họ Tên thực tế & Mã Người Dùng (Dựa vào UserID)
            string hoTenHienThi = Session.Username; // Mặc định hiển thị Username cho Admin

            try
            {
                using (var db = new QuanLyDiemSV.Data.QLDSVDbContext())
                {
                    if (Session.RoleID == 2) // Nếu là Giảng viên
                    {
                        // Dò bảng GiangVien xem ai đang cầm cái UserID này
                        var gv = db.GiangVien.FirstOrDefault(x => x.UserID == Session.UserID);
                        if (gv != null)
                        {
                            hoTenHienThi = gv.HoTen; // Cập nhật tên thật
                            Session.MaNguoiDung = gv.MaGV; // LƯU MÃ GV VÀO SESSION ĐỂ UC_GiangVien_ChamDiem SỬ DỤNG
                        }
                    }
                    else if (Session.RoleID == 3) // Nếu là Sinh viên
                    {
                        // Dò bảng SinhVien xem ai đang cầm cái UserID này
                        var sv = db.SinhVien.FirstOrDefault(x => x.UserID == Session.UserID);
                        if (sv != null)
                        {
                            hoTenHienThi = sv.HoTen; // Cập nhật tên thật
                            Session.MaNguoiDung = sv.MaSV; // LƯU MÃ SV VÀO SESSION ĐỂ TRA CỨU ĐIỂM SỬ DỤNG
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đồng bộ dữ liệu người dùng: " + ex.Message);
            }

            // Gán Họ Tên vào Label trên giao diện
            lblTenNguoiDung.Text = hoTenHienThi;

            // 3. Xử lý phân quyền 
            PhanQuyenTruyCap();

            uC_ThongKe1.Visible = true;

            // 4. Nếu là Sinh viên thì tự động chuyển sang tab Tra Cứu 
            if (Session.RoleID == 3)
            {
                btnTraCuuDiem.PerformClick();
            }
            if (Session.RoleID == 2)
            {
                uC_ThongKe1.Visible = true;
                uC_ThongKe1.BringToFront();

                // Đồng thời kích hoạt màu xanh cho nút Lớp Học Phần trên thanh Menu bên trái
                ActivateButton(btnLopHocPhan);
            }
            if (Session.RoleID == 1)
            {
                uC_ThongKe1.Visible = true;
                uC_ThongKe1.BringToFront();
            }
            if (Session.RoleID != 1)
            {
                // Ẩn hoàn toàn nút Nhật ký hoạt động đối với người không phải Admin
                btnNhatKyHoatDong.Visible = false;
            }
            KhoiTaoRadarThongBao();
        }
        private void KhoiTaoRadarThongBao()
        {
            timerThongBao = new System.Windows.Forms.Timer();
            timerThongBao.Interval = 5000; // Cứ 5 giây (5000ms) quét 1 lần
            timerThongBao.Tick += (s, e) => DemSoThongBaoMoi(); // CHỈ GỌI 1 HÀM DUY NHẤT
            timerThongBao.Start();

            DemSoThongBaoMoi(); // Chạy ngay lần đầu tiên
        }
        private async void DemSoThongBaoMoi()
        {
            try
            {
                using (var context = new QLDSVDbContext())
                {
                    int soThongBao = 0;

                    if (Session.RoleID == 2) // GIẢNG VIÊN: Đếm đơn chờ xử lý trong bảng DonKhieuNai
                    {
                        soThongBao = await context.DonKhieuNai
                            .CountAsync(d => d.TrangThai == 0 && d.MaLHPNavigation.MaGV == Session.MaNguoiDung);
                    }
                    else if (Session.RoleID == 1) // ADMIN: Đếm đơn giảng viên xin sửa điểm
                    {
                        soThongBao = await context.YeuCauSuaDiem.CountAsync(y => y.TrangThai == 0);
                    }
                    else if (Session.RoleID == 3) // SINH VIÊN: Đếm phản hồi trong bảng ThongBao
                    {
                        // Thay vì đếm DonKhieuNai như cũ, giờ Sinh viên sẽ đếm trong bảng ThongBao
                        soThongBao = await context.ThongBaos
                            .CountAsync(t => t.MaNguoiNhan == Session.MaNguoiDung && t.DaDoc == false);
                    }

                    // CẬP NHẬT GIAO DIỆN NÚT CHUÔNG
                    if (soThongBao > 0)
                    {
                        btnThongBao.Text = $"🔔 Thông báo ({soThongBao})";
                        btnThongBao.BackColor = Color.Crimson; // Đổi nền đỏ
                        btnThongBao.ForeColor = Color.White;
                    }
                    else
                    {
                        btnThongBao.Text = "🔔 Thông báo (0)";
                        btnThongBao.BackColor = normalColor; // Trả về màu nền mặc định của thanh menu
                        btnThongBao.ForeColor = Color.White;
                    }
                }
            }
            catch { /* Bỏ qua nếu lỗi mạng để không làm gián đoạn phần mềm */ }
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
            btnThongKe.Visible = false; // Nếu bạn có nút thống kê

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
                    btnThongKe.Visible = true;
                    break;

                case 2: // GIẢNG VIÊN - Chỉ Mở Nhập điểm, Tra cứu, Thống kê
                    //btnDiemSV.Visible = true;
                    btnTraCuuDiem.Visible = true;
                    btnLopHocPhan.Visible = true;
                    btnTrangChu.Visible = true;
                    //btnThongKe.Visible = true; 
                    break;

                case 3: // SINH VIÊN - Chỉ Mở Tra cứu
                    btnTraCuuDiem.Visible = true;
                    btnTrangChu.Visible = true;
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //uC_GiangVien_ChamDiem1.BringToFront();
            uC_TrangChu1.BringToFront();
        }

        private async void btnTrangChu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            //uC_GiangVien_ChamDiem1.BringToFront();
            uC_ThongKe1.BringToFront();
        }
        // Viết hàm này ở Form có nút Thông báo


        private void btnThongBao_Click(object sender, EventArgs e)
        {
            if (Session.RoleID == 2) // Nếu là Giảng viên bấm chuông
            {
                using (FrmQuanLyKhieuNai frm = new FrmQuanLyKhieuNai())
                {
                    frm.ShowDialog();
                }

                // Sau khi Form Quản lý đóng lại, gọi hàm quét radar để update lại số đếm trên chuông ngay lập tức
                DemSoThongBaoMoi();
            }
            else if (Session.RoleID == 1) // Nếu là Admin bấm chuông
            {
                using (FrmQuanLyYeuCauSuaDiem frm = new FrmQuanLyYeuCauSuaDiem())
                {
                    frm.ShowDialog();
                }
                DemSoThongBaoMoi();
            }
            else if (Session.RoleID == 3) // Nếu là Sinh viên bấm chuông
            {
                // Gọi Form xem thông báo của sinh viên
                using (FrmThongBaoSinhVien frm = new FrmThongBaoSinhVien())
                {
                    frm.ShowDialog();
                }

                // Sau khi SV đóng form thông báo (có thể đã xem một số cái), update lại chuông báo
                DemSoThongBaoMoi();

            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhaucs frmDoiMatKhaucs = new FrmDoiMatKhaucs();
            frmDoiMatKhaucs.ShowDialog();
        }

        private void btnNhatKyHoatDong_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_NhatKyHoatDong1.BringToFront();
        }
    }
}