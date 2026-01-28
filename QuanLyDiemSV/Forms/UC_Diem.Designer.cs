namespace GUI
{
    partial class UC_Diem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Diem));
            panel1 = new Panel();
            panel5 = new Panel();
            groupBox4 = new GroupBox();
            label1 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            groupBox3 = new GroupBox();
            dgvBangDiem = new DataGridView();
            MaKQ = new DataGridViewTextBoxColumn();
            MaLHP = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            btnAdSua_SV = new Button();
            btnAdLamLai_SV = new Button();
            btnAdLua_SV = new Button();
            btnAdThem_SV = new Button();
            btnAdXoa_SV = new Button();
            button5 = new Button();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            txtDiemCK = new TextBox();
            label23 = new Label();
            txtDiemQT = new TextBox();
            txtSTC = new TextBox();
            txtTenMon = new TextBox();
            cboMaMon = new ComboBox();
            comboBox1 = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            lblCVHT = new Label();
            lblNganh = new Label();
            lblKhoa = new Label();
            lblLop = new Label();
            lblHoTen = new Label();
            lblMaSV = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            groupBox4.SuspendLayout();
            panel4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 954);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(groupBox4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 691);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10, 0, 10, 10);
            panel5.Size = new Size(1694, 263);
            panel5.TabIndex = 3;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label2);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(10, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1674, 253);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tổng Kết Học Kỳ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label1.Location = new Point(25, 54);
            label1.Name = "label1";
            label1.Size = new Size(196, 18);
            label1.TabIndex = 6;
            label1.Text = "Điểm TB Học Kỳ (hệ 10):";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label5.Location = new Point(25, 187);
            label5.Name = "label5";
            label5.Size = new Size(144, 18);
            label5.TabIndex = 2;
            label5.Text = "Xếp Loại Học Kỳ: ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label4.Location = new Point(25, 155);
            label4.Name = "label4";
            label4.Size = new Size(165, 18);
            label4.TabIndex = 3;
            label4.Text = "Số môn đã có điểm: ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label3.Location = new Point(21, 125);
            label3.Name = "label3";
            label3.Size = new Size(180, 18);
            label3.TabIndex = 4;
            label3.Text = "Tổng số tín chỉ Học Kỳ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label2.Location = new Point(25, 87);
            label2.Name = "label2";
            label2.Size = new Size(187, 18);
            label2.TabIndex = 5;
            label2.Text = "Điểm TB Học Kỳ (hệ 4):";
            // 
            // panel4
            // 
            panel4.Controls.Add(groupBox3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 369);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10, 0, 10, 10);
            panel4.Size = new Size(1694, 322);
            panel4.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvBangDiem);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(10, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1674, 312);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách điểm Sinh Viên";
            // 
            // dgvBangDiem
            // 
            dgvBangDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBangDiem.Columns.AddRange(new DataGridViewColumn[] { MaKQ, MaLHP });
            dgvBangDiem.Dock = DockStyle.Fill;
            dgvBangDiem.Location = new Point(3, 26);
            dgvBangDiem.Name = "dgvBangDiem";
            dgvBangDiem.RowHeadersWidth = 51;
            dgvBangDiem.Size = new Size(1668, 283);
            dgvBangDiem.TabIndex = 0;
            // 
            // MaKQ
            // 
            MaKQ.HeaderText = "STT";
            MaKQ.MinimumWidth = 6;
            MaKQ.Name = "MaKQ";
            MaKQ.ReadOnly = true;
            MaKQ.Width = 125;
            // 
            // MaLHP
            // 
            MaLHP.HeaderText = "Mã Lớp HP";
            MaLHP.MinimumWidth = 6;
            MaLHP.Name = "MaLHP";
            MaLHP.ReadOnly = true;
            MaLHP.Width = 125;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnAdSua_SV);
            panel3.Controls.Add(btnAdLamLai_SV);
            panel3.Controls.Add(btnAdLua_SV);
            panel3.Controls.Add(btnAdThem_SV);
            panel3.Controls.Add(btnAdXoa_SV);
            panel3.Controls.Add(button5);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 319);
            panel3.Name = "panel3";
            panel3.Size = new Size(1694, 50);
            panel3.TabIndex = 1;
            // 
            // btnAdSua_SV
            // 
            btnAdSua_SV.Anchor = AnchorStyles.Left;
            btnAdSua_SV.FlatAppearance.BorderColor = Color.Blue;
            btnAdSua_SV.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnAdSua_SV.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnAdSua_SV.Image = (Image)resources.GetObject("btnAdSua_SV.Image");
            btnAdSua_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdSua_SV.Location = new Point(739, 4);
            btnAdSua_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdSua_SV.Name = "btnAdSua_SV";
            btnAdSua_SV.Padding = new Padding(5, 0, 0, 0);
            btnAdSua_SV.Size = new Size(199, 43);
            btnAdSua_SV.TabIndex = 142;
            btnAdSua_SV.Text = "Sửa ";
            btnAdSua_SV.UseVisualStyleBackColor = true;
            btnAdSua_SV.Click += btnAdSua_SV_Click;
            // 
            // btnAdLamLai_SV
            // 
            btnAdLamLai_SV.Anchor = AnchorStyles.Left;
            btnAdLamLai_SV.FlatAppearance.BorderColor = Color.Blue;
            btnAdLamLai_SV.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnAdLamLai_SV.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnAdLamLai_SV.Image = (Image)resources.GetObject("btnAdLamLai_SV.Image");
            btnAdLamLai_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdLamLai_SV.Location = new Point(509, 4);
            btnAdLamLai_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdLamLai_SV.Name = "btnAdLamLai_SV";
            btnAdLamLai_SV.Padding = new Padding(5, 0, 0, 0);
            btnAdLamLai_SV.Size = new Size(199, 43);
            btnAdLamLai_SV.TabIndex = 140;
            btnAdLamLai_SV.Text = "Làm lại";
            btnAdLamLai_SV.UseVisualStyleBackColor = true;
            btnAdLamLai_SV.Click += btnAdLamLai_SV_Click;
            // 
            // btnAdLua_SV
            // 
            btnAdLua_SV.Anchor = AnchorStyles.Left;
            btnAdLua_SV.FlatAppearance.BorderColor = Color.Blue;
            btnAdLua_SV.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnAdLua_SV.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnAdLua_SV.Image = (Image)resources.GetObject("btnAdLua_SV.Image");
            btnAdLua_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdLua_SV.Location = new Point(35, 3);
            btnAdLua_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdLua_SV.Name = "btnAdLua_SV";
            btnAdLua_SV.Padding = new Padding(5, 0, 0, 0);
            btnAdLua_SV.Size = new Size(199, 43);
            btnAdLua_SV.TabIndex = 138;
            btnAdLua_SV.Text = "Lưu";
            btnAdLua_SV.UseVisualStyleBackColor = true;
            btnAdLua_SV.Click += btnAdLua_SV_Click;
            // 
            // btnAdThem_SV
            // 
            btnAdThem_SV.Anchor = AnchorStyles.Left;
            btnAdThem_SV.FlatAppearance.BorderColor = Color.Blue;
            btnAdThem_SV.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnAdThem_SV.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnAdThem_SV.Image = (Image)resources.GetObject("btnAdThem_SV.Image");
            btnAdThem_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdThem_SV.Location = new Point(290, 3);
            btnAdThem_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdThem_SV.Name = "btnAdThem_SV";
            btnAdThem_SV.Padding = new Padding(5, 0, 0, 0);
            btnAdThem_SV.Size = new Size(199, 43);
            btnAdThem_SV.TabIndex = 139;
            btnAdThem_SV.Text = "Thêm ";
            btnAdThem_SV.UseVisualStyleBackColor = true;
            btnAdThem_SV.Click += btnAdThem_SV_Click;
            // 
            // btnAdXoa_SV
            // 
            btnAdXoa_SV.Anchor = AnchorStyles.Left;
            btnAdXoa_SV.FlatAppearance.BorderColor = Color.Blue;
            btnAdXoa_SV.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnAdXoa_SV.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnAdXoa_SV.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdXoa_SV.Image = (Image)resources.GetObject("btnAdXoa_SV.Image");
            btnAdXoa_SV.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdXoa_SV.Location = new Point(981, 3);
            btnAdXoa_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdXoa_SV.Name = "btnAdXoa_SV";
            btnAdXoa_SV.Padding = new Padding(5, 0, 0, 0);
            btnAdXoa_SV.Size = new Size(199, 43);
            btnAdXoa_SV.TabIndex = 141;
            btnAdXoa_SV.Text = "Xóa";
            btnAdXoa_SV.UseVisualStyleBackColor = true;
            btnAdXoa_SV.Click += btnAdXoa_SV_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Right;
            button5.Location = new Point(1545, 8);
            button5.Name = "button5";
            button5.Size = new Size(116, 36);
            button5.TabIndex = 134;
            button5.Text = "Quay lại";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1694, 319);
            panel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtDiemCK);
            groupBox2.Controls.Add(label23);
            groupBox2.Controls.Add(txtDiemQT);
            groupBox2.Controls.Add(txtSTC);
            groupBox2.Controls.Add(txtTenMon);
            groupBox2.Controls.Add(cboMaMon);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(475, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1186, 291);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin điểm";
            // 
            // txtDiemCK
            // 
            txtDiemCK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDiemCK.Location = new Point(229, 252);
            txtDiemCK.Margin = new Padding(3, 4, 3, 4);
            txtDiemCK.Name = "txtDiemCK";
            txtDiemCK.Size = new Size(910, 27);
            txtDiemCK.TabIndex = 16;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(47, 256);
            label23.Name = "label23";
            label23.Size = new Size(117, 20);
            label23.TabIndex = 15;
            label23.Text = "Điểm cuối kỳ";
            // 
            // txtDiemQT
            // 
            txtDiemQT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDiemQT.Location = new Point(229, 211);
            txtDiemQT.Margin = new Padding(3, 4, 3, 4);
            txtDiemQT.Name = "txtDiemQT";
            txtDiemQT.Size = new Size(910, 27);
            txtDiemQT.TabIndex = 12;
            // 
            // txtSTC
            // 
            txtSTC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSTC.Location = new Point(229, 171);
            txtSTC.Margin = new Padding(3, 4, 3, 4);
            txtSTC.Name = "txtSTC";
            txtSTC.Size = new Size(910, 27);
            txtSTC.TabIndex = 13;
            // 
            // txtTenMon
            // 
            txtTenMon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTenMon.Location = new Point(229, 130);
            txtTenMon.Margin = new Padding(3, 4, 3, 4);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(910, 27);
            txtTenMon.TabIndex = 14;
            // 
            // cboMaMon
            // 
            cboMaMon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboMaMon.FormattingEnabled = true;
            cboMaMon.Location = new Point(229, 86);
            cboMaMon.Margin = new Padding(3, 4, 3, 4);
            cboMaMon.Name = "cboMaMon";
            cboMaMon.Size = new Size(910, 28);
            cboMaMon.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(229, 37);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(88, 28);
            comboBox1.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(47, 214);
            label10.Name = "label10";
            label10.Size = new Size(132, 20);
            label10.TabIndex = 5;
            label10.Text = "Điểm quá trình";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(47, 171);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 6;
            label9.Text = "Số tín chỉ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(47, 130);
            label8.Name = "label8";
            label8.Size = new Size(81, 20);
            label8.TabIndex = 7;
            label8.Text = "Tên môn";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(47, 86);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 8;
            label7.Text = "Mã Môn";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(52, 41);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 9;
            label6.Text = "Học Kỳ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCVHT);
            groupBox1.Controls.Add(lblNganh);
            groupBox1.Controls.Add(lblKhoa);
            groupBox1.Controls.Add(lblLop);
            groupBox1.Controls.Add(lblHoTen);
            groupBox1.Controls.Add(lblMaSV);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(24, 15);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(445, 291);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin Sinh Viên";
            // 
            // lblCVHT
            // 
            lblCVHT.AutoSize = true;
            lblCVHT.Location = new Point(150, 218);
            lblCVHT.Name = "lblCVHT";
            lblCVHT.Size = new Size(142, 20);
            lblCVHT.TabIndex = 1;
            lblCVHT.Text = "Huỳnh Văn Tiến";
            // 
            // lblNganh
            // 
            lblNganh.AutoSize = true;
            lblNganh.Location = new Point(150, 178);
            lblNganh.Name = "lblNganh";
            lblNganh.Size = new Size(177, 20);
            lblNganh.TabIndex = 2;
            lblNganh.Text = "Công nghệ thông tin";
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(150, 137);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(177, 20);
            lblKhoa.TabIndex = 3;
            lblKhoa.Text = "Công nghệ thông tin";
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(150, 105);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(92, 20);
            lblLop.TabIndex = 4;
            lblLop.Text = "DH24TH3";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(149, 69);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(95, 20);
            lblHoTen.TabIndex = 5;
            lblHoTen.Text = "Võ Văn Tỷ";
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(149, 41);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(108, 20);
            lblMaSV.TabIndex = 6;
            lblMaSV.Text = "DTH235811";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(7, 218);
            label16.Name = "label16";
            label16.Size = new Size(135, 20);
            label16.TabIndex = 0;
            label16.Text = "Cố vấn học tập";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(11, 178);
            label15.Name = "label15";
            label15.Size = new Size(74, 20);
            label15.TabIndex = 0;
            label15.Text = "Ngành: ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(7, 137);
            label14.Name = "label14";
            label14.Size = new Size(63, 20);
            label14.TabIndex = 0;
            label14.Text = "Khoa: ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(11, 105);
            label13.Name = "label13";
            label13.Size = new Size(52, 20);
            label13.TabIndex = 0;
            label13.Text = "Lớp: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(7, 69);
            label12.Name = "label12";
            label12.Size = new Size(110, 20);
            label12.TabIndex = 0;
            label12.Text = "Họ Và Tên: ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(7, 40);
            label11.Name = "label11";
            label11.Size = new Size(126, 20);
            label11.TabIndex = 0;
            label11.Text = "Mã Sinh Viên:";
            // 
            // UC_Diem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "UC_Diem";
            Size = new Size(1694, 954);
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            panel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBangDiem).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox1;
        private Label lblCVHT;
        private Label lblNganh;
        private Label lblKhoa;
        private Label lblLop;
        private Label lblHoTen;
        private Label lblMaSV;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private GroupBox groupBox2;
        private TextBox txtDiemCK;
        private Label label23;
        private TextBox txtDiemQT;
        private TextBox txtSTC;
        private TextBox txtTenMon;
        private ComboBox cboMaMon;
        private ComboBox comboBox1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Panel panel3;
        private Button button5;
        private Panel panel5;
        private Panel panel4;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private DataGridView dgvBangDiem;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAdSua_SV;
        private Button btnAdLamLai_SV;
        private Button btnAdLua_SV;
        private Button btnAdThem_SV;
        private Button btnAdXoa_SV;
        private DataGridViewTextBoxColumn MaKQ;
        private DataGridViewTextBoxColumn MaLHP;
    }
}
