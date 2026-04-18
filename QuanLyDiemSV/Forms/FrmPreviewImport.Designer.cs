namespace QuanLyDiemSV.Forms
{
    partial class FrmPreviewImport
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvPreview = new DataGridView();
            panelBottom = new Panel();
            lblLoi = new Label();
            lblHopLe = new Label();
            btnHuy = new Button();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPreview
            // 
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.AllowUserToDeleteRows = false;
            dgvPreview.BackgroundColor = SystemColors.Window;
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.Dock = DockStyle.Fill;
            dgvPreview.Location = new Point(0, 0);
            dgvPreview.Name = "dgvPreview";
            dgvPreview.ReadOnly = true;
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.Size = new Size(1224, 469);
            dgvPreview.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = SystemColors.ControlLightLight;
            panelBottom.Controls.Add(lblLoi);
            panelBottom.Controls.Add(lblHopLe);
            panelBottom.Controls.Add(btnHuy);
            panelBottom.Controls.Add(btnLuu);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 469);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1224, 60);
            panelBottom.TabIndex = 1;
            // 
            // lblLoi
            // 
            lblLoi.AutoSize = true;
            lblLoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLoi.ForeColor = Color.Red;
            lblLoi.Location = new Point(250, 20);
            lblLoi.Name = "lblLoi";
            lblLoi.Size = new Size(143, 20);
            lblLoi.TabIndex = 3;
            lblLoi.Text = "Tổng số dòng lỗi: 0";
            // 
            // lblHopLe
            // 
            lblHopLe.AutoSize = true;
            lblHopLe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHopLe.ForeColor = Color.Green;
            lblHopLe.Location = new Point(20, 20);
            lblHopLe.Name = "lblHopLe";
            lblHopLe.Size = new Size(169, 20);
            lblHopLe.TabIndex = 2;
            lblHopLe.Text = "Tổng số dòng hợp lệ: 0";
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy.BackColor = Color.Crimson;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(1124, 10);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(90, 40);
            btnHuy.TabIndex = 1;
            btnHuy.Text = "X Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.BackColor = Color.ForestGreen;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(1024, 10);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(90, 40);
            btnLuu.TabIndex = 0;
            btnLuu.Text = "✔ Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // FrmPreviewImport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 529);
            Controls.Add(dgvPreview);
            Controls.Add(panelBottom);
            Name = "FrmPreviewImport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Preview Import";
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPreview;
        private Panel panelBottom;
        private Label lblLoi;
        private Label lblHopLe;
        private Button btnHuy;
        private Button btnLuu;
    }
}
