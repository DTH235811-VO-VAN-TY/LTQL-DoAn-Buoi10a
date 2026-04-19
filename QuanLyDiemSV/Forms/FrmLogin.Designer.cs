namespace QuanLyDiemSV.Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            lblQuenMatKhau = new Label();
            checkHienMatKhau = new CheckBox();
            btnDangNhap = new Button();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Segoe UI", 9F);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1148, 10);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Dock = DockStyle.Left;
            panel2.Font = new Font("Segoe UI", 9F);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(0, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 668);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MidnightBlue;
            panel3.Dock = DockStyle.Bottom;
            panel3.Font = new Font("Segoe UI", 9F);
            panel3.ForeColor = SystemColors.ControlText;
            panel3.Location = new Point(10, 668);
            panel3.Name = "panel3";
            panel3.Size = new Size(1138, 10);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MidnightBlue;
            panel4.Dock = DockStyle.Right;
            panel4.Font = new Font("Segoe UI", 9F);
            panel4.ForeColor = SystemColors.ControlText;
            panel4.Location = new Point(1138, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 658);
            panel4.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.2234039F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.7765961F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Segoe UI", 9F);
            tableLayoutPanel1.ForeColor = SystemColors.ControlText;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1128, 658);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Font = new Font("Segoe UI", 9F);
            pictureBox1.ForeColor = SystemColors.ControlText;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(459, 652);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(lblQuenMatKhau);
            panel5.Controls.Add(checkHienMatKhau);
            panel5.Controls.Add(btnDangNhap);
            panel5.Controls.Add(txtTenDangNhap);
            panel5.Controls.Add(txtMatKhau);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Fill;
            panel5.Font = new Font("Segoe UI", 9F);
            panel5.ForeColor = SystemColors.ControlText;
            panel5.Location = new Point(468, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(657, 652);
            panel5.TabIndex = 1;
            // 
            // lblQuenMatKhau
            // 
            lblQuenMatKhau.AutoSize = true;
            lblQuenMatKhau.BackColor = SystemColors.Control;
            lblQuenMatKhau.Font = new Font("Segoe UI", 9F);
            lblQuenMatKhau.ForeColor = Color.Blue;
            lblQuenMatKhau.Location = new Point(114, 339);
            lblQuenMatKhau.Name = "lblQuenMatKhau";
            lblQuenMatKhau.Size = new Size(116, 20);
            lblQuenMatKhau.TabIndex = 4;
            lblQuenMatKhau.Text = "Quên mật khẩu?";
            lblQuenMatKhau.Click += lblQuenMatKhau_Click;
            // 
            // checkHienMatKhau
            // 
            checkHienMatKhau.AutoSize = true;
            checkHienMatKhau.BackColor = SystemColors.Control;
            checkHienMatKhau.Font = new Font("Segoe UI", 9F);
            checkHienMatKhau.ForeColor = SystemColors.ControlText;
            checkHienMatKhau.Location = new Point(401, 335);
            checkHienMatKhau.Name = "checkHienMatKhau";
            checkHienMatKhau.Size = new Size(129, 24);
            checkHienMatKhau.TabIndex = 3;
            checkHienMatKhau.Text = "Hiện Mật Khẩu";
            checkHienMatKhau.UseVisualStyleBackColor = false;
            checkHienMatKhau.CheckedChanged += checkHienMatKhau_CheckedChanged;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.MidnightBlue;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangNhap.ForeColor = SystemColors.ButtonFace;
            btnDangNhap.Location = new Point(114, 374);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(416, 54);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BackColor = SystemColors.Window;
            txtTenDangNhap.Font = new Font("Segoe UI", 9F);
            txtTenDangNhap.ForeColor = SystemColors.WindowText;
            txtTenDangNhap.Location = new Point(240, 220);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(290, 27);
            txtTenDangNhap.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = SystemColors.Window;
            txtMatKhau.Font = new Font("Segoe UI", 9F);
            txtMatKhau.ForeColor = SystemColors.WindowText;
            txtMatKhau.Location = new Point(240, 288);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(290, 27);
            txtMatKhau.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(93, 292);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(93, 221);
            label2.Name = "label2";
            label2.Size = new Size(133, 23);
            label2.TabIndex = 0;
            label2.Text = "Tên đăng nhập:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(93, 117);
            label1.Name = "label1";
            label1.Size = new Size(557, 41);
            label1.TabIndex = 0;
            label1.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM SINH VIÊN";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 678);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F);
            ForeColor = SystemColors.ControlText;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += FrmLogin_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Panel panel5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDangNhap;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private CheckBox checkHienMatKhau;
        private Label lblQuenMatKhau;
    }
}