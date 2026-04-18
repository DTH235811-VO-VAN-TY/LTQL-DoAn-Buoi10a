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
    public partial class FrmPreviewImport : Form
    {
        public DataTable DataToImport { get; private set; }

        public FrmPreviewImport(DataTable dt)
        {
            InitializeComponent();
            DataToImport = dt;
            dgvPreview.DataSource = DataToImport;
            
            int loiCount = dt.AsEnumerable().Count(r => !string.IsNullOrEmpty(r.Field<string>("GhiChu")));
            int hopLeCount = dt.Rows.Count - loiCount;

            lblHopLe.Text = $"Tổng số dòng hợp lệ: {hopLeCount}";
            lblLoi.Text = $"Tổng số dòng lỗi: {loiCount}";

            // Tự động chỉnh cột cho đẹp
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (dgvPreview.Columns.Contains("GhiChu"))
            {
                dgvPreview.Columns["GhiChu"].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
