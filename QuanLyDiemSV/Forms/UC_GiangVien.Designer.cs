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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_GiangVien));
            dtpAdNamSinhGV = new DateTimePicker();
            radNu = new RadioButton();
            radNam = new RadioButton();
            groupBoxList = new GroupBox();
            dgvAdminGiangVien = new DataGridView();
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
            txtAdCCCDgv = new TextBox();
            cboLoaiTK = new ComboBox();
            txtAdMaGV = new TextBox();
            txtAdHoTenGV = new TextBox();
            txtTuKhoaTK = new TextBox();
            groupBoxSearch = new GroupBox();
            label11 = new Label();
            panelSearch = new Panel();
            cboKhoa = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtAdCCCD_GV = new TextBox();
            label6 = new Label();
            groupBoxInfo = new GroupBox();
            panelInput = new Panel();
            cboHocVi = new ComboBox();
            label2 = new Label();
            MaGV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            HocVi = new DataGridViewTextBoxColumn();
            Khoa = new DataGridViewTextBoxColumn();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdminGiangVien).BeginInit();
            panelGrid.SuspendLayout();
            groupBoxSearch.SuspendLayout();
            panelSearch.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // dtpAdNamSinhGV
            // 
            dtpAdNamSinhGV.Format = DateTimePickerFormat.Custom;
            dtpAdNamSinhGV.Location = new Point(171, 94);
            dtpAdNamSinhGV.Margin = new Padding(3, 4, 3, 4);
            dtpAdNamSinhGV.Name = "dtpAdNamSinhGV";
            dtpAdNamSinhGV.Size = new Size(400, 27);
            dtpAdNamSinhGV.TabIndex = 2;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(249, 200);
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
            radNam.Location = new Point(182, 200);
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
            groupBoxList.Size = new Size(1674, 476);
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
            dgvAdminGiangVien.Size = new Size(1668, 448);
            dgvAdminGiangVien.TabIndex = 0;
            // 
            // panelGrid
            // 
            panelGrid.Controls.Add(groupBoxList);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 454);
            panelGrid.Margin = new Padding(3, 4, 3, 4);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(10, 12, 10, 12);
            panelGrid.Size = new Size(1694, 500);
            panelGrid.TabIndex = 6;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(710, 285);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Padding = new Padding(10, 0, 0, 0);
            btnSua.Size = new Size(195, 56);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnLamLai
            // 
            btnLamLai.BackColor = Color.White;
            btnLamLai.FlatStyle = FlatStyle.Flat;
            btnLamLai.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamLai.Image = (Image)resources.GetObject("btnLamLai.Image");
            btnLamLai.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamLai.Location = new Point(488, 285);
            btnLamLai.Margin = new Padding(3, 4, 3, 4);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Padding = new Padding(10, 0, 0, 0);
            btnLamLai.Size = new Size(195, 56);
            btnLamLai.TabIndex = 15;
            btnLamLai.Text = "Làm lại";
            btnLamLai.UseVisualStyleBackColor = false;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.White;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.Location = new Point(1038, 19);
            btnShowAll.Margin = new Padding(3, 4, 3, 4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(120, 40);
            btnShowAll.TabIndex = 21;
            btnShowAll.Text = "Hiện tất cả";
            btnShowAll.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Location = new Point(903, 19);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 40);
            btnTimKiem.TabIndex = 20;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
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
            label12.Location = new Point(375, 31);
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
            btnLuu.Location = new Point(31, 285);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Padding = new Padding(10, 0, 0, 0);
            btnLuu.Size = new Size(195, 56);
            btnLuu.TabIndex = 13;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(262, 285);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(10, 0, 0, 0);
            btnThem.Size = new Size(195, 56);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 202);
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
            btnXoa.Location = new Point(934, 285);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Padding = new Padding(10, 0, 0, 0);
            btnXoa.Size = new Size(195, 56);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // txtAdCCCDgv
            // 
            txtAdCCCDgv.Location = new Point(171, 129);
            txtAdCCCDgv.Margin = new Padding(3, 4, 3, 4);
            txtAdCCCDgv.Name = "txtAdCCCDgv";
            txtAdCCCDgv.Size = new Size(400, 27);
            txtAdCCCDgv.TabIndex = 3;
            // 
            // cboLoaiTK
            // 
            cboLoaiTK.FormattingEnabled = true;
            cboLoaiTK.Location = new Point(150, 26);
            cboLoaiTK.Margin = new Padding(3, 4, 3, 4);
            cboLoaiTK.Name = "cboLoaiTK";
            cboLoaiTK.Size = new Size(200, 28);
            cboLoaiTK.TabIndex = 18;
            // 
            // txtAdMaGV
            // 
            txtAdMaGV.Location = new Point(171, 24);
            txtAdMaGV.Margin = new Padding(3, 4, 3, 4);
            txtAdMaGV.Name = "txtAdMaGV";
            txtAdMaGV.Size = new Size(400, 27);
            txtAdMaGV.TabIndex = 0;
            // 
            // txtAdHoTenGV
            // 
            txtAdHoTenGV.Location = new Point(171, 59);
            txtAdHoTenGV.Margin = new Padding(3, 4, 3, 4);
            txtAdHoTenGV.Name = "txtAdHoTenGV";
            txtAdHoTenGV.Size = new Size(400, 27);
            txtAdHoTenGV.TabIndex = 1;
            // 
            // txtTuKhoaTK
            // 
            txtTuKhoaTK.Location = new Point(455, 26);
            txtTuKhoaTK.Margin = new Padding(3, 4, 3, 4);
            txtTuKhoaTK.Name = "txtTuKhoaTK";
            txtTuKhoaTK.Size = new Size(400, 27);
            txtTuKhoaTK.TabIndex = 19;
            // 
            // groupBoxSearch
            // 
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
            groupBoxSearch.Size = new Size(1674, 60);
            groupBoxSearch.TabIndex = 0;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "Tìm kiếm";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(35, 31);
            label11.Name = "label11";
            label11.Size = new Size(109, 20);
            label11.TabIndex = 74;
            label11.Text = "Loại Tìm Kiếm";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = SystemColors.ControlLight;
            panelSearch.Controls.Add(groupBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 382);
            panelSearch.Margin = new Padding(3, 4, 3, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(10, 6, 10, 6);
            panelSearch.Size = new Size(1694, 72);
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
            label9.Location = new Point(55, 168);
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
            // txtAdCCCD_GV
            // 
            txtAdCCCD_GV.Location = new Point(170, 164);
            txtAdCCCD_GV.Margin = new Padding(3, 4, 3, 4);
            txtAdCCCD_GV.Name = "txtAdCCCD_GV";
            txtAdCCCD_GV.Size = new Size(400, 27);
            txtAdCCCD_GV.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(112, 133);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 106;
            label6.Text = "CCCD:";
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.BackColor = Color.LemonChiffon;
            groupBoxInfo.Controls.Add(dtpAdNamSinhGV);
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
            groupBoxInfo.Controls.Add(txtAdCCCDgv);
            groupBoxInfo.Controls.Add(txtAdMaGV);
            groupBoxInfo.Controls.Add(txtAdHoTenGV);
            groupBoxInfo.Controls.Add(cboHocVi);
            groupBoxInfo.Controls.Add(cboKhoa);
            groupBoxInfo.Controls.Add(label10);
            groupBoxInfo.Controls.Add(label9);
            groupBoxInfo.Controls.Add(label8);
            groupBoxInfo.Controls.Add(label7);
            groupBoxInfo.Controls.Add(txtAdCCCD_GV);
            groupBoxInfo.Controls.Add(label6);
            groupBoxInfo.Dock = DockStyle.Fill;
            groupBoxInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxInfo.Location = new Point(10, 12);
            groupBoxInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Padding = new Padding(3, 4, 3, 4);
            groupBoxInfo.Size = new Size(1674, 358);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "Thông tin giảng viên";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.LemonChiffon;
            panelInput.Controls.Add(groupBoxInfo);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(0, 0);
            panelInput.Margin = new Padding(3, 4, 3, 4);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(10, 12, 10, 12);
            panelInput.Size = new Size(1694, 382);
            panelInput.TabIndex = 4;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(604, 66);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 126;
            label2.Text = "Học Vị:";
            // 
            // MaGV
            // 
            MaGV.DataPropertyName = "MaGV";
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
            Khoa.DataPropertyName = "Khoa";
            Khoa.HeaderText = "Khoa";
            Khoa.MinimumWidth = 6;
            Khoa.Name = "Khoa";
            Khoa.ReadOnly = true;
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
        private DateTimePicker dtpAdNamSinhGV;
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
        private TextBox txtAdCCCDgv;
        private ComboBox cboLoaiTK;
        private TextBox txtAdMaGV;
        private TextBox txtAdHoTenGV;
        private TextBox txtTuKhoaTK;
        private GroupBox groupBoxSearch;
        private Label label11;
        private Panel panelSearch;
        private ComboBox cboKhoa;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txtAdCCCD_GV;
        private Label label6;
        private GroupBox groupBoxInfo;
        private Panel panelInput;
        private DataGridViewTextBoxColumn MaGV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn HocVi;
        private DataGridViewTextBoxColumn Khoa;
        private Label label2;
        private ComboBox cboHocVi;
    }
}
