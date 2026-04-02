namespace QuanLyDiemSV.Forms
{
    partial class UC_QuanLyDiem_Container
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            txtTuKhoa = new TextBox();
            label1 = new Label();
            label11 = new Label();
            label12 = new Label();
            cboKhoa = new ComboBox();
            cboTimKiem = new ComboBox();
            btnShowAll = new Button();
            btnTimKiem = new Button();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            cboKieuSX = new ComboBox();
            label9 = new Label();
            panel3 = new Panel();
            groupBox3 = new GroupBox();
            dgvDanhSachSV = new DataGridView();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            LopHanhChinh = new DataGridViewTextBoxColumn();
            MaKhoa = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            ThaoTac = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 132);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTuKhoa);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(cboKhoa);
            groupBox1.Controls.Add(cboTimKiem);
            groupBox1.Controls.Add(btnShowAll);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1694, 132);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm Kiếm";
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(848, 57);
            txtTuKhoa.Margin = new Padding(3, 4, 3, 4);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Nhập từ khóa cần tìm...";
            txtTuKhoa.Size = new Size(400, 30);
            txtTuKhoa.TabIndex = 84;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 55);
            label1.Name = "label1";
            label1.Size = new Size(55, 23);
            label1.TabIndex = 87;
            label1.Text = "Khoa:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(398, 58);
            label11.Name = "label11";
            label11.Size = new Size(130, 23);
            label11.TabIndex = 87;
            label11.Text = "Loại Tìm Kiếm:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(756, 61);
            label12.Name = "label12";
            label12.Size = new Size(76, 23);
            label12.TabIndex = 88;
            label12.Text = "Từ Khóa";
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(151, 53);
            cboKhoa.Margin = new Padding(3, 4, 3, 4);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(200, 31);
            cboKhoa.TabIndex = 83;
            // 
            // cboTimKiem
            // 
            cboTimKiem.FormattingEnabled = true;
            cboTimKiem.Location = new Point(546, 58);
            cboTimKiem.Margin = new Padding(3, 4, 3, 4);
            cboTimKiem.Name = "cboTimKiem";
            cboTimKiem.Size = new Size(200, 31);
            cboTimKiem.TabIndex = 83;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.White;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.Location = new Point(1398, 52);
            btnShowAll.Margin = new Padding(3, 4, 3, 4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(120, 40);
            btnShowAll.TabIndex = 86;
            btnShowAll.Text = "Hiện tất cả";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.White;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Location = new Point(1263, 51);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 40);
            btnTimKiem.TabIndex = 85;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Controls.Add(groupBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 132);
            panel2.Name = "panel2";
            panel2.Size = new Size(1694, 75);
            panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(radGiam);
            groupBox2.Controls.Add(radTang);
            groupBox2.Controls.Add(cboKieuSX);
            groupBox2.Controls.Add(label9);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1694, 75);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sắp xếp theo";
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(603, 33);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(73, 27);
            radGiam.TabIndex = 88;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            radGiam.CheckedChanged += radGiam_CheckedChanged;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Location = new Point(506, 33);
            radTang.Name = "radTang";
            radTang.Size = new Size(70, 27);
            radTang.TabIndex = 89;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            radTang.CheckedChanged += radTang_CheckedChanged;
            // 
            // cboKieuSX
            // 
            cboKieuSX.FormattingEnabled = true;
            cboKieuSX.Location = new Point(170, 29);
            cboKieuSX.Name = "cboKieuSX";
            cboKieuSX.Size = new Size(198, 31);
            cboKieuSX.TabIndex = 87;
            cboKieuSX.SelectedIndexChanged += cboKieuSX_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 33);
            label9.Name = "label9";
            label9.Size = new Size(121, 23);
            label9.TabIndex = 86;
            label9.Text = "Kiểu Sắp Xếp:";
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 207);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10, 0, 10, 0);
            panel3.Size = new Size(1694, 747);
            panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvDanhSachSV);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(10, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1674, 747);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách sinh viên";
            // 
            // dgvDanhSachSV
            // 
            dgvDanhSachSV.AllowUserToAddRows = false;
            dgvDanhSachSV.AllowUserToDeleteRows = false;
            dgvDanhSachSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSV.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDanhSachSV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDanhSachSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSV.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, NgaySinh, GioiTinh, LopHanhChinh, MaKhoa, TrangThai, ThaoTac });
            dgvDanhSachSV.Dock = DockStyle.Fill;
            dgvDanhSachSV.EnableHeadersVisualStyles = false;
            dgvDanhSachSV.Location = new Point(3, 26);
            dgvDanhSachSV.Name = "dgvDanhSachSV";
            dgvDanhSachSV.RowHeadersWidth = 51;
            dgvDanhSachSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachSV.Size = new Size(1668, 718);
            dgvDanhSachSV.TabIndex = 1;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Blue;
            MaSV.DefaultCellStyle = dataGridViewCellStyle1;
            MaSV.FillWeight = 53.1703568F;
            MaSV.HeaderText = "Mã SV";
            MaSV.MinimumWidth = 6;
            MaSV.Name = "MaSV";
            MaSV.ReadOnly = true;
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            HoTen.FillWeight = 53.1703568F;
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.ReadOnly = true;
            // 
            // NgaySinh
            // 
            NgaySinh.DataPropertyName = "NgaySinh";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NgaySinh.DefaultCellStyle = dataGridViewCellStyle2;
            NgaySinh.FillWeight = 53.1703568F;
            NgaySinh.HeaderText = "Ngày Sinh";
            NgaySinh.MinimumWidth = 6;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.ReadOnly = true;
            // 
            // GioiTinh
            // 
            GioiTinh.DataPropertyName = "GioiTinh";
            GioiTinh.FillWeight = 53.1703568F;
            GioiTinh.HeaderText = "Giới tính";
            GioiTinh.MinimumWidth = 6;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.ReadOnly = true;
            // 
            // LopHanhChinh
            // 
            LopHanhChinh.DataPropertyName = "LopHanhChinh";
            LopHanhChinh.FillWeight = 53.1703568F;
            LopHanhChinh.HeaderText = "Lớp";
            LopHanhChinh.MinimumWidth = 6;
            LopHanhChinh.Name = "LopHanhChinh";
            LopHanhChinh.ReadOnly = true;
            // 
            // MaKhoa
            // 
            MaKhoa.DataPropertyName = "MaKhoa";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MaKhoa.DefaultCellStyle = dataGridViewCellStyle3;
            MaKhoa.FillWeight = 53.1703568F;
            MaKhoa.HeaderText = "Khoa";
            MaKhoa.MinimumWidth = 6;
            MaKhoa.Name = "MaKhoa";
            MaKhoa.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Lime;
            TrangThai.DefaultCellStyle = dataGridViewCellStyle4;
            TrangThai.FillWeight = 53.1703568F;
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            // 
            // ThaoTac
            // 
            ThaoTac.DataPropertyName = "ThaoTac";
            dataGridViewCellStyle5.BackColor = Color.SpringGreen;
            ThaoTac.DefaultCellStyle = dataGridViewCellStyle5;
            ThaoTac.FillWeight = 53.1703568F;
            ThaoTac.HeaderText = "Thao Tác";
            ThaoTac.MinimumWidth = 6;
            ThaoTac.Name = "ThaoTac";
            ThaoTac.ReadOnly = true;
            // 
            // UC_QuanLyDiem_Container
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_QuanLyDiem_Container";
            Size = new Size(1694, 954);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private Panel panel2;
        private GroupBox groupBox2;
        private Panel panel3;
        private GroupBox groupBox3;
        private DataGridView dgvDanhSachSV;
        private TextBox txtTuKhoa;
        private Label label11;
        private Label label12;
        private ComboBox cboTimKiem;
        private Button btnShowAll;
        private Button btnTimKiem;
        private RadioButton radGiam;
        private RadioButton radTang;
        private ComboBox cboKieuSX;
        private Label label9;
        private Label label1;
        private ComboBox cboKhoa;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn LopHanhChinh;
        private DataGridViewTextBoxColumn MaKhoa;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn ThaoTac;
    }
}
