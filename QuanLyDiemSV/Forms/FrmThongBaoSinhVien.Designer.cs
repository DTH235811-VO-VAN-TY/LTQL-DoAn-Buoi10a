namespace QuanLyDiemSV.Forms
{
    partial class FrmThongBaoSinhVien
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
            groupBox1 = new GroupBox();
            dgvThongBao = new DataGridView();
            groupBox2 = new GroupBox();
            rtbNoiDungChiTiet = new RichTextBox();
            MaThongBao = new DataGridViewTextBoxColumn();
            TieuDe = new DataGridViewTextBoxColumn();
            MaNguoiGui = new DataGridViewTextBoxColumn();
            MaNguoiNhan = new DataGridViewTextBoxColumn();
            NoiDung = new DataGridViewTextBoxColumn();
            NgayGui = new DataGridViewTextBoxColumn();
            DaDoc = new DataGridViewTextBoxColumn();
            ThamChieuID = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvThongBao);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1186, 353);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Báo";
            // 
            // dgvThongBao
            // 
            dgvThongBao.AllowUserToAddRows = false;
            dgvThongBao.AllowUserToDeleteRows = false;
            dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongBao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongBao.Columns.AddRange(new DataGridViewColumn[] { MaThongBao, TieuDe, MaNguoiGui, MaNguoiNhan, NoiDung, NgayGui, DaDoc, ThamChieuID });
            dgvThongBao.Dock = DockStyle.Fill;
            dgvThongBao.Location = new Point(3, 26);
            dgvThongBao.Name = "dgvThongBao";
            dgvThongBao.RowHeadersWidth = 51;
            dgvThongBao.Size = new Size(1180, 324);
            dgvThongBao.TabIndex = 0;
            dgvThongBao.CellClick += dgvThongBao_CellClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtbNoiDungChiTiet);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(10, 363);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1186, 369);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nội dung";
            // 
            // rtbNoiDungChiTiet
            // 
            rtbNoiDungChiTiet.Dock = DockStyle.Fill;
            rtbNoiDungChiTiet.Location = new Point(3, 26);
            rtbNoiDungChiTiet.Name = "rtbNoiDungChiTiet";
            rtbNoiDungChiTiet.Size = new Size(1180, 340);
            rtbNoiDungChiTiet.TabIndex = 0;
            rtbNoiDungChiTiet.Text = "";
            // 
            // MaThongBao
            // 
            MaThongBao.DataPropertyName = "MaThongBao";
            MaThongBao.HeaderText = "Mã TB";
            MaThongBao.MinimumWidth = 6;
            MaThongBao.Name = "MaThongBao";
            MaThongBao.ReadOnly = true;
            // 
            // TieuDe
            // 
            TieuDe.DataPropertyName = "TieuDe";
            TieuDe.HeaderText = "Tiêu Đề";
            TieuDe.MinimumWidth = 6;
            TieuDe.Name = "TieuDe";
            TieuDe.ReadOnly = true;
            // 
            // MaNguoiGui
            // 
            MaNguoiGui.DataPropertyName = "NguoiGui";
            MaNguoiGui.HeaderText = "Người Gửi";
            MaNguoiGui.MinimumWidth = 6;
            MaNguoiGui.Name = "MaNguoiGui";
            MaNguoiGui.ReadOnly = true;
            // 
            // MaNguoiNhan
            // 
            MaNguoiNhan.DataPropertyName = "NguoiNhan";
            MaNguoiNhan.HeaderText = "Người Nhận";
            MaNguoiNhan.MinimumWidth = 6;
            MaNguoiNhan.Name = "MaNguoiNhan";
            MaNguoiNhan.ReadOnly = true;
            // 
            // NoiDung
            // 
            NoiDung.DataPropertyName = "NoiDung";
            NoiDung.HeaderText = "Nội dung";
            NoiDung.MinimumWidth = 6;
            NoiDung.Name = "NoiDung";
            NoiDung.ReadOnly = true;
            // 
            // NgayGui
            // 
            NgayGui.DataPropertyName = "NgayGui";
            NgayGui.HeaderText = "Ngày Gửi";
            NgayGui.MinimumWidth = 6;
            NgayGui.Name = "NgayGui";
            NgayGui.ReadOnly = true;
            // 
            // DaDoc
            // 
            DaDoc.DataPropertyName = "DaDoc";
            DaDoc.HeaderText = "Trạng Thái";
            DaDoc.MinimumWidth = 6;
            DaDoc.Name = "DaDoc";
            DaDoc.ReadOnly = true;
            // 
            // ThamChieuID
            // 
            ThamChieuID.DataPropertyName = "ThamChieuID";
            ThamChieuID.HeaderText = "Thám Chiếu ID";
            ThamChieuID.MinimumWidth = 6;
            ThamChieuID.Name = "ThamChieuID";
            ThamChieuID.ReadOnly = true;
            // 
            // FrmThongBaoSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 742);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmThongBaoSinhVien";
            Padding = new Padding(10);
            Text = "Thông Báo";
            Load += FrmThongBaoSinhVien_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvThongBao;
        private GroupBox groupBox2;
        private RichTextBox rtbNoiDungChiTiet;
        private DataGridViewTextBoxColumn MaThongBao;
        private DataGridViewTextBoxColumn TieuDe;
        private DataGridViewTextBoxColumn MaNguoiGui;
        private DataGridViewTextBoxColumn MaNguoiNhan;
        private DataGridViewTextBoxColumn NoiDung;
        private DataGridViewTextBoxColumn NgayGui;
        private DataGridViewTextBoxColumn DaDoc;
        private DataGridViewTextBoxColumn ThamChieuID;
    }
}