namespace QuanLyDiemSV.Forms
{
    partial class FrmBieuDoPhoDiem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmBieuDoPhoDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmBieuDoPhoDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân tích phổ điểm";
            this.Load += new System.EventHandler(this.FrmBieuDoPhoDiem_Load);
            this.ResumeLayout(false);
        }
    }
}
