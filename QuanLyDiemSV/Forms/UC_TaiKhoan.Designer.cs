namespace QuanLyDiemSV.Forms
{
    partial class UC_TaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TaiKhoan));
            panel1 = new Panel();
            panel4 = new Panel();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            UserID = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            PasswordHash = new DataGridViewTextBoxColumn();
            RoleID = new DataGridViewTextBoxColumn();
            IsActive = new DataGridViewTextBoxColumn();
            NgayTao = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            groupBox2 = new GroupBox();
            label8 = new Label();
            cboKieuSX = new ComboBox();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            txtTuKhoaTK = new TextBox();
            label11 = new Label();
            label12 = new Label();
            cboLoaiTK = new ComboBox();
            btnShowAll = new Button();
            btnTimKiem = new Button();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            btnXuat = new Button();
            btnSua = new Button();
            btnLamLai = new Button();
            btnLuu = new Button();
            btnThemQuyenHan = new Button();
            btnThem = new Button();
            btnNhap = new Button();
            btnXoa = new Button();
            dtpNgayTao = new DateTimePicker();
            cboQuyenHan = new ComboBox();
            cbKhoa = new ComboBox();
            cboTrangThai = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtMatKhau = new TextBox();
            label3 = new Label();
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            txtUserID = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 954);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(groupBox3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 411);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10, 0, 10, 0);
            panel4.Size = new Size(1694, 543);
            panel4.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(10, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1674, 543);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách tài khoản";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { UserID, Username, PasswordHash, RoleID, IsActive, NgayTao });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1668, 514);
            dataGridView1.TabIndex = 0;
            // 
            // UserID
            // 
            UserID.DataPropertyName = "UserID";
            UserID.HeaderText = "UserID";
            UserID.MinimumWidth = 6;
            UserID.Name = "UserID";
            UserID.ReadOnly = true;
            // 
            // Username
            // 
            Username.DataPropertyName = "Username";
            Username.HeaderText = "Tên Đăng Nhập";
            Username.MinimumWidth = 6;
            Username.Name = "Username";
            Username.ReadOnly = true;
            // 
            // PasswordHash
            // 
            PasswordHash.DataPropertyName = "PasswordHash";
            PasswordHash.HeaderText = "Mật khẩu";
            PasswordHash.MinimumWidth = 6;
            PasswordHash.Name = "PasswordHash";
            PasswordHash.ReadOnly = true;
            // 
            // RoleID
            // 
            RoleID.DataPropertyName = "RoleID";
            RoleID.HeaderText = "Quyền Hạn";
            RoleID.MinimumWidth = 6;
            RoleID.Name = "RoleID";
            RoleID.ReadOnly = true;
            // 
            // IsActive
            // 
            IsActive.DataPropertyName = "IsActive";
            IsActive.HeaderText = "Trạng thái";
            IsActive.MinimumWidth = 6;
            IsActive.Name = "IsActive";
            IsActive.ReadOnly = true;
            // 
            // NgayTao
            // 
            NgayTao.DataPropertyName = "NgayTao";
            NgayTao.HeaderText = "Ngày Tạo";
            NgayTao.MinimumWidth = 6;
            NgayTao.Name = "NgayTao";
            NgayTao.ReadOnly = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 286);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10, 0, 10, 0);
            panel3.Size = new Size(1694, 125);
            panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cboKieuSX);
            groupBox2.Controls.Add(radGiam);
            groupBox2.Controls.Add(radTang);
            groupBox2.Controls.Add(txtTuKhoaTK);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(cboLoaiTK);
            groupBox2.Controls.Add(btnShowAll);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(10, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1674, 125);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tiềm Kiếm và Sắp xếp";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1180, 66);
            label8.Name = "label8";
            label8.Size = new Size(111, 23);
            label8.TabIndex = 90;
            label8.Text = "Kiểu Sắp Xếp";
            // 
            // cboKieuSX
            // 
            cboKieuSX.FormattingEnabled = true;
            cboKieuSX.Location = new Point(1297, 63);
            cboKieuSX.Name = "cboKieuSX";
            cboKieuSX.Size = new Size(151, 31);
            cboKieuSX.TabIndex = 89;
            cboKieuSX.SelectedIndexChanged += cboKieuSX_SelectedIndexChanged;
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(1562, 67);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(71, 27);
            radGiam.TabIndex = 87;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            radGiam.CheckedChanged += radGiam_CheckedChanged;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Location = new Point(1475, 67);
            radTang.Name = "radTang";
            radTang.Size = new Size(67, 27);
            radTang.TabIndex = 88;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            radTang.CheckedChanged += radTang_CheckedChanged;
            // 
            // txtTuKhoaTK
            // 
            txtTuKhoaTK.Location = new Point(477, 59);
            txtTuKhoaTK.Margin = new Padding(3, 4, 3, 4);
            txtTuKhoaTK.Name = "txtTuKhoaTK";
            txtTuKhoaTK.Size = new Size(400, 30);
            txtTuKhoaTK.TabIndex = 82;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(31, 59);
            label11.Name = "label11";
            label11.Size = new Size(117, 23);
            label11.TabIndex = 85;
            label11.Text = "Loại Tìm Kiếm";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(385, 62);
            label12.Name = "label12";
            label12.Size = new Size(74, 23);
            label12.TabIndex = 86;
            label12.Text = "Từ Khóa";
            // 
            // cboLoaiTK
            // 
            cboLoaiTK.FormattingEnabled = true;
            cboLoaiTK.Location = new Point(160, 57);
            cboLoaiTK.Margin = new Padding(3, 4, 3, 4);
            cboLoaiTK.Name = "cboLoaiTK";
            cboLoaiTK.Size = new Size(200, 31);
            cboLoaiTK.TabIndex = 81;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.White;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.Location = new Point(1039, 59);
            btnShowAll.Margin = new Padding(3, 4, 3, 4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(120, 34);
            btnShowAll.TabIndex = 84;
            btnShowAll.Text = "Hiện tất cả";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click_1;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Location = new Point(901, 59);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 34);
            btnTimKiem.TabIndex = 83;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1694, 286);
            panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnLamLai);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnThemQuyenHan);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnNhap);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(dtpNgayTao);
            groupBox1.Controls.Add(cboQuyenHan);
            groupBox1.Controls.Add(cbKhoa);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTenDangNhap);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtUserID);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1694, 286);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin tài khoản";
            // 
            // btnXuat
            // 
            btnXuat.BackColor = Color.White;
            btnXuat.FlatStyle = FlatStyle.Flat;
            btnXuat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuat.Image = (Image)resources.GetObject("btnXuat.Image");
            btnXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuat.Location = new Point(1168, 210);
            btnXuat.Margin = new Padding(3, 4, 3, 4);
            btnXuat.Name = "btnXuat";
            btnXuat.Padding = new Padding(10, 0, 0, 0);
            btnXuat.Size = new Size(159, 41);
            btnXuat.TabIndex = 21;
            btnXuat.Text = "Xuất";
            btnXuat.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(727, 210);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Padding = new Padding(10, 0, 0, 0);
            btnSua.Size = new Size(159, 41);
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
            btnLamLai.Location = new Point(505, 210);
            btnLamLai.Margin = new Padding(3, 4, 3, 4);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Padding = new Padding(10, 0, 0, 0);
            btnLamLai.Size = new Size(159, 41);
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
            btnLuu.Location = new Point(48, 210);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Padding = new Padding(10, 0, 0, 0);
            btnLuu.Size = new Size(159, 41);
            btnLuu.TabIndex = 18;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThemQuyenHan
            // 
            btnThemQuyenHan.BackColor = Color.White;
            btnThemQuyenHan.FlatStyle = FlatStyle.Flat;
            btnThemQuyenHan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemQuyenHan.Image = (Image)resources.GetObject("btnThemQuyenHan.Image");
            btnThemQuyenHan.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemQuyenHan.Location = new Point(747, 147);
            btnThemQuyenHan.Margin = new Padding(3, 4, 3, 4);
            btnThemQuyenHan.Name = "btnThemQuyenHan";
            btnThemQuyenHan.Padding = new Padding(10, 0, 0, 0);
            btnThemQuyenHan.Size = new Size(63, 43);
            btnThemQuyenHan.TabIndex = 19;
            btnThemQuyenHan.Text = "         ";
            btnThemQuyenHan.UseVisualStyleBackColor = false;
            btnThemQuyenHan.Click += btnThemQuyenHan_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(279, 210);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(10, 0, 0, 0);
            btnThem.Size = new Size(159, 41);
            btnThem.TabIndex = 19;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnNhap
            // 
            btnNhap.BackColor = Color.White;
            btnNhap.FlatStyle = FlatStyle.Flat;
            btnNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhap.Image = (Image)resources.GetObject("btnNhap.Image");
            btnNhap.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhap.Location = new Point(1392, 210);
            btnNhap.Margin = new Padding(3, 4, 3, 4);
            btnNhap.Name = "btnNhap";
            btnNhap.Padding = new Padding(10, 0, 0, 0);
            btnNhap.Size = new Size(159, 41);
            btnNhap.TabIndex = 22;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(951, 210);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Padding = new Padding(10, 0, 0, 0);
            btnXoa.Size = new Size(159, 41);
            btnXoa.TabIndex = 22;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // dtpNgayTao
            // 
            dtpNgayTao.Format = DateTimePickerFormat.Custom;
            dtpNgayTao.Location = new Point(578, 97);
            dtpNgayTao.Name = "dtpNgayTao";
            dtpNgayTao.Size = new Size(292, 30);
            dtpNgayTao.TabIndex = 4;
            // 
            // cboQuyenHan
            // 
            cboQuyenHan.FormattingEnabled = true;
            cboQuyenHan.Location = new Point(578, 150);
            cboQuyenHan.Name = "cboQuyenHan";
            cboQuyenHan.Size = new Size(151, 31);
            cboQuyenHan.TabIndex = 3;
            // 
            // cbKhoa
            // 
            cbKhoa.FormattingEnabled = true;
            cbKhoa.Location = new Point(925, 49);
            cbKhoa.Name = "cbKhoa";
            cbKhoa.Size = new Size(288, 31);
            cbKhoa.TabIndex = 3;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(578, 46);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 31);
            cboTrangThai.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(469, 153);
            label6.Name = "label6";
            label6.Size = new Size(102, 23);
            label6.TabIndex = 2;
            label6.Text = "Quyền Hạn:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(776, 49);
            label7.Name = "label7";
            label7.Size = new Size(143, 23);
            label7.TabIndex = 2;
            label7.Text = "Khoa(Nếu là GV):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(469, 97);
            label5.Name = "label5";
            label5.Size = new Size(85, 23);
            label5.TabIndex = 2;
            label5.Text = "Ngày tạo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(469, 49);
            label4.Name = "label4";
            label4.Size = new Size(91, 23);
            label4.TabIndex = 2;
            label4.Text = "Trạng thái:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(189, 147);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(233, 30);
            txtMatKhau.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 150);
            label3.Name = "label3";
            label3.Size = new Size(103, 23);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu(*)";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(189, 90);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(233, 30);
            txtTenDangNhap.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 97);
            label2.Name = "label2";
            label2.Size = new Size(128, 23);
            label2.TabIndex = 0;
            label2.Text = "Tên đăng nhập:";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(189, 42);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(233, 30);
            txtUserID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 42);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 0;
            label1.Text = "UserID:";
            // 
            // UC_TaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "UC_TaiKhoan";
            Size = new Size(1694, 954);
            Load += UC_TaiKhoan_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox1;
        private TextBox txtMatKhau;
        private Label label3;
        private TextBox txtTenDangNhap;
        private Label label2;
        private TextBox txtUserID;
        private Label label1;
        private ComboBox cboTrangThai;
        private Label label5;
        private Label label4;
        private DateTimePicker dtpNgayTao;
        private ComboBox cboQuyenHan;
        private Label label6;
        private Button btnSua;
        private Button btnLamLai;
        private Button btnLuu;
        private Button btnThem;
        private Button btnXoa;
        private ComboBox cbKhoa;
        private Label label7;
        private Panel panel4;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private Panel panel3;
        private GroupBox groupBox2;
        private Label label8;
        private ComboBox cboKieuSX;
        private RadioButton radGiam;
        private RadioButton radTang;
        private TextBox txtTuKhoaTK;
        private Label label11;
        private Label label12;
        private ComboBox cboLoaiTK;
        private Button btnShowAll;
        private Button btnTimKiem;
        private Button btnThemQuyenHan;
        private DataGridViewTextBoxColumn UserID;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn PasswordHash;
        private DataGridViewTextBoxColumn RoleID;
        private DataGridViewTextBoxColumn IsActive;
        private DataGridViewTextBoxColumn NgayTao;
        private Button btnXuat;
        private Button btnNhap;
    }
}
