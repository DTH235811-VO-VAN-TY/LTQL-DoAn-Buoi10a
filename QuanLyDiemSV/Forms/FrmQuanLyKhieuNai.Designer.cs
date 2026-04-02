namespace QuanLyDiemSV.Forms
{
    partial class FrmQuanLyKhieuNai
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
            groupBox1 = new GroupBox();
            dgvKhieuNai = new DataGridView();
            MaDon = new DataGridViewTextBoxColumn();
            MaSV = new DataGridViewTextBoxColumn();
            TenSV = new DataGridViewTextBoxColumn();
            MonHoc = new DataGridViewTextBoxColumn();
            LyDo = new DataGridViewTextBoxColumn();
            NgayGui = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            btnTuChoi = new Button();
            btnDuyet = new Button();
            txtPhanHoi = new TextBox();
            txtDiemCKMoi = new TextBox();
            txtDiemGKMoi = new TextBox();
            txtDiemCKCu = new TextBox();
            txtDiemGTCu = new TextBox();
            label7 = new Label();
            lblLyDo = new Label();
            label5 = new Label();
            label6 = new Label();
            lblMonHoc = new Label();
            label4 = new Label();
            lblSinhVien = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhieuNai).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvKhieuNai);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8, 3, 8, 3);
            groupBox1.Size = new Size(1182, 338);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đơn khiếu nại";
            // 
            // dgvKhieuNai
            // 
            dgvKhieuNai.AllowUserToAddRows = false;
            dgvKhieuNai.AllowUserToDeleteRows = false;
            dgvKhieuNai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhieuNai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhieuNai.Columns.AddRange(new DataGridViewColumn[] { MaDon, MaSV, TenSV, MonHoc, LyDo, NgayGui });
            dgvKhieuNai.Dock = DockStyle.Fill;
            dgvKhieuNai.Location = new Point(8, 26);
            dgvKhieuNai.Name = "dgvKhieuNai";
            dgvKhieuNai.RowHeadersWidth = 51;
            dgvKhieuNai.Size = new Size(1166, 309);
            dgvKhieuNai.TabIndex = 0;
            dgvKhieuNai.CellClick += dgvKhieuNai_CellClick;
            // 
            // MaDon
            // 
            MaDon.DataPropertyName = "MaKN";
            MaDon.HeaderText = "Mã Đơn";
            MaDon.MinimumWidth = 6;
            MaDon.Name = "MaDon";
            MaDon.ReadOnly = true;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
            MaSV.HeaderText = "Mã SV";
            MaSV.MinimumWidth = 6;
            MaSV.Name = "MaSV";
            MaSV.ReadOnly = true;
            // 
            // TenSV
            // 
            TenSV.DataPropertyName = "HoTen";
            TenSV.HeaderText = "Tên SV";
            TenSV.MinimumWidth = 6;
            TenSV.Name = "TenSV";
            TenSV.ReadOnly = true;
            // 
            // MonHoc
            // 
            MonHoc.DataPropertyName = "MonHoc";
            MonHoc.HeaderText = "Môn Học";
            MonHoc.MinimumWidth = 6;
            MonHoc.Name = "MonHoc";
            MonHoc.ReadOnly = true;
            // 
            // LyDo
            // 
            LyDo.DataPropertyName = "LyDo";
            LyDo.HeaderText = "Lý Do";
            LyDo.MinimumWidth = 6;
            LyDo.Name = "LyDo";
            LyDo.ReadOnly = true;
            // 
            // NgayGui
            // 
            NgayGui.DataPropertyName = "NgayGui";
            NgayGui.HeaderText = "Ngày Gửi";
            NgayGui.MinimumWidth = 6;
            NgayGui.Name = "NgayGui";
            NgayGui.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnTuChoi);
            groupBox2.Controls.Add(btnDuyet);
            groupBox2.Controls.Add(txtPhanHoi);
            groupBox2.Controls.Add(txtDiemCKMoi);
            groupBox2.Controls.Add(txtDiemGKMoi);
            groupBox2.Controls.Add(txtDiemCKCu);
            groupBox2.Controls.Add(txtDiemGTCu);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(lblLyDo);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(lblMonHoc);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(lblSinhVien);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(10, 348);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1182, 337);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Xử lý đơn";
            // 
            // btnTuChoi
            // 
            btnTuChoi.BackColor = Color.Red;
            btnTuChoi.Location = new Point(207, 291);
            btnTuChoi.Name = "btnTuChoi";
            btnTuChoi.Size = new Size(123, 30);
            btnTuChoi.TabIndex = 3;
            btnTuChoi.Text = "Từ Chối";
            btnTuChoi.UseVisualStyleBackColor = false;
            btnTuChoi.Click += btnTuChoi_Click;
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = Color.Lime;
            btnDuyet.Location = new Point(48, 291);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(123, 30);
            btnDuyet.TabIndex = 3;
            btnDuyet.Text = "Duyệt";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // txtPhanHoi
            // 
            txtPhanHoi.Location = new Point(41, 150);
            txtPhanHoi.Multiline = true;
            txtPhanHoi.Name = "txtPhanHoi";
            txtPhanHoi.Size = new Size(1103, 124);
            txtPhanHoi.TabIndex = 2;
            // 
            // txtDiemCKMoi
            // 
            txtDiemCKMoi.Location = new Point(1019, 100);
            txtDiemCKMoi.Name = "txtDiemCKMoi";
            txtDiemCKMoi.Size = new Size(125, 30);
            txtDiemCKMoi.TabIndex = 1;
            // 
            // txtDiemGKMoi
            // 
            txtDiemGKMoi.Location = new Point(718, 100);
            txtDiemGKMoi.Name = "txtDiemGKMoi";
            txtDiemGKMoi.Size = new Size(125, 30);
            txtDiemGKMoi.TabIndex = 1;
            // 
            // txtDiemCKCu
            // 
            txtDiemCKCu.Location = new Point(453, 96);
            txtDiemCKCu.Name = "txtDiemCKCu";
            txtDiemCKCu.Size = new Size(125, 30);
            txtDiemCKCu.TabIndex = 1;
            // 
            // txtDiemGTCu
            // 
            txtDiemGTCu.Location = new Point(151, 96);
            txtDiemGTCu.Name = "txtDiemGTCu";
            txtDiemGTCu.Size = new Size(125, 30);
            txtDiemGTCu.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(862, 103);
            label7.Name = "label7";
            label7.Size = new Size(151, 23);
            label7.TabIndex = 0;
            label7.Text = "Điểm Cuối Kỳ mới:";
            // 
            // lblLyDo
            // 
            lblLyDo.AutoSize = true;
            lblLyDo.Location = new Point(525, 49);
            lblLyDo.Name = "lblLyDo";
            lblLyDo.Size = new Size(53, 23);
            lblLyDo.TabIndex = 0;
            lblLyDo.Text = "label1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(301, 103);
            label5.Name = "label5";
            label5.Size = new Size(140, 23);
            label5.TabIndex = 0;
            label5.Text = "Điểm Cuối kỳ cũ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(601, 103);
            label6.Name = "label6";
            label6.Size = new Size(111, 23);
            label6.TabIndex = 0;
            label6.Text = "Điểm GK mới";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(301, 49);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(53, 23);
            lblMonHoc.TabIndex = 0;
            lblMonHoc.Text = "label1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 103);
            label4.Name = "label4";
            label4.Size = new Size(103, 23);
            label4.TabIndex = 0;
            label4.Text = "Điểm CK cũ:";
            // 
            // lblSinhVien
            // 
            lblSinhVien.AutoSize = true;
            lblSinhVien.Location = new Point(42, 49);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Size = new Size(53, 23);
            lblSinhVien.TabIndex = 0;
            lblSinhVien.Text = "label1";
            // 
            // FrmQuanLyKhieuNai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 695);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmQuanLyKhieuNai";
            Padding = new Padding(10);
            Text = "Quản Lý Khiếu Nại";
            Load += FrmQuanLyKhieuNai_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhieuNai).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvKhieuNai;
        private GroupBox groupBox2;
        private TextBox txtDiemCKMoi;
        private TextBox txtDiemGKMoi;
        private TextBox txtDiemCKCu;
        private TextBox txtDiemGTCu;
        private Label label7;
        private Label lblLyDo;
        private Label label5;
        private Label label6;
        private Label lblMonHoc;
        private Label label4;
        private Label lblSinhVien;
        private Button btnTuChoi;
        private Button btnDuyet;
        private TextBox txtPhanHoi;
        private DataGridViewTextBoxColumn MaDon;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn TenSV;
        private DataGridViewTextBoxColumn MonHoc;
        private DataGridViewTextBoxColumn LyDo;
        private DataGridViewTextBoxColumn NgayGui;
    }
}