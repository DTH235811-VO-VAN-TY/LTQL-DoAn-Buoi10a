namespace QuanLyDiemSV
{
    partial class UC_SinhVien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_SinhVien));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelInput = new Panel();
            groupBoxInfo = new GroupBox();
            dtpAdNamSinhSV = new DateTimePicker();
            radAdSV_Nu = new RadioButton();
            radAdSV_Nam = new RadioButton();
            txtAdSV_Khoa = new TextBox();
            txtAdSV_Email = new TextBox();
            txtAdSV_ChuyenNganh = new TextBox();
            label13 = new Label();
            txtAdSV_DiaChi = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnNhap = new Button();
            btnAdSua_SV = new Button();
            btnAdLamLai_SV = new Button();
            txtAdSV_NienKhoa = new TextBox();
            btnAdLua_SV = new Button();
            btnAdThem_SV = new Button();
            label1 = new Label();
            label23 = new Label();
            btnXuat = new Button();
            btnAdXoa_SV = new Button();
            txtAdCCCDsv = new TextBox();
            txtAdMaSV = new TextBox();
            txtAdHoTenSV = new TextBox();
            cboAdSV_TenLop = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtAdSDT_SV = new TextBox();
            label6 = new Label();
            panelSearch = new Panel();
            groupBoxSearch = new GroupBox();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            cboKieuSX = new ComboBox();
            label14 = new Label();
            txtAdTuKhoa_SV = new TextBox();
            label11 = new Label();
            label12 = new Label();
            cboAdTimKiem_SV = new ComboBox();
            btnAdShowAll_SV = new Button();
            btnAdTimKiem_SV = new Button();
            panelGrid = new Panel();
            groupBoxList = new GroupBox();
            dgvAdminSinhVien = new DataGridView();
            helpProvider1 = new HelpProvider();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            CCCD = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            MaLop = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            panelInput.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            panelSearch.SuspendLayout();
            groupBoxSearch.SuspendLayout();
            panelGrid.SuspendLayout();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdminSinhVien).BeginInit();
            SuspendLayout();
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(groupBoxInfo);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(0, 0);
            panelInput.Margin = new Padding(3, 4, 3, 4);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(10, 12, 10, 12);
            panelInput.Size = new Size(1694, 350);
            panelInput.TabIndex = 1;
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.BackColor = Color.White;
            groupBoxInfo.Controls.Add(dtpAdNamSinhSV);
            groupBoxInfo.Controls.Add(radAdSV_Nu);
            groupBoxInfo.Controls.Add(radAdSV_Nam);
            groupBoxInfo.Controls.Add(txtAdSV_Khoa);
            groupBoxInfo.Controls.Add(txtAdSV_Email);
            groupBoxInfo.Controls.Add(txtAdSV_ChuyenNganh);
            groupBoxInfo.Controls.Add(label13);
            groupBoxInfo.Controls.Add(txtAdSV_DiaChi);
            groupBoxInfo.Controls.Add(label2);
            groupBoxInfo.Controls.Add(label3);
            groupBoxInfo.Controls.Add(label4);
            groupBoxInfo.Controls.Add(label5);
            groupBoxInfo.Controls.Add(btnNhap);
            groupBoxInfo.Controls.Add(btnAdSua_SV);
            groupBoxInfo.Controls.Add(btnAdLamLai_SV);
            groupBoxInfo.Controls.Add(txtAdSV_NienKhoa);
            groupBoxInfo.Controls.Add(btnAdLua_SV);
            groupBoxInfo.Controls.Add(btnAdThem_SV);
            groupBoxInfo.Controls.Add(label1);
            groupBoxInfo.Controls.Add(label23);
            groupBoxInfo.Controls.Add(btnXuat);
            groupBoxInfo.Controls.Add(btnAdXoa_SV);
            groupBoxInfo.Controls.Add(txtAdCCCDsv);
            groupBoxInfo.Controls.Add(txtAdMaSV);
            groupBoxInfo.Controls.Add(txtAdHoTenSV);
            groupBoxInfo.Controls.Add(cboAdSV_TenLop);
            groupBoxInfo.Controls.Add(label10);
            groupBoxInfo.Controls.Add(label9);
            groupBoxInfo.Controls.Add(label8);
            groupBoxInfo.Controls.Add(label7);
            groupBoxInfo.Controls.Add(txtAdSDT_SV);
            groupBoxInfo.Controls.Add(label6);
            groupBoxInfo.Dock = DockStyle.Fill;
            groupBoxInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxInfo.Location = new Point(10, 12);
            groupBoxInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Padding = new Padding(3, 4, 3, 4);
            groupBoxInfo.Size = new Size(1674, 326);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "Thông tin sinh viên";
            // 
            // dtpAdNamSinhSV
            // 
            dtpAdNamSinhSV.Format = DateTimePickerFormat.Custom;
            helpProvider1.SetHelpString(dtpAdNamSinhSV, "Sinh Vien phải đủ 18 tuổi");
            dtpAdNamSinhSV.Location = new Point(171, 94);
            dtpAdNamSinhSV.Margin = new Padding(3, 4, 3, 4);
            dtpAdNamSinhSV.Name = "dtpAdNamSinhSV";
            helpProvider1.SetShowHelp(dtpAdNamSinhSV, true);
            dtpAdNamSinhSV.Size = new Size(400, 27);
            dtpAdNamSinhSV.TabIndex = 2;
            // 
            // radAdSV_Nu
            // 
            radAdSV_Nu.AutoSize = true;
            radAdSV_Nu.Location = new Point(249, 199);
            radAdSV_Nu.Margin = new Padding(3, 4, 3, 4);
            radAdSV_Nu.Name = "radAdSV_Nu";
            radAdSV_Nu.Size = new Size(52, 24);
            radAdSV_Nu.TabIndex = 6;
            radAdSV_Nu.Text = "Nữ";
            radAdSV_Nu.UseVisualStyleBackColor = true;
            // 
            // radAdSV_Nam
            // 
            radAdSV_Nam.AutoSize = true;
            radAdSV_Nam.Checked = true;
            radAdSV_Nam.Location = new Point(182, 199);
            radAdSV_Nam.Margin = new Padding(3, 4, 3, 4);
            radAdSV_Nam.Name = "radAdSV_Nam";
            radAdSV_Nam.Size = new Size(64, 24);
            radAdSV_Nam.TabIndex = 5;
            radAdSV_Nam.TabStop = true;
            radAdSV_Nam.Text = "Nam";
            radAdSV_Nam.UseVisualStyleBackColor = true;
            // 
            // txtAdSV_Khoa
            // 
            txtAdSV_Khoa.Location = new Point(823, 226);
            txtAdSV_Khoa.Margin = new Padding(3, 4, 3, 4);
            txtAdSV_Khoa.Name = "txtAdSV_Khoa";
            txtAdSV_Khoa.Size = new Size(400, 27);
            txtAdSV_Khoa.TabIndex = 11;
            // 
            // txtAdSV_Email
            // 
            helpProvider1.SetHelpString(txtAdSV_Email, "VD: abc@gmail.com");
            txtAdSV_Email.Location = new Point(823, 176);
            txtAdSV_Email.Margin = new Padding(3, 4, 3, 4);
            txtAdSV_Email.Name = "txtAdSV_Email";
            helpProvider1.SetShowHelp(txtAdSV_Email, true);
            txtAdSV_Email.Size = new Size(400, 27);
            txtAdSV_Email.TabIndex = 10;
            // 
            // txtAdSV_ChuyenNganh
            // 
            txtAdSV_ChuyenNganh.Location = new Point(823, 76);
            txtAdSV_ChuyenNganh.Margin = new Padding(3, 4, 3, 4);
            txtAdSV_ChuyenNganh.Name = "txtAdSV_ChuyenNganh";
            txtAdSV_ChuyenNganh.Size = new Size(400, 27);
            txtAdSV_ChuyenNganh.TabIndex = 8;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(763, 229);
            label13.Name = "label13";
            label13.Size = new Size(49, 20);
            label13.TabIndex = 123;
            label13.Text = "Khoa:";
            // 
            // txtAdSV_DiaChi
            // 
            txtAdSV_DiaChi.Location = new Point(170, 231);
            txtAdSV_DiaChi.Margin = new Padding(3, 4, 3, 4);
            txtAdSV_DiaChi.Name = "txtAdSV_DiaChi";
            txtAdSV_DiaChi.PlaceholderText = "Địa chỉ";
            txtAdSV_DiaChi.Size = new Size(550, 27);
            txtAdSV_DiaChi.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(758, 179);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 123;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(726, 129);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 124;
            label3.Text = "Niên khóa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(695, 79);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 125;
            label4.Text = "Chuyên Ngành:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(741, 29);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 126;
            label5.Text = "Tên Lớp:";
            // 
            // btnNhap
            // 
            btnNhap.BackColor = Color.White;
            btnNhap.FlatStyle = FlatStyle.Flat;
            btnNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhap.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhap.Location = new Point(903, 271);
            btnNhap.Margin = new Padding(3, 4, 3, 4);
            btnNhap.Name = "btnNhap";
            btnNhap.Padding = new Padding(10, 0, 0, 0);
            btnNhap.Size = new Size(149, 44);
            btnNhap.TabIndex = 16;
            btnNhap.Text = "Nhập..";
            btnNhap.UseVisualStyleBackColor = false;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnAdSua_SV
            // 
            btnAdSua_SV.BackColor = Color.White;
            btnAdSua_SV.FlatStyle = FlatStyle.Flat;
            btnAdSua_SV.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdSua_SV.Image = (Image)resources.GetObject("btnAdSua_SV.Image");
            btnAdSua_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdSua_SV.Location = new Point(571, 271);
            btnAdSua_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdSua_SV.Name = "btnAdSua_SV";
            btnAdSua_SV.Padding = new Padding(10, 0, 0, 0);
            btnAdSua_SV.Size = new Size(149, 44);
            btnAdSua_SV.TabIndex = 16;
            btnAdSua_SV.Text = "Sửa";
            btnAdSua_SV.UseVisualStyleBackColor = false;
            btnAdSua_SV.Click += btnAdSua_SV_Click;
            // 
            // btnAdLamLai_SV
            // 
            btnAdLamLai_SV.BackColor = Color.White;
            btnAdLamLai_SV.FlatStyle = FlatStyle.Flat;
            btnAdLamLai_SV.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdLamLai_SV.Image = (Image)resources.GetObject("btnAdLamLai_SV.Image");
            btnAdLamLai_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdLamLai_SV.Location = new Point(401, 271);
            btnAdLamLai_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdLamLai_SV.Name = "btnAdLamLai_SV";
            btnAdLamLai_SV.Padding = new Padding(10, 0, 0, 0);
            btnAdLamLai_SV.Size = new Size(149, 44);
            btnAdLamLai_SV.TabIndex = 15;
            btnAdLamLai_SV.Text = "Làm lại";
            btnAdLamLai_SV.UseVisualStyleBackColor = false;
            btnAdLamLai_SV.Click += btnAdLamLai_SV_Click;
            // 
            // txtAdSV_NienKhoa
            // 
            txtAdSV_NienKhoa.Location = new Point(823, 126);
            txtAdSV_NienKhoa.Margin = new Padding(3, 4, 3, 4);
            txtAdSV_NienKhoa.Name = "txtAdSV_NienKhoa";
            txtAdSV_NienKhoa.Size = new Size(200, 27);
            txtAdSV_NienKhoa.TabIndex = 9;
            // 
            // btnAdLua_SV
            // 
            btnAdLua_SV.BackColor = Color.White;
            btnAdLua_SV.FlatStyle = FlatStyle.Flat;
            btnAdLua_SV.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdLua_SV.Image = (Image)resources.GetObject("btnAdLua_SV.Image");
            btnAdLua_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdLua_SV.Location = new Point(45, 271);
            btnAdLua_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdLua_SV.Name = "btnAdLua_SV";
            btnAdLua_SV.Padding = new Padding(10, 0, 0, 0);
            btnAdLua_SV.Size = new Size(149, 44);
            btnAdLua_SV.TabIndex = 13;
            btnAdLua_SV.Text = "Lưu";
            btnAdLua_SV.UseVisualStyleBackColor = false;
            btnAdLua_SV.Click += btnAdLua_SV_Click;
            // 
            // btnAdThem_SV
            // 
            btnAdThem_SV.BackColor = Color.White;
            btnAdThem_SV.FlatStyle = FlatStyle.Flat;
            btnAdThem_SV.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdThem_SV.Image = (Image)resources.GetObject("btnAdThem_SV.Image");
            btnAdThem_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdThem_SV.Location = new Point(226, 271);
            btnAdThem_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdThem_SV.Name = "btnAdThem_SV";
            btnAdThem_SV.Padding = new Padding(10, 0, 0, 0);
            btnAdThem_SV.Size = new Size(149, 44);
            btnAdThem_SV.TabIndex = 14;
            btnAdThem_SV.Text = "Thêm";
            btnAdThem_SV.UseVisualStyleBackColor = false;
            btnAdThem_SV.Click += btnAdThem_SV_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 201);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 120;
            label1.Text = "Giới tính:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(96, 234);
            label23.Name = "label23";
            label23.Size = new Size(60, 20);
            label23.TabIndex = 121;
            label23.Text = "Địa chỉ:";
            // 
            // btnXuat
            // 
            btnXuat.BackColor = Color.White;
            btnXuat.FlatStyle = FlatStyle.Flat;
            btnXuat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuat.Location = new Point(1074, 271);
            btnXuat.Margin = new Padding(3, 4, 3, 4);
            btnXuat.Name = "btnXuat";
            btnXuat.Padding = new Padding(10, 0, 0, 0);
            btnXuat.Size = new Size(149, 44);
            btnXuat.TabIndex = 17;
            btnXuat.Text = "Xuất..";
            btnXuat.UseVisualStyleBackColor = false;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnAdXoa_SV
            // 
            btnAdXoa_SV.BackColor = Color.White;
            btnAdXoa_SV.FlatStyle = FlatStyle.Flat;
            btnAdXoa_SV.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdXoa_SV.Image = (Image)resources.GetObject("btnAdXoa_SV.Image");
            btnAdXoa_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdXoa_SV.Location = new Point(741, 271);
            btnAdXoa_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdXoa_SV.Name = "btnAdXoa_SV";
            btnAdXoa_SV.Padding = new Padding(10, 0, 0, 0);
            btnAdXoa_SV.Size = new Size(149, 44);
            btnAdXoa_SV.TabIndex = 17;
            btnAdXoa_SV.Text = "Xóa";
            btnAdXoa_SV.UseVisualStyleBackColor = false;
            btnAdXoa_SV.Click += btnAdXoa_SV_Click;
            // 
            // txtAdCCCDsv
            // 
            helpProvider1.SetHelpString(txtAdCCCDsv, "CCCD phải đủ 12 ký tự");
            txtAdCCCDsv.Location = new Point(171, 129);
            txtAdCCCDsv.Margin = new Padding(3, 4, 3, 4);
            txtAdCCCDsv.Name = "txtAdCCCDsv";
            txtAdCCCDsv.PlaceholderText = "CCCD là số và phải đủ 12 ký tự";
            helpProvider1.SetShowHelp(txtAdCCCDsv, true);
            txtAdCCCDsv.Size = new Size(400, 27);
            txtAdCCCDsv.TabIndex = 3;
            // 
            // txtAdMaSV
            // 
            helpProvider1.SetHelpString(txtAdMaSV, "Mã SV có 9 ký tu, VD: DTHxxxxxx");
            txtAdMaSV.Location = new Point(171, 24);
            txtAdMaSV.Margin = new Padding(3, 4, 3, 4);
            txtAdMaSV.Name = "txtAdMaSV";
            txtAdMaSV.PlaceholderText = "Mã SV có 9 ký tự, VD: DTHxxxxxx";
            helpProvider1.SetShowHelp(txtAdMaSV, true);
            txtAdMaSV.Size = new Size(400, 27);
            txtAdMaSV.TabIndex = 0;
            // 
            // txtAdHoTenSV
            // 
            txtAdHoTenSV.Location = new Point(171, 59);
            txtAdHoTenSV.Margin = new Padding(3, 4, 3, 4);
            txtAdHoTenSV.Name = "txtAdHoTenSV";
            txtAdHoTenSV.PlaceholderText = "Họ Và Tên";
            txtAdHoTenSV.Size = new Size(400, 27);
            txtAdHoTenSV.TabIndex = 1;
            // 
            // cboAdSV_TenLop
            // 
            cboAdSV_TenLop.FormattingEnabled = true;
            cboAdSV_TenLop.Location = new Point(823, 26);
            cboAdSV_TenLop.Margin = new Padding(3, 4, 3, 4);
            cboAdSV_TenLop.Name = "cboAdSV_TenLop";
            cboAdSV_TenLop.Size = new Size(400, 28);
            cboAdSV_TenLop.TabIndex = 7;
            cboAdSV_TenLop.SelectedIndexChanged += cboAdSV_TenLop_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(85, 97);
            label10.Name = "label10";
            label10.Size = new Size(81, 20);
            label10.TabIndex = 109;
            label10.Text = "Năm Sinh:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(55, 167);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 112;
            label9.Text = "Số điện thoại:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(77, 62);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 113;
            label8.Text = "Họ và Tên:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(59, 27);
            label7.Name = "label7";
            label7.Size = new Size(104, 20);
            label7.TabIndex = 114;
            label7.Text = "Mã Sinh Viên:";
            // 
            // txtAdSDT_SV
            // 
            helpProvider1.SetHelpKeyword(txtAdSDT_SV, "SDT phải đủ 10 ký tự");
            helpProvider1.SetHelpString(txtAdSDT_SV, "SDT phải đủ ");
            txtAdSDT_SV.Location = new Point(170, 164);
            txtAdSDT_SV.Margin = new Padding(3, 4, 3, 4);
            txtAdSDT_SV.Name = "txtAdSDT_SV";
            txtAdSDT_SV.PlaceholderText = "Số điện thoại là số và có đúng 10 ký tự";
            helpProvider1.SetShowHelp(txtAdSDT_SV, true);
            txtAdSDT_SV.Size = new Size(400, 27);
            txtAdSDT_SV.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(112, 132);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 106;
            label6.Text = "CCCD:";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = SystemColors.ControlLight;
            panelSearch.Controls.Add(groupBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 350);
            panelSearch.Margin = new Padding(3, 4, 3, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(10, 6, 10, 6);
            panelSearch.Size = new Size(1694, 72);
            panelSearch.TabIndex = 2;
            // 
            // groupBoxSearch
            // 
            groupBoxSearch.Controls.Add(radGiam);
            groupBoxSearch.Controls.Add(radTang);
            groupBoxSearch.Controls.Add(cboKieuSX);
            groupBoxSearch.Controls.Add(label14);
            groupBoxSearch.Controls.Add(txtAdTuKhoa_SV);
            groupBoxSearch.Controls.Add(label11);
            groupBoxSearch.Controls.Add(label12);
            groupBoxSearch.Controls.Add(cboAdTimKiem_SV);
            groupBoxSearch.Controls.Add(btnAdShowAll_SV);
            groupBoxSearch.Controls.Add(btnAdTimKiem_SV);
            groupBoxSearch.Dock = DockStyle.Fill;
            groupBoxSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxSearch.Location = new Point(10, 6);
            groupBoxSearch.Margin = new Padding(3, 4, 3, 4);
            groupBoxSearch.Name = "groupBoxSearch";
            groupBoxSearch.Padding = new Padding(3, 4, 3, 4);
            groupBoxSearch.Size = new Size(1674, 60);
            groupBoxSearch.TabIndex = 0;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "Tìm kiếm";
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(1562, 23);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(67, 24);
            radGiam.TabIndex = 88;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            radGiam.CheckedChanged += radGiam_CheckedChanged;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Location = new Point(1478, 23);
            radTang.Name = "radTang";
            radTang.Size = new Size(64, 24);
            radTang.TabIndex = 89;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            radTang.CheckedChanged += radTang_CheckedChanged;
            // 
            // cboKieuSX
            // 
            cboKieuSX.FormattingEnabled = true;
            cboKieuSX.Location = new Point(1311, 25);
            cboKieuSX.Name = "cboKieuSX";
            cboKieuSX.Size = new Size(151, 28);
            cboKieuSX.TabIndex = 87;
            cboKieuSX.SelectedIndexChanged += cboKieuSX_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1184, 27);
            label14.Name = "label14";
            label14.Size = new Size(104, 20);
            label14.TabIndex = 86;
            label14.Text = "Kiểu Sắp Xếp:";
            // 
            // txtAdTuKhoa_SV
            // 
            txtAdTuKhoa_SV.Location = new Point(455, 26);
            txtAdTuKhoa_SV.Margin = new Padding(3, 4, 3, 4);
            txtAdTuKhoa_SV.Name = "txtAdTuKhoa_SV";
            txtAdTuKhoa_SV.PlaceholderText = "Nhập từ khóa tìm kiếm (F3)...";
            txtAdTuKhoa_SV.Size = new Size(400, 27);
            txtAdTuKhoa_SV.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(35, 30);
            label11.Name = "label11";
            label11.Size = new Size(109, 20);
            label11.TabIndex = 74;
            label11.Text = "Loại Tìm Kiếm";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(375, 30);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 76;
            label12.Text = "Từ Khóa";
            // 
            // cboAdTimKiem_SV
            // 
            cboAdTimKiem_SV.FormattingEnabled = true;
            cboAdTimKiem_SV.Location = new Point(150, 26);
            cboAdTimKiem_SV.Margin = new Padding(3, 4, 3, 4);
            cboAdTimKiem_SV.Name = "cboAdTimKiem_SV";
            cboAdTimKiem_SV.Size = new Size(200, 28);
            cboAdTimKiem_SV.TabIndex = 18;
            // 
            // btnAdShowAll_SV
            // 
            btnAdShowAll_SV.BackColor = Color.White;
            btnAdShowAll_SV.FlatStyle = FlatStyle.Flat;
            btnAdShowAll_SV.Location = new Point(1038, 19);
            btnAdShowAll_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdShowAll_SV.Name = "btnAdShowAll_SV";
            btnAdShowAll_SV.Size = new Size(120, 40);
            btnAdShowAll_SV.TabIndex = 21;
            btnAdShowAll_SV.Text = "Hiện tất cả";
            btnAdShowAll_SV.UseVisualStyleBackColor = false;
            btnAdShowAll_SV.Click += btnAdShowAll_SV_Click;
            // 
            // btnAdTimKiem_SV
            // 
            btnAdTimKiem_SV.BackColor = Color.White;
            btnAdTimKiem_SV.FlatStyle = FlatStyle.Flat;
            btnAdTimKiem_SV.Location = new Point(903, 19);
            btnAdTimKiem_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdTimKiem_SV.Name = "btnAdTimKiem_SV";
            btnAdTimKiem_SV.Size = new Size(120, 40);
            btnAdTimKiem_SV.TabIndex = 20;
            btnAdTimKiem_SV.Text = "Tìm Kiếm";
            btnAdTimKiem_SV.UseVisualStyleBackColor = false;
            btnAdTimKiem_SV.Click += btnAdTimKiem_SV_Click;
            btnAdTimKiem_SV.KeyDown += btnAdTimKiem_SV_KeyDown;
            // 
            // panelGrid
            // 
            panelGrid.Controls.Add(groupBoxList);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 422);
            panelGrid.Margin = new Padding(3, 4, 3, 4);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(10, 12, 10, 12);
            panelGrid.Size = new Size(1694, 1068);
            panelGrid.TabIndex = 3;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvAdminSinhVien);
            groupBoxList.Dock = DockStyle.Fill;
            groupBoxList.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxList.Location = new Point(10, 12);
            groupBoxList.Margin = new Padding(3, 4, 3, 4);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(3, 4, 3, 4);
            groupBoxList.Size = new Size(1674, 1044);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Danh sách sinh viên";
            // 
            // dgvAdminSinhVien
            // 
            dgvAdminSinhVien.AllowUserToAddRows = false;
            dgvAdminSinhVien.AllowUserToDeleteRows = false;
            dgvAdminSinhVien.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAdminSinhVien.ColumnHeadersHeight = 29;
            dgvAdminSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAdminSinhVien.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, NgaySinh, GioiTinh, CCCD, SDT, Email, MaLop, DiaChi });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAdminSinhVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAdminSinhVien.Dock = DockStyle.Fill;
            dgvAdminSinhVien.Location = new Point(3, 24);
            dgvAdminSinhVien.Margin = new Padding(3, 4, 3, 4);
            dgvAdminSinhVien.MultiSelect = false;
            dgvAdminSinhVien.Name = "dgvAdminSinhVien";
            dgvAdminSinhVien.ReadOnly = true;
            dgvAdminSinhVien.RowHeadersWidth = 51;
            dgvAdminSinhVien.RowTemplate.Height = 24;
            dgvAdminSinhVien.Size = new Size(1668, 1016);
            dgvAdminSinhVien.TabIndex = 0;
            dgvAdminSinhVien.CellClick += dgvAdminSinhVien_CellClick;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
            dataGridViewCellStyle1.ForeColor = Color.Blue;
            MaSV.DefaultCellStyle = dataGridViewCellStyle1;
            MaSV.HeaderText = "Mã SV";
            MaSV.MinimumWidth = 6;
            MaSV.Name = "MaSV";
            MaSV.ReadOnly = true;
            MaSV.Width = 179;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "Họ và Tên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            HoTen.Width = 180;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NgaySinh.DefaultCellStyle = dataGridViewCellStyle2;
            NgaySinh.HeaderText = "Ngày Sinh";
            NgaySinh.MinimumWidth = 6;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            NgaySinh.Width = 179;
            // 
            // GioiTinh
            // 
            GioiTinh.DataPropertyName = "GioiTinh";
            GioiTinh.HeaderText = "Giới tính";
            GioiTinh.MinimumWidth = 6;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.ReadOnly = true;
            GioiTinh.Width = 180;
            // 
            // CCCD
            // 
            CCCD.DataPropertyName = "CCCD";
            CCCD.HeaderText = "CCCD";
            CCCD.MinimumWidth = 6;
            CCCD.Name = "CCCD";
            CCCD.ReadOnly = true;
            CCCD.Width = 179;
            // 
            // SDT
            // 
            SDT.DataPropertyName = "SDT";
            SDT.HeaderText = "SĐT";
            SDT.MinimumWidth = 6;
            SDT.Name = "SDT";
            SDT.ReadOnly = true;
            SDT.Width = 179;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 180;
            // 
            // MaLop
            // 
            MaLop.DataPropertyName = "MaLop";
            MaLop.HeaderText = "Lớp";
            MaLop.MinimumWidth = 6;
            MaLop.Name = "MaLop";
            MaLop.ReadOnly = true;
            MaLop.Width = 180;
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.MinimumWidth = 6;
            DiaChi.Name = "DiaChi";
            DiaChi.ReadOnly = true;
            DiaChi.Width = 179;
            // 
            // UC_SinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelGrid);
            Controls.Add(panelSearch);
            Controls.Add(panelInput);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_SinhVien";
            Size = new Size(1694, 1490);
            panelInput.ResumeLayout(false);
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            panelSearch.ResumeLayout(false);
            groupBoxSearch.ResumeLayout(false);
            groupBoxSearch.PerformLayout();
            panelGrid.ResumeLayout(false);
            groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdminSinhVien).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.TextBox txtAdMaSV;
        private System.Windows.Forms.TextBox txtAdHoTenSV;
        private System.Windows.Forms.DateTimePicker dtpAdNamSinhSV;
        private System.Windows.Forms.TextBox txtAdCCCDsv;
        private System.Windows.Forms.TextBox txtAdSDT_SV;
        private System.Windows.Forms.RadioButton radAdSV_Nam;
        private System.Windows.Forms.RadioButton radAdSV_Nu;
        private System.Windows.Forms.ComboBox cboAdSV_TenLop;
        private System.Windows.Forms.TextBox txtAdSV_ChuyenNganh;
        private System.Windows.Forms.TextBox txtAdSV_NienKhoa;
        private System.Windows.Forms.TextBox txtAdSV_Email;
        private System.Windows.Forms.TextBox txtAdSV_Khoa;
        private System.Windows.Forms.TextBox txtAdSV_DiaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnAdLua_SV;
        private System.Windows.Forms.Button btnAdThem_SV;
        private System.Windows.Forms.Button btnAdLamLai_SV;
        private System.Windows.Forms.Button btnAdSua_SV;
        private System.Windows.Forms.Button btnAdXoa_SV;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.ComboBox cboAdTimKiem_SV;
        private System.Windows.Forms.TextBox txtAdTuKhoa_SV;
        private System.Windows.Forms.Button btnAdTimKiem_SV;
        private System.Windows.Forms.Button btnAdShowAll_SV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvAdminSinhVien;
        private RadioButton radGiam;
        private RadioButton radTang;
        private ComboBox cboKieuSX;
        private Label label14;
        private Button btnNhap;
        private Button btnXuat;
        private HelpProvider helpProvider1;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn CCCD;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn MaLop;
        private DataGridViewTextBoxColumn DiaChi;
    }
}