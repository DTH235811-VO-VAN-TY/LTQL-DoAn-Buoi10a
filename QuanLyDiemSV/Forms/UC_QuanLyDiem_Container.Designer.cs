namespace QuanLyDiemSV.Forms
{
    partial class UC_QuanLyDiem_Container
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
            groupBox1 = new GroupBox();
            txtAdTuKhoa_SV = new TextBox();
            label11 = new Label();
            label12 = new Label();
            cboAdTimKiem_SV = new ComboBox();
            btnAdShowAll_SV = new Button();
            btnAdTimKiem_SV = new Button();
            cboKhoa = new ComboBox();
            label1 = new Label();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            radioButton1 = new RadioButton();
            panel3 = new Panel();
            dgvDanhSachSV = new DataGridView();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1694, 132);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtAdTuKhoa_SV);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(cboAdTimKiem_SV);
            groupBox1.Controls.Add(btnAdShowAll_SV);
            groupBox1.Controls.Add(btnAdTimKiem_SV);
            groupBox1.Controls.Add(cboKhoa);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1694, 132);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm Kiếm";
            // 
            // txtAdTuKhoa_SV
            // 
            txtAdTuKhoa_SV.Location = new Point(817, 59);
            txtAdTuKhoa_SV.Margin = new Padding(3, 4, 3, 4);
            txtAdTuKhoa_SV.Name = "txtAdTuKhoa_SV";
            txtAdTuKhoa_SV.Size = new Size(400, 30);
            txtAdTuKhoa_SV.TabIndex = 78;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(374, 61);
            label11.Name = "label11";
            label11.Size = new Size(130, 23);
            label11.TabIndex = 81;
            label11.Text = "Loại Tìm Kiếm:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(730, 61);
            label12.Name = "label12";
            label12.Size = new Size(81, 23);
            label12.TabIndex = 82;
            label12.Text = "Từ Khóa:";
            // 
            // cboAdTimKiem_SV
            // 
            cboAdTimKiem_SV.FormattingEnabled = true;
            cboAdTimKiem_SV.Location = new Point(505, 58);
            cboAdTimKiem_SV.Margin = new Padding(3, 4, 3, 4);
            cboAdTimKiem_SV.Name = "cboAdTimKiem_SV";
            cboAdTimKiem_SV.Size = new Size(200, 31);
            cboAdTimKiem_SV.TabIndex = 77;
            // 
            // btnAdShowAll_SV
            // 
            btnAdShowAll_SV.BackColor = Color.White;
            btnAdShowAll_SV.FlatStyle = FlatStyle.Flat;
            btnAdShowAll_SV.Location = new Point(1436, 59);
            btnAdShowAll_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdShowAll_SV.Name = "btnAdShowAll_SV";
            btnAdShowAll_SV.Size = new Size(120, 40);
            btnAdShowAll_SV.TabIndex = 80;
            btnAdShowAll_SV.Text = "Hiện tất cả";
            btnAdShowAll_SV.UseVisualStyleBackColor = false;
            // 
            // btnAdTimKiem_SV
            // 
            btnAdTimKiem_SV.BackColor = Color.White;
            btnAdTimKiem_SV.FlatStyle = FlatStyle.Flat;
            btnAdTimKiem_SV.Location = new Point(1266, 58);
            btnAdTimKiem_SV.Margin = new Padding(3, 4, 3, 4);
            btnAdTimKiem_SV.Name = "btnAdTimKiem_SV";
            btnAdTimKiem_SV.Size = new Size(120, 40);
            btnAdTimKiem_SV.TabIndex = 79;
            btnAdTimKiem_SV.Text = "Tìm Kiếm";
            btnAdTimKiem_SV.UseVisualStyleBackColor = false;
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(103, 58);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(249, 31);
            cboKhoa.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 56);
            label1.Name = "label1";
            label1.Size = new Size(55, 23);
            label1.TabIndex = 0;
            label1.Text = "Khoa:";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Controls.Add(groupBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 132);
            panel2.Name = "panel2";
            panel2.Size = new Size(1694, 75);
            panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1694, 75);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sắp xếp theo";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(51, 30);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(215, 27);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Sắp xếp theo họ và tên";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvDanhSachSV);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 207);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10, 0, 10, 0);
            panel3.Size = new Size(1694, 747);
            panel3.TabIndex = 2;
            // 
            // dgvDanhSachSV
            // 
            dgvDanhSachSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSV.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDanhSachSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSV.Dock = DockStyle.Fill;
            dgvDanhSachSV.Location = new Point(10, 0);
            dgvDanhSachSV.Name = "dgvDanhSachSV";
            dgvDanhSachSV.RowHeadersWidth = 51;
            dgvDanhSachSV.Size = new Size(1674, 747);
            dgvDanhSachSV.TabIndex = 0;
            // 
            // UC_QuanLyDiem_Container
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_QuanLyDiem_Container";
            Size = new Size(1694, 954);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private ComboBox cboKhoa;
        private Label label1;
        private TextBox txtAdTuKhoa_SV;
        private Label label11;
        private Label label12;
        private ComboBox cboAdTimKiem_SV;
        private Button btnAdShowAll_SV;
        private Button btnAdTimKiem_SV;
        private Panel panel2;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private Panel panel3;
        private DataGridView dgvDanhSachSV;
    }
}
