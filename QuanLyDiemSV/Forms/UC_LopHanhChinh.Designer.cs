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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_LopHanhChinh));
            panelGrid = new Panel();
            groupBoxList = new GroupBox();
            dgvAdminSinhVien = new DataGridView();
            btnAdTimKiem_SV = new Button();
            cboAdTimKiem_SV = new ComboBox();
            btnAdShowAll_SV = new Button();
            txtAdTuKhoa_SV = new TextBox();
            label11 = new Label();
            groupBoxSearch = new GroupBox();
            label12 = new Label();
            panelSearch = new Panel();
            panelInput = new Panel();
            groupBoxInfo = new GroupBox();
            btnSua = new Button();
            btnLamLai = new Button();
            btnLuu = new Button();
            btnThem = new Button();
            btnXoa = new Button();
            label1 = new Label();
            txtMaLop = new TextBox();
            label2 = new Label();
            txtTenLop = new TextBox();
            label3 = new Label();
            txtNienKhoa = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cboHocVi = new ComboBox();
            cboKhoa = new ComboBox();
            btnAddNganh = new Button();
            MaLop = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            MaNganh = new DataGridViewTextBoxColumn();
            MaGVCN = new DataGridViewTextBoxColumn();
            panelGrid.SuspendLayout();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdminSinhVien).BeginInit();
            groupBoxSearch.SuspendLayout();
            panelSearch.SuspendLayout();
            panelInput.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelGrid
            // 
            panelGrid.Controls.Add(groupBoxList);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 381);
            panelGrid.Margin = new Padding(3, 4, 3, 4);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(10, 12, 10, 12);
            panelGrid.Size = new Size(1694, 573);
            panelGrid.TabIndex = 6;
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
            groupBoxList.Size = new Size(1674, 549);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Danh sách lớp học ";
            // 
            // dgvAdminSinhVien
            // 
            dgvAdminSinhVien.AllowUserToAddRows = false;
            dgvAdminSinhVien.AllowUserToDeleteRows = false;
            dgvAdminSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdminSinhVien.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAdminSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdminSinhVien.Columns.AddRange(new DataGridViewColumn[] { MaLop, TenLop, NgaySinh, MaNganh, MaGVCN });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvAdminSinhVien.DefaultCellStyle = dataGridViewCellStyle1;
            dgvAdminSinhVien.Dock = DockStyle.Fill;
            dgvAdminSinhVien.Location = new Point(3, 24);
            dgvAdminSinhVien.Margin = new Padding(3, 4, 3, 4);
            dgvAdminSinhVien.MultiSelect = false;
            dgvAdminSinhVien.Name = "dgvAdminSinhVien";
            dgvAdminSinhVien.ReadOnly = true;
            dgvAdminSinhVien.RowHeadersWidth = 51;
            dgvAdminSinhVien.RowTemplate.Height = 24;
            dgvAdminSinhVien.Size = new Size(1668, 521);
            dgvAdminSinhVien.TabIndex = 0;
            // 
            // btnAdTimKiem_SV
            // 
            btnAdTimKiem_SV.BackColor = Color.White;
            btnAdTimKiem_SV.FlatStyle = FlatStyle.Flat;
            btnAdTimKiem_SV.Location = new Point(899, 16);
            btnAdTimKiem_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdTimKiem_SV.Name = "btnAdTimKiem_SV";
            btnAdTimKiem_SV.Size = new Size(120, 40);
            btnAdTimKiem_SV.TabIndex = 20;
            btnAdTimKiem_SV.Text = "Tìm Kiếm";
            btnAdTimKiem_SV.UseVisualStyleBackColor = false;
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
            btnAdShowAll_SV.Location = new Point(1043, 13);
            btnAdShowAll_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdShowAll_SV.Name = "btnAdShowAll_SV";
            btnAdShowAll_SV.Size = new Size(120, 40);
            btnAdShowAll_SV.TabIndex = 21;
            btnAdShowAll_SV.Text = "Hiện tất cả";
            btnAdShowAll_SV.UseVisualStyleBackColor = false;
            // 
            // txtAdTuKhoa_SV
            // 
            txtAdTuKhoa_SV.Location = new Point(455, 26);
            txtAdTuKhoa_SV.Margin = new Padding(3, 4, 3, 4);
            txtAdTuKhoa_SV.Name = "txtAdTuKhoa_SV";
            txtAdTuKhoa_SV.Size = new Size(400, 27);
            txtAdTuKhoa_SV.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(25, 29);
            label11.Name = "label11";
            label11.Size = new Size(109, 20);
            label11.TabIndex = 74;
            label11.Text = "Loại Tìm Kiếm";
            // 
            // groupBoxSearch
            // 
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
            groupBoxSearch.Size = new Size(1674, 68);
            groupBoxSearch.TabIndex = 0;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "Tìm kiếm";
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
            // panelSearch
            // 
            panelSearch.BackColor = SystemColors.ControlLight;
            panelSearch.Controls.Add(groupBoxSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 301);
            panelSearch.Margin = new Padding(3, 4, 3, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(10, 6, 10, 6);
            panelSearch.Size = new Size(1694, 80);
            panelSearch.TabIndex = 5;
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
            panelInput.Size = new Size(1694, 301);
            panelInput.TabIndex = 4;
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.BackColor = Color.LemonChiffon;
            groupBoxInfo.Controls.Add(label4);
            groupBoxInfo.Controls.Add(label5);
            groupBoxInfo.Controls.Add(cboHocVi);
            groupBoxInfo.Controls.Add(cboKhoa);
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
            groupBoxInfo.Size = new Size(1674, 277);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "Thông tin lớp học";
            groupBoxInfo.Enter += groupBoxInfo_Enter;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(744, 206);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Padding = new Padding(10, 0, 0, 0);
            btnSua.Size = new Size(195, 56);
            btnSua.TabIndex = 21;
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
            btnLamLai.Location = new Point(522, 206);
            btnLamLai.Margin = new Padding(3, 4, 3, 4);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Padding = new Padding(10, 0, 0, 0);
            btnLamLai.Size = new Size(195, 56);
            btnLamLai.TabIndex = 20;
            btnLamLai.Text = "Làm lại";
            btnLamLai.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(65, 206);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Padding = new Padding(10, 0, 0, 0);
            btnLuu.Size = new Size(195, 56);
            btnLuu.TabIndex = 18;
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
            btnThem.Location = new Point(296, 206);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(10, 0, 0, 0);
            btnThem.Size = new Size(195, 56);
            btnThem.TabIndex = 19;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(968, 206);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Padding = new Padding(10, 0, 0, 0);
            btnXoa.Size = new Size(195, 56);
            btnXoa.TabIndex = 22;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
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
            // txtMaLop
            // 
            txtMaLop.Location = new Point(180, 45);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(216, 27);
            txtMaLop.TabIndex = 24;
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
            // txtTenLop
            // 
            txtTenLop.Location = new Point(180, 97);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(216, 27);
            txtTenLop.TabIndex = 24;
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
            // txtNienKhoa
            // 
            txtNienKhoa.Location = new Point(180, 152);
            txtNienKhoa.Name = "txtNienKhoa";
            txtNienKhoa.Size = new Size(216, 27);
            txtNienKhoa.TabIndex = 24;
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
            // cboHocVi
            // 
            cboHocVi.FormattingEnabled = true;
            cboHocVi.Location = new Point(513, 97);
            cboHocVi.Margin = new Padding(3, 4, 3, 4);
            cboHocVi.Name = "cboHocVi";
            cboHocVi.Size = new Size(400, 28);
            cboHocVi.TabIndex = 127;
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(513, 45);
            cboKhoa.Margin = new Padding(3, 4, 3, 4);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(400, 28);
            cboKhoa.TabIndex = 128;
            // 
            // btnAddNganh
            // 
            btnAddNganh.BackColor = Color.White;
            btnAddNganh.FlatStyle = FlatStyle.Flat;
            btnAddNganh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNganh.Image = (Image)resources.GetObject("btnAddNganh.Image");
            btnAddNganh.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddNganh.Location = new Point(942, 40);
            btnAddNganh.Margin = new Padding(3, 4, 3, 4);
            btnAddNganh.Name = "btnAddNganh";
            btnAddNganh.Padding = new Padding(10, 0, 0, 0);
            btnAddNganh.Size = new Size(147, 39);
            btnAddNganh.TabIndex = 19;
            btnAddNganh.Text = "Ngành";
            btnAddNganh.UseVisualStyleBackColor = false;
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
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            NgaySinh.HeaderText = "Niên khóa";
            NgaySinh.MinimumWidth = 6;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            // 
            // MaNganh
            // 
            MaNganh.DataPropertyName = "MaNganh";
            MaNganh.HeaderText = "Ngành";
            MaNganh.MinimumWidth = 6;
            MaNganh.Name = "MaNganh";
            MaNganh.ReadOnly = true;
            // 
            // MaGVCN
            // 
            MaGVCN.DataPropertyName = "MaGVCN";
            MaGVCN.HeaderText = "Cố vấn học tập";
            MaGVCN.MinimumWidth = 6;
            MaGVCN.Name = "MaGVCN";
            MaGVCN.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)dgvAdminSinhVien).EndInit();
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
        private DataGridView dgvAdminSinhVien;
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
        private ComboBox cboHocVi;
        private ComboBox cboKhoa;
        private Button btnAddNganh;
        private DataGridViewTextBoxColumn MaLop;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn MaNganh;
        private DataGridViewTextBoxColumn MaGVCN;
    }
}
