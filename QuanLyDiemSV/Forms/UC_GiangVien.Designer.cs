namespace QuanLyDiemSV.Forms
{
    partial class UC_GiangVien
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_GiangVien));
            dtpNamSinhGV = new DateTimePicker();
            radNu = new RadioButton();
            radNam = new RadioButton();
            groupBoxList = new GroupBox();
            dgvAdminGiangVien = new DataGridView();
            MaGV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            HocVi = new DataGridViewTextBoxColumn();
            Khoa = new DataGridViewTextBoxColumn();
            panelGrid = new Panel();
            btnSua = new Button();
            btnLamLai = new Button();
            btnShowAll = new Button();
            btnTimKiem = new Button();
            label5 = new Label();
            label12 = new Label();
            btnLuu = new Button();
            btnThem = new Button();
            label1 = new Label();
            btnXoa = new Button();
            txtEmail = new TextBox();
            cboLoaiTK = new ComboBox();
            txtMaGV = new TextBox();
            txtHoTenGV = new TextBox();
            txtTuKhoaTK = new TextBox();
            groupBoxSearch = new GroupBox();
            label4 = new Label();
            cboLocTheoKhoa = new ComboBox();
            label3 = new Label();
            cboKieuSX = new ComboBox();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            label11 = new Label();
            panelSearch = new Panel();
            cboKhoa = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtSDT = new TextBox();
            label6 = new Label();
            groupBoxInfo = new GroupBox();
            btnNhap = new Button();
            btnXuat = new Button();
            label2 = new Label();
            cboHocVi = new ComboBox();
            panelInput = new Panel();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdminGiangVien).BeginInit();
            panelGrid.SuspendLayout();
            groupBoxSearch.SuspendLayout();
            panelSearch.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // dtpNamSinhGV
            // 
            dtpNamSinhGV.Format = DateTimePickerFormat.Custom;
            dtpNamSinhGV.Location = new Point(171, 94);
            dtpNamSinhGV.Margin = new Padding(3, 4, 3, 4);
            dtpNamSinhGV.Name = "dtpNamSinhGV";
            dtpNamSinhGV.Size = new Size(400, 27);
            dtpNamSinhGV.TabIndex = 2;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(249, 168);
            radNu.Margin = new Padding(3, 4, 3, 4);
            radNu.Name = "radNu";
            radNu.Size = new Size(52, 24);
            radNu.TabIndex = 6;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new Point(182, 168);
            radNam.Margin = new Padding(3, 4, 3, 4);
            radNam.Name = "radNam";
            radNam.Size = new Size(64, 24);
            radNam.TabIndex = 5;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvAdminGiangVien);
            groupBoxList.Dock = DockStyle.Fill;
            groupBoxList.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxList.Location = new Point(10, 12);
            groupBoxList.Margin = new Padding(3, 4, 3, 4);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(3, 4, 3, 4);
            groupBoxList.Size = new Size(1674, 517);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Danh sách sinh viên";
            // 
            // dgvAdminGiangVien
            // 
            dgvAdminGiangVien.AllowUserToAddRows = false;
            dgvAdminGiangVien.AllowUserToDeleteRows = false;
            dgvAdminGiangVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdminGiangVien.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAdminGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdminGiangVien.Columns.AddRange(new DataGridViewColumn[] { MaGV, HoTen, NgaySinh, GioiTinh, Email, SDT, HocVi, Khoa });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAdminGiangVien.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAdminGiangVien.Dock = DockStyle.Fill;
            dgvAdminGiangVien.Location = new Point(3, 24);
            dgvAdminGiangVien.Margin = new Padding(3, 4, 3, 4);
            dgvAdminGiangVien.MultiSelect = false;
            dgvAdminGiangVien.Name = "dgvAdminGiangVien";
            dgvAdminGiangVien.ReadOnly = true;
            dgvAdminGiangVien.RowHeadersWidth = 51;
            dgvAdminGiangVien.RowTemplate.Height = 24;
            dgvAdminGiangVien.Size = new Size(1668, 489);
            dgvAdminGiangVien.TabIndex = 0;
            // 
            // MaGV
            // 
            MaGV.DataPropertyName = "MaGV";
            dataGridViewCellStyle1.ForeColor = Color.Blue;
            MaGV.DefaultCellStyle = dataGridViewCellStyle1;
            MaGV.HeaderText = "Mã GV";
            MaGV.MinimumWidth = 6;
            MaGV.Name = "MaGV";
            MaGV.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "Họ và Tên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            NgaySinh.HeaderText = "Ngày Sinh";
            NgaySinh.MinimumWidth = 6;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            // 
            // GioiTinh
            // 
            GioiTinh.DataPropertyName = "GioiTinh";
            GioiTinh.HeaderText = "Giới tính";
            GioiTinh.MinimumWidth = 6;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.ReadOnly = true;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // SDT
            // 
            SDT.DataPropertyName = "SDT";
            SDT.HeaderText = "SĐT";
            SDT.MinimumWidth = 6;
            SDT.Name = "SDT";
            SDT.ReadOnly = true;
            // 
            // HocVi
            // 
            HocVi.DataPropertyName = "HocVi";
            HocVi.HeaderText = "Học vị";
            HocVi.MinimumWidth = 6;
            HocVi.Name = "HocVi";
            HocVi.ReadOnly = true;
            // 
            // Khoa
            // 
            Khoa.DataPropertyName = "MaKhoa";
            Khoa.HeaderText = "Khoa";
            Khoa.MinimumWidth = 6;
            Khoa.Name = "Khoa";
            Khoa.ReadOnly = true;
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(groupBoxList);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 413);
            panelGrid.Margin = new Padding(3, 4, 3, 4);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(10, 12, 10, 12);
            panelGrid.Size = new Size(1694, 541);
            panelGrid.TabIndex = 6;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(473, 200);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Padding = new Padding(10, 0, 0, 0);
            btnSua.Size = new Size(137, 39);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamLai
            // 
            btnLamLai.BackColor = Color.White;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamLai.Image = (Image)resources.GetObject("btnLamLai.Image");
            btnLamLai.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamLai.Location = new Point(330, 200);
            btnLamLai.Margin = new Padding(3, 4, 3, 4);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Padding = new Padding(10, 0, 0, 0);
            btnLamLai.Size = new Size(137, 39);
            btnLamLai.TabIndex = 15;
            btnLamLai.Text = "Làm lại";
            btnLamLai.UseVisualStyleBackColor = false;
            btnLamLai.Click += btnLamLai_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.White;
            btnShowAll.FlatAppearance.BorderSize = 0;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.Image = (Image)resources.GetObject("btnShowAll.Image");
            btnShowAll.Location = new Point(1500, 30);
            btnShowAll.Margin = new Padding(3, 4, 3, 4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(39, 40);
            btnShowAll.TabIndex = 21;
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Image = (Image)resources.GetObject("btnTimKiem.Image");
            btnTimKiem.Location = new Point(1445, 35);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(39, 35);
            btnTimKiem.TabIndex = 20;
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(604, 31);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 126;
            label5.Text = "Khoa:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(712, 42);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 76;
            label12.Text = "Từ Khóa";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(44, 200);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Padding = new Padding(10, 0, 0, 0);
            btnLuu.Size = new Size(137, 39);
            btnLuu.TabIndex = 13;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(187, 200);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(10, 0, 0, 0);
            btnThem.Size = new Size(137, 39);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 170);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 120;
            label1.Text = "Giới tính:";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(625, 200);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Padding = new Padding(10, 0, 0, 0);
            btnXoa.Size = new Size(137, 39);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(686, 99);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 27);
            txtEmail.TabIndex = 3;
            // 
            // cboLoaiTK
            // 
            cboLoaiTK.FormattingEnabled = true;
            cboLoaiTK.Location = new Point(519, 37);
            cboLoaiTK.Margin = new Padding(3, 4, 3, 4);
            cboLoaiTK.Name = "cboLoaiTK";
            cboLoaiTK.Size = new Size(159, 28);
            cboLoaiTK.TabIndex = 18;
            // 
            // txtMaGV
            // 
            txtMaGV.Location = new Point(171, 24);
            txtMaGV.Margin = new Padding(3, 4, 3, 4);
            txtMaGV.Name = "txtMaGV";
            txtMaGV.Size = new Size(400, 27);
            txtMaGV.TabIndex = 0;
            // 
            // txtHoTenGV
            // 
            txtHoTenGV.Location = new Point(171, 59);
            txtHoTenGV.Margin = new Padding(3, 4, 3, 4);
            txtHoTenGV.Name = "txtHoTenGV";
            txtHoTenGV.Size = new Size(400, 27);
            txtHoTenGV.TabIndex = 1;
            // 
            // txtTuKhoaTK
            // 
            txtTuKhoaTK.Location = new Point(802, 37);
            txtTuKhoaTK.Margin = new Padding(3, 4, 3, 4);
            txtTuKhoaTK.Name = "txtTuKhoaTK";
            txtTuKhoaTK.PlaceholderText = "Nhập từ khóa cần tìm..";
            txtTuKhoaTK.Size = new Size(597, 27);
            txtTuKhoaTK.TabIndex = 19;
            // 
            // groupBoxSearch
            // 
            groupBoxSearch.BackColor = Color.White;
            groupBoxSearch.Controls.Add(label4);
            groupBoxSearch.Controls.Add(cboLocTheoKhoa);
            groupBoxSearch.Controls.Add(label3);
            groupBoxSearch.Controls.Add(cboKieuSX);
            groupBoxSearch.Controls.Add(radGiam);
            groupBoxSearch.Controls.Add(radTang);
            groupBoxSearch.Controls.Add(txtTuKhoaTK);
            groupBoxSearch.Controls.Add(label11);
            groupBoxSearch.Controls.Add(label12);
            groupBoxSearch.Controls.Add(cboLoaiTK);
            groupBoxSearch.Controls.Add(btnShowAll);
            groupBoxSearch.Controls.Add(btnTimKiem);
            groupBoxSearch.Dock = DockStyle.Fill;
            groupBoxSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxSearch.Location = new Point(10, 6);
            groupBoxSearch.Margin = new Padding(3, 4, 3, 4);
            groupBoxSearch.Name = "groupBoxSearch";
            groupBoxSearch.Padding = new Padding(3, 4, 3, 4);
            groupBoxSearch.Size = new Size(1674, 121);
            groupBoxSearch.TabIndex = 0;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "Tìm kiếm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 35);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 128;
            label4.Text = "Khoa:";
            // 
            // cboLocTheoKhoa
            // 
            cboLocTheoKhoa.FormattingEnabled = true;
            cboLocTheoKhoa.Location = new Point(85, 33);
            cboLocTheoKhoa.Margin = new Padding(3, 4, 3, 4);
            cboLocTheoKhoa.Name = "cboLocTheoKhoa";
            cboLocTheoKhoa.Size = new Size(274, 28);
            cboLocTheoKhoa.TabIndex = 127;
            cboLocTheoKhoa.SelectedIndexChanged += cboLocTheoKhoa_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 78);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 80;
            label3.Text = "Kiểu Sắp Xếp";
            // 
            // cboKieuSX
            // 
            cboKieuSX.FormattingEnabled = true;
            cboKieuSX.Location = new Point(166, 73);
            cboKieuSX.Name = "cboKieuSX";
            cboKieuSX.Size = new Size(193, 28);
            cboKieuSX.TabIndex = 79;
            cboKieuSX.SelectedIndexChanged += cboKieuSX_SelectedIndexChanged;
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(473, 74);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(67, 24);
            radGiam.TabIndex = 77;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            radGiam.CheckedChanged += radGiam_CheckedChanged;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Location = new Point(386, 74);
            radTang.Name = "radTang";
            radTang.Size = new Size(64, 24);
            radTang.TabIndex = 78;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            radTang.CheckedChanged += radTang_CheckedChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(382, 40);
            label11.Name = "label11";
            label11.Size = new Size(109, 20);
            label11.TabIndex = 74;
            label11.Text = "Loại Tìm Kiếm";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(groupBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 280);
            panelSearch.Margin = new Padding(3, 4, 3, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(10, 6, 10, 6);
            panelSearch.Size = new Size(1694, 133);
            panelSearch.TabIndex = 5;
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(686, 27);
            cboKhoa.Margin = new Padding(3, 4, 3, 4);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(400, 28);
            cboKhoa.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(85, 98);
            label10.Name = "label10";
            label10.Size = new Size(81, 20);
            label10.TabIndex = 109;
            label10.Text = "Năm Sinh:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(55, 136);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 112;
            label9.Text = "Số điện thoại:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(77, 63);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 113;
            label8.Text = "Họ và Tên:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 26);
            label7.Name = "label7";
            label7.Size = new Size(115, 20);
            label7.TabIndex = 114;
            label7.Text = "Mã Giảng Viên:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(170, 132);
            txtSDT.Margin = new Padding(3, 4, 3, 4);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(400, 27);
            txtSDT.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(606, 102);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 106;
            label6.Text = "Email";
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.BackColor = Color.White;
            groupBoxInfo.Controls.Add(btnNhap);
            groupBoxInfo.Controls.Add(btnXuat);
            groupBoxInfo.Controls.Add(dtpNamSinhGV);
            groupBoxInfo.Controls.Add(radNu);
            groupBoxInfo.Controls.Add(radNam);
            groupBoxInfo.Controls.Add(label2);
            groupBoxInfo.Controls.Add(label5);
            groupBoxInfo.Controls.Add(btnSua);
            groupBoxInfo.Controls.Add(btnLamLai);
            groupBoxInfo.Controls.Add(btnLuu);
            groupBoxInfo.Controls.Add(btnThem);
            groupBoxInfo.Controls.Add(label1);
            groupBoxInfo.Controls.Add(btnXoa);
            groupBoxInfo.Controls.Add(txtEmail);
            groupBoxInfo.Controls.Add(txtMaGV);
            groupBoxInfo.Controls.Add(txtHoTenGV);
            groupBoxInfo.Controls.Add(cboHocVi);
            groupBoxInfo.Controls.Add(cboKhoa);
            groupBoxInfo.Controls.Add(label10);
            groupBoxInfo.Controls.Add(label9);
            groupBoxInfo.Controls.Add(label8);
            groupBoxInfo.Controls.Add(label7);
            groupBoxInfo.Controls.Add(txtSDT);
            groupBoxInfo.Controls.Add(label6);
            groupBoxInfo.Dock = DockStyle.Fill;
            groupBoxInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxInfo.Location = new Point(10, 12);
            groupBoxInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Padding = new Padding(3, 4, 3, 4);
            groupBoxInfo.Size = new Size(1674, 256);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "Thông tin giảng viên";
            // 
            // btnNhap
            // 
            btnNhap.BackColor = Color.White;
            btnNhap.FlatStyle = FlatStyle.Flat;
            btnNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhap.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhap.Location = new Point(768, 200);
            btnNhap.Margin = new Padding(3, 4, 3, 4);
            btnNhap.Name = "btnNhap";
            btnNhap.Padding = new Padding(10, 0, 0, 0);
            btnNhap.Size = new Size(137, 39);
            btnNhap.TabIndex = 127;
            btnNhap.Text = "Nhập..";
            btnNhap.UseVisualStyleBackColor = false;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnXuat
            // 
            btnXuat.BackColor = Color.White;
            btnXuat.FlatStyle = FlatStyle.Flat;
            btnXuat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuat.Location = new Point(911, 200);
            btnXuat.Margin = new Padding(3, 4, 3, 4);
            btnXuat.Name = "btnXuat";
            btnXuat.Padding = new Padding(10, 0, 0, 0);
            btnXuat.Size = new Size(137, 39);
            btnXuat.TabIndex = 128;
            btnXuat.Text = "Xuất..";
            btnXuat.UseVisualStyleBackColor = false;
            btnXuat.Click += btnXuat_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(604, 66);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 126;
            label2.Text = "Học Vị:";
            // 
            // cboHocVi
            // 
            cboHocVi.FormattingEnabled = true;
            cboHocVi.Location = new Point(686, 63);
            cboHocVi.Margin = new Padding(3, 4, 3, 4);
            cboHocVi.Name = "cboHocVi";
            cboHocVi.Size = new Size(400, 28);
            cboHocVi.TabIndex = 7;
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
            panelInput.Size = new Size(1694, 280);
            panelInput.TabIndex = 4;
            // 
            // UC_GiangVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelGrid);
            Controls.Add(panelSearch);
            Controls.Add(panelInput);
            Name = "UC_GiangVien";
            Size = new Size(1694, 954);
            groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdminGiangVien).EndInit();
            panelGrid.ResumeLayout(false);
            groupBoxSearch.ResumeLayout(false);
            groupBoxSearch.PerformLayout();
            panelSearch.ResumeLayout(false);
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            panelInput.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DateTimePicker dtpNamSinhGV;
        private RadioButton radNu;
        private RadioButton radNam;
        private GroupBox groupBoxList;
        private DataGridView dgvAdminGiangVien;
        private Panel panelGrid;
        private Button btnSua;
        private Button btnLamLai;
        private Button btnShowAll;
        private Button btnTimKiem;
        private Label label5;
        private Label label12;
        private Button btnLuu;
        private Button btnThem;
        private Label label1;
        private Button btnXoa;
        private TextBox txtEmail;
        private ComboBox cboLoaiTK;
        private TextBox txtMaGV;
        private TextBox txtHoTenGV;
        private TextBox txtTuKhoaTK;
        private GroupBox groupBoxSearch;
        private Label label11;
        private Panel panelSearch;
        private ComboBox cboKhoa;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtSDT;
        private Label label6;
        private GroupBox groupBoxInfo;
        private Panel panelInput;
        private Label label2;
        private ComboBox cboHocVi;
        private Label label3;
        private ComboBox cboKieuSX;
        private RadioButton radGiam;
        private RadioButton radTang;
        private Button btnNhap;
        private Button btnXuat;
        private DataGridViewTextBoxColumn MaGV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn HocVi;
        private DataGridViewTextBoxColumn Khoa;
        private Label label4;
        private ComboBox cboLocTheoKhoa;
    }
}
