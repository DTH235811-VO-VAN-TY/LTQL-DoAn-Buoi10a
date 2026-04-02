namespace QuanLyDiemSV.Forms
{
    partial class FrmKhieuNaiDiem
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
            lblGiangVien = new Label();
            lblKhoa = new Label();
            lblSoTtinChi = new Label();
            lblMaMon = new Label();
            label1 = new Label();
            cboMonHoc = new ComboBox();
            lblThongTinSV = new Label();
            groupBox2 = new GroupBox();
            lblDiemTK = new Label();
            lblDiemCK = new Label();
            lblDiemQT = new Label();
            groupBox3 = new GroupBox();
            txtLyDo = new TextBox();
            btnGuiThieuNai = new Button();
            btnHuy = new Button();
            button3 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblGiangVien);
            groupBox1.Controls.Add(lblKhoa);
            groupBox1.Controls.Add(lblSoTtinChi);
            groupBox1.Controls.Add(lblMaMon);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cboMonHoc);
            groupBox1.Controls.Add(lblThongTinSV);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(944, 212);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin";
            // 
            // lblGiangVien
            // 
            lblGiangVien.AutoSize = true;
            lblGiangVien.Location = new Point(649, 143);
            lblGiangVien.Name = "lblGiangVien";
            lblGiangVien.Size = new Size(100, 23);
            lblGiangVien.TabIndex = 3;
            lblGiangVien.Text = "Giảng viên:";
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(393, 143);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(55, 23);
            lblKhoa.TabIndex = 3;
            lblKhoa.Text = "Khoa:";
            // 
            // lblSoTtinChi
            // 
            lblSoTtinChi.AutoSize = true;
            lblSoTtinChi.Location = new Point(238, 143);
            lblSoTtinChi.Name = "lblSoTtinChi";
            lblSoTtinChi.Size = new Size(96, 23);
            lblSoTtinChi.TabIndex = 3;
            lblSoTtinChi.Text = "Số Tín Chỉ:";
            // 
            // lblMaMon
            // 
            lblMaMon.AutoSize = true;
            lblMaMon.Location = new Point(54, 143);
            lblMaMon.Name = "lblMaMon";
            lblMaMon.Size = new Size(81, 23);
            lblMaMon.TabIndex = 3;
            lblMaMon.Text = "Mã Môn:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 85);
            label1.Name = "label1";
            label1.Size = new Size(97, 23);
            label1.TabIndex = 2;
            label1.Text = "Chọn môn:";
            // 
            // cboMonHoc
            // 
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(166, 77);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(304, 31);
            cboMonHoc.TabIndex = 1;
            cboMonHoc.SelectedIndexChanged += cboMonHoc_SelectedIndexChanged;
            // 
            // lblThongTinSV
            // 
            lblThongTinSV.AutoSize = true;
            lblThongTinSV.ForeColor = Color.Blue;
            lblThongTinSV.Location = new Point(54, 35);
            lblThongTinSV.Name = "lblThongTinSV";
            lblThongTinSV.Size = new Size(133, 23);
            lblThongTinSV.TabIndex = 0;
            lblThongTinSV.Text = "Mã SV - Họ Tên";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblDiemTK);
            groupBox2.Controls.Add(lblDiemCK);
            groupBox2.Controls.Add(lblDiemQT);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(10, 222);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(944, 85);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin điểm hiện tại";
            // 
            // lblDiemTK
            // 
            lblDiemTK.AutoSize = true;
            lblDiemTK.Location = new Point(576, 38);
            lblDiemTK.Name = "lblDiemTK";
            lblDiemTK.Size = new Size(53, 23);
            lblDiemTK.TabIndex = 0;
            lblDiemTK.Text = "Điểm";
            // 
            // lblDiemCK
            // 
            lblDiemCK.AutoSize = true;
            lblDiemCK.Location = new Point(315, 38);
            lblDiemCK.Name = "lblDiemCK";
            lblDiemCK.Size = new Size(53, 23);
            lblDiemCK.TabIndex = 0;
            lblDiemCK.Text = "Điểm";
            // 
            // lblDiemQT
            // 
            lblDiemQT.AutoSize = true;
            lblDiemQT.Location = new Point(54, 38);
            lblDiemQT.Name = "lblDiemQT";
            lblDiemQT.Size = new Size(53, 23);
            lblDiemQT.TabIndex = 0;
            lblDiemQT.Text = "Điểm";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtLyDo);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(10, 307);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(944, 267);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Lý do khiếu nại";
            // 
            // txtLyDo
            // 
            txtLyDo.Dock = DockStyle.Fill;
            txtLyDo.Location = new Point(3, 26);
            txtLyDo.Multiline = true;
            txtLyDo.Name = "txtLyDo";
            txtLyDo.Size = new Size(938, 238);
            txtLyDo.TabIndex = 0;
            // 
            // btnGuiThieuNai
            // 
            btnGuiThieuNai.Location = new Point(20, 599);
            btnGuiThieuNai.Name = "btnGuiThieuNai";
            btnGuiThieuNai.Size = new Size(141, 29);
            btnGuiThieuNai.TabIndex = 3;
            btnGuiThieuNai.Text = "Gửi Khiếu Nại";
            btnGuiThieuNai.UseVisualStyleBackColor = true;
            btnGuiThieuNai.Click += btnGuiThieuNai_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(176, 599);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy Bỏ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // button3
            // 
            button3.Location = new Point(794, 599);
            button3.Name = "button3";
            button3.Size = new Size(160, 29);
            button3.TabIndex = 3;
            button3.Text = "In Bảng Khiếu Nại";
            button3.UseVisualStyleBackColor = true;
            // 
            // FrmKhieuNaiDiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 661);
            Controls.Add(button3);
            Controls.Add(btnHuy);
            Controls.Add(btnGuiThieuNai);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmKhieuNaiDiem";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khiếu Nại Điểm";
            Load += FrmKhieuNaiDiem_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cboMonHoc;
        private Label lblThongTinSV;
        private Label lblMaMon;
        private Label label1;
        private GroupBox groupBox2;
        private Label lblDiemQT;
        private Label lblKhoa;
        private Label lblSoTtinChi;
        private Label lblDiemTK;
        private Label lblDiemCK;
        private GroupBox groupBox3;
        private TextBox txtLyDo;
        private Button btnGuiThieuNai;
        private Button btnHuy;
        private Button button3;
        private Label lblGiangVien;
    }
}