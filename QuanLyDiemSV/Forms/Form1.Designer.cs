namespace QuanLyDiemSV
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            btnCaiDat = new Button();
            btnDangXuat = new Button();
            btnTaiKhoan = new Button();
            btnTraCuuDiem = new Button();
            btnThongKe = new Button();
            btnMonHoc = new Button();
            btnDiemSV = new Button();
            btnLopHanhChinh = new Button();
            btnLopHocPhan = new Button();
            btnGiangVien = new Button();
            btnSinhVien = new Button();
            btnTrangChu = new Button();
            pnlTenNguoiDung = new Panel();
            btnDoiMatKhau = new Button();
            panel5 = new Panel();
            lblTenNguoiDung = new Label();
            lblVaiTro = new Label();
            panel4 = new Panel();
            btnNhatKyHoatDong = new Button();
            btnThongBao = new Button();
            panel2 = new Panel();
            uC_NhatKyHoatDong1 = new QuanLyDiemSV.Forms.UC_NhatKyHoatDong();
            uC_TrangChu1 = new QuanLyDiemSV.Forms.UC_TrangChu();
            uC_ThongKe1 = new QuanLyDiemSV.Forms.UC_ThongKe();
            uC_GiangVien_ChamDiem1 = new QuanLyDiemSV.Forms.UC_GiangVien_ChamDiem();
            uC_TraCuu_ChiTiet1 = new QuanLyDiemSV.Forms.UC_TraCuu_ChiTiet();
            uC_TraCuuDiem_Container1 = new QuanLyDiemSV.Forms.UC_TraCuuDiem_Container();
            uC_TaiKhoan1 = new QuanLyDiemSV.Forms.UC_TaiKhoan();
            uC_LopHanhChinh1 = new QuanLyDiemSV.Forms.UC_LopHanhChinh();
            uC_GiangVien1 = new QuanLyDiemSV.Forms.UC_GiangVien();
            uC_QuanLyDiem_Container1 = new QuanLyDiemSV.Forms.UC_QuanLyDiem_Container();
            uC_LopHocPhan1 = new UC_LopHocPhan();
            uC_Diem1 = new GUI.UC_Diem();
            uC_MonHoc1 = new GUI.UC_MonHoc();
            uC_SinhVien1 = new QuanLyDiemSV.Forms.UC_SinhVien();
            uC_Home1 = new UC_LopHocPhan();
            uC_CaiDat1 = new QuanLyDiemSV.Forms.UC_CaiDat();
            panel1.SuspendLayout();
            pnlTenNguoiDung.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(52, 73, 94);
            panel1.Controls.Add(btnCaiDat);
            panel1.Controls.Add(btnDangXuat);
            panel1.Controls.Add(btnTaiKhoan);
            panel1.Controls.Add(btnTraCuuDiem);
            panel1.Controls.Add(btnThongKe);
            panel1.Controls.Add(btnMonHoc);
            panel1.Controls.Add(btnDiemSV);
            panel1.Controls.Add(btnLopHanhChinh);
            panel1.Controls.Add(btnLopHocPhan);
            panel1.Controls.Add(btnGiangVien);
            panel1.Controls.Add(btnSinhVien);
            panel1.Controls.Add(btnTrangChu);
            panel1.Controls.Add(pnlTenNguoiDung);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(5, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 1025);
            panel1.TabIndex = 0;
            // 
            // btnCaiDat
            // 
            btnCaiDat.BackColor = Color.FromArgb(52, 73, 94);
            btnCaiDat.Dock = DockStyle.Top;
            btnCaiDat.FlatAppearance.BorderSize = 0;
            btnCaiDat.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnCaiDat.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnCaiDat.FlatStyle = FlatStyle.Flat;
            btnCaiDat.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCaiDat.ForeColor = SystemColors.ButtonHighlight;
            btnCaiDat.Image = (Image)resources.GetObject("btnCaiDat.Image");
            btnCaiDat.ImageAlign = ContentAlignment.MiddleLeft;
            btnCaiDat.Location = new Point(0, 826);
            btnCaiDat.Margin = new Padding(0);
            btnCaiDat.Name = "btnCaiDat";
            btnCaiDat.Size = new Size(220, 41);
            btnCaiDat.TabIndex = 14;
            btnCaiDat.Text = "               Cài Đặt";
            btnCaiDat.TextAlign = ContentAlignment.MiddleLeft;
            btnCaiDat.UseVisualStyleBackColor = false;
            btnCaiDat.Click += btnCaiDat_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.Salmon;
            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(0, 978);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(220, 47);
            btnDangXuat.TabIndex = 13;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.BackColor = Color.FromArgb(52, 73, 94);
            btnTaiKhoan.Dock = DockStyle.Top;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnTaiKhoan.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaiKhoan.ForeColor = SystemColors.ButtonHighlight;
            btnTaiKhoan.Image = (Image)resources.GetObject("btnTaiKhoan.Image");
            btnTaiKhoan.ImageAlign = ContentAlignment.MiddleLeft;
            btnTaiKhoan.Location = new Point(0, 759);
            btnTaiKhoan.Margin = new Padding(0);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(220, 67);
            btnTaiKhoan.TabIndex = 8;
            btnTaiKhoan.Text = "               Tài khoản";
            btnTaiKhoan.TextAlign = ContentAlignment.MiddleLeft;
            btnTaiKhoan.UseVisualStyleBackColor = false;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            // 
            // btnTraCuuDiem
            // 
            btnTraCuuDiem.BackColor = Color.FromArgb(52, 73, 94);
            btnTraCuuDiem.Dock = DockStyle.Top;
            btnTraCuuDiem.FlatAppearance.BorderSize = 0;
            btnTraCuuDiem.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnTraCuuDiem.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnTraCuuDiem.FlatStyle = FlatStyle.Flat;
            btnTraCuuDiem.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTraCuuDiem.ForeColor = SystemColors.ButtonHighlight;
            btnTraCuuDiem.Image = (Image)resources.GetObject("btnTraCuuDiem.Image");
            btnTraCuuDiem.ImageAlign = ContentAlignment.MiddleLeft;
            btnTraCuuDiem.Location = new Point(0, 692);
            btnTraCuuDiem.Margin = new Padding(0);
            btnTraCuuDiem.Name = "btnTraCuuDiem";
            btnTraCuuDiem.Size = new Size(220, 67);
            btnTraCuuDiem.TabIndex = 7;
            btnTraCuuDiem.Text = "               Tra cứu điểm";
            btnTraCuuDiem.TextAlign = ContentAlignment.MiddleLeft;
            btnTraCuuDiem.UseVisualStyleBackColor = false;
            btnTraCuuDiem.Click += btnTraCuuDiem_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.FromArgb(52, 73, 94);
            btnThongKe.Dock = DockStyle.Top;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnThongKe.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongKe.ForeColor = SystemColors.ButtonHighlight;
            btnThongKe.Image = (Image)resources.GetObject("btnThongKe.Image");
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(0, 625);
            btnThongKe.Margin = new Padding(0);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(220, 67);
            btnThongKe.TabIndex = 6;
            btnThongKe.Text = "               Thống kê";
            btnThongKe.TextAlign = ContentAlignment.MiddleLeft;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnMonHoc
            // 
            btnMonHoc.BackColor = Color.FromArgb(52, 73, 94);
            btnMonHoc.Dock = DockStyle.Top;
            btnMonHoc.FlatAppearance.BorderSize = 0;
            btnMonHoc.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnMonHoc.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnMonHoc.FlatStyle = FlatStyle.Flat;
            btnMonHoc.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMonHoc.ForeColor = SystemColors.ButtonHighlight;
            btnMonHoc.Image = (Image)resources.GetObject("btnMonHoc.Image");
            btnMonHoc.ImageAlign = ContentAlignment.MiddleLeft;
            btnMonHoc.Location = new Point(0, 558);
            btnMonHoc.Margin = new Padding(0);
            btnMonHoc.Name = "btnMonHoc";
            btnMonHoc.Size = new Size(220, 67);
            btnMonHoc.TabIndex = 5;
            btnMonHoc.Text = "               Môn học";
            btnMonHoc.TextAlign = ContentAlignment.MiddleLeft;
            btnMonHoc.UseVisualStyleBackColor = false;
            btnMonHoc.Click += btnMonHoc_Click;
            // 
            // btnDiemSV
            // 
            btnDiemSV.BackColor = Color.FromArgb(52, 73, 94);
            btnDiemSV.Dock = DockStyle.Top;
            btnDiemSV.FlatAppearance.BorderSize = 0;
            btnDiemSV.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnDiemSV.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnDiemSV.FlatStyle = FlatStyle.Flat;
            btnDiemSV.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDiemSV.ForeColor = SystemColors.ButtonHighlight;
            btnDiemSV.Image = (Image)resources.GetObject("btnDiemSV.Image");
            btnDiemSV.ImageAlign = ContentAlignment.MiddleLeft;
            btnDiemSV.Location = new Point(0, 491);
            btnDiemSV.Margin = new Padding(0);
            btnDiemSV.Name = "btnDiemSV";
            btnDiemSV.Size = new Size(220, 67);
            btnDiemSV.TabIndex = 4;
            btnDiemSV.Text = "               Điểm";
            btnDiemSV.TextAlign = ContentAlignment.MiddleLeft;
            btnDiemSV.UseVisualStyleBackColor = false;
            btnDiemSV.Click += btnDiemSV_Click;
            // 
            // btnLopHanhChinh
            // 
            btnLopHanhChinh.BackColor = Color.FromArgb(52, 73, 94);
            btnLopHanhChinh.Dock = DockStyle.Top;
            btnLopHanhChinh.FlatAppearance.BorderSize = 0;
            btnLopHanhChinh.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnLopHanhChinh.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnLopHanhChinh.FlatStyle = FlatStyle.Flat;
            btnLopHanhChinh.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLopHanhChinh.ForeColor = SystemColors.ButtonHighlight;
            btnLopHanhChinh.Image = (Image)resources.GetObject("btnLopHanhChinh.Image");
            btnLopHanhChinh.ImageAlign = ContentAlignment.MiddleLeft;
            btnLopHanhChinh.Location = new Point(0, 424);
            btnLopHanhChinh.Margin = new Padding(0);
            btnLopHanhChinh.Name = "btnLopHanhChinh";
            btnLopHanhChinh.Size = new Size(220, 67);
            btnLopHanhChinh.TabIndex = 12;
            btnLopHanhChinh.Text = "            Lớp Hành Chính";
            btnLopHanhChinh.UseVisualStyleBackColor = false;
            btnLopHanhChinh.Click += btnLopHanhChinh_Click;
            // 
            // btnLopHocPhan
            // 
            btnLopHocPhan.BackColor = Color.FromArgb(52, 73, 94);
            btnLopHocPhan.Dock = DockStyle.Top;
            btnLopHocPhan.FlatAppearance.BorderSize = 0;
            btnLopHocPhan.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnLopHocPhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnLopHocPhan.FlatStyle = FlatStyle.Flat;
            btnLopHocPhan.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLopHocPhan.ForeColor = SystemColors.ButtonHighlight;
            btnLopHocPhan.Image = (Image)resources.GetObject("btnLopHocPhan.Image");
            btnLopHocPhan.ImageAlign = ContentAlignment.MiddleLeft;
            btnLopHocPhan.Location = new Point(0, 357);
            btnLopHocPhan.Margin = new Padding(0);
            btnLopHocPhan.Name = "btnLopHocPhan";
            btnLopHocPhan.Size = new Size(220, 67);
            btnLopHocPhan.TabIndex = 3;
            btnLopHocPhan.Text = "               Lớp học phần";
            btnLopHocPhan.TextAlign = ContentAlignment.MiddleLeft;
            btnLopHocPhan.UseVisualStyleBackColor = false;
            btnLopHocPhan.Click += btnLopHocPhan_Click;
            // 
            // btnGiangVien
            // 
            btnGiangVien.BackColor = Color.FromArgb(52, 73, 94);
            btnGiangVien.Dock = DockStyle.Top;
            btnGiangVien.FlatAppearance.BorderSize = 0;
            btnGiangVien.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnGiangVien.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnGiangVien.FlatStyle = FlatStyle.Flat;
            btnGiangVien.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGiangVien.ForeColor = SystemColors.ButtonHighlight;
            btnGiangVien.Image = (Image)resources.GetObject("btnGiangVien.Image");
            btnGiangVien.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiangVien.Location = new Point(0, 290);
            btnGiangVien.Margin = new Padding(0);
            btnGiangVien.Name = "btnGiangVien";
            btnGiangVien.Size = new Size(220, 67);
            btnGiangVien.TabIndex = 11;
            btnGiangVien.Text = "        Giảng Viên";
            btnGiangVien.UseVisualStyleBackColor = false;
            btnGiangVien.Click += btnGiangVien_Click;
            // 
            // btnSinhVien
            // 
            btnSinhVien.BackColor = Color.FromArgb(52, 73, 94);
            btnSinhVien.Dock = DockStyle.Top;
            btnSinhVien.FlatAppearance.BorderSize = 0;
            btnSinhVien.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnSinhVien.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnSinhVien.FlatStyle = FlatStyle.Flat;
            btnSinhVien.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSinhVien.ForeColor = SystemColors.ButtonHighlight;
            btnSinhVien.Image = (Image)resources.GetObject("btnSinhVien.Image");
            btnSinhVien.ImageAlign = ContentAlignment.MiddleLeft;
            btnSinhVien.Location = new Point(0, 223);
            btnSinhVien.Margin = new Padding(0);
            btnSinhVien.Name = "btnSinhVien";
            btnSinhVien.Size = new Size(220, 67);
            btnSinhVien.TabIndex = 2;
            btnSinhVien.Text = "               Sinh Viên";
            btnSinhVien.TextAlign = ContentAlignment.MiddleLeft;
            btnSinhVien.UseVisualStyleBackColor = false;
            btnSinhVien.Click += btnSinhVien_Click;
            // 
            // btnTrangChu
            // 
            btnTrangChu.BackColor = Color.FromArgb(52, 73, 94);
            btnTrangChu.Dock = DockStyle.Top;
            btnTrangChu.FlatAppearance.BorderSize = 0;
            btnTrangChu.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnTrangChu.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrangChu.ForeColor = SystemColors.ButtonHighlight;
            btnTrangChu.Image = (Image)resources.GetObject("btnTrangChu.Image");
            btnTrangChu.ImageAlign = ContentAlignment.MiddleLeft;
            btnTrangChu.Location = new Point(0, 156);
            btnTrangChu.Margin = new Padding(0);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(220, 67);
            btnTrangChu.TabIndex = 10;
            btnTrangChu.Text = "   Trang chủ";
            btnTrangChu.UseVisualStyleBackColor = false;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // pnlTenNguoiDung
            // 
            pnlTenNguoiDung.Controls.Add(btnDoiMatKhau);
            pnlTenNguoiDung.Controls.Add(panel5);
            pnlTenNguoiDung.Controls.Add(lblTenNguoiDung);
            pnlTenNguoiDung.Controls.Add(lblVaiTro);
            pnlTenNguoiDung.Dock = DockStyle.Top;
            pnlTenNguoiDung.Location = new Point(0, 0);
            pnlTenNguoiDung.Name = "pnlTenNguoiDung";
            pnlTenNguoiDung.Size = new Size(220, 156);
            pnlTenNguoiDung.TabIndex = 0;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.BackColor = Color.Yellow;
            btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat;
            btnDoiMatKhau.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoiMatKhau.ForeColor = Color.Red;
            btnDoiMatKhau.Location = new Point(18, 95);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(128, 37);
            btnDoiMatKhau.TabIndex = 2;
            btnDoiMatKhau.Text = "Đổi Mật Khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = false;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(210, 218, 226);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 146);
            panel5.Name = "panel5";
            panel5.Size = new Size(220, 10);
            panel5.TabIndex = 1;
            // 
            // lblTenNguoiDung
            // 
            lblTenNguoiDung.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenNguoiDung.ForeColor = Color.Lime;
            lblTenNguoiDung.Location = new Point(9, 22);
            lblTenNguoiDung.Name = "lblTenNguoiDung";
            lblTenNguoiDung.Size = new Size(211, 23);
            lblTenNguoiDung.TabIndex = 0;
            lblTenNguoiDung.Text = "Tên Người Dùng";
            // 
            // lblVaiTro
            // 
            lblVaiTro.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVaiTro.ForeColor = Color.Fuchsia;
            lblVaiTro.Location = new Point(9, 56);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(211, 25);
            lblVaiTro.TabIndex = 0;
            lblVaiTro.Text = "Vai trò";
            // 
            // panel4
            // 
            panel4.BackColor = Color.DodgerBlue;
            panel4.Controls.Add(btnNhatKyHoatDong);
            panel4.Controls.Add(btnThongBao);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(225, 25);
            panel4.Name = "panel4";
            panel4.Size = new Size(1694, 71);
            panel4.TabIndex = 0;
            // 
            // btnNhatKyHoatDong
            // 
            btnNhatKyHoatDong.BackColor = Color.DodgerBlue;
            btnNhatKyHoatDong.FlatAppearance.BorderSize = 0;
            btnNhatKyHoatDong.FlatStyle = FlatStyle.Flat;
            btnNhatKyHoatDong.Image = (Image)resources.GetObject("btnNhatKyHoatDong.Image");
            btnNhatKyHoatDong.Location = new Point(1335, 11);
            btnNhatKyHoatDong.Name = "btnNhatKyHoatDong";
            btnNhatKyHoatDong.Size = new Size(76, 52);
            btnNhatKyHoatDong.TabIndex = 1;
            btnNhatKyHoatDong.UseVisualStyleBackColor = false;
            btnNhatKyHoatDong.Click += btnNhatKyHoatDong_Click;
            // 
            // btnThongBao
            // 
            btnThongBao.BackColor = Color.DodgerBlue;
            btnThongBao.FlatAppearance.BorderSize = 0;
            btnThongBao.FlatStyle = FlatStyle.Flat;
            btnThongBao.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongBao.ForeColor = Color.Yellow;
            btnThongBao.Location = new Point(1458, 12);
            btnThongBao.Name = "btnThongBao";
            btnThongBao.Size = new Size(213, 46);
            btnThongBao.TabIndex = 1;
            btnThongBao.Text = "🔔 Thông báo";
            btnThongBao.UseVisualStyleBackColor = false;
            btnThongBao.Click += btnThongBao_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(uC_NhatKyHoatDong1);
            panel2.Controls.Add(uC_TrangChu1);
            panel2.Controls.Add(uC_ThongKe1);
            panel2.Controls.Add(uC_GiangVien_ChamDiem1);
            panel2.Controls.Add(uC_TraCuu_ChiTiet1);
            panel2.Controls.Add(uC_TraCuuDiem_Container1);
            panel2.Controls.Add(uC_TaiKhoan1);
            panel2.Controls.Add(uC_LopHanhChinh1);
            panel2.Controls.Add(uC_GiangVien1);
            panel2.Controls.Add(uC_QuanLyDiem_Container1);
            panel2.Controls.Add(uC_LopHocPhan1);
            panel2.Controls.Add(uC_Diem1);
            panel2.Controls.Add(uC_MonHoc1);
            panel2.Controls.Add(uC_SinhVien1);
            panel2.Controls.Add(uC_Home1);
            panel2.Controls.Add(uC_CaiDat1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(225, 96);
            panel2.Name = "panel2";
            panel2.Size = new Size(1694, 954);
            panel2.TabIndex = 1;
            // 
            // uC_NhatKyHoatDong1
            // 
            uC_NhatKyHoatDong1.Dock = DockStyle.Fill;
            uC_NhatKyHoatDong1.Location = new Point(0, 0);
            uC_NhatKyHoatDong1.Name = "uC_NhatKyHoatDong1";
            uC_NhatKyHoatDong1.Padding = new Padding(10);
            uC_NhatKyHoatDong1.Size = new Size(1694, 954);
            uC_NhatKyHoatDong1.TabIndex = 14;
            // 
            // uC_TrangChu1
            // 
            uC_TrangChu1.Dock = DockStyle.Fill;
            uC_TrangChu1.Location = new Point(0, 0);
            uC_TrangChu1.Name = "uC_TrangChu1";
            uC_TrangChu1.Padding = new Padding(20);
            uC_TrangChu1.Size = new Size(1694, 954);
            uC_TrangChu1.TabIndex = 13;
            // 
            // uC_ThongKe1
            // 
            uC_ThongKe1.Dock = DockStyle.Fill;
            uC_ThongKe1.Location = new Point(0, 0);
            uC_ThongKe1.Name = "uC_ThongKe1";
            uC_ThongKe1.Size = new Size(1694, 954);
            uC_ThongKe1.TabIndex = 12;
            // 
            // uC_GiangVien_ChamDiem1
            // 
            uC_GiangVien_ChamDiem1.Dock = DockStyle.Fill;
            uC_GiangVien_ChamDiem1.Location = new Point(0, 0);
            uC_GiangVien_ChamDiem1.Name = "uC_GiangVien_ChamDiem1";
            uC_GiangVien_ChamDiem1.Size = new Size(1694, 954);
            uC_GiangVien_ChamDiem1.TabIndex = 11;
            // 
            // uC_TraCuu_ChiTiet1
            // 
            uC_TraCuu_ChiTiet1.Dock = DockStyle.Fill;
            uC_TraCuu_ChiTiet1.Location = new Point(0, 0);
            uC_TraCuu_ChiTiet1.Name = "uC_TraCuu_ChiTiet1";
            uC_TraCuu_ChiTiet1.Size = new Size(1694, 954);
            uC_TraCuu_ChiTiet1.TabIndex = 10;
            // 
            // uC_TraCuuDiem_Container1
            // 
            uC_TraCuuDiem_Container1.Dock = DockStyle.Fill;
            uC_TraCuuDiem_Container1.Location = new Point(0, 0);
            uC_TraCuuDiem_Container1.Name = "uC_TraCuuDiem_Container1";
            uC_TraCuuDiem_Container1.Size = new Size(1694, 954);
            uC_TraCuuDiem_Container1.TabIndex = 9;
            // 
            // uC_TaiKhoan1
            // 
            uC_TaiKhoan1.Dock = DockStyle.Fill;
            uC_TaiKhoan1.Location = new Point(0, 0);
            uC_TaiKhoan1.Name = "uC_TaiKhoan1";
            uC_TaiKhoan1.Size = new Size(1694, 954);
            uC_TaiKhoan1.TabIndex = 8;
            // 
            // uC_LopHanhChinh1
            // 
            uC_LopHanhChinh1.Dock = DockStyle.Fill;
            uC_LopHanhChinh1.Location = new Point(0, 0);
            uC_LopHanhChinh1.Name = "uC_LopHanhChinh1";
            uC_LopHanhChinh1.Size = new Size(1694, 954);
            uC_LopHanhChinh1.TabIndex = 7;
            // 
            // uC_GiangVien1
            // 
            uC_GiangVien1.Dock = DockStyle.Fill;
            uC_GiangVien1.Location = new Point(0, 0);
            uC_GiangVien1.Name = "uC_GiangVien1";
            uC_GiangVien1.Size = new Size(1694, 954);
            uC_GiangVien1.TabIndex = 6;
            // 
            // uC_QuanLyDiem_Container1
            // 
            uC_QuanLyDiem_Container1.Dock = DockStyle.Fill;
            uC_QuanLyDiem_Container1.Location = new Point(0, 0);
            uC_QuanLyDiem_Container1.Name = "uC_QuanLyDiem_Container1";
            uC_QuanLyDiem_Container1.Size = new Size(1694, 954);
            uC_QuanLyDiem_Container1.TabIndex = 5;
            // 
            // uC_LopHocPhan1
            // 
            uC_LopHocPhan1.Dock = DockStyle.Fill;
            uC_LopHocPhan1.Location = new Point(0, 0);
            uC_LopHocPhan1.Margin = new Padding(3, 4, 3, 4);
            uC_LopHocPhan1.Name = "uC_LopHocPhan1";
            uC_LopHocPhan1.Size = new Size(1694, 954);
            uC_LopHocPhan1.TabIndex = 4;
            // 
            // uC_Diem1
            // 
            uC_Diem1.Dock = DockStyle.Fill;
            uC_Diem1.Location = new Point(0, 0);
            uC_Diem1.Name = "uC_Diem1";
            uC_Diem1.Size = new Size(1694, 954);
            uC_Diem1.TabIndex = 3;
            // 
            // uC_MonHoc1
            // 
            uC_MonHoc1.Dock = DockStyle.Fill;
            uC_MonHoc1.Location = new Point(0, 0);
            uC_MonHoc1.Name = "uC_MonHoc1";
            uC_MonHoc1.Size = new Size(1694, 954);
            uC_MonHoc1.TabIndex = 2;
            // 
            // uC_SinhVien1
            // 
            uC_SinhVien1.Dock = DockStyle.Fill;
            uC_SinhVien1.Location = new Point(0, 0);
            uC_SinhVien1.Margin = new Padding(3, 4, 3, 4);
            uC_SinhVien1.Name = "uC_SinhVien1";
            uC_SinhVien1.Size = new Size(1694, 954);
            uC_SinhVien1.TabIndex = 1;
            // 
            // uC_Home1
            // 
            uC_Home1.Dock = DockStyle.Fill;
            uC_Home1.Location = new Point(0, 0);
            uC_Home1.Margin = new Padding(3, 4, 3, 4);
            uC_Home1.Name = "uC_Home1";
            uC_Home1.Size = new Size(1694, 954);
            uC_Home1.TabIndex = 0;
            // 
            // uC_CaiDat1
            // 
            uC_CaiDat1.Dock = DockStyle.Fill;
            uC_CaiDat1.Location = new Point(0, 0);
            uC_CaiDat1.Name = "uC_CaiDat1";
            uC_CaiDat1.Size = new Size(1694, 954);
            uC_CaiDat1.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(53, 45, 125);
            ClientSize = new Size(1924, 1055);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            Padding = new Padding(5, 25, 5, 5);
            Text = "HỆ THỐNG QUẢN LÝ ĐIỂM SINH VIÊN";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            pnlTenNguoiDung.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTenNguoiDung;
       
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private Button btnSinhVien;
        private Button btnMonHoc;
        private Button btnDiemSV;
        private Button btnLopHocPhan;
        private Button btnTaiKhoan;
        private Button btnTraCuuDiem;
        private Button btnThongKe;
        private Label lblVaiTro;
        private Panel panel5;
        private UC_LopHocPhan uC_Home1;
        private Forms.UC_SinhVien uC_SinhVien1;
        private GUI.UC_MonHoc uC_MonHoc1;
        private GUI.UC_Diem uC_Diem1;
        private UC_LopHocPhan uC_LopHocPhan1;
        private Button btnTrangChu;
        private Button btnLopHanhChinh;
        private Button btnGiangVien;
        private Forms.UC_QuanLyDiem_Container uC_QuanLyDiem_Container1;
        private Forms.UC_GiangVien uC_GiangVien1;
        private Forms.UC_LopHanhChinh uC_LopHanhChinh1;
        private Forms.UC_TaiKhoan uC_TaiKhoan1;
        private Forms.UC_TraCuuDiem_Container uC_TraCuuDiem_Container1;
        private Forms.UC_TraCuu_ChiTiet uC_TraCuu_ChiTiet1;
        private Button btnDangXuat;
        private Label lblTenNguoiDung;
        private Forms.UC_GiangVien_ChamDiem uC_GiangVien_ChamDiem1;
        private Forms.UC_ThongKe uC_ThongKe1;
        private Forms.UC_TrangChu uC_TrangChu1;
        private Button btnThongBao;
        private Button btnNhatKyHoatDong;
        private Button btnDoiMatKhau;
        private Forms.UC_NhatKyHoatDong uC_NhatKyHoatDong1;
        private Button btnCaiDat;
        private Forms.UC_CaiDat uC_CaiDat1;
    }
}

