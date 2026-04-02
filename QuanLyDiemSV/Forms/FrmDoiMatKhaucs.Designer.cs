namespace QuanLyDiemSV.Forms
{
    partial class FrmDoiMatKhaucs
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
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            txtMatKhauCu = new TextBox();
            label3 = new Label();
            txtMatKhauMoi = new TextBox();
            label4 = new Label();
            txtXacNhanMatKhau = new TextBox();
            groupBox1 = new GroupBox();
            btnLuu = new Button();
            btnHuy = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 61);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Enabled = false;
            txtTenDangNhap.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTenDangNhap.Location = new Point(219, 51);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(350, 30);
            txtTenDangNhap.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 117);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 0;
            label2.Text = "Mật Khẩu Củ:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMatKhauCu.Location = new Point(219, 107);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(350, 30);
            txtMatKhauCu.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 181);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 0;
            label3.Text = "Mật Khẩu Mới:";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMatKhauMoi.Location = new Point(219, 171);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(350, 30);
            txtMatKhauMoi.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 236);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 0;
            label4.Text = "Xác Nhận Mật Khẩu:";
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtXacNhanMatKhau.Location = new Point(209, 226);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(350, 30);
            txtXacNhanMatKhau.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtXacNhanMatKhau);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(646, 301);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin tài khoản";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(68, 328);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(175, 41);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(394, 328);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(175, 41);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // FrmDoiMatKhaucs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 479);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(label4);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label3);
            Controls.Add(txtMatKhauCu);
            Controls.Add(label2);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "FrmDoiMatKhaucs";
            Padding = new Padding(10);
            Text = "Đổi Mật Khẩu";
            Load += FrmDoiMatKhaucs_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenDangNhap;
        private Label label2;
        private TextBox txtMatKhauCu;
        private Label label3;
        private TextBox txtMatKhauMoi;
        private Label label4;
        private TextBox txtXacNhanMatKhau;
        private GroupBox groupBox1;
        private Button btnLuu;
        private Button btnHuy;
    }
}