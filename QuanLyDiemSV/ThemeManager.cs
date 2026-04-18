using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSV
{
    public static class ThemeManager
    {
        public static Font CurrentFont { get; set; } = new Font("Segoe UI", 9);
        public static string CurrentTheme { get; set; } = "Default";

        // Lưu trữ màu gốc của từng control để khôi phục khi chọn Default
        private static Dictionary<Control, (Color Back, Color Fore)> _originalColors
            = new Dictionary<Control, (Color, Color)>();

        // Các panel thống kê UC_ThongKe - không đổi màu
        private static readonly HashSet<string> SkipPanelNames = new HashSet<string>
        { "panel1", "panel2", "panel3", "panel4", "panel5", "panel6" };

        public static void ApplyToAllOpenForms()
        {
            foreach (Form f in Application.OpenForms)
            {
                ApplyTheme(f);
            }
        }

        public static void ApplyTheme(Form form)
        {
            ApplyToControl(form, false);
        }

        private static void SaveOriginalColor(Control c)
        {
            if (!_originalColors.ContainsKey(c))
            {
                _originalColors[c] = (c.BackColor, c.ForeColor);
            }
        }

        private static void ApplyToControl(Control control, bool isInsideThongKe)
        {
            if (control.GetType().Name == "UC_ThongKe")
                isInsideThongKe = true;

            // Lưu màu gốc lần đầu tiên
            SaveOriginalColor(control);

            // Chỉ đổi font family, giữ nguyên size và style
            control.Font = new Font(CurrentFont.FontFamily, control.Font.Size, control.Font.Style);

            switch (CurrentTheme)
            {
                case "Dark":
                    ApplyDarkTheme(control, isInsideThongKe);
                    break;
                case "Light":
                    ApplyLightTheme(control, isInsideThongKe);
                    break;
                default: // "Default" - khôi phục màu gốc của dự án
                    RestoreOriginalTheme(control, isInsideThongKe);
                    break;
            }

            foreach (Control sub in control.Controls)
                ApplyToControl(sub, isInsideThongKe);
        }

        // ===========================
        // DARK THEME
        // ===========================
        private static void ApplyDarkTheme(Control control, bool isInsideThongKe)
        {
            // Bỏ qua panel thống kê + label bên trong nó
            if (isInsideThongKe && control is Panel p && SkipPanelNames.Contains(p.Name)) return;
            if (isInsideThongKe && control.Parent is Panel pp && SkipPanelNames.Contains(pp.Name)) return;

            if (control is Form || control is UserControl ||
                control is Panel || control is GroupBox ||
                control is TabPage || control is SplitContainer ||
                control is SplitterPanel || control is TabControl)
            {
                control.BackColor = Color.FromArgb(41, 44, 51);
                control.ForeColor = Color.White;
            }
            else if (control is Button btn)
            {
                if (IsNormalColor(btn.BackColor))
                {
                    btn.BackColor = Color.FromArgb(55, 60, 70);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(80, 85, 95);
                }
                else
                {
                    btn.ForeColor = Color.White; // Button có màu đặc biệt: giữ nền, chữ trắng
                }
            }
            else if (control is TextBox || control is RichTextBox ||
                     control is ComboBox || control is ListBox ||
                     control is DateTimePicker || control is NumericUpDown)
            {
                control.BackColor = Color.FromArgb(30, 33, 40);
                control.ForeColor = Color.White;
            }
            else if (control is DataGridView dgv)
            {
                // Lấy cảm hứng từ TraCuuDiem_Container nhưng phối tối
                dgv.EnableHeadersVisualStyles = false;
                dgv.BackgroundColor = Color.FromArgb(30, 33, 40);
                dgv.GridColor = Color.FromArgb(60, 65, 75);

                // Header
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);

                // Dòng chẵn
                dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(45, 48, 56);
                dgv.RowsDefaultCellStyle.ForeColor = Color.White;

                // Dòng lẻ (xen kẽ) - đậm hơn chút để phân biệt rõ
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(55, 58, 66);
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

                // Dòng được chọn
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 100, 180);
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (control is Label || control is RadioButton || control is CheckBox)
            {
                control.ForeColor = Color.White;
            }
        }

        // ===========================
        // LIGHT THEME
        // ===========================
        private static void ApplyLightTheme(Control control, bool isInsideThongKe)
        {
            if (isInsideThongKe && control is Panel p && SkipPanelNames.Contains(p.Name)) return;
            if (isInsideThongKe && control.Parent is Panel pp && SkipPanelNames.Contains(pp.Name)) return;

            if (control is Form || control is UserControl ||
                control is Panel || control is GroupBox ||
                control is TabPage || control is SplitContainer ||
                control is SplitterPanel || control is TabControl)
            {
                control.BackColor = Color.FromArgb(245, 246, 250);
                control.ForeColor = Color.FromArgb(33, 33, 33);
            }
            else if (control is Button btn)
            {
                if (IsNormalColor(btn.BackColor))
                {
                    btn.BackColor = Color.FromArgb(225, 230, 238);
                    btn.ForeColor = Color.FromArgb(33, 33, 33);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(190, 195, 205);
                }
                else
                {
                    btn.ForeColor = Color.White;
                }
            }
            else if (control is TextBox || control is RichTextBox ||
                     control is ComboBox || control is ListBox ||
                     control is DateTimePicker || control is NumericUpDown)
            {
                control.BackColor = Color.White;
                control.ForeColor = Color.FromArgb(33, 33, 33);
            }
            else if (control is DataGridView dgv)
            {
                dgv.EnableHeadersVisualStyles = false;
                dgv.BackgroundColor = Color.White;
                dgv.GridColor = Color.FromArgb(215, 220, 228);

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);

                dgv.RowsDefaultCellStyle.BackColor = Color.White;
                dgv.RowsDefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);

                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 248);
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);

                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 230, 241);
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else if (control is Label || control is RadioButton || control is CheckBox)
            {
                control.ForeColor = Color.FromArgb(33, 33, 33);
            }
        }

        // ===========================
        // DEFAULT - Khôi phục màu gốc của dự án
        // ===========================
        private static void RestoreOriginalTheme(Control control, bool isInsideThongKe)
        {
            if (_originalColors.TryGetValue(control, out var colors))
            {
                control.BackColor = colors.Back;
                control.ForeColor = colors.Fore;
            }

            if (control is Button btn)
            {
                btn.FlatStyle = FlatStyle.Standard;
            }
            else if (control is DataGridView dgv)
            {
                // Khôi phục lại style gốc của DataGridView
                // (Giữ nguyên style đẹp từ designer - chỉ reset lại ForeColor nếu cần)
                if (_originalColors.ContainsKey(dgv))
                {
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.RowsDefaultCellStyle.BackColor = Color.White;
                    dgv.RowsDefaultCellStyle.ForeColor = SystemColors.ControlText;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
                    dgv.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.ControlText;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 230, 241);
                    dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dgv.BackgroundColor = SystemColors.AppWorkspace;
                    dgv.GridColor = SystemColors.ControlDark;
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem màu có phải "bình thường" (theme có thể ghi đè) hay "đặc biệt" (giữ nguyên)
        /// </summary>
        private static bool IsNormalColor(Color c)
        {
            if (c == SystemColors.Control || c == SystemColors.Window ||
                c == Color.Transparent || c == Color.White ||
                c == Color.WhiteSmoke ||
                c == Color.FromArgb(245, 246, 250) ||   // Light theme bg
                c == Color.FromArgb(225, 230, 238) ||   // Light theme button
                c == Color.FromArgb(55, 60, 70) ||      // Dark theme button
                c == Color.FromArgb(41, 44, 51))        // Dark theme bg
                return true;

            return false; // Màu đặc biệt - không ghi đè
        }
    }
}
