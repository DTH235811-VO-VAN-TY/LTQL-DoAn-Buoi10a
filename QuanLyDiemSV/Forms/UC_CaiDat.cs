using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSV.Forms
{
    public partial class UC_CaiDat : UserControl
    {
        public UC_CaiDat()
        {
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            // Theme
            string theme = ThemeManager.CurrentTheme;
            if (theme == "Light") radLight.Checked = true;
            else if (theme == "Dark") radDark.Checked = true;
            else radDefault.Checked = true;

            // Font
            string fontName = ThemeManager.CurrentFont.FontFamily.Name;
            if (fontName == "Arial") radArial.Checked = true;
            else if (fontName == "Tahoma") radTahoma.Checked = true;
            else radSegoe.Checked = true;
        }

        private void radFont_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (rad != null && rad.Checked)
            {
                string fontName = rad.Tag.ToString();
                ThemeManager.CurrentFont = new Font(fontName, 9);
                ThemeManager.ApplyToAllOpenForms();
            }
        }

        private void radTheme_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (rad != null && rad.Checked)
            {
                ThemeManager.CurrentTheme = rad.Tag.ToString();
                ThemeManager.ApplyToAllOpenForms();
            }
        }
    }
}
