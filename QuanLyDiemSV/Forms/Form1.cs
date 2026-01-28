using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // --- CÁC HÀM XỬ LÝ MÀU SẮC (Vừa thêm ở Bước 1) ---
        Color normalColor = Color.FromArgb(52, 73, 94);
        Color activeColor = Color.DodgerBlue; // Hoặc Color.FromArgb(41, 128, 185)
        private Button? currentButton;

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = activeColor;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = normalColor;
                }
            }
        }

        private void btnLopHocPhan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_LopHocPhan1.BringToFront();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_MonHoc1.BringToFront();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_SinhVien1.BringToFront();
        }

        private void btnDiemSV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            // uC_Diem1.BringToFront();
            uC_QuanLyDiem_Container1.BringToFront();
        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_GiangVien1.BringToFront();

        }

        private void btnLopHanhChinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_LopHanhChinh1.BringToFront();
        }
    }
}
