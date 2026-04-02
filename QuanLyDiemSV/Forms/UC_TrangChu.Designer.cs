namespace QuanLyDiemSV.Forms
{
    partial class UC_TrangChu
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
            grbThongKe = new GroupBox();
            cboHocKy = new Panel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            cboHocKy.SuspendLayout();
            SuspendLayout();
            // 
            // grbThongKe
            // 
            grbThongKe.Dock = DockStyle.Fill;
            grbThongKe.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbThongKe.Location = new Point(20, 88);
            grbThongKe.Name = "grbThongKe";
            grbThongKe.Size = new Size(1654, 846);
            grbThongKe.TabIndex = 1;
            grbThongKe.TabStop = false;
            grbThongKe.Text = "Thống Kê";
            // 
            // cboHocKy
            // 
            cboHocKy.Controls.Add(comboBox1);
            cboHocKy.Controls.Add(label1);
            cboHocKy.Dock = DockStyle.Top;
            cboHocKy.Location = new Point(20, 20);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(1654, 68);
            cboHocKy.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(117, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(273, 27);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 25);
            label1.Name = "label1";
            label1.Size = new Size(68, 23);
            label1.TabIndex = 0;
            label1.Text = "Học Kỳ:";
            // 
            // UC_TrangChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grbThongKe);
            Controls.Add(cboHocKy);
            Name = "UC_TrangChu";
            Padding = new Padding(20);
            Size = new Size(1694, 954);
            cboHocKy.ResumeLayout(false);
            cboHocKy.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox grbThongKe;
        private Panel cboHocKy;
        private ComboBox comboBox1;
        private Label label1;
    }
}
