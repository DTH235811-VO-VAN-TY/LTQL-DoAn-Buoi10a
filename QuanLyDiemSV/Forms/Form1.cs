using System;
using System.Drawing;
using System.Windows.Forms;
using GUI; // Namespace của UC_Diem
using QuanLyDiemSV.Forms; // Namespace của UC_Container

namespace QuanLyDiemSV
{
    public partial class Form1 : Form
    {
        Color normalColor = Color.FromArgb(52, 73, 94);
        Color activeColor = Color.DodgerBlue;
        private Button currentButton;

        public Form1()
        {
            InitializeComponent();
           // uC_TraCuuDiem_Container1.AddTraCuuDiemClicked += UC_TraCuuDiem_Container1_AddTraCuuDiemClicked;
            uC_TraCuu_ChiTiet1.QuayLaiTraCuulicked += (s, e) =>
            {
                uC_TraCuuDiem_Container1.BringToFront();
            };

            // --- SỬA LỖI Ở ĐÂY: KẾT NỐI 2 FORM CON ---
            // Phần này phải viết trong Constructor (sau InitializeComponent)

            // 1. Khi bấm "Nhập điểm" ở Container -> Chuyển dữ liệu sang uC_Diem1
            uC_QuanLyDiem_Container1.OnChuyenManHinhNhapDiem += (maSV) =>
            {
                // Truyền mã SV sang
                uC_Diem1.LoadThongTinSinhVien(maSV);

                // Hiển thị uC_Diem1 lên
                uC_Diem1.Visible = true;
                uC_Diem1.BringToFront();

                // Ẩn Container đi (nếu muốn)
                uC_QuanLyDiem_Container1.Visible = false;
            };

            // 2. Khi bấm "Quay lại" ở uC_Diem1 -> Hiện lại Container
            uC_Diem1.OnQuayLai += () =>
            {
                uC_QuanLyDiem_Container1.Visible = true;
                uC_QuanLyDiem_Container1.BringToFront();
                uC_Diem1.Visible = false;
            };
        }

        private void UC_TraCuuDiem_Container1_AddTraCuuDiemClicked(object? sender, EventArgs e)
        {
            //
            uC_TraCuu_ChiTiet1.BringToFront();
        }

        // --- CÁC NÚT MENU ---

        private void btnDiemSV_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // Mặc định hiện Container trước, ẩn Diem đi
            uC_QuanLyDiem_Container1.Visible = true;
            uC_QuanLyDiem_Container1.BringToFront();
            uC_Diem1.Visible = false;
        }

        // ... Các nút khác giữ nguyên code BringToFront của bạn ...
        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_SinhVien1.BringToFront();
          //  uC_SinhVien1.LoadDuLieuSinhVien();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_MonHoc1.BringToFront();
        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_GiangVien1.BringToFront();
           // uC_GiangVien1.LoadData();
        }

        private void btnLopHanhChinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_LopHanhChinh1.BringToFront();
        }

        private void btnLopHocPhan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_LopHocPhan1.BringToFront();
        }

        // --- XỬ LÝ MÀU SẮC ---
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

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_TaiKhoan1.BringToFront();
        }

        private void btnTraCuuDiem_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            uC_TraCuuDiem_Container1.BringToFront();
        }
    }
}