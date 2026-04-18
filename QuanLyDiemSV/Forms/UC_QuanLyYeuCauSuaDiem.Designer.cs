namespace QuanLyDiemSV.Forms
{
    partial class UC_QuanLyYeuCauSuaDiem
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
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MaYC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "QUẢN LÝ YÊU CẦU SỬA ĐIỂM (DÀNH CHO ADMIN)";

            // dgvYeuCau
            this.dgvYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYeuCau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaYC, this.TenGV, this.TenMon, this.MaLHP, this.LyDo, this.NgayGui});
            this.dgvYeuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvYeuCau.Location = new System.Drawing.Point(0, 80);
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.RowTemplate.Height = 25;
            this.dgvYeuCau.Size = new System.Drawing.Size(1000, 400);

            // Column configs
            this.MaYC.DataPropertyName = "MaYC"; this.MaYC.HeaderText = "Mã Đơn";
            this.TenGV.DataPropertyName = "TenGV"; this.TenGV.HeaderText = "Giảng Viên";
            this.TenMon.DataPropertyName = "TenMon"; this.TenMon.HeaderText = "Môn Học";
            this.MaLHP.DataPropertyName = "MaLHP"; this.MaLHP.HeaderText = "Mã LHP";
            this.LyDo.DataPropertyName = "LyDo"; this.LyDo.HeaderText = "Lý do xin sửa"; this.LyDo.Width = 300;
            this.NgayGui.DataPropertyName = "NgayGui"; this.NgayGui.HeaderText = "Ngày gửi";

            // panel1
            this.panel1.Controls.Add(this.btnTuChoi);
            this.panel1.Controls.Add(this.btnDuyet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Size = new System.Drawing.Size(1000, 100);

            // btnDuyet
            this.btnDuyet.BackColor = System.Drawing.Color.Green;
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Location = new System.Drawing.Point(20, 30);
            this.btnDuyet.Size = new System.Drawing.Size(200, 40);
            this.btnDuyet.Text = "PHÊ DUYỆT (MỞ KHÓA)";
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);

            // btnTuChoi
            this.btnTuChoi.BackColor = System.Drawing.Color.Red;
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(240, 30);
            this.btnTuChoi.Size = new System.Drawing.Size(200, 40);
            this.btnTuChoi.Text = "TỪ CHỐI YÊU CẦU";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);

            // UC_QuanLyYeuCauSuaDiem
            this.Controls.Add(this.dgvYeuCau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "UC_QuanLyYeuCauSuaDiem";
            this.Size = new System.Drawing.Size(1200, 600);
            this.Load += new System.EventHandler(this.UC_QuanLyYeuCauSuaDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGui;
    }
}
