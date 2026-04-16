namespace QuanLyDiemSV.Forms
{
    partial class UC_LopHanhChinh
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_LopHanhChinh));
            panelGrid = new Panel();
            groupBoxList = new GroupBox();
            dgvLopHanhChinh = new DataGridView();
            MaLop = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            NienKhoa = new DataGridViewTextBoxColumn();
            MaNganh = new DataGridViewTextBoxColumn();
            MaGVCN = new DataGridViewTextBoxColumn();
            btnAdTimKiem_SV = new Button();
            cboAdTimKiem_SV = new ComboBox();
            btnAdShowAll_SV = new Button();
            txtAdTuKhoa_SV = new TextBox();
            label11 = new Label();
            groupBoxSearch = new GroupBox();
            cboLocDuLieu = new ComboBox();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            cboKieuSX = new ComboBox();
            label9 = new Label();
            label6 = new Label();
            label12 = new Label();
            panelSearch = new Panel();
            panelInput = new Panel();
            groupBoxInfo = new GroupBox();
            label4 = new Label();
            label5 = new Label();
            cboGCVN = new ComboBox();
            cboNganh = new ComboBox();
            txtNienKhoa = new TextBox();
            label3 = new Label();
            txtTenLop = new TextBox();
            label2 = new Label();
            txtMaLop = new TextBox();
            label1 = new Label();
            btnSua = new Button();
            btnLamLai = new Button();
            btnLuu = new Button();
            btnAddNganh = new Button();
            btnThem = new Button();
            btnXoa = new Button();
            btnNhap = new Button();
            btnXuat = new Button();
            panelGrid.SuspendLayout();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHanhChinh).BeginInit();
            groupBoxSearch.SuspendLayout();
            panelSearch.SuspendLayout();
            panelInput.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(groupBoxList);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 394);
            panelGrid.Margin = new Padding(3, 4, 3, 4);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(10, 12, 10, 12);
            panelGrid.Size = new Size(1694, 560);
            panelGrid.TabIndex = 6;
            // 
            // groupBoxList
            // 
            groupBoxList.BackColor = Color.White;
            groupBoxList.Controls.Add(dgvLopHanhChinh);
            groupBoxList.Dock = DockStyle.Fill;
            groupBoxList.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxList.Location = new Point(10, 12);
            groupBoxList.Margin = new Padding(3, 4, 3, 4);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(3, 4, 3, 4);
            groupBoxList.Size = new Size(1674, 536);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Danh sách lớp học ";
            // 
            // dgvLopHanhChinh
            // 
            dgvLopHanhChinh.AllowUserToAddRows = false;
            dgvLopHanhChinh.AllowUserToDeleteRows = false;
            dgvLopHanhChinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLopHanhChinh.BackgroundColor = SystemColors.ButtonHighlight;
            dgvLopHanhChinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHanhChinh.Columns.AddRange(new DataGridViewColumn[] { MaLop, TenLop, NienKhoa, MaNganh, MaGVCN });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvLopHanhChinh.DefaultCellStyle = dataGridViewCellStyle4;
            dgvLopHanhChinh.Dock = DockStyle.Fill;
            dgvLopHanhChinh.Location = new Point(3, 24);
            dgvLopHanhChinh.Margin = new Padding(3, 4, 3, 4);
            dgvLopHanhChinh.MultiSelect = false;
            dgvLopHanhChinh.Name = "dgvLopHanhChinh";
            dgvLopHanhChinh.ReadOnly = true;
            dgvLopHanhChinh.RowHeadersWidth = 51;
            dgvLopHanhChinh.RowTemplate.Height = 24;
            dgvLopHanhChinh.Size = new Size(1668, 508);
            dgvLopHanhChinh.TabIndex = 0;
            // 
            // MaLop
            // 
            MaLop.DataPropertyName = "MaLop";
            MaLop.HeaderText = "Mã Lớp";
            MaLop.MinimumWidth = 6;
            MaLop.Name = "MaLop";
            MaLop.ReadOnly = true;
            // 
            // TenLop
            // 
            TenLop.DataPropertyName = "TenLop";
            TenLop.HeaderText = "Tên Lớp";
            TenLop.MinimumWidth = 6;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // NienKhoa
            // 
            NienKhoa.DataPropertyName = "NienKhoa";
            NienKhoa.HeaderText = "Niên khóa";
            NienKhoa.MinimumWidth = 6;
            NienKhoa.Name = "NienKhoa";
            NienKhoa.ReadOnly = true;
            // 
            // MaNganh
            // 
            MaNganh.DataPropertyName = "TenNganh";
            MaNganh.HeaderText = "Ngành";
            MaNganh.MinimumWidth = 6;
            MaNganh.Name = "MaNganh";
            MaNganh.ReadOnly = true;
            // 
            // MaGVCN
            // 
            MaGVCN.DataPropertyName = "TenGV";
            MaGVCN.HeaderText = "Cố vấn học tập";
            MaGVCN.MinimumWidth = 6;
            MaGVCN.Name = "MaGVCN";
            MaGVCN.ReadOnly = true;
            // 
            // btnAdTimKiem_SV
            // 
            btnAdTimKiem_SV.BackColor = Color.White;
            btnAdTimKiem_SV.FlatStyle = FlatStyle.Flat;
            btnAdTimKiem_SV.Location = new Point(1375, 24);
            btnAdTimKiem_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdTimKiem_SV.Name = "btnAdTimKiem_SV";
            btnAdTimKiem_SV.Size = new Size(108, 35);
            btnAdTimKiem_SV.TabIndex = 20;
            btnAdTimKiem_SV.Text = "Tìm Kiếm";
            btnAdTimKiem_SV.UseVisualStyleBackColor = false;
            btnAdTimKiem_SV.Click += btnAdTimKiem_SV_Click;
            // 
            // cboAdTimKiem_SV
            // 
            cboAdTimKiem_SV.FormattingEnabled = true;
            cboAdTimKiem_SV.Location = new Point(650, 26);
            cboAdTimKiem_SV.Margin = new Padding(3, 4, 3, 4);
            cboAdTimKiem_SV.Name = "cboAdTimKiem_SV";
            cboAdTimKiem_SV.Size = new Size(200, 28);
            cboAdTimKiem_SV.TabIndex = 18;
            // 
            // btnAdShowAll_SV
            // 
            btnAdShowAll_SV.BackColor = Color.White;
            btnAdShowAll_SV.FlatStyle = FlatStyle.Flat;
            btnAdShowAll_SV.Location = new Point(1508, 24);
            btnAdShowAll_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdShowAll_SV.Name = "btnAdShowAll_SV";
            btnAdShowAll_SV.Size = new Size(108, 35);
            btnAdShowAll_SV.TabIndex = 21;
            btnAdShowAll_SV.Text = "Hiện tất cả";
            btnAdShowAll_SV.UseVisualStyleBackColor = false;
            btnAdShowAll_SV.Click += btnAdShowAll_SV_Click;
            // 
            // txtAdTuKhoa_SV
            // 
            txtAdTuKhoa_SV.Location = new Point(939, 27);
            txtAdTuKhoa_SV.Margin = new Padding(3, 4, 3, 4);
            txtAdTuKhoa_SV.Name = "txtAdTuKhoa_SV";
            txtAdTuKhoa_SV.PlaceholderText = "Nhập từ khóa cần tìm..";
            txtAdTuKhoa_SV.Size = new Size(400, 27);
            txtAdTuKhoa_SV.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(524, 31);
            label11.Name = "label11";
            label11.Size = new Size(109, 20);
            label11.TabIndex = 74;
            label11.Text = "Loại Tìm Kiếm";
            // 
            // groupBoxSearch
            // 
            groupBoxSearch.BackColor = Color.White;
            groupBoxSearch.Controls.Add(cboLocDuLieu);
            groupBoxSearch.Controls.Add(radGiam);
            groupBoxSearch.Controls.Add(radTang);
            groupBoxSearch.Controls.Add(cboKieuSX);
            groupBoxSearch.Controls.Add(label9);
            groupBoxSearch.Controls.Add(txtAdTuKhoa_SV);
            groupBoxSearch.Controls.Add(label6);
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
            groupBoxSearch.Size = new Size(1674, 111);
            groupBoxSearch.TabIndex = 0;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "Tìm kiếm";
            // 
            // cboLocDuLieu
            // 
            cboLocDuLieu.FormattingEnabled = true;
            cboLocDuLieu.Location = new Point(151, 23);
            cboLocDuLieu.Name = "cboLocDuLieu";
            cboLocDuLieu.Size = new Size(356, 28);
            cboLocDuLieu.TabIndex = 90;
            cboLocDuLieu.SelectedIndexChanged += cboLocDuLieu_SelectedIndexChanged;
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(392, 73);
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
            radTang.Location = new Point(322, 73);
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
            cboKieuSX.Location = new Point(151, 69);
            cboKieuSX.Name = "cboKieuSX";
            cboKieuSX.Size = new Size(151, 28);
            cboKieuSX.TabIndex = 87;
            cboKieuSX.SelectedIndexChanged += cboKieuSX_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(30, 75);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 86;
            label9.Text = "Kiểu Sắp Xếp:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 29);
            label6.Name = "label6";
            label6.Size = new Size(111, 20);
            label6.TabIndex = 74;
            label6.Text = "Lọc theo khoa:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(866, 29);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 76;
            label12.Text = "Từ Khóa";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(groupBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 271);
            panelSearch.Margin = new Padding(3, 4, 3, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(10, 6, 10, 6);
            panelSearch.Size = new Size(1694, 123);
            panelSearch.TabIndex = 5;
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
            panelInput.Size = new Size(1694, 271);
            panelInput.TabIndex = 4;
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.BackColor = Color.White;
            groupBoxInfo.Controls.Add(btnXuat);
            groupBoxInfo.Controls.Add(btnNhap);
            groupBoxInfo.Controls.Add(label4);
            groupBoxInfo.Controls.Add(label5);
            groupBoxInfo.Controls.Add(cboGCVN);
            groupBoxInfo.Controls.Add(cboNganh);
            groupBoxInfo.Controls.Add(txtNienKhoa);
            groupBoxInfo.Controls.Add(label3);
            groupBoxInfo.Controls.Add(txtTenLop);
            groupBoxInfo.Controls.Add(label2);
            groupBoxInfo.Controls.Add(txtMaLop);
            groupBoxInfo.Controls.Add(label1);
            groupBoxInfo.Controls.Add(btnSua);
            groupBoxInfo.Controls.Add(btnLamLai);
            groupBoxInfo.Controls.Add(btnLuu);
            groupBoxInfo.Controls.Add(btnAddNganh);
            groupBoxInfo.Controls.Add(btnThem);
            groupBoxInfo.Controls.Add(btnXoa);
            groupBoxInfo.Dock = DockStyle.Fill;
            groupBoxInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxInfo.Location = new Point(10, 12);
            groupBoxInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Padding = new Padding(3, 4, 3, 4);
            groupBoxInfo.Size = new Size(1674, 247);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "Thông tin lớp học";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(431, 100);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 129;
            label4.Text = "GVCN:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(431, 49);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 130;
            label5.Text = "Ngành: ";
            // 
            // cboGCVN
            // 
            cboGCVN.FormattingEnabled = true;
            cboGCVN.Location = new Point(513, 97);
            cboGCVN.Margin = new Padding(3, 4, 3, 4);
            cboGCVN.Name = "cboGCVN";
            cboGCVN.Size = new Size(400, 28);
            cboGCVN.TabIndex = 127;
            // 
            // cboNganh
            // 
            cboNganh.FormattingEnabled = true;
            cboNganh.Location = new Point(513, 45);
            cboNganh.Margin = new Padding(3, 4, 3, 4);
            cboNganh.Name = "cboNganh";
            cboNganh.Size = new Size(400, 28);
            cboNganh.TabIndex = 128;
            // 
            // txtNienKhoa
            // 
            txtNienKhoa.Location = new Point(180, 152);
            txtNienKhoa.Name = "txtNienKhoa";
            txtNienKhoa.Size = new Size(216, 27);
            txtNienKhoa.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 155);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 23;
            label3.Text = "Niên Khóa:";
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(180, 97);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(216, 27);
            txtTenLop.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 100);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 23;
            label2.Text = "Tên Lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new Point(180, 45);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(216, 27);
            txtMaLop.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 45);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 23;
            label1.Text = "Mã Lớp:";
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(746, 194);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Padding = new Padding(10, 0, 0, 0);
            btnSua.Size = new Size(152, 41);
            btnSua.TabIndex = 21;
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
            btnLamLai.Location = new Point(524, 194);
            btnLamLai.Margin = new Padding(3, 4, 3, 4);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Padding = new Padding(10, 0, 0, 0);
            btnLamLai.Size = new Size(152, 41);
            btnLamLai.TabIndex = 20;
            btnLamLai.Text = "Làm lại";
            btnLamLai.UseVisualStyleBackColor = false;
            btnLamLai.Click += btnLamLai_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(67, 194);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Padding = new Padding(10, 0, 0, 0);
            btnLuu.Size = new Size(152, 41);
            btnLuu.TabIndex = 18;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnAddNganh
            // 
            btnAddNganh.BackColor = Color.White;
            btnAddNganh.FlatStyle = FlatStyle.Flat;
            btnAddNganh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNganh.Image = (Image)resources.GetObject("btnAddNganh.Image");
            btnAddNganh.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddNganh.Location = new Point(939, 36);
            btnAddNganh.Margin = new Padding(3, 4, 3, 4);
            btnAddNganh.Name = "btnAddNganh";
            btnAddNganh.Padding = new Padding(10, 0, 0, 0);
            btnAddNganh.Size = new Size(147, 39);
            btnAddNganh.TabIndex = 19;
            btnAddNganh.Text = "Ngành";
            btnAddNganh.UseVisualStyleBackColor = false;
            btnAddNganh.Click += btnAddNganh_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(298, 194);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(10, 0, 0, 0);
            btnThem.Size = new Size(152, 41);
            btnThem.TabIndex = 19;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(970, 194);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Padding = new Padding(10, 0, 0, 0);
            btnXoa.Size = new Size(152, 41);
            btnXoa.TabIndex = 22;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(1148, 194);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(152, 41);
            btnNhap.TabIndex = 131;
            btnNhap.Text = "Nhập Excel";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnXuat
            // 
            btnXuat.Location = new Point(1331, 194);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(152, 41);
            btnXuat.TabIndex = 131;
            btnXuat.Text = "Xuất Excel";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // UC_LopHanhChinh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelGrid);
            Controls.Add(panelSearch);
            Controls.Add(panelInput);
            Name = "UC_LopHanhChinh";
            Size = new Size(1694, 954);
            panelGrid.ResumeLayout(false);
            groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLopHanhChinh).EndInit();
            groupBoxSearch.ResumeLayout(false);
            groupBoxSearch.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGrid;
        private GroupBox groupBoxList;
        private DataGridView dgvLopHanhChinh;
        private Button btnAdTimKiem_SV;
        private ComboBox cboAdTimKiem_SV;
        private Button btnAdShowAll_SV;
        private TextBox txtAdTuKhoa_SV;
        private Label label11;
        private GroupBox groupBoxSearch;
        private Label label12;
        private Panel panelSearch;
        private Panel panelInput;
        private GroupBox groupBoxInfo;
        private Button btnSua;
        private Button btnLamLai;
        private Button btnLuu;
        private Button btnThem;
        private Button btnXoa;
        private TextBox txtNienKhoa;
        private Label label3;
        private TextBox txtTenLop;
        private Label label2;
        private TextBox txtMaLop;
        private Label label1;
        private Label label4;
        private Label label5;
        private ComboBox cboGCVN;
        private ComboBox cboNganh;
        private Button btnAddNganh;
        private RadioButton radGiam;
        private RadioButton radTang;
        private ComboBox cboKieuSX;
        private Label label9;
        private DataGridViewTextBoxColumn MaLop;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn NienKhoa;
        private DataGridViewTextBoxColumn MaNganh;
        private DataGridViewTextBoxColumn MaGVCN;
        private ComboBox cboLocDuLieu;
        private Label label6;
        private Button btnXuat;
        private Button btnNhap;
    }
}
