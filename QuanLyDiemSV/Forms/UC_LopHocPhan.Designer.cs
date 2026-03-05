namespace QuanLyDiemSV
{
    partial class UC_LopHocPhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_LopHocPhan));
            panel1 = new Panel();
            panel4 = new Panel();
            groupBox3 = new GroupBox();
            dgvLopHocPhan = new DataGridView();
            MaLHP = new DataGridViewTextBoxColumn();
            MaMon = new DataGridViewTextBoxColumn();
            MaHK = new DataGridViewTextBoxColumn();
            MaGV = new DataGridViewTextBoxColumn();
            TenLopHP = new DataGridViewTextBoxColumn();
            PhongHoc = new DataGridViewTextBoxColumn();
            SiSoToiDa = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            groupBox2 = new GroupBox();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            cboKieuSX = new ComboBox();
            label9 = new Label();
            txtTuKhoa = new TextBox();
            label11 = new Label();
            label12 = new Label();
            cboTimKiem = new ComboBox();
            btnShowAll = new Button();
            btnTimKiem = new Button();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            btnAddHocKy = new Button();
            btnSua = new Button();
            btnLamLai = new Button();
            btnLuu = new Button();
            btnThem = new Button();
            btnXoa = new Button();
            cboTrangThai = new ComboBox();
            txtSiSo = new TextBox();
            txtPhongHoc = new TextBox();
            label1 = new Label();
            txtMaLHP = new TextBox();
            label6 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label8 = new Label();
            label7 = new Label();
            cboHocKy = new ComboBox();
            label5 = new Label();
            cboMaGV = new ComboBox();
            txtTenLHP = new TextBox();
            cboMaMon = new ComboBox();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHocPhan).BeginInit();
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
            panel1.Size = new Size(1684, 1169);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(groupBox3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 375);
            panel4.Name = "panel4";
            panel4.Size = new Size(1684, 794);
            panel4.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvLopHocPhan);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1684, 794);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin Lớp học phần";
            // 
            // dgvLopHocPhan
            // 
            dgvLopHocPhan.AllowUserToAddRows = false;
            dgvLopHocPhan.AllowUserToDeleteRows = false;
            dgvLopHocPhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLopHocPhan.BackgroundColor = Color.White;
            dgvLopHocPhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHocPhan.Columns.AddRange(new DataGridViewColumn[] { MaLHP, MaMon, MaHK, MaGV, TenLopHP, PhongHoc, SiSoToiDa, TrangThai });
            dgvLopHocPhan.Dock = DockStyle.Fill;
            dgvLopHocPhan.Location = new Point(3, 26);
            dgvLopHocPhan.MultiSelect = false;
            dgvLopHocPhan.Name = "dgvLopHocPhan";
            dgvLopHocPhan.RowHeadersWidth = 51;
            dgvLopHocPhan.Size = new Size(1678, 765);
            dgvLopHocPhan.TabIndex = 0;
            dgvLopHocPhan.CellFormatting += dgvLopHocPhan_CellFormatting;
            // 
            // MaLHP
            // 
            MaLHP.DataPropertyName = "MaLHP";
            MaLHP.HeaderText = "Mã LHP";
            MaLHP.MinimumWidth = 6;
            MaLHP.Name = "MaLHP";
            MaLHP.ReadOnly = true;
            // 
            // MaMon
            // 
            MaMon.DataPropertyName = "MaMon";
            MaMon.HeaderText = "Mã Môn";
            MaMon.MinimumWidth = 6;
            MaMon.Name = "MaMon";
            MaMon.ReadOnly = true;
            // 
            // MaHK
            // 
            MaHK.DataPropertyName = "MaHK";
            MaHK.HeaderText = "Học Kỳ";
            MaHK.MinimumWidth = 6;
            MaHK.Name = "MaHK";
            MaHK.ReadOnly = true;
            // 
            // MaGV
            // 
            MaGV.DataPropertyName = "MaGV";
            MaGV.HeaderText = "Giảng Viên";
            MaGV.MinimumWidth = 6;
            MaGV.Name = "MaGV";
            MaGV.ReadOnly = true;
            // 
            // TenLopHP
            // 
            TenLopHP.DataPropertyName = "TenLopHP";
            TenLopHP.HeaderText = "Tên Lớp HP";
            TenLopHP.MinimumWidth = 6;
            TenLopHP.Name = "TenLopHP";
            TenLopHP.ReadOnly = true;
            // 
            // PhongHoc
            // 
            PhongHoc.DataPropertyName = "PhongHoc";
            PhongHoc.HeaderText = "Phòng Học";
            PhongHoc.MinimumWidth = 6;
            PhongHoc.Name = "PhongHoc";
            PhongHoc.ReadOnly = true;
            // 
            // SiSoToiDa
            // 
            SiSoToiDa.DataPropertyName = "SiSoToiDa";
            SiSoToiDa.HeaderText = "Sĩ số";
            SiSoToiDa.MinimumWidth = 6;
            SiSoToiDa.Name = "SiSoToiDa";
            SiSoToiDa.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 275);
            panel3.Name = "panel3";
            panel3.Size = new Size(1684, 100);
            panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radGiam);
            groupBox2.Controls.Add(radTang);
            groupBox2.Controls.Add(cboKieuSX);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtTuKhoa);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(cboTimKiem);
            groupBox2.Controls.Add(btnShowAll);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1684, 100);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm Kiếm và Sắp xếp";
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(1578, 51);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(73, 27);
            radGiam.TabIndex = 85;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            radGiam.CheckedChanged += radGiam_CheckedChanged;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Location = new Point(1502, 49);
            radTang.Name = "radTang";
            radTang.Size = new Size(70, 27);
            radTang.TabIndex = 85;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            radTang.CheckedChanged += radTang_CheckedChanged;
            // 
            // cboKieuSX
            // 
            cboKieuSX.FormattingEnabled = true;
            cboKieuSX.Location = new Point(1278, 45);
            cboKieuSX.Name = "cboKieuSX";
            cboKieuSX.Size = new Size(198, 31);
            cboKieuSX.TabIndex = 84;
            cboKieuSX.SelectedIndexChanged += cboKieuSX_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1161, 49);
            label9.Name = "label9";
            label9.Size = new Size(121, 23);
            label9.TabIndex = 83;
            label9.Text = "Kiểu Sắp Xếp:";
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(475, 44);
            txtTuKhoa.Margin = new Padding(3, 4, 3, 4);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.Size = new Size(400, 30);
            txtTuKhoa.TabIndex = 78;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(25, 45);
            label11.Name = "label11";
            label11.Size = new Size(125, 23);
            label11.TabIndex = 81;
            label11.Text = "Loại Tìm Kiếm";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(383, 48);
            label12.Name = "label12";
            label12.Size = new Size(76, 23);
            label12.TabIndex = 82;
            label12.Text = "Từ Khóa";
            // 
            // cboTimKiem
            // 
            cboTimKiem.FormattingEnabled = true;
            cboTimKiem.Location = new Point(161, 44);
            cboTimKiem.Margin = new Padding(3, 4, 3, 4);
            cboTimKiem.Name = "cboTimKiem";
            cboTimKiem.Size = new Size(200, 31);
            cboTimKiem.TabIndex = 77;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.White;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.Location = new Point(1025, 39);
            btnShowAll.Margin = new Padding(3, 4, 3, 4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(120, 40);
            btnShowAll.TabIndex = 80;
            btnShowAll.Text = "Hiện tất cả";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Location = new Point(890, 38);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 40);
            btnTimKiem.TabIndex = 79;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1684, 275);
            panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddHocKy);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnLamLai);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(txtSiSo);
            groupBox1.Controls.Add(txtPhongHoc);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMaLHP);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboHocKy);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cboMaGV);
            groupBox1.Controls.Add(txtTenLHP);
            groupBox1.Controls.Add(cboMaMon);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1684, 275);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lớp học phần";
            // 
            // btnAddHocKy
            // 
            btnAddHocKy.Location = new Point(1001, 157);
            btnAddHocKy.Name = "btnAddHocKy";
            btnAddHocKy.Size = new Size(116, 31);
            btnAddHocKy.TabIndex = 148;
            btnAddHocKy.Text = "+ Học Kỳ";
            btnAddHocKy.UseVisualStyleBackColor = true;
            btnAddHocKy.Click += btnAddHocKy_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Left;
            btnSua.FlatAppearance.BorderColor = Color.Blue;
            btnSua.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnSua.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(766, 207);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Padding = new Padding(5, 0, 0, 0);
            btnSua.Size = new Size(199, 43);
            btnSua.TabIndex = 147;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamLai
            // 
            btnLamLai.Anchor = AnchorStyles.Left;
            btnLamLai.FlatAppearance.BorderColor = Color.Blue;
            btnLamLai.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnLamLai.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnLamLai.Image = (Image)resources.GetObject("btnLamLai.Image");
            btnLamLai.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamLai.Location = new Point(536, 207);
            btnLamLai.Margin = new Padding(3, 4, 3, 4);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Padding = new Padding(5, 0, 0, 0);
            btnLamLai.Size = new Size(199, 43);
            btnLamLai.TabIndex = 145;
            btnLamLai.Text = "Làm lại";
            btnLamLai.UseVisualStyleBackColor = true;
            btnLamLai.Click += btnLamLai_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Left;
            btnLuu.FlatAppearance.BorderColor = Color.Blue;
            btnLuu.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnLuu.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuu.Location = new Point(62, 206);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Padding = new Padding(5, 0, 0, 0);
            btnLuu.Size = new Size(199, 43);
            btnLuu.TabIndex = 143;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Left;
            btnThem.FlatAppearance.BorderColor = Color.Blue;
            btnThem.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnThem.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(317, 206);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(5, 0, 0, 0);
            btnThem.Size = new Size(199, 43);
            btnThem.TabIndex = 144;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Left;
            btnXoa.FlatAppearance.BorderColor = Color.Blue;
            btnXoa.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnXoa.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnXoa.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(988, 208);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Padding = new Padding(5, 0, 0, 0);
            btnXoa.Size = new Size(199, 43);
            btnXoa.TabIndex = 146;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Mở lớp", "Đóng" });
            cboTrangThai.Location = new Point(1105, 48);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 31);
            cboTrangThai.TabIndex = 136;
            // 
            // txtSiSo
            // 
            txtSiSo.Location = new Point(425, 154);
            txtSiSo.Margin = new Padding(3, 4, 3, 4);
            txtSiSo.Name = "txtSiSo";
            txtSiSo.Size = new Size(136, 30);
            txtSiSo.TabIndex = 131;
            // 
            // txtPhongHoc
            // 
            txtPhongHoc.Location = new Point(161, 154);
            txtPhongHoc.Margin = new Padding(3, 4, 3, 4);
            txtPhongHoc.Name = "txtPhongHoc";
            txtPhongHoc.Size = new Size(187, 30);
            txtPhongHoc.TabIndex = 130;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(367, 154);
            label1.Name = "label1";
            label1.Size = new Size(52, 23);
            label1.TabIndex = 132;
            label1.Text = "Sĩ số:";
            // 
            // txtMaLHP
            // 
            txtMaLHP.Location = new Point(161, 45);
            txtMaLHP.Margin = new Padding(3, 4, 3, 4);
            txtMaLHP.Name = "txtMaLHP";
            txtMaLHP.Size = new Size(400, 30);
            txtMaLHP.TabIndex = 128;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(997, 48);
            label6.Name = "label6";
            label6.Size = new Size(97, 23);
            label6.TabIndex = 132;
            label6.Text = "Trạng thái:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 157);
            label2.Name = "label2";
            label2.Size = new Size(102, 23);
            label2.TabIndex = 132;
            label2.Text = "Phòng Học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 103);
            label3.Name = "label3";
            label3.Size = new Size(106, 23);
            label3.TabIndex = 133;
            label3.Text = "Tên Lớp HP:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 48);
            label4.Name = "label4";
            label4.Size = new Size(104, 23);
            label4.TabIndex = 134;
            label4.Text = "Mã Lớp HP:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(619, 157);
            label8.Name = "label8";
            label8.Size = new Size(70, 23);
            label8.TabIndex = 135;
            label8.Text = "Học Kỳ:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(619, 103);
            label7.Name = "label7";
            label7.Size = new Size(68, 23);
            label7.TabIndex = 135;
            label7.Text = "Mã GV:";
            // 
            // cboHocKy
            // 
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(734, 157);
            cboHocKy.Margin = new Padding(3, 4, 3, 4);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(243, 31);
            cboHocKy.TabIndex = 127;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(619, 48);
            label5.Name = "label5";
            label5.Size = new Size(81, 23);
            label5.TabIndex = 135;
            label5.Text = "Mã môn:";
            // 
            // cboMaGV
            // 
            cboMaGV.FormattingEnabled = true;
            cboMaGV.Location = new Point(734, 103);
            cboMaGV.Margin = new Padding(3, 4, 3, 4);
            cboMaGV.Name = "cboMaGV";
            cboMaGV.Size = new Size(243, 31);
            cboMaGV.TabIndex = 127;
            // 
            // txtTenLHP
            // 
            txtTenLHP.Location = new Point(161, 96);
            txtTenLHP.Margin = new Padding(3, 4, 3, 4);
            txtTenLHP.Name = "txtTenLHP";
            txtTenLHP.Size = new Size(400, 30);
            txtTenLHP.TabIndex = 129;
            // 
            // cboMaMon
            // 
            cboMaMon.FormattingEnabled = true;
            cboMaMon.Location = new Point(734, 45);
            cboMaMon.Margin = new Padding(3, 4, 3, 4);
            cboMaMon.Name = "cboMaMon";
            cboMaMon.Size = new Size(243, 31);
            cboMaMon.TabIndex = 127;
            // 
            // UC_LopHocPhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_LopHocPhan";
            Size = new Size(1684, 1169);
            Load += UC_LopHocPhan_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLopHocPhan).EndInit();
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
        private ComboBox cboTrangThai;
        private TextBox txtSiSo;
        private TextBox txtPhongHoc;
        private Label label1;
        private TextBox txtMaLHP;
        private Label label6;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTenLHP;
        private ComboBox cboMaMon;
        private Panel panel3;
        private GroupBox groupBox2;
        private Label label8;
        private Label label7;
        private ComboBox cboHocKy;
        private ComboBox cboMaGV;
        private TextBox txtTuKhoa;
        private Label label11;
        private Label label12;
        private ComboBox cboTimKiem;
        private Button btnShowAll;
        private Button btnTimKiem;
        private Panel panel4;
        private GroupBox groupBox3;
        private DataGridView dgvLopHocPhan;
        private RadioButton radGiam;
        private RadioButton radTang;
        private ComboBox cboKieuSX;
        private Label label9;
        private Button btnSua;
        private Button btnLamLai;
        private Button btnLuu;
        private Button btnThem;
        private Button btnXoa;
        private Button btnAddHocKy;
        private DataGridViewTextBoxColumn MaLHP;
        private DataGridViewTextBoxColumn MaMon;
        private DataGridViewTextBoxColumn MaHK;
        private DataGridViewTextBoxColumn MaGV;
        private DataGridViewTextBoxColumn TenLopHP;
        private DataGridViewTextBoxColumn PhongHoc;
        private DataGridViewTextBoxColumn SiSoToiDa;
        private DataGridViewTextBoxColumn TrangThai;
    }
}
