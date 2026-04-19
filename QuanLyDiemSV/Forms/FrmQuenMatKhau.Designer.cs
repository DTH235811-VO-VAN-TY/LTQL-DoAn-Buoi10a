namespace QuanLyDiemSV.Forms
{
    partial class FrmQuenMatKhau
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
            btnXacNhan = new Button();
            txtTenDangNhap = new TextBox();
            txtEmail = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            SuspendLayout();
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.MidnightBlue;
            btnXacNhan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.ForeColor = SystemColors.ButtonFace;
            btnXacNhan.Location = new Point(153, 372);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(437, 54);
            btnXacNhan.TabIndex = 10;
            btnXacNhan.Text = "XÁC NHẬN";
            btnXacNhan.UseVisualStyleBackColor = false;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(300, 240);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(290, 27);
            txtTenDangNhap.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(300, 308);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(290, 27);
            txtEmail.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(153, 308);
            label3.Name = "label3";
            label3.Size = new Size(55, 23);
            label3.TabIndex = 5;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(153, 241);
            label2.Name = "label2";
            label2.Size = new Size(116, 23);
            label2.TabIndex = 6;
            label2.Text = "Mã Sinh Viên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(153, 137);
            label1.Name = "label1";
            label1.Size = new Size(557, 41);
            label1.TabIndex = 7;
            label1.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM SINH VIÊN";
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(827, 10);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 656);
            panel2.Name = "panel2";
            panel2.Size = new Size(827, 10);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MidnightBlue;
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(817, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 646);
            panel3.TabIndex = 12;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MidnightBlue;
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 646);
            panel4.TabIndex = 12;
            // 
            // FrmQuenMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 666);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnXacNhan);
            Controls.Add(txtTenDangNhap);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmQuenMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuenMatKhau;
        private CheckBox checkHienMatKhau;
        private Button btnDangNhap;
        private TextBox txtTenDangNhap;
        private Button btnXacNhan;
        private TextBox txtEmail;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}