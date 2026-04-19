namespace QuanLyDiemSV.Forms
{
    partial class FrmThongKeNoMon
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
            dgvNoMon = new DataGridView();
            MaMon = new DataGridViewTextBoxColumn();
            TenMon = new DataGridViewTextBoxColumn();
            TongSV = new DataGridViewTextBoxColumn();
            SoSVRot = new DataGridViewTextBoxColumn();
            TyLeRot = new DataGridViewTextBoxColumn();
            splitContainer = new SplitContainer();
            chartNoMon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            ((System.ComponentModel.ISupportInitialize)dgvNoMon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartNoMon).BeginInit();
            SuspendLayout();
            // 
            // dgvNoMon
            // 
            dgvNoMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNoMon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNoMon.Columns.AddRange(new DataGridViewColumn[] { MaMon, TenMon, TongSV, SoSVRot, TyLeRot });
            dgvNoMon.Dock = DockStyle.Fill;
            dgvNoMon.Location = new Point(0, 0);
            dgvNoMon.Name = "dgvNoMon";
            dgvNoMon.RowHeadersWidth = 51;
            dgvNoMon.Size = new Size(1184, 208);
            dgvNoMon.TabIndex = 0;
            // 
            // MaMon
            // 
            MaMon.DataPropertyName = "MaMon";
            MaMon.HeaderText = "Mã Môn";
            MaMon.MinimumWidth = 6;
            MaMon.Name = "MaMon";
            // 
            // TenMon
            // 
            TenMon.DataPropertyName = "TenMon";
            TenMon.HeaderText = "Tên Môn Học";
            TenMon.MinimumWidth = 6;
            TenMon.Name = "TenMon";
            // 
            // TongSV
            // 
            TongSV.DataPropertyName = "TongSV";
            TongSV.HeaderText = "Tổng số đăng ký";
            TongSV.MinimumWidth = 6;
            TongSV.Name = "TongSV";
            // 
            // SoSVRot
            // 
            SoSVRot.DataPropertyName = "SoSVRot";
            SoSVRot.HeaderText = "Số SV rớt (F)";
            SoSVRot.MinimumWidth = 6;
            SoSVRot.Name = "SoSVRot";
            // 
            // TyLeRot
            // 
            TyLeRot.DataPropertyName = "TyLeRot";
            TyLeRot.HeaderText = "Tỉ lệ rớt (%)";
            TyLeRot.MinimumWidth = 6;
            TyLeRot.Name = "TyLeRot";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(chartNoMon);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(dgvNoMon);
            splitContainer.Size = new Size(1184, 729);
            splitContainer.SplitterDistance = 517;
            splitContainer.TabIndex = 0;
            // 
            // chartNoMon
            // 
            chartArea1.Name = "ChartArea1";
            chartNoMon.ChartAreas.Add(chartArea1);
            chartNoMon.Dock = DockStyle.Fill;
            chartNoMon.Location = new Point(0, 0);
            chartNoMon.Name = "chartNoMon";
            chartNoMon.Size = new Size(1184, 517);
            chartNoMon.TabIndex = 0;
            chartNoMon.Text = "chart1";
            // 
            // FrmThongKeNoMon
            // 
            ClientSize = new Size(1184, 729);
            Controls.Add(splitContainer);
            Name = "FrmThongKeNoMon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống Kê Tỉ Lệ Nợ Môn Từng Môn Học";
            Load += FrmThongKeNoMon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNoMon).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartNoMon).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvNoMon;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNoMon;
        private System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoSVRot;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyLeRot;
    }
}
