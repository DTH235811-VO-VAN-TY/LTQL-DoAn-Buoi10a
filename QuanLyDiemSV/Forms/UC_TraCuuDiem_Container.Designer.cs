namespace QuanLyDiemSV.Forms
{
    partial class UC_TraCuuDiem_Container
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
            panel1 = new Panel();
            panel3 = new Panel();
            groupBox2 = new GroupBox();
            dgvDanhSachSV = new DataGridView();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            TenKhoa = new DataGridViewTextBoxColumn();
            DiemTrungBinh = new DataGridViewTextBoxColumn();
            SoTinChi = new DataGridViewTextBoxColumn();
            ThaoTac = new DataGridViewLinkColumn();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            btnXemChitiet = new Button();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            cboLoaiSX = new ComboBox();
            label3 = new Label();
            btnReset = new Button();
            btnTimKiem = new Button();
            txtTuKhoa = new TextBox();
            cboLop = new ComboBox();
            label2 = new Label();
            cboKhoa = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 954);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 209);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(1694, 745);
            panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDanhSachSV);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(10, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1674, 725);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sinh viên";
            // 
            // dgvDanhSachSV
            // 
            dgvDanhSachSV.AllowUserToAddRows = false;
            dgvDanhSachSV.AllowUserToDeleteRows = false;
            dgvDanhSachSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSV.BackgroundColor = Color.White;
            dgvDanhSachSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSV.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, TenLop, TenKhoa, DiemTrungBinh, SoTinChi, ThaoTac });
            dgvDanhSachSV.Dock = DockStyle.Fill;
            dgvDanhSachSV.Location = new Point(3, 26);
            dgvDanhSachSV.Name = "dgvDanhSachSV";
            dgvDanhSachSV.RowHeadersWidth = 51;
            dgvDanhSachSV.Size = new Size(1668, 696);
            dgvDanhSachSV.TabIndex = 0;
            dgvDanhSachSV.CellClick += dgvDanhSachSV_CellClick;
            // 
            // MaSV
            // 
            MaSV.HeaderText = "Mã SV";
            MaSV.MinimumWidth = 6;
            MaSV.Name = "MaSV";
            MaSV.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // TenLop
            // 
            TenLop.HeaderText = "Lớp";
            TenLop.MinimumWidth = 6;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // TenKhoa
            // 
            TenKhoa.HeaderText = "Khoa";
            TenKhoa.MinimumWidth = 6;
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            // 
            // DiemTrungBinh
            // 
            DiemTrungBinh.HeaderText = "ĐTB Tích lũy";
            DiemTrungBinh.MinimumWidth = 6;
            DiemTrungBinh.Name = "DiemTrungBinh";
            DiemTrungBinh.ReadOnly = true;
            // 
            // SoTinChi
            // 
            SoTinChi.HeaderText = "STC tích lũy";
            SoTinChi.MinimumWidth = 6;
            SoTinChi.Name = "SoTinChi";
            SoTinChi.ReadOnly = true;
            // 
            // ThaoTac
            // 
            ThaoTac.DataPropertyName = "ThaoTac";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ThaoTac.DefaultCellStyle = dataGridViewCellStyle2;
            ThaoTac.HeaderText = "Thao Tác";
            ThaoTac.MinimumWidth = 6;
            ThaoTac.Name = "ThaoTac";
            ThaoTac.ReadOnly = true;
            ThaoTac.Resizable = DataGridViewTriState.True;
            ThaoTac.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(1694, 209);
            panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXemChitiet);
            groupBox1.Controls.Add(radGiam);
            groupBox1.Controls.Add(radTang);
            groupBox1.Controls.Add(cboLoaiSX);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnReset);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(txtTuKhoa);
            groupBox1.Controls.Add(cboLop);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboKhoa);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1674, 189);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm Kiếm";
            // 
            // btnXemChitiet
            // 
            btnXemChitiet.Location = new Point(42, 134);
            btnXemChitiet.Name = "btnXemChitiet";
            btnXemChitiet.Size = new Size(166, 29);
            btnXemChitiet.TabIndex = 9;
            btnXemChitiet.Text = "Xem chi tiết";
            btnXemChitiet.UseVisualStyleBackColor = true;
            btnXemChitiet.Click += btnXemChitiet_Click;
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(1468, 133);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(71, 27);
            radGiam.TabIndex = 8;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            radGiam.CheckedChanged += radGiam_CheckedChanged;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Location = new Point(1378, 133);
            radTang.Name = "radTang";
            radTang.Size = new Size(67, 27);
            radTang.TabIndex = 8;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            radTang.CheckedChanged += radTang_CheckedChanged;
            // 
            // cboLoaiSX
            // 
            cboLoaiSX.FormattingEnabled = true;
            cboLoaiSX.Items.AddRange(new object[] { "Mã Số SV", "Điểm số", "Họ Tên" });
            cboLoaiSX.Location = new Point(1062, 133);
            cboLoaiSX.Name = "cboLoaiSX";
            cboLoaiSX.Size = new Size(283, 31);
            cboLoaiSX.TabIndex = 7;
            cboLoaiSX.SelectedIndexChanged += cboLoaiSX_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(966, 137);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 6;
            label3.Text = "Sắp xếp:";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1399, 64);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(140, 38);
            btnReset.TabIndex = 5;
            btnReset.Text = "Tải lại";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(1231, 64);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(140, 38);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(834, 63);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.Size = new Size(361, 30);
            txtTuKhoa.TabIndex = 4;
            // 
            // cboLop
            // 
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(505, 60);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(295, 31);
            cboLop.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(433, 63);
            label2.Name = "label2";
            label2.Size = new Size(42, 23);
            label2.TabIndex = 2;
            label2.Text = "Lớp:";
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(102, 60);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(294, 31);
            cboKhoa.TabIndex = 1;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 60);
            label1.Name = "label1";
            label1.Size = new Size(53, 23);
            label1.TabIndex = 0;
            label1.Text = "Khoa:";
            // 
            // UC_TraCuuDiem_Container
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "UC_TraCuuDiem_Container";
            Size = new Size(1694, 954);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).EndInit();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox1;
        private ComboBox cboLoaiSX;
        private Label label3;
        private Button btnReset;
        private Button btnTimKiem;
        private TextBox txtTuKhoa;
        private ComboBox cboLop;
        private Label label2;
        private ComboBox cboKhoa;
        private Label label1;
        private RadioButton radGiam;
        private RadioButton radTang;
        private Panel panel3;
        private GroupBox groupBox2;
        private DataGridView dgvDanhSachSV;
        private Button btnXemChitiet;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn TenKhoa;
        private DataGridViewTextBoxColumn DiemTrungBinh;
        private DataGridViewTextBoxColumn SoTinChi;
        private DataGridViewLinkColumn ThaoTac;
    }
}
