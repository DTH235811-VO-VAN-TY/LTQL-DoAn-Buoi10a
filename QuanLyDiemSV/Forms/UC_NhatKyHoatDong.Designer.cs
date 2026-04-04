namespace QuanLyDiemSV.Forms
{
    partial class UC_NhatKyHoatDong
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
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txtTenNguoiDung = new TextBox();
            label2 = new Label();
            cboHanhDong = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnTimKiem = new Button();
            btnLamLai = new Button();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            dgvNhatKyHoatDong = new DataGridView();
            MaLog = new DataGridViewTextBoxColumn();
            NguoiDung = new DataGridViewTextBoxColumn();
            ThoiGian = new DataGridViewTextBoxColumn();
            HanhDong = new DataGridViewTextBoxColumn();
            ChiTiet = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhatKyHoatDong).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(1674, 141);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLamLai);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(dtpDenNgay);
            groupBox1.Controls.Add(dtpTuNgay);
            groupBox1.Controls.Add(cboHanhDong);
            groupBox1.Controls.Add(txtTenNguoiDung);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1674, 141);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lọc Và Tìm Kiếm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 66);
            label1.Name = "label1";
            label1.Size = new Size(126, 19);
            label1.TabIndex = 0;
            label1.Text = "Tên Người Dùng:";
            // 
            // txtTenNguoiDung
            // 
            txtTenNguoiDung.Location = new Point(155, 64);
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.Size = new Size(280, 27);
            txtTenNguoiDung.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(460, 70);
            label2.Name = "label2";
            label2.Size = new Size(90, 19);
            label2.TabIndex = 0;
            label2.Text = "Hành Động:";
            // 
            // cboHanhDong
            // 
            cboHanhDong.FormattingEnabled = true;
            cboHanhDong.Location = new Point(556, 67);
            cboHanhDong.Name = "cboHanhDong";
            cboHanhDong.Size = new Size(219, 27);
            cboHanhDong.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(807, 66);
            label3.Name = "label3";
            label3.Size = new Size(71, 19);
            label3.TabIndex = 0;
            label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1054, 70);
            label4.Name = "label4";
            label4.Size = new Size(81, 19);
            label4.TabIndex = 0;
            label4.Text = "Đến Ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(884, 64);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(137, 27);
            dtpTuNgay.TabIndex = 3;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(1155, 66);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(137, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(1329, 64);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(131, 36);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLamLai
            // 
            btnLamLai.Location = new Point(1482, 66);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Size = new Size(131, 36);
            btnLamLai.TabIndex = 4;
            btnLamLai.Text = "Tải Lại";
            btnLamLai.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(10, 151);
            panel2.Name = "panel2";
            panel2.Size = new Size(1674, 793);
            panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvNhatKyHoatDong);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10, 3, 10, 3);
            groupBox2.Size = new Size(1674, 793);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin";
            // 
            // dgvNhatKyHoatDong
            // 
            dgvNhatKyHoatDong.AllowUserToAddRows = false;
            dgvNhatKyHoatDong.AllowUserToDeleteRows = false;
            dgvNhatKyHoatDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhatKyHoatDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhatKyHoatDong.Columns.AddRange(new DataGridViewColumn[] { MaLog, NguoiDung, ThoiGian, HanhDong, ChiTiet });
            dgvNhatKyHoatDong.Dock = DockStyle.Fill;
            dgvNhatKyHoatDong.Location = new Point(10, 26);
            dgvNhatKyHoatDong.Name = "dgvNhatKyHoatDong";
            dgvNhatKyHoatDong.RowHeadersWidth = 51;
            dgvNhatKyHoatDong.Size = new Size(1654, 764);
            dgvNhatKyHoatDong.TabIndex = 0;
            // 
            // MaLog
            // 
            MaLog.DataPropertyName = "MaLog";
            MaLog.HeaderText = "Mã Log";
            MaLog.MinimumWidth = 6;
            MaLog.Name = "MaLog";
            MaLog.ReadOnly = true;
            // 
            // NguoiDung
            // 
            NguoiDung.DataPropertyName = "NguoiDung";
            NguoiDung.HeaderText = "Tên Người Dùng";
            NguoiDung.MinimumWidth = 6;
            NguoiDung.Name = "NguoiDung";
            NguoiDung.ReadOnly = true;
            // 
            // ThoiGian
            // 
            ThoiGian.DataPropertyName = "ThoiGian";
            ThoiGian.HeaderText = "Thời Gian";
            ThoiGian.MinimumWidth = 6;
            ThoiGian.Name = "ThoiGian";
            ThoiGian.ReadOnly = true;
            // 
            // HanhDong
            // 
            HanhDong.DataPropertyName = "HanhDong";
            HanhDong.HeaderText = "Hành Động";
            HanhDong.MinimumWidth = 6;
            HanhDong.Name = "HanhDong";
            HanhDong.ReadOnly = true;
            // 
            // ChiTiet
            // 
            ChiTiet.DataPropertyName = "ChiTiet";
            ChiTiet.HeaderText = "Chi Tiết";
            ChiTiet.MinimumWidth = 6;
            ChiTiet.Name = "ChiTiet";
            ChiTiet.ReadOnly = true;
            // 
            // UC_NhatKyHoatDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_NhatKyHoatDong";
            Padding = new Padding(10);
            Size = new Size(1694, 954);
            Load += UC_NhatKyHoatDong_Load;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhatKyHoatDong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private ComboBox cboHanhDong;
        private TextBox txtTenNguoiDung;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnLamLai;
        private Button btnTimKiem;
        private Panel panel2;
        private GroupBox groupBox2;
        private DataGridView dgvNhatKyHoatDong;
        private DataGridViewTextBoxColumn MaLog;
        private DataGridViewTextBoxColumn NguoiDung;
        private DataGridViewTextBoxColumn ThoiGian;
        private DataGridViewTextBoxColumn HanhDong;
        private DataGridViewTextBoxColumn ChiTiet;
    }
}
