namespace GUI
{
    partial class UC_MonHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MonHoc));
            panel1 = new Panel();
            panel4 = new Panel();
            groupBox2 = new GroupBox();
            cboKhoa = new ComboBox();
            btnSua = new Button();
            btnLamLai = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtSoTietTH = new TextBox();
            txtSoTietLT = new TextBox();
            txtSTC = new TextBox();
            txtTenMon = new TextBox();
            txtMaMon = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label13 = new Label();
            label7 = new Label();
            label6 = new Label();
            groupBox4 = new GroupBox();
            dgvMonTienQuyet = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            MaMonTQ = new DataGridViewTextBoxColumn();
            TenMonTQ = new DataGridViewTextBoxColumn();
            groupBox3 = new GroupBox();
            btnThemMonTienQuyet = new Button();
            btnXoaMonTienQuyet = new Button();
            cbboMonTienQuyet = new ComboBox();
            label5 = new Label();
            lblTenMon = new Label();
            lblMaMon = new Label();
            label12 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            btnReset = new Button();
            btnTimKiem = new Button();
            txtTuKhoa = new TextBox();
            label4 = new Label();
            cboLoc = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            dgvDSMon = new DataGridView();
            MaMon = new DataGridViewTextBoxColumn();
            TenMon = new DataGridViewTextBoxColumn();
            SoTinChi = new DataGridViewTextBoxColumn();
            SoTietLyThuyet = new DataGridViewTextBoxColumn();
            SoTietThucHanh = new DataGridViewTextBoxColumn();
            MaKhoa = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonTienQuyet).BeginInit();
            groupBox3.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSMon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBox3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 954);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(groupBox2);
            panel4.Location = new Point(954, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(737, 327);
            panel4.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top;
            groupBox2.Controls.Add(cboKhoa);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnLamLai);
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Controls.Add(txtSoTietTH);
            groupBox2.Controls.Add(txtSoTietLT);
            groupBox2.Controls.Add(txtSTC);
            groupBox2.Controls.Add(txtTenMon);
            groupBox2.Controls.Add(txtMaMon);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(3, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(713, 300);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin môn học";
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(193, 189);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(478, 31);
            cboKhoa.TabIndex = 138;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(460, 241);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Padding = new Padding(10, 0, 0, 0);
            btnSua.Size = new Size(115, 35);
            btnSua.TabIndex = 136;
            btnSua.Text = "      Sửa";
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
            btnLamLai.Location = new Point(327, 242);
            btnLamLai.Margin = new Padding(3, 4, 3, 4);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Padding = new Padding(10, 0, 0, 0);
            btnLamLai.Size = new Size(115, 35);
            btnLamLai.TabIndex = 135;
            btnLamLai.Text = "      Làm lại";
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
            btnLuu.Location = new Point(71, 241);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Padding = new Padding(10, 0, 0, 0);
            btnLuu.Size = new Size(115, 35);
            btnLuu.TabIndex = 133;
            btnLuu.Text = "   Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(581, 241);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Padding = new Padding(10, 0, 0, 0);
            btnXoa.Size = new Size(115, 35);
            btnXoa.TabIndex = 137;
            btnXoa.Text = "       Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Image = (Image)resources.GetObject("btnThem.Image");
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(193, 242);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Padding = new Padding(10, 0, 0, 0);
            btnThem.Size = new Size(115, 35);
            btnThem.TabIndex = 134;
            btnThem.Text = "       Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtSoTietTH
            // 
            txtSoTietTH.Anchor = AnchorStyles.Right;
            txtSoTietTH.Location = new Point(537, 142);
            txtSoTietTH.Margin = new Padding(3, 4, 3, 4);
            txtSoTietTH.Name = "txtSoTietTH";
            txtSoTietTH.Size = new Size(134, 30);
            txtSoTietTH.TabIndex = 129;
            // 
            // txtSoTietLT
            // 
            txtSoTietLT.Anchor = AnchorStyles.Right;
            txtSoTietLT.Location = new Point(193, 141);
            txtSoTietLT.Margin = new Padding(3, 4, 3, 4);
            txtSoTietLT.Name = "txtSoTietLT";
            txtSoTietLT.Size = new Size(134, 30);
            txtSoTietLT.TabIndex = 129;
            // 
            // txtSTC
            // 
            txtSTC.Anchor = AnchorStyles.Right;
            txtSTC.Location = new Point(193, 103);
            txtSTC.Margin = new Padding(3, 4, 3, 4);
            txtSTC.Name = "txtSTC";
            txtSTC.Size = new Size(478, 30);
            txtSTC.TabIndex = 130;
            // 
            // txtTenMon
            // 
            txtTenMon.Anchor = AnchorStyles.Right;
            txtTenMon.Location = new Point(193, 66);
            txtTenMon.Margin = new Padding(3, 4, 3, 4);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(478, 30);
            txtTenMon.TabIndex = 130;
            // 
            // txtMaMon
            // 
            txtMaMon.Anchor = AnchorStyles.Right;
            txtMaMon.Location = new Point(193, 30);
            txtMaMon.Margin = new Padding(3, 4, 3, 4);
            txtMaMon.Name = "txtMaMon";
            txtMaMon.Size = new Size(478, 30);
            txtMaMon.TabIndex = 130;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(38, 103);
            label10.Name = "label10";
            label10.Size = new Size(95, 20);
            label10.TabIndex = 124;
            label10.Text = "Số tín chỉ:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(38, 200);
            label9.Name = "label9";
            label9.Size = new Size(57, 20);
            label9.TabIndex = 125;
            label9.Text = "Khoa:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(38, 68);
            label8.Name = "label8";
            label8.Size = new Size(87, 20);
            label8.TabIndex = 126;
            label8.Text = "Tên môn:";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(379, 148);
            label13.Name = "label13";
            label13.Size = new Size(101, 20);
            label13.TabIndex = 123;
            label13.Text = "Số tiết TH:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(38, 34);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 127;
            label7.Text = "Mã Môn:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(35, 147);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 123;
            label6.Text = "Số tiết LT:";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom;
            groupBox4.Controls.Add(dgvMonTienQuyet);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(954, 617);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(716, 309);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Danh sách môn tiên quyết đã chọn";
            // 
            // dgvMonTienQuyet
            // 
            dgvMonTienQuyet.AllowUserToAddRows = false;
            dgvMonTienQuyet.AllowUserToDeleteRows = false;
            dgvMonTienQuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonTienQuyet.BackgroundColor = SystemColors.ButtonFace;
            dgvMonTienQuyet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonTienQuyet.Columns.AddRange(new DataGridViewColumn[] { ID, MaMonTQ, TenMonTQ });
            dgvMonTienQuyet.Dock = DockStyle.Fill;
            dgvMonTienQuyet.Location = new Point(3, 26);
            dgvMonTienQuyet.Name = "dgvMonTienQuyet";
            dgvMonTienQuyet.RowHeadersWidth = 51;
            dgvMonTienQuyet.Size = new Size(710, 280);
            dgvMonTienQuyet.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // MaMonTQ
            // 
            MaMonTQ.DataPropertyName = "MaMonTQ";
            MaMonTQ.HeaderText = "Mã Môn TQ";
            MaMonTQ.MinimumWidth = 6;
            MaMonTQ.Name = "MaMonTQ";
            MaMonTQ.ReadOnly = true;
            // 
            // TenMonTQ
            // 
            TenMonTQ.DataPropertyName = "TenMonTQ";
            TenMonTQ.HeaderText = "Tên Môn TQ";
            TenMonTQ.MinimumWidth = 6;
            TenMonTQ.Name = "TenMonTQ";
            TenMonTQ.ReadOnly = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            groupBox3.Controls.Add(btnThemMonTienQuyet);
            groupBox3.Controls.Add(btnXoaMonTienQuyet);
            groupBox3.Controls.Add(cbboMonTienQuyet);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(lblTenMon);
            groupBox3.Controls.Add(lblMaMon);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label3);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(954, 338);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(716, 273);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chọn môn tiên quyết";
            // 
            // btnThemMonTienQuyet
            // 
            btnThemMonTienQuyet.Anchor = AnchorStyles.None;
            btnThemMonTienQuyet.BackColor = Color.Green;
            btnThemMonTienQuyet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMonTienQuyet.ForeColor = Color.White;
            btnThemMonTienQuyet.Location = new Point(23, 185);
            btnThemMonTienQuyet.Name = "btnThemMonTienQuyet";
            btnThemMonTienQuyet.Size = new Size(166, 45);
            btnThemMonTienQuyet.TabIndex = 134;
            btnThemMonTienQuyet.Text = "Thêm";
            btnThemMonTienQuyet.UseVisualStyleBackColor = false;
            btnThemMonTienQuyet.Click += btnThemMonTienQuyet_Click;
            // 
            // btnXoaMonTienQuyet
            // 
            btnXoaMonTienQuyet.Anchor = AnchorStyles.None;
            btnXoaMonTienQuyet.BackColor = Color.Red;
            btnXoaMonTienQuyet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaMonTienQuyet.ForeColor = Color.White;
            btnXoaMonTienQuyet.Location = new Point(236, 185);
            btnXoaMonTienQuyet.Name = "btnXoaMonTienQuyet";
            btnXoaMonTienQuyet.Size = new Size(166, 45);
            btnXoaMonTienQuyet.TabIndex = 134;
            btnXoaMonTienQuyet.Text = "Xóa";
            btnXoaMonTienQuyet.UseVisualStyleBackColor = false;
            btnXoaMonTienQuyet.Click += btnXoaMonTienQuyet_Click;
            // 
            // cbboMonTienQuyet
            // 
            cbboMonTienQuyet.Anchor = AnchorStyles.None;
            cbboMonTienQuyet.FormattingEnabled = true;
            cbboMonTienQuyet.Location = new Point(23, 139);
            cbboMonTienQuyet.Name = "cbboMonTienQuyet";
            cbboMonTienQuyet.Size = new Size(436, 31);
            cbboMonTienQuyet.TabIndex = 3;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(236, 85);
            label5.Name = "label5";
            label5.Size = new Size(20, 28);
            label5.TabIndex = 2;
            label5.Text = "-";
            // 
            // lblTenMon
            // 
            lblTenMon.Anchor = AnchorStyles.None;
            lblTenMon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenMon.ForeColor = Color.Blue;
            lblTenMon.Location = new Point(307, 85);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(242, 28);
            lblTenMon.TabIndex = 1;
            lblTenMon.Text = "Tên môn";
            // 
            // lblMaMon
            // 
            lblMaMon.Anchor = AnchorStyles.None;
            lblMaMon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaMon.ForeColor = Color.Blue;
            lblMaMon.Location = new Point(23, 85);
            lblMaMon.Name = "lblMaMon";
            lblMaMon.Size = new Size(173, 31);
            lblMaMon.TabIndex = 1;
            lblMaMon.Text = "Mã môn";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Location = new Point(23, 113);
            label12.Name = "label12";
            label12.Size = new Size(263, 23);
            label12.TabIndex = 0;
            label12.Text = "Chọn môn tiên quyết(cùng khoa)";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(24, 60);
            label3.Name = "label3";
            label3.Size = new Size(169, 23);
            label3.TabIndex = 0;
            label3.Text = "Môn học đang chọn:";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(946, 954);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnReset);
            panel3.Controls.Add(btnTimKiem);
            panel3.Controls.Add(txtTuKhoa);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(cboLoc);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(946, 126);
            panel3.TabIndex = 4;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(832, 84);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 5;
            btnReset.Text = "Tải lại";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(732, 84);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.ForeColor = Color.Gray;
            txtTuKhoa.Location = new Point(450, 84);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.Size = new Size(272, 27);
            txtTuKhoa.TabIndex = 4;
            txtTuKhoa.Text = "Vui lòng nhập tên môn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(364, 87);
            label4.Name = "label4";
            label4.Size = new Size(80, 23);
            label4.TabIndex = 3;
            label4.Text = "Tên môn:";
            // 
            // cboLoc
            // 
            cboLoc.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cboLoc.FormattingEnabled = true;
            cboLoc.Items.AddRange(new object[] { "--Tất cả khoa--" });
            cboLoc.Location = new Point(144, 84);
            cboLoc.Name = "cboLoc";
            cboLoc.Size = new Size(212, 27);
            cboLoc.TabIndex = 2;
            cboLoc.SelectedIndexChanged += cboLoc_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 85);
            label2.Name = "label2";
            label2.Size = new Size(127, 23);
            label2.TabIndex = 1;
            label2.Text = "Lọc theo khoa: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 20);
            label1.Name = "label1";
            label1.Size = new Size(344, 46);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ MÔN HỌC";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom;
            groupBox1.Controls.Add(dgvDSMon);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(21, 195);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(891, 737);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách môn học";
            // 
            // dgvDSMon
            // 
            dgvDSMon.AllowUserToAddRows = false;
            dgvDSMon.AllowUserToDeleteRows = false;
            dgvDSMon.Anchor = AnchorStyles.Top;
            dgvDSMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSMon.BackgroundColor = SystemColors.ButtonFace;
            dgvDSMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSMon.Columns.AddRange(new DataGridViewColumn[] { MaMon, TenMon, SoTinChi, SoTietLyThuyet, SoTietThucHanh, MaKhoa });
            dgvDSMon.Location = new Point(11, 35);
            dgvDSMon.Name = "dgvDSMon";
            dgvDSMon.RowHeadersWidth = 51;
            dgvDSMon.Size = new Size(860, 696);
            dgvDSMon.TabIndex = 0;
            // 
            // MaMon
            // 
            MaMon.DataPropertyName = "MaMon";
            MaMon.HeaderText = "Mã Môn";
            MaMon.MinimumWidth = 6;
            MaMon.Name = "MaMon";
            MaMon.ReadOnly = true;
            // 
            // TenMon
            // 
            TenMon.DataPropertyName = "TenMon";
            TenMon.HeaderText = "Tên Môn";
            TenMon.MinimumWidth = 6;
            TenMon.Name = "TenMon";
            TenMon.ReadOnly = true;
            // 
            // SoTinChi
            // 
            SoTinChi.DataPropertyName = "SoTinChi";
            SoTinChi.HeaderText = "Số TC";
            SoTinChi.MinimumWidth = 6;
            SoTinChi.Name = "SoTinChi";
            SoTinChi.ReadOnly = true;
            // 
            // SoTietLyThuyet
            // 
            SoTietLyThuyet.DataPropertyName = "SoTietLyThuyet";
            SoTietLyThuyet.HeaderText = "Số Tiết LT";
            SoTietLyThuyet.MinimumWidth = 6;
            SoTietLyThuyet.Name = "SoTietLyThuyet";
            SoTietLyThuyet.ReadOnly = true;
            // 
            // SoTietThucHanh
            // 
            SoTietThucHanh.DataPropertyName = "SoTietThucHanh";
            SoTietThucHanh.HeaderText = "Số Tiết TH";
            SoTietThucHanh.MinimumWidth = 6;
            SoTietThucHanh.Name = "SoTietThucHanh";
            SoTietThucHanh.ReadOnly = true;
            // 
            // MaKhoa
            // 
            MaKhoa.DataPropertyName = "MaKhoa";
            MaKhoa.HeaderText = "Khoa";
            MaKhoa.MinimumWidth = 6;
            MaKhoa.Name = "MaKhoa";
            MaKhoa.ReadOnly = true;
            // 
            // UC_MonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_MonHoc";
            Size = new Size(1694, 954);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMonTienQuyet).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDSMon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private DataGridView dgvDSMon;
        private ComboBox cboLoc;
        private Label label2;
        private Label label1;
        private ComboBox cboMaMon;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Panel panel3;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private DataGridView dgvMonTienQuyet;
        private Button button6;
        private Button btnXoaMonTienQuyet;
        private ComboBox cbboMonTienQuyet;
        private Label label5;
        private Label lblTenMon;
        private Label lblMaMon;
        private Label label12;
        private Label label3;
        private Panel panel4;
        private TextBox textBox4;
        private TextBox txtSoTietLT;
        private Label label13;
        private Button btnSua;
        private Button btnLamLai;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtMaMon;
        private ComboBox cboKhoa;
        private TextBox txtSoTietTH;
        private TextBox txtSTC;
        private TextBox txtTenMon;
        private Button btnThemMonTienQuyet;
        private DataGridViewTextBoxColumn MaMon;
        private DataGridViewTextBoxColumn TenMon;
        private DataGridViewTextBoxColumn SoTinChi;
        private DataGridViewTextBoxColumn SoTietLyThuyet;
        private DataGridViewTextBoxColumn SoTietThucHanh;
        private DataGridViewTextBoxColumn MaKhoa;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn MaMonTQ;
        private DataGridViewTextBoxColumn TenMonTQ;
        private Button btnReset;
        private Button btnTimKiem;
        private TextBox txtTuKhoa;
        private Label label4;
    }
}
