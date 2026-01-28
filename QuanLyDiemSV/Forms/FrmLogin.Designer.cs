namespace GUI
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
           
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
          
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(817, 9);
            label1.Name = "label1";
            label1.Size = new Size(37, 39);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDark;
            label2.Location = new Point(493, 67);
            label2.Name = "label2";
            label2.Size = new Size(200, 41);
            label2.TabIndex = 1;
            label2.Text = "ĐĂNG NHẬP";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 502);
            panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Desktop;
            textBox1.ForeColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(366, 152);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(444, 27);
            textBox1.TabIndex = 3;
            textBox1.Text = "Tên đăng nhập";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Desktop;
            textBox2.ForeColor = SystemColors.ScrollBar;
            textBox2.Location = new Point(366, 211);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(444, 27);
            textBox2.TabIndex = 3;
            textBox2.Text = "Mật khẩu";
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(370, 293);
            button1.Name = "button1";
            button1.Size = new Size(440, 54);
            button1.TabIndex = 4;
            button1.Text = "Đăng Nhập";
            button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(866, 502);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel1;
        private Label label2;
        private Button button1;
    }
}
