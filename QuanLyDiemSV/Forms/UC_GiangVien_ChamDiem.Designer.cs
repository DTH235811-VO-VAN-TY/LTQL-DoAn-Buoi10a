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
            button1 = new Button();
            btnTaiLai = new Button();
            btnLoc = new Button();
            txtTimKiem = new TextBox();
            cboHocKy = new ComboBox();
            label1 = new Label();
            flpDanhSachLop = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
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
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button1.Location = new Point(1230, 49);
            button1.Name = "button1";
            button1.Size = new Size(217, 35);
            button1.TabIndex = 3;
            button1.Text = "In Danh Sách";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnTaiLai_Click;
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
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(439, 56);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(396, 27);
            txtTimKiem.TabIndex = 2;
            // 
            // cboHocKy
            // 
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(153, 56);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(244, 28);
            cboHocKy.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 56);
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
            // UC_GiangVien_ChamDiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpDanhSachLop);
            Controls.Add(panel1);
            Name = "UC_GiangVien_ChamDiem";
            Size = new Size(1694, 954);
            Load += UC_GiangVien_ChamDiem_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnTaiLai;
        private Button btnLoc;
        private TextBox txtTimKiem;
        private ComboBox cboHocKy;
        private Button button1;
        private FlowLayoutPanel flpDanhSachLop;
    }
}
