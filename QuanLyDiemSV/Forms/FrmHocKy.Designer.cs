namespace QuanLyDiemSV.Forms
{
    partial class FrmHocKy
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
            groupBox2 = new GroupBox();
            dgvHocKy = new DataGridView();
            MaHK = new DataGridViewTextBoxColumn();
            TenHK = new DataGridViewTextBoxColumn();
            NamHocBatDau = new DataGridViewTextBoxColumn();
            NamHocKetThuc = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            txtNamKetThuc = new TextBox();
            label4 = new Label();
            txtNamBatDau = new TextBox();
            label3 = new Label();
            txtTenHK = new TextBox();
            label2 = new Label();
            txtMaHK = new TextBox();
            label1 = new Label();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            btnThem = new Button();
            comboBox1 = new ComboBox();
            label5 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvHocKy);
            groupBox2.Location = new Point(12, 265);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1179, 448);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách học kỳ";
            // 
            // dgvHocKy
            // 
            dgvHocKy.AllowUserToAddRows = false;
            dgvHocKy.AllowUserToDeleteRows = false;
            dgvHocKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHocKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHocKy.Columns.AddRange(new DataGridViewColumn[] { MaHK, TenHK, NamHocBatDau, NamHocKetThuc });
            dgvHocKy.Dock = DockStyle.Fill;
            dgvHocKy.Location = new Point(3, 23);
            dgvHocKy.MultiSelect = false;
            dgvHocKy.Name = "dgvHocKy";
            dgvHocKy.ReadOnly = true;
            dgvHocKy.RowHeadersWidth = 51;
            dgvHocKy.Size = new Size(1173, 422);
            dgvHocKy.TabIndex = 0;
            // 
            // MaHK
            // 
            MaHK.DataPropertyName = "MaHK";
            MaHK.HeaderText = "Mã HK";
            MaHK.MinimumWidth = 6;
            MaHK.Name = "MaHK";
            MaHK.ReadOnly = true;
            // 
            // TenHK
            // 
            TenHK.DataPropertyName = "TenHK";
            TenHK.HeaderText = "Tên Học Kỳ";
            TenHK.MinimumWidth = 6;
            TenHK.Name = "TenHK";
            TenHK.ReadOnly = true;
            // 
            // NamHocBatDau
            // 
            NamHocBatDau.DataPropertyName = "NamHocBatDau";
            NamHocBatDau.HeaderText = "Năm Bắt Đầu";
            NamHocBatDau.MinimumWidth = 6;
            NamHocBatDau.Name = "NamHocBatDau";
            NamHocBatDau.ReadOnly = true;
            // 
            // NamHocKetThuc
            // 
            NamHocKetThuc.DataPropertyName = "NamHocKetThuc";
            NamHocKetThuc.HeaderText = "Năm kết thúc";
            NamHocKetThuc.MinimumWidth = 6;
            NamHocKetThuc.Name = "NamHocKetThuc";
            NamHocKetThuc.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNamKetThuc);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtNamBatDau);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTenHK);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaHK);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(15, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1173, 181);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin học kỳ";
            // 
            // txtNamKetThuc
            // 
            txtNamKetThuc.Location = new Point(661, 88);
            txtNamKetThuc.Name = "txtNamKetThuc";
            txtNamKetThuc.Size = new Size(246, 30);
            txtNamKetThuc.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(527, 95);
            label4.Name = "label4";
            label4.Size = new Size(118, 23);
            label4.TabIndex = 10;
            label4.Text = "Năm kết thúc:";
            // 
            // txtNamBatDau
            // 
            txtNamBatDau.Location = new Point(215, 92);
            txtNamBatDau.Name = "txtNamBatDau";
            txtNamBatDau.Size = new Size(246, 30);
            txtNamBatDau.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 95);
            label3.Name = "label3";
            label3.Size = new Size(115, 23);
            label3.TabIndex = 10;
            label3.Text = "Năm bắt đầu:";
            // 
            // txtTenHK
            // 
            txtTenHK.Location = new Point(661, 39);
            txtTenHK.Name = "txtTenHK";
            txtTenHK.Size = new Size(246, 30);
            txtTenHK.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(528, 42);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 10;
            label2.Text = "Tên Học Kỳ:";
            // 
            // txtMaHK
            // 
            txtMaHK.Location = new Point(215, 46);
            txtMaHK.Name = "txtMaHK";
            txtMaHK.Size = new Size(246, 30);
            txtMaHK.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 46);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 10;
            label1.Text = "Mã HK:";
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThoat.Location = new Point(813, 137);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHuyBo.Location = new Point(695, 137);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 29);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Hủy bỏ ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(564, 137);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.Location = new Point(423, 137);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sữa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(272, 137);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 9;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.Location = new Point(144, 137);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(148, 217);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 220);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 9;
            label5.Text = "Kiểu Tìm Kiếm:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(1071, 205);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(62, 24);
            radioButton1.TabIndex = 10;
            radioButton1.TabStop = true;
            radioButton1.Text = "Tăng";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(1071, 235);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(65, 24);
            radioButton2.TabIndex = 10;
            radioButton2.Text = "Giảm";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(579, 220);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 11;
            button1.Text = "Tìm Kiếm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(679, 220);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 11;
            button2.Text = "Tải Lại";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(324, 219);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 27);
            textBox1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(790, 224);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 14;
            label6.Text = "Kiểu Sắp Xếp";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(903, 221);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 13;
            // 
            // FrmHocKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 725);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "FrmHocKy";
            Text = "Học Kỳ";
            Load += FrmHocKy_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHocKy).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView dgvHocKy;
        private DataGridViewTextBoxColumn MaHK;
        private DataGridViewTextBoxColumn TenHK;
        private DataGridViewTextBoxColumn NamHocBatDau;
        private DataGridViewTextBoxColumn NamHocKetThuc;
        private GroupBox groupBox1;
        private TextBox txtNamKetThuc;
        private Label label4;
        private TextBox txtNamBatDau;
        private Label label3;
        private TextBox txtTenHK;
        private Label label2;
        private TextBox txtMaHK;
        private Label label1;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private Button btnThem;
        private ComboBox comboBox1;
        private Label label5;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label6;
        private ComboBox comboBox2;
    }
}