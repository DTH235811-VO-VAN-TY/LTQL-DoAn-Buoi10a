namespace QuanLyDiemSV.Forms
{
    partial class FrmQuanLyYeuCauSuaDiem
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
            dgvYeuCau = new DataGridView();
            MaYC = new DataGridViewTextBoxColumn();
            TenGV = new DataGridViewTextBoxColumn();
            MonHoc = new DataGridViewTextBoxColumn();
            MaLHP = new DataGridViewTextBoxColumn();
            LyDo = new DataGridViewTextBoxColumn();
            NgayGui = new DataGridViewTextBoxColumn();
            btnDuyet = new Button();
            btnTuChoi = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvYeuCau).BeginInit();
            SuspendLayout();
            // 
            // dgvYeuCau
            // 
            dgvYeuCau.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvYeuCau.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvYeuCau.Columns.AddRange(new DataGridViewColumn[] { MaYC, TenGV, MonHoc, MaLHP, LyDo, NgayGui });
            dgvYeuCau.Location = new Point(12, 53);
            dgvYeuCau.Name = "dgvYeuCau";
            dgvYeuCau.RowHeadersWidth = 51;
            dgvYeuCau.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvYeuCau.Size = new Size(960, 480);
            dgvYeuCau.TabIndex = 2;
            // 
            // MaYC
            // 
            MaYC.DataPropertyName = "MaYC";
            MaYC.HeaderText = "Mã Đơn";
            MaYC.MinimumWidth = 6;
            MaYC.Name = "MaYC";
            // 
            // TenGV
            // 
            TenGV.DataPropertyName = "TenGV";
            TenGV.HeaderText = "Giảng Viên";
            TenGV.MinimumWidth = 6;
            TenGV.Name = "TenGV";
            // 
            // MonHoc
            // 
            MonHoc.DataPropertyName = "MonHoc";
            MonHoc.HeaderText = "Môn Học";
            MonHoc.MinimumWidth = 6;
            MonHoc.Name = "MonHoc";
            // 
            // MaLHP
            // 
            MaLHP.DataPropertyName = "MaLHP";
            MaLHP.HeaderText = "Mã LHP";
            MaLHP.MinimumWidth = 6;
            MaLHP.Name = "MaLHP";
            // 
            // LyDo
            // 
            LyDo.DataPropertyName = "LyDo";
            LyDo.HeaderText = "Lý do xin sửa";
            LyDo.MinimumWidth = 6;
            LyDo.Name = "LyDo";
            // 
            // NgayGui
            // 
            NgayGui.DataPropertyName = "NgayGui";
            NgayGui.HeaderText = "Ngày gửi";
            NgayGui.MinimumWidth = 6;
            NgayGui.Name = "NgayGui";
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = Color.MediumSeaGreen;
            btnDuyet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDuyet.ForeColor = Color.White;
            btnDuyet.Location = new Point(568, 550);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(222, 45);
            btnDuyet.TabIndex = 1;
            btnDuyet.Text = "DUYỆT (MỞ KHÓA)";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnTuChoi
            // 
            btnTuChoi.BackColor = Color.IndianRed;
            btnTuChoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTuChoi.ForeColor = Color.White;
            btnTuChoi.Location = new Point(800, 550);
            btnTuChoi.Name = "btnTuChoi";
            btnTuChoi.Size = new Size(170, 45);
            btnTuChoi.TabIndex = 0;
            btnTuChoi.Text = "TỪ CHỐI";
            btnTuChoi.UseVisualStyleBackColor = false;
            btnTuChoi.Click += btnTuChoi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(514, 32);
            label1.TabIndex = 3;
            label1.Text = "DANH SÁCH YÊU CẦU MỞ KHÓA SỬA ĐIỂM";
            // 
            // FrmQuanLyYeuCauSuaDiem
            // 
            ClientSize = new Size(984, 611);
            Controls.Add(btnTuChoi);
            Controls.Add(btnDuyet);
            Controls.Add(dgvYeuCau);
            Controls.Add(label1);
            Name = "FrmQuanLyYeuCauSuaDiem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống duyệt đơn sửa điểm - Admin";
            Load += FrmQuanLyYeuCauSuaDiem_Load;
            ((System.ComponentModel.ISupportInitialize)dgvYeuCau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGui;
    }
}
