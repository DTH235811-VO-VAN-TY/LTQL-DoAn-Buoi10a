namespace QuanLyDiemSV.Forms
{
    partial class UC_GiangVien_ChamDiem
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
            btnInDanhSach = new Button();
            btnTaiLai = new Button();
            btnLoc = new Button();
            txtTimKiem = new TextBox();
            cboHocKy = new ComboBox();
            label1 = new Label();
            flpDanhSachLop = new FlowLayoutPanel();
            pnlDanhSachSV = new Panel();
            groupBox1 = new GroupBox();
            DgvDSSV = new DataGridView();
            MaSV = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            DiemGK = new DataGridViewTextBoxColumn();
            DiemCK = new DataGridViewTextBoxColumn();
            DiemThiLan1 = new DataGridViewTextBoxColumn();
            DiemThiLan2 = new DataGridViewTextBoxColumn();
            DiemTongKet = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            lblSoLuongSV = new Label();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            txtTuKhoa = new TextBox();
            btnXuatExcel = new Button();
            btnHienTatCa = new Button();
            btnTimKiem = new Button();
            btnLuuBangDiem = new Button();
            cboKieuSX = new ComboBox();
            label3 = new Label();
            cboLoaiTK = new ComboBox();
            label2 = new Label();
            btnQuayLaiLop = new Button();
            panel1.SuspendLayout();
            pnlDanhSachSV.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDSSV).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnInDanhSach);
            panel1.Controls.Add(btnTaiLai);
            panel1.Controls.Add(btnLoc);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(cboHocKy);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 107);
            panel1.TabIndex = 0;
            // 
            // btnInDanhSach
            // 
            btnInDanhSach.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnInDanhSach.Location = new Point(1230, 49);
            btnInDanhSach.Name = "btnInDanhSach";
            btnInDanhSach.Size = new Size(217, 35);
            btnInDanhSach.TabIndex = 3;
            btnInDanhSach.Text = "In Danh Sách";
            btnInDanhSach.UseVisualStyleBackColor = true;
            btnInDanhSach.Click += btnInDanhSach_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnTaiLai.Location = new Point(1074, 49);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(150, 35);
            btnTaiLai.TabIndex = 3;
            btnTaiLai.Text = "Tải Lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // btnLoc
            // 
            btnLoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLoc.Location = new Point(918, 49);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(150, 35);
            btnLoc.TabIndex = 3;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = true;
            btnLoc.Click += btnLoc_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(395, 45);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập từ khóa tìm kiếm...";
            txtTimKiem.Size = new Size(396, 34);
            txtTimKiem.TabIndex = 2;
            // 
            // cboHocKy
            // 
            cboHocKy.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(123, 45);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(244, 27);
            cboHocKy.TabIndex = 1;
            cboHocKy.SelectedIndexChanged += cboHocKy_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 45);
            label1.Name = "label1";
            label1.Size = new Size(90, 28);
            label1.TabIndex = 0;
            label1.Text = "HỌC KỲ:";
            // 
            // flpDanhSachLop
            // 
            flpDanhSachLop.AutoScroll = true;
            flpDanhSachLop.BackColor = Color.LightGray;
            flpDanhSachLop.Dock = DockStyle.Fill;
            flpDanhSachLop.Location = new Point(0, 107);
            flpDanhSachLop.Name = "flpDanhSachLop";
            flpDanhSachLop.Size = new Size(1694, 847);
            flpDanhSachLop.TabIndex = 1;
            // 
            // pnlDanhSachSV
            // 
            pnlDanhSachSV.Controls.Add(groupBox1);
            pnlDanhSachSV.Controls.Add(panel2);
            pnlDanhSachSV.Dock = DockStyle.Fill;
            pnlDanhSachSV.Location = new Point(0, 107);
            pnlDanhSachSV.Name = "pnlDanhSachSV";
            pnlDanhSachSV.Size = new Size(1694, 847);
            pnlDanhSachSV.TabIndex = 0;
            pnlDanhSachSV.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DgvDSSV);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1694, 728);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh Sách Sinh Viên";
            // 
            // DgvDSSV
            // 
            DgvDSSV.AllowUserToAddRows = false;
            DgvDSSV.AllowUserToDeleteRows = false;
            DgvDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvDSSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDSSV.Columns.AddRange(new DataGridViewColumn[] { MaSV, HoTen, DiemGK, DiemCK, DiemThiLan1, DiemThiLan2, DiemTongKet });
            DgvDSSV.Dock = DockStyle.Fill;
            DgvDSSV.Location = new Point(3, 26);
            DgvDSSV.Name = "DgvDSSV";
            DgvDSSV.RowHeadersWidth = 51;
            DgvDSSV.Size = new Size(1688, 699);
            DgvDSSV.TabIndex = 1;
            DgvDSSV.CellFormatting += DgvDSSV_CellFormatting;
            DgvDSSV.CellValueChanged += DgvDSSV_CellValueChanged;
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
            // DiemGK
            // 
            DiemGK.DataPropertyName = "DiemGK";
            DiemGK.HeaderText = "Điểm GK";
            DiemGK.MinimumWidth = 6;
            DiemGK.Name = "DiemGK";
            // 
            // DiemCK
            // 
            DiemCK.DataPropertyName = "DiemCK";
            DiemCK.HeaderText = "Điểm CK";
            DiemCK.MinimumWidth = 6;
            DiemCK.Name = "DiemCK";
            // 
            // DiemThiLan1
            // 
            DiemThiLan1.DataPropertyName = "DiemThiLan1";
            DiemThiLan1.HeaderText = "Thi Lại Lần 1";
            DiemThiLan1.MinimumWidth = 6;
            DiemThiLan1.Name = "DiemThiLan1";
            // 
            // DiemThiLan2
            // 
            DiemThiLan2.DataPropertyName = "DiemThiLan2";
            DiemThiLan2.HeaderText = "Thi lại lần 2";
            DiemThiLan2.MinimumWidth = 6;
            DiemThiLan2.Name = "DiemThiLan2";
            // 
            // DiemTongKet
            // 
            DiemTongKet.DataPropertyName = "DiemTongKet";
            DiemTongKet.HeaderText = "Điểm Tổng Kết";
            DiemTongKet.MinimumWidth = 6;
            DiemTongKet.Name = "DiemTongKet";
            DiemTongKet.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblSoLuongSV);
            panel2.Controls.Add(radGiam);
            panel2.Controls.Add(radTang);
            panel2.Controls.Add(txtTuKhoa);
            panel2.Controls.Add(btnXuatExcel);
            panel2.Controls.Add(btnHienTatCa);
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(btnLuuBangDiem);
            panel2.Controls.Add(cboKieuSX);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(cboLoaiTK);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnQuayLaiLop);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1694, 119);
            panel2.TabIndex = 0;
            // 
            // lblSoLuongSV
            // 
            lblSoLuongSV.AutoSize = true;
            lblSoLuongSV.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoLuongSV.ForeColor = Color.Blue;
            lblSoLuongSV.Location = new Point(33, 72);
            lblSoLuongSV.Name = "lblSoLuongSV";
            lblSoLuongSV.Size = new Size(113, 23);
            lblSoLuongSV.TabIndex = 8;
            lblSoLuongSV.Text = "Số Lượng SV";
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radGiam.Location = new Point(783, 71);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(80, 32);
            radGiam.TabIndex = 7;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            radTang.Location = new Point(701, 70);
            radTang.Name = "radTang";
            radTang.Size = new Size(76, 32);
            radTang.TabIndex = 7;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTuKhoa.Location = new Point(701, 16);
            txtTuKhoa.Multiline = true;
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Nhập từ khóa tìm kiếm...";
            txtTuKhoa.Size = new Size(514, 37);
            txtTuKhoa.TabIndex = 6;
            txtTuKhoa.TextAlign = HorizontalAlignment.Center;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnXuatExcel.Location = new Point(1527, 16);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(147, 41);
            btnXuatExcel.TabIndex = 2;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnHienTatCa.Location = new Point(1374, 16);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(147, 41);
            btnHienTatCa.TabIndex = 2;
            btnHienTatCa.Text = "Hiện Tất Cả";
            btnHienTatCa.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTimKiem.Location = new Point(1221, 16);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(147, 41);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnLuuBangDiem
            // 
            btnLuuBangDiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnLuuBangDiem.Location = new Point(1221, 65);
            btnLuuBangDiem.Name = "btnLuuBangDiem";
            btnLuuBangDiem.Size = new Size(147, 41);
            btnLuuBangDiem.TabIndex = 4;
            btnLuuBangDiem.Text = "Lưu Bảng Điểm";
            btnLuuBangDiem.UseVisualStyleBackColor = true;
            btnLuuBangDiem.Click += btnLuuBangDiem_Click;
            // 
            // cboKieuSX
            // 
            cboKieuSX.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cboKieuSX.FormattingEnabled = true;
            cboKieuSX.Location = new Point(451, 68);
            cboKieuSX.Name = "cboKieuSX";
            cboKieuSX.Size = new Size(244, 33);
            cboKieuSX.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(293, 71);
            label3.Name = "label3";
            label3.Size = new Size(89, 28);
            label3.TabIndex = 0;
            label3.Text = "Kiểu SX:";
            // 
            // cboLoaiTK
            // 
            cboLoaiTK.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cboLoaiTK.FormattingEnabled = true;
            cboLoaiTK.Location = new Point(451, 19);
            cboLoaiTK.Name = "cboLoaiTK";
            cboLoaiTK.Size = new Size(244, 33);
            cboLoaiTK.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(293, 19);
            label2.Name = "label2";
            label2.Size = new Size(152, 28);
            label2.TabIndex = 0;
            label2.Text = "Loại Tìm Kiếm:";
            // 
            // btnQuayLaiLop
            // 
            btnQuayLaiLop.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnQuayLaiLop.Location = new Point(27, 19);
            btnQuayLaiLop.Name = "btnQuayLaiLop";
            btnQuayLaiLop.Size = new Size(102, 41);
            btnQuayLaiLop.TabIndex = 5;
            btnQuayLaiLop.Text = "Quay Lại";
            btnQuayLaiLop.UseVisualStyleBackColor = true;
            btnQuayLaiLop.Click += btnQuayLaiLop_Click;
            // 
            // UC_GiangVien_ChamDiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlDanhSachSV);
            Controls.Add(flpDanhSachLop);
            Controls.Add(panel1);
            Name = "UC_GiangVien_ChamDiem";
            Size = new Size(1694, 954);
            Load += UC_GiangVien_ChamDiem_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlDanhSachSV.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvDSSV).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnTaiLai;
        private Button btnLoc;
        private TextBox txtTimKiem;
        private ComboBox cboHocKy;
        private Button btnInDanhSach;
        private FlowLayoutPanel flpDanhSachLop;
        private Panel pnlDanhSachSV;
        private DataGridView DgvDSSV;
        private Panel panel2;
        private TextBox txtTuKhoa;
        private Button btnHienTatCa;
        private Button btnTimKiem;
        private Button btnLuuBangDiem;
        private Button btnQuayLaiLop;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn DiemGK;
        private DataGridViewTextBoxColumn DiemCK;
        private DataGridViewTextBoxColumn DiemThiLan1;
        private DataGridViewTextBoxColumn DiemThiLan2;
        private DataGridViewTextBoxColumn DiemTongKet;
        private ComboBox cboLoaiTK;
        private Label label2;
        private RadioButton radGiam;
        private RadioButton radTang;
        private ComboBox cboKieuSX;
        private Label label3;
        private Button btnXuatExcel;
        private Label lblSoLuongSV;
    }
}
