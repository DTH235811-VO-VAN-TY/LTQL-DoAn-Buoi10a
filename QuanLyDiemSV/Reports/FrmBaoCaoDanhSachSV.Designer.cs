namespace QuanLyDiemSV.Reports
{
    partial class FrmBaoCaoDanhSachSV
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1 = new Panel();
            btnLoc = new Button();
            btnReset = new Button();
            radGiam = new RadioButton();
            radTang = new RadioButton();
            cboLoaiSX = new ComboBox();
            label3 = new Label();
            cboLop = new ComboBox();
            label2 = new Label();
            cboHocKy = new ComboBox();
            label4 = new Label();
            cboKhoa = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 139);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1317, 637);
            reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLoc);
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(radGiam);
            panel1.Controls.Add(radTang);
            panel1.Controls.Add(cboLoaiSX);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cboLop);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cboHocKy);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cboKhoa);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1317, 139);
            panel1.TabIndex = 1;
            // 
            // btnLoc
            // 
            btnLoc.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnLoc.Location = new Point(899, 83);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(160, 40);
            btnLoc.TabIndex = 17;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = true;
            btnLoc.Click += btnLoc_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnReset.Location = new Point(1083, 83);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(160, 40);
            btnReset.TabIndex = 17;
            btnReset.Text = "Tải lại";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // radGiam
            // 
            radGiam.AutoSize = true;
            radGiam.Location = new Point(1178, 40);
            radGiam.Name = "radGiam";
            radGiam.Size = new Size(65, 24);
            radGiam.TabIndex = 15;
            radGiam.Text = "Giảm";
            radGiam.UseVisualStyleBackColor = true;
            // 
            // radTang
            // 
            radTang.AutoSize = true;
            radTang.Checked = true;
            radTang.Location = new Point(1101, 40);
            radTang.Name = "radTang";
            radTang.Size = new Size(62, 24);
            radTang.TabIndex = 16;
            radTang.TabStop = true;
            radTang.Text = "Tăng";
            radTang.UseVisualStyleBackColor = true;
            // 
            // cboLoaiSX
            // 
            cboLoaiSX.FormattingEnabled = true;
            cboLoaiSX.Items.AddRange(new object[] { "Mã Số SV", "Điểm số", "Họ Tên" });
            cboLoaiSX.Location = new Point(951, 36);
            cboLoaiSX.Name = "cboLoaiSX";
            cboLoaiSX.Size = new Size(143, 28);
            cboLoaiSX.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(854, 40);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 13;
            label3.Text = "Sắp xếp:";
            // 
            // cboLop
            // 
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(503, 36);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(328, 28);
            cboLop.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(444, 39);
            label2.Name = "label2";
            label2.Size = new Size(42, 23);
            label2.TabIndex = 11;
            label2.Text = "Lớp:";
            // 
            // cboHocKy
            // 
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(130, 83);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(294, 28);
            cboHocKy.TabIndex = 10;
            cboHocKy.SelectedIndexChanged += cboHocKy_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(33, 86);
            label4.Name = "label4";
            label4.Size = new Size(68, 23);
            label4.TabIndex = 9;
            label4.Text = "Học Kỳ:";
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(130, 36);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(294, 28);
            cboKhoa.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(33, 39);
            label1.Name = "label1";
            label1.Size = new Size(53, 23);
            label1.TabIndex = 9;
            label1.Text = "Khoa:";
            // 
            // FrmBaoCaoDanhSachSV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 776);
            Controls.Add(reportViewer1);
            Controls.Add(panel1);
            Name = "FrmBaoCaoDanhSachSV";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Báo Cáo Danh Sách SV";
            Load += FrmBaoCaoDanhSachSV_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Panel panel1;
        private RadioButton radGiam;
        private RadioButton radTang;
        private ComboBox cboLoaiSX;
        private Label label3;
        private ComboBox cboLop;
        private Label label2;
        private ComboBox cboKhoa;
        private Label label1;
        private Button btnLoc;
        private Button btnReset;
        private ComboBox cboHocKy;
        private Label label4;
    }
}