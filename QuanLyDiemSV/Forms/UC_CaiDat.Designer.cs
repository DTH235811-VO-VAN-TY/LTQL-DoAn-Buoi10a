namespace QuanLyDiemSV.Forms
{
    partial class UC_CaiDat
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            grpFont = new GroupBox();
            radTahoma = new RadioButton();
            radArial = new RadioButton();
            radSegoe = new RadioButton();
            grpTheme = new GroupBox();
            radDark = new RadioButton();
            radLight = new RadioButton();
            radDefault = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            grpFont.SuspendLayout();
            grpTheme.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(41, 128, 185);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(328, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "⚙ Cài Đặt Font Và Theme";
            // 
            // grpFont
            // 
            grpFont.Controls.Add(radTahoma);
            grpFont.Controls.Add(radArial);
            grpFont.Controls.Add(radSegoe);
            grpFont.Location = new Point(30, 120);
            grpFont.Name = "grpFont";
            grpFont.Size = new Size(600, 150);
            grpFont.TabIndex = 1;
            grpFont.TabStop = false;
            grpFont.Text = "Font chữ hệ thống";
            // 
            // radTahoma
            // 
            radTahoma.AutoSize = true;
            radTahoma.Location = new Point(30, 100);
            radTahoma.Name = "radTahoma";
            radTahoma.Size = new Size(82, 24);
            radTahoma.TabIndex = 2;
            radTahoma.TabStop = true;
            radTahoma.Tag = "Tahoma";
            radTahoma.Text = "Tahoma";
            radTahoma.UseVisualStyleBackColor = true;
            radTahoma.CheckedChanged += radFont_CheckedChanged;
            // 
            // radArial
            // 
            radArial.AutoSize = true;
            radArial.Location = new Point(30, 65);
            radArial.Name = "radArial";
            radArial.Size = new Size(61, 24);
            radArial.TabIndex = 1;
            radArial.TabStop = true;
            radArial.Tag = "Arial";
            radArial.Text = "Arial";
            radArial.UseVisualStyleBackColor = true;
            radArial.CheckedChanged += radFont_CheckedChanged;
            // 
            // radSegoe
            // 
            radSegoe.AutoSize = true;
            radSegoe.Location = new Point(30, 30);
            radSegoe.Name = "radSegoe";
            radSegoe.Size = new Size(89, 24);
            radSegoe.TabIndex = 0;
            radSegoe.TabStop = true;
            radSegoe.Tag = "Segoe UI";
            radSegoe.Text = "Segoe UI";
            radSegoe.UseVisualStyleBackColor = true;
            radSegoe.CheckedChanged += radFont_CheckedChanged;
            // 
            // grpTheme
            // 
            grpTheme.Controls.Add(radDark);
            grpTheme.Controls.Add(radLight);
            grpTheme.Controls.Add(radDefault);
            grpTheme.Location = new Point(30, 330);
            grpTheme.Name = "grpTheme";
            grpTheme.Size = new Size(600, 150);
            grpTheme.TabIndex = 2;
            grpTheme.TabStop = false;
            grpTheme.Text = "Theme hệ thống";
            // 
            // radDark
            // 
            radDark.AutoSize = true;
            radDark.Location = new Point(30, 100);
            radDark.Name = "radDark";
            radDark.Size = new Size(50, 24);
            radDark.TabIndex = 2;
            radDark.TabStop = true;
            radDark.Tag = "Dark";
            radDark.Text = "Tối";
            radDark.UseVisualStyleBackColor = true;
            radDark.CheckedChanged += radTheme_CheckedChanged;
            // 
            // radLight
            // 
            radLight.AutoSize = true;
            radLight.Location = new Point(30, 65);
            radLight.Name = "radLight";
            radLight.Size = new Size(63, 24);
            radLight.TabIndex = 1;
            radLight.TabStop = true;
            radLight.Tag = "Light";
            radLight.Text = "Sáng";
            radLight.UseVisualStyleBackColor = true;
            radLight.CheckedChanged += radTheme_CheckedChanged;
            // 
            // radDefault
            // 
            radDefault.AutoSize = true;
            radDefault.Location = new Point(30, 30);
            radDefault.Name = "radDefault";
            radDefault.Size = new Size(92, 24);
            radDefault.TabIndex = 0;
            radDefault.TabStop = true;
            radDefault.Tag = "Default";
            radDefault.Text = "Mặc định";
            radDefault.UseVisualStyleBackColor = true;
            radDefault.CheckedChanged += radTheme_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(30, 80);
            label1.Name = "label1";
            label1.Size = new Size(411, 25);
            label1.TabIndex = 3;
            label1.Text = "Đổi toàn bộ font chữ trên giao diện của bạn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(30, 290);
            label2.Name = "label2";
            label2.Size = new Size(424, 25);
            label2.TabIndex = 4;
            label2.Text = "Đổi toàn bộ theme trên giao diện phần mềm";
            // 
            // UC_CaiDat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(grpTheme);
            Controls.Add(grpFont);
            Controls.Add(labelTitle);
            Name = "UC_CaiDat";
            Size = new Size(800, 600);
            grpFont.ResumeLayout(false);
            grpFont.PerformLayout();
            grpTheme.ResumeLayout(false);
            grpTheme.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private GroupBox grpFont;
        private RadioButton radTahoma;
        private RadioButton radArial;
        private RadioButton radSegoe;
        private GroupBox grpTheme;
        private RadioButton radDark;
        private RadioButton radLight;
        private RadioButton radDefault;
        private Label label1;
        private Label label2;
    }
}
