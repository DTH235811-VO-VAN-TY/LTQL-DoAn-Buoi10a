namespace QuanLyDiemSV.Forms
{
    partial class FrmXepLop
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtMaLHP = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtTenSV = new TextBox();
            btnLuu = new Button();
            btnHuyBo = new Button();
            btnNhap = new Button();
            groupBox1 = new GroupBox();
            dgvSinhVien = new DataGridView();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            lblSiSo = new Label();
            btnTimKiem = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            btnXoa = new Button();
            btnThem = new Button();
            panel2 = new Panel();
            cboMaSV = new ComboBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(16, 27);
            label1.Name = "label1";
            label1.Size = new Size(156, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã Lớp Học Phần:";
            // 
            // txtMaLHP
            // 
            txtMaLHP.Location = new Point(178, 30);
            txtMaLHP.Name = "txtMaLHP";
            txtMaLHP.Size = new Size(304, 27);
            txtMaLHP.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(501, 30);
            label2.Name = "label2";
            label2.Size = new Size(120, 23);
            label2.TabIndex = 0;
            label2.Text = "Mã Sinh Viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(854, 34);
            label3.Name = "label3";
            label3.Size = new Size(122, 23);
            label3.TabIndex = 0;
            label3.Text = "Tên Sinh Viên:";
            // 
            // txtTenSV
            // 
            txtTenSV.Location = new Point(987, 30);
            txtTenSV.Name = "txtTenSV";
            txtTenSV.ReadOnly = true;
            txtTenSV.Size = new Size(254, 27);
            txtTenSV.TabIndex = 1;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(181, 72);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(561, 72);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 29);
            btnHuyBo.TabIndex = 2;
            btnHuyBo.Text = "Hủy Bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(671, 72);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(112, 29);
            btnNhap.TabIndex = 2;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvSinhVien);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 208);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1268, 562);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh Sách Sinh Viên";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, TenLop, GioiTinh });
            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.Location = new Point(3, 26);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(1262, 533);
            dgvSinhVien.TabIndex = 0;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
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
            TenLop.HeaderText = "Lớp Hành Chính";
            TenLop.MinimumWidth = 6;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // GioiTinh
            // 
            GioiTinh.DataPropertyName = "GioiTinh";
            GioiTinh.HeaderText = "Giới Tính";
            GioiTinh.MinimumWidth = 6;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.ReadOnly = true;
            // 
            // lblSiSo
            // 
            lblSiSo.AutoSize = true;
            lblSiSo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSiSo.Location = new Point(898, 23);
            lblSiSo.Name = "lblSiSo";
            lblSiSo.Size = new Size(56, 28);
            lblSiSo.TabIndex = 4;
            lblSiSo.Text = "Sĩ số";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(650, 26);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnLuu_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(112, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(519, 27);
            textBox1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(25, 26);
            label4.Name = "label4";
            label4.Size = new Size(81, 23);
            label4.TabIndex = 0;
            label4.Text = "Từ Khóa:";
            // 
            // panel1
            // 
            panel1.Controls.Add(cboMaSV);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtMaLHP);
            panel1.Controls.Add(btnNhap);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(btnHuyBo);
            panel1.Controls.Add(txtTenSV);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1268, 113);
            panel1.TabIndex = 5;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(435, 72);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(307, 72);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnHuyBo_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblSiSo);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(btnTimKiem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 113);
            panel2.Name = "panel2";
            panel2.Size = new Size(1268, 95);
            panel2.TabIndex = 6;
            // 
            // cboMaSV
            // 
            cboMaSV.FormattingEnabled = true;
            cboMaSV.Location = new Point(632, 33);
            cboMaSV.Name = "cboMaSV";
            cboMaSV.Size = new Size(216, 28);
            cboMaSV.TabIndex = 3;
            // 
            // FrmXepLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 770);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmXepLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmXepLop";
            Load += FrmXepLop_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtMaLHP;
        private Label label2;
        private Label label3;
        private TextBox txtTenSV;
        private Button btnLuu;
        private Button btnHuyBo;
        private Button btnNhap;
        private GroupBox groupBox1;
        private DataGridView dgvSinhVien;
        private Label lblSiSo;
        private Button btnTimKiem;
        private TextBox textBox1;
        private Label label4;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn GioiTinh;
        private Panel panel1;
        private Button btnXoa;
        private Button btnThem;
        private Panel panel2;
        private ComboBox cboMaSV;
    }
}