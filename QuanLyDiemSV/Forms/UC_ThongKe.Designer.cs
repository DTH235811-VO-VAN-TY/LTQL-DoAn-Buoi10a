namespace QuanLyDiemSV.Forms
{
    partial class UC_ThongKe
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
            panel1 = new Panel();
            lblTongSV = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lblSVGioi = new Label();
            label4 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            lblSVRot = new Label();
            label7 = new Label();
            label8 = new Label();
            panel4 = new Panel();
            lblTyLeDat = new Label();
            lbl = new Label();
            label11 = new Label();
            label3 = new Label();
            cboKhoa = new ComboBox();
            label6 = new Label();
            cboLop = new ComboBox();
            label10 = new Label();
            cboDieuKien = new ComboBox();
            btnThongKe = new Button();
            btnLamMoi = new Button();
            btnXuatExcel = new Button();
            panel5 = new Panel();
            panel6 = new Panel();
            lblSVXuatSac = new Label();
            label13 = new Label();
            cboHocKy = new ComboBox();
            label9 = new Label();
            groupBox1 = new GroupBox();
            dgvThongKe = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            DiemTK = new DataGridViewTextBoxColumn();
            XepLoai = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Yellow;
            panel1.Controls.Add(lblTongSV);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(10, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 136);
            panel1.TabIndex = 0;
            // 
            // lblTongSV
            // 
            lblTongSV.AutoSize = true;
            lblTongSV.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTongSV.Location = new Point(20, 78);
            lblTongSV.Name = "lblTongSV";
            lblTongSV.Size = new Size(99, 28);
            lblTongSV.TabIndex = 1;
            lblTongSV.Text = "Số Lượng";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.Location = new Point(20, 13);
            label2.Name = "label2";
            label2.Size = new Size(211, 50);
            label2.TabIndex = 0;
            label2.Text = "Tổng Số SV";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 13);
            label1.Name = "label1";
            label1.Size = new Size(211, 50);
            label1.TabIndex = 0;
            label1.Text = "Tổng Số SV";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Cyan;
            panel2.Controls.Add(lblSVGioi);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(373, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(281, 136);
            panel2.TabIndex = 1;
            // 
            // lblSVGioi
            // 
            lblSVGioi.AutoSize = true;
            lblSVGioi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblSVGioi.Location = new Point(20, 78);
            lblSVGioi.Name = "lblSVGioi";
            lblSVGioi.Size = new Size(99, 28);
            lblSVGioi.TabIndex = 1;
            lblSVGioi.Text = "Số Lượng";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.Location = new Point(20, 13);
            label4.Name = "label4";
            label4.Size = new Size(211, 50);
            label4.TabIndex = 0;
            label4.Text = "Số Sinh Viên Giỏi";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 13);
            label5.Name = "label5";
            label5.Size = new Size(211, 50);
            label5.TabIndex = 0;
            label5.Text = "Tổng Số SV";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Controls.Add(lblSVRot);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(1055, 28);
            panel3.Name = "panel3";
            panel3.Size = new Size(281, 136);
            panel3.TabIndex = 2;
            // 
            // lblSVRot
            // 
            lblSVRot.AutoSize = true;
            lblSVRot.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblSVRot.Location = new Point(20, 78);
            lblSVRot.Name = "lblSVRot";
            lblSVRot.Size = new Size(99, 28);
            lblSVRot.TabIndex = 1;
            lblSVRot.Text = "Số Lượng";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label7.Location = new Point(20, 13);
            label7.Name = "label7";
            label7.Size = new Size(211, 50);
            label7.TabIndex = 0;
            label7.Text = "Sinh Viên Rớt";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(20, 13);
            label8.Name = "label8";
            label8.Size = new Size(211, 50);
            label8.TabIndex = 0;
            label8.Text = "Tổng Số SV";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 0, 192);
            panel4.Controls.Add(lblTyLeDat);
            panel4.Controls.Add(lbl);
            panel4.Controls.Add(label11);
            panel4.Location = new Point(1403, 28);
            panel4.Name = "panel4";
            panel4.Size = new Size(281, 136);
            panel4.TabIndex = 2;
            // 
            // lblTyLeDat
            // 
            lblTyLeDat.AutoSize = true;
            lblTyLeDat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTyLeDat.Location = new Point(20, 78);
            lblTyLeDat.Name = "lblTyLeDat";
            lblTyLeDat.Size = new Size(99, 28);
            lblTyLeDat.TabIndex = 1;
            lblTyLeDat.Text = "Số Lượng";
            // 
            // lbl
            // 
            lbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lbl.Location = new Point(20, 13);
            lbl.Name = "lbl";
            lbl.Size = new Size(211, 50);
            lbl.TabIndex = 0;
            lbl.Text = "Tỷ lệ đạt";
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(20, 13);
            label11.Name = "label11";
            label11.Size = new Size(211, 50);
            label11.TabIndex = 0;
            label11.Text = "Tổng Số SV";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(75, 198);
            label3.Name = "label3";
            label3.Size = new Size(65, 28);
            label3.TabIndex = 3;
            label3.Text = "Khoa:";
            // 
            // cboKhoa
            // 
            cboKhoa.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(146, 202);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(244, 27);
            cboKhoa.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(401, 198);
            label6.Name = "label6";
            label6.Size = new Size(52, 28);
            label6.TabIndex = 3;
            label6.Text = "Lớp:";
            // 
            // cboLop
            // 
            cboLop.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(449, 201);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(269, 27);
            cboLop.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(724, 200);
            label10.Name = "label10";
            label10.Size = new Size(109, 28);
            label10.TabIndex = 3;
            label10.Text = "Điều Kiện:";
            // 
            // cboDieuKien
            // 
            cboDieuKien.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            cboDieuKien.FormattingEnabled = true;
            cboDieuKien.Location = new Point(839, 203);
            cboDieuKien.Name = "cboDieuKien";
            cboDieuKien.Size = new Size(449, 27);
            cboDieuKien.TabIndex = 4;
            // 
            // btnThongKe
            // 
            btnThongKe.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThongKe.Location = new Point(1294, 253);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(115, 39);
            btnThongKe.TabIndex = 5;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLamMoi.Location = new Point(1437, 253);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(115, 39);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXuatExcel.Location = new Point(1569, 253);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(115, 39);
            btnXuatExcel.TabIndex = 5;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(btnXuatExcel);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(btnLamMoi);
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(btnThongKe);
            panel5.Controls.Add(panel3);
            panel5.Controls.Add(cboHocKy);
            panel5.Controls.Add(cboDieuKien);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(cboKhoa);
            panel5.Controls.Add(cboLop);
            panel5.Controls.Add(label6);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1694, 305);
            panel5.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Cyan;
            panel6.Controls.Add(lblSVXuatSac);
            panel6.Controls.Add(label13);
            panel6.Location = new Point(724, 28);
            panel6.Name = "panel6";
            panel6.Size = new Size(281, 136);
            panel6.TabIndex = 6;
            // 
            // lblSVXuatSac
            // 
            lblSVXuatSac.AutoSize = true;
            lblSVXuatSac.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblSVXuatSac.Location = new Point(20, 78);
            lblSVXuatSac.Name = "lblSVXuatSac";
            lblSVXuatSac.Size = new Size(99, 28);
            lblSVXuatSac.TabIndex = 1;
            lblSVXuatSac.Text = "Số Lượng";
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label13.Location = new Point(20, 13);
            label13.Name = "label13";
            label13.Size = new Size(258, 50);
            label13.TabIndex = 0;
            label13.Text = "Số Sinh Viên Xuất Sắc";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboHocKy
            // 
            cboHocKy.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(1394, 202);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(290, 27);
            cboHocKy.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(1294, 202);
            label9.Name = "label9";
            label9.Size = new Size(83, 28);
            label9.TabIndex = 3;
            label9.Text = "Học Kỳ:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvThongKe);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 305);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10, 3, 10, 3);
            groupBox1.Size = new Size(1694, 649);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh Sách Sinh Viên";
            // 
            // dgvThongKe
            // 
            dgvThongKe.AllowUserToAddRows = false;
            dgvThongKe.AllowUserToDeleteRows = false;
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongKe.Columns.AddRange(new DataGridViewColumn[] { STT, MaSV, HoTen, TenLop, DiemTK, XepLoai });
            dgvThongKe.Dock = DockStyle.Fill;
            dgvThongKe.Location = new Point(10, 26);
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.RowHeadersWidth = 51;
            dgvThongKe.Size = new Size(1674, 620);
            dgvThongKe.TabIndex = 0;
            // 
            // STT
            // 
            STT.DataPropertyName = "STT";
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            STT.ReadOnly = true;
            // 
            // MaSV
            // 
            MaSV.DataPropertyName = "MaSV";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Blue;
            MaSV.DefaultCellStyle = dataGridViewCellStyle1;
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
            TenLop.HeaderText = "Tên Lớp";
            TenLop.MinimumWidth = 6;
            TenLop.Name = "TenLop";
            TenLop.ReadOnly = true;
            // 
            // DiemTK
            // 
            DiemTK.DataPropertyName = "DiemTK";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = Color.Blue;
            DiemTK.DefaultCellStyle = dataGridViewCellStyle2;
            DiemTK.HeaderText = "Điểm Tổng Kết";
            DiemTK.MinimumWidth = 6;
            DiemTK.Name = "DiemTK";
            DiemTK.ReadOnly = true;
            // 
            // XepLoai
            // 
            XepLoai.DataPropertyName = "XepLoai";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(192, 0, 0);
            XepLoai.DefaultCellStyle = dataGridViewCellStyle3;
            XepLoai.HeaderText = "Xếp Loại";
            XepLoai.MinimumWidth = 6;
            XepLoai.Name = "XepLoai";
            XepLoai.ReadOnly = true;
            // 
            // UC_ThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(panel5);
            Name = "UC_ThongKe";
            Size = new Size(1694, 954);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label lblTongSV;
        private Label label2;
        private Panel panel2;
        private Label lblSVGioi;
        private Label label4;
        private Label label5;
        private Panel panel3;
        private Label lblSVRot;
        private Label label7;
        private Label label8;
        private Panel panel4;
        private Label lblTyLeDat;
        private Label lbl;
        private Label label11;
        private Label label3;
        private ComboBox cboKhoa;
        private Label label6;
        private ComboBox cboLop;
        private Label label10;
        private ComboBox cboDieuKien;
        private Button btnThongKe;
        private Button btnLamMoi;
        private Button btnXuatExcel;
        private Panel panel5;
        private GroupBox groupBox1;
        private DataGridView dgvThongKe;
        private ComboBox cboHocKy;
        private Label label9;
        private Panel panel6;
        private Label lblSVXuatSac;
        private Label label13;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn DiemTK;
        private DataGridViewTextBoxColumn XepLoai;
    }
}
