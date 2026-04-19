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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TraCuuDiem_Container));
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
            btnInBaoCao = new Button();
            btnInDanhSach = new Button();
            btnXuat = new Button();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            cboLoaiSX = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            btnReset = new Button();
            btnTimKiem = new Button();
            txtTuKhoa = new TextBox();
            cboLop = new ComboBox();
            label2 = new Label();
            cboKhoa = new ComboBox();
            label1 = new Label();
            btnBaoCaoSVHB = new Button();
            btnBaoCaoSVTN = new Button();
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
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.DeepSkyBlue;
            dataGridViewCellStyle7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvDanhSachSV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvDanhSachSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSV.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, TenLop, TenKhoa, DiemTrungBinh, SoTinChi, ThaoTac });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle12.SelectionForeColor = Color.Black;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dgvDanhSachSV.DefaultCellStyle = dataGridViewCellStyle12;
            dgvDanhSachSV.Dock = DockStyle.Fill;
            dgvDanhSachSV.EnableHeadersVisualStyles = false;
            dgvDanhSachSV.Location = new Point(3, 26);
            dgvDanhSachSV.Name = "dgvDanhSachSV";
            dgvDanhSachSV.RowHeadersWidth = 51;
            dgvDanhSachSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachSV.Size = new Size(1668, 696);
            dgvDanhSachSV.TabIndex = 0;
            dgvDanhSachSV.CellClick += dgvDanhSachSV_CellClick;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Blue;
            MaSV.DefaultCellStyle = dataGridViewCellStyle8;
            MaSV.HeaderText = "Mã SV";
            MaSV.MinimumWidth = 6;
            MaSV.Name = "MaSV";
            MaSV.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // TenLop
            // 
            TenLop.DataPropertyName = "TenLop";
            TenLop.HeaderText = "Lớp";
            TenLop.MinimumWidth = 6;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // TenKhoa
            // 
            TenKhoa.DataPropertyName = "TenKhoa";
            TenKhoa.HeaderText = "Khoa";
            TenKhoa.MinimumWidth = 6;
            TenKhoa.Name = "TenKhoa";
            TenKhoa.ReadOnly = true;
            // 
            // DiemTrungBinh
            // 
            DiemTrungBinh.DataPropertyName = "DiemTrungBinh";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.Blue;
            DiemTrungBinh.DefaultCellStyle = dataGridViewCellStyle9;
            DiemTrungBinh.HeaderText = "ĐTB Tích lũy";
            DiemTrungBinh.MinimumWidth = 6;
            DiemTrungBinh.Name = "DiemTrungBinh";
            DiemTrungBinh.ReadOnly = true;
            // 
            // SoTinChi
            // 
            SoTinChi.DataPropertyName = "SoTinChi";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.Blue;
            SoTinChi.DefaultCellStyle = dataGridViewCellStyle10;
            SoTinChi.HeaderText = "STC tích lũy";
            SoTinChi.MinimumWidth = 6;
            SoTinChi.Name = "SoTinChi";
            SoTinChi.ReadOnly = true;
            // 
            // ThaoTac
            // 
            ThaoTac.DataPropertyName = "ThaoTac";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ThaoTac.DefaultCellStyle = dataGridViewCellStyle11;
            ThaoTac.HeaderText = "Thao Tác";
            ThaoTac.MinimumWidth = 6;
            ThaoTac.Name = "ThaoTac";
            ThaoTac.ReadOnly = true;
            ThaoTac.Resizable = DataGridViewTriState.True;
            ThaoTac.SortMode = DataGridViewColumnSortMode.Automatic;
            ThaoTac.Text = "Xem Chi tiết";
            ThaoTac.UseColumnTextForLinkValue = true;
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
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(btnBaoCaoSVTN);
            groupBox1.Controls.Add(btnBaoCaoSVHB);
            groupBox1.Controls.Add(btnInBaoCao);
            groupBox1.Controls.Add(btnInDanhSach);
            groupBox1.Controls.Add(btnXuat);
            groupBox1.Controls.Add(radGiam);
            groupBox1.Controls.Add(radTang);
            groupBox1.Controls.Add(cboLoaiSX);
            groupBox1.Controls.Add(label4);
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
            // btnInBaoCao
            // 
            btnInBaoCao.Location = new Point(1472, 123);
            btnInBaoCao.Name = "btnInBaoCao";
            btnInBaoCao.Size = new Size(175, 41);
            btnInBaoCao.TabIndex = 144;
            btnInBaoCao.Text = "In Báo Cáo";
            btnInBaoCao.UseVisualStyleBackColor = true;
            btnInBaoCao.Click += btnInBaoCao_Click;
            // 
            // btnInDanhSach
            // 
            btnInDanhSach.Anchor = AnchorStyles.Left;
            btnInDanhSach.FlatAppearance.BorderColor = Color.Blue;
            btnInDanhSach.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnInDanhSach.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnInDanhSach.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInDanhSach.ImageAlign = ContentAlignment.MiddleLeft;
            btnInDanhSach.Location = new Point(1507, 57);
            btnInDanhSach.Margin = new Padding(3, 4, 3, 4);
            btnInDanhSach.Name = "btnInDanhSach";
            btnInDanhSach.Padding = new Padding(5, 0, 0, 0);
            btnInDanhSach.Size = new Size(140, 43);
            btnInDanhSach.TabIndex = 142;
            btnInDanhSach.Text = "In Danh Sách";
            btnInDanhSach.UseVisualStyleBackColor = true;
            btnInDanhSach.Click += btnInDanhSach_Click;
            // 
            // btnXuat
            // 
            btnXuat.Anchor = AnchorStyles.Left;
            btnXuat.FlatAppearance.BorderColor = Color.Blue;
            btnXuat.FlatAppearance.MouseDownBackColor = Color.Blue;
            btnXuat.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnXuat.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnXuat.Location = new Point(1391, 54);
            btnXuat.Margin = new Padding(3, 4, 3, 4);
            btnXuat.Name = "btnXuat";
            btnXuat.Padding = new Padding(5, 0, 0, 0);
            btnXuat.Size = new Size(97, 43);
            btnXuat.TabIndex = 143;
            btnXuat.Text = "Xuất File";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(499, 134);
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
            radTang.Location = new Point(426, 134);
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
            cboLoaiSX.Location = new Point(112, 129);
            cboLoaiSX.Name = "cboLoaiSX";
            cboLoaiSX.Size = new Size(294, 31);
            cboLoaiSX.TabIndex = 7;
            cboLoaiSX.SelectedIndexChanged += cboLoaiSX_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(819, 61);
            label4.Name = "label4";
            label4.Size = new Size(77, 23);
            label4.TabIndex = 6;
            label4.Text = "Từ khóa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 133);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 6;
            label3.Text = "Sắp xếp:";
            // 
            // btnReset
            // 
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Image = (Image)resources.GetObject("btnReset.Image");
            btnReset.Location = new Point(1343, 54);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(42, 38);
            btnReset.TabIndex = 5;
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.Image = (Image)resources.GetObject("btnTimKiem.Image");
            btnTimKiem.Location = new Point(1292, 52);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(45, 40);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(902, 58);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Nhập từ khóa cần tìm...";
            txtTuKhoa.Size = new Size(374, 30);
            txtTuKhoa.TabIndex = 4;
            // 
            // cboLop
            // 
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(485, 57);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(328, 31);
            cboLop.TabIndex = 3;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(437, 60);
            label2.Name = "label2";
            label2.Size = new Size(42, 23);
            label2.TabIndex = 2;
            label2.Text = "Lớp:";
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(112, 57);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(294, 31);
            cboKhoa.TabIndex = 1;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 60);
            label1.Name = "label1";
            label1.Size = new Size(53, 23);
            label1.TabIndex = 0;
            label1.Text = "Khoa:";
            // 
            // btnBaoCaoSVHB
            // 
            btnBaoCaoSVHB.Location = new Point(760, 123);
            btnBaoCaoSVHB.Name = "btnBaoCaoSVHB";
            btnBaoCaoSVHB.Size = new Size(342, 43);
            btnBaoCaoSVHB.TabIndex = 145;
            btnBaoCaoSVHB.Text = "Sinh Viên Đủ Điều Kiện Nhận Học Bổng";
            btnBaoCaoSVHB.UseVisualStyleBackColor = true;
            btnBaoCaoSVHB.Click += btnBaoCaoSVHB_Click;
            // 
            // btnBaoCaoSVTN
            // 
            btnBaoCaoSVTN.Location = new Point(1108, 123);
            btnBaoCaoSVTN.Name = "btnBaoCaoSVTN";
            btnBaoCaoSVTN.Size = new Size(342, 41);
            btnBaoCaoSVTN.TabIndex = 145;
            btnBaoCaoSVTN.Text = "Sinh Viên Đủ Điều Kiện Tốt Nghiệp";
            btnBaoCaoSVTN.UseVisualStyleBackColor = true;
            btnBaoCaoSVTN.Click += btnBaoCaoSVTN_Click;
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
        private Button btnInDanhSach;
        private Button btnXuat;
        private Label label4;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn TenKhoa;
        private DataGridViewTextBoxColumn DiemTrungBinh;
        private DataGridViewTextBoxColumn SoTinChi;
        private DataGridViewLinkColumn ThaoTac;
        private Button btnInBaoCao;
        private Button btnBaoCaoSVTN;
        private Button btnBaoCaoSVHB;
    }
}
