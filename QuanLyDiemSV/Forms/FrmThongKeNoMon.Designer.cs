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
            this.dgvNoMon = new System.Windows.Forms.DataGridView();
            this.chartNoMon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoSVRot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyLeRot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.SplitterDistance = 350;
            
            // chartNoMon
            this.chartArea1.Name = "ChartArea1";
            this.chartArea1.AxisX.MajorGrid.Enabled = false;
            this.chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            this.chartNoMon.ChartAreas.Add(this.chartArea1);
            this.chartNoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            
            // dgvNoMon
            this.dgvNoMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNoMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.MaMon, this.TenMon, this.TongSV, this.SoSVRot, this.TyLeRot
            });
            this.dgvNoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            
            // Columns
            this.MaMon.DataPropertyName = "MaMon"; this.MaMon.HeaderText = "Mã Môn";
            this.TenMon.DataPropertyName = "TenMon"; this.TenMon.HeaderText = "Tên Môn Học";
            this.TongSV.DataPropertyName = "TongSV"; this.TongSV.HeaderText = "Tổng số đăng ký";
            this.SoSVRot.DataPropertyName = "SoSVRot"; this.SoSVRot.HeaderText = "Số SV rớt (F)";
            this.TyLeRot.DataPropertyName = "TyLeRot"; this.TyLeRot.HeaderText = "Tỉ lệ rớt (%)";

            this.splitContainer.Panel1.Controls.Add(this.chartNoMon);
            this.splitContainer.Panel2.Controls.Add(this.dgvNoMon);

            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.splitContainer);
            this.Name = "FrmThongKeNoMon";
            this.Text = "Thống Kê Tỉ Lệ Nợ Môn Từng Môn Học";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmThongKeNoMon_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoMon)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
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
