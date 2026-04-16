using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.VariantTypes;
using QuanLyDiemSV.Data;

namespace QuanLyDiemSV.Forms
{
    public partial class FrmXepLop : Form
    {
        private int currentMaLHP;
        private string currentTenLHP;
        private QLDSVDbContext context = new QLDSVDbContext();

        // Biến lưu danh sách các sinh viên HỢP LỆ (Cùng Khoa hoặc Môn đại cương)
        private List<string> listMaSVHopLe = new List<string>();

        public FrmXepLop(int maLHP, string tenLHP)
        {
            InitializeComponent();
            currentMaLHP = maLHP;
            currentTenLHP = tenLHP;
            this.Load += FrmXepLop_Load;

            // Gắn sự kiện khi chọn Mã SV thì tự động nhảy Tên SV
            cboMaSV.SelectedIndexChanged += CboMaSV_SelectedIndexChanged;
        }

        private void FrmXepLop_Load(object sender, EventArgs e)
        {
            txtMaLHP.Text = $"{currentMaLHP} - {currentTenLHP}";
            txtMaLHP.Enabled = false;

            LoadDanhSachSinhVienHopLe(); // Nạp ComboBox Sinh Viên
            LoadDanhSachLop();           // Nạp Lưới Sinh viên đã xếp
        }

        // ===============================================
        // 1. NẠP COMBOBOX SINH VIÊN (CHỈ LẤY SV CÙNG KHOA)
        // ===============================================
        private async Task LoadDanhSachSinhVienHopLe()
        {
            try
            {
                var lhpInfo = (from l in context.LopHocPhan
                               join m in context.MonHoc on l.MaMon equals m.MaMon
                               where l.MaLHP == currentMaLHP
                               select new { m.MaKhoa }).FirstOrDefault();

                string maKhoaMonHoc = lhpInfo?.MaKhoa?.Trim();

                var querySV = from sv in context.SinhVien
                              join lop in context.LopHanhChinh on sv.MaLop equals lop.MaLop
                              join nganh in context.Nganh on lop.MaNganh equals nganh.MaNganh
                              where sv.TrangThai == 1
                              select new
                              {
                                  sv.MaSV,
                                  sv.HoTen,
                                  MaKhoaSinhVien = nganh.MaKhoa
                              };

                if (!string.IsNullOrEmpty(maKhoaMonHoc))
                {
                    querySV = querySV.Where(x => x.MaKhoaSinhVien.Trim() == maKhoaMonHoc);
                }
                var listSV = querySV.ToList().Select(x => new
                {
                    MaSV = x.MaSV,
                    HoTen = x.HoTen,
                    HienThi = $"[{x.MaSV} - {x.HoTen}]"
                }).ToList();

                listMaSVHopLe = listSV.Select(x => x.MaSV).ToList();

                cboMaSV.DataSource = listSV;
                cboMaSV.DisplayMember = "HienThi";
                cboMaSV.ValueMember = "MaSV";
                cboMaSV.SelectedIndex = -1;

                cboMaSV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMaSV.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên hợp lệ: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSV.SelectedItem != null)
            {
                dynamic sv = cboMaSV.SelectedItem;
                txtTenSV.Text = sv.HoTen;
            }
            else
            {
                txtTenSV.Text = "";
            }
        }

        // ===============================================
        // 2. TẢI VÀ TÌM KIẾM DANH SÁCH LỚP TRÊN LƯỚI
        // ===============================================
        private void LoadDanhSachLop(string tuKhoa = "")
        {
            try
            {
                var query = (from kq in context.KetQuaHocTap
                             join sv in context.SinhVien on kq.MaSV equals sv.MaSV
                             join lop in context.LopHanhChinh on sv.MaLop equals lop.MaLop
                             where kq.MaLHP == currentMaLHP
                             select new
                             {
                                 MaSV = sv.MaSV,
                                 HoTen = sv.HoTen,
                                 TenLop = lop.TenLop,
                                 GioiTinh = sv.GioiTinh
                             });

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(x => x.MaSV.ToLower().Contains(tuKhoa) ||
                                             x.HoTen.ToLower().Contains(tuKhoa) ||
                                             x.TenLop.ToLower().Contains(tuKhoa));
                }

                dgvSinhVien.DataSource = query.ToList();

                var lhp = context.LopHocPhan.FirstOrDefault(x => x.MaLHP == currentMaLHP);
                int siSoMax = lhp != null ? (int)lhp.SiSoToiDa : 0;
                int hienTai = context.KetQuaHocTap.Count(x => x.MaLHP == currentMaLHP);

                lblSiSo.Text = $"Sĩ số hiện tại: {hienTai} / {siSoMax}";
                lblSiSo.ForeColor = hienTai >= siSoMax ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            catch { }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachLop(txtTuKhoa.Text.Trim());
        }

        // ===============================================
        // 3. THÊM SINH VIÊN VÀO LỚP
        // ===============================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboMaSV.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hoặc gõ mã sinh viên hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaSV.Focus();
                return;
            }

            string maSV = cboMaSV.SelectedValue.ToString();

            // Kiểm tra sĩ số
            var lhp = context.LopHocPhan.FirstOrDefault(x => x.MaLHP == currentMaLHP);
            int siSoMax = lhp != null ? (int)lhp.SiSoToiDa : 0;
            int hienTai = context.KetQuaHocTap.Count(x => x.MaLHP == currentMaLHP);

            if (hienTai >= siSoMax)
            {
                MessageBox.Show($"Lớp học phần này đã đủ sĩ số tối đa ({siSoMax} sinh viên)!\nKhông thể xếp thêm.", "Lớp đã đầy", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Kiểm tra trùng
            var checkExist = context.KetQuaHocTap.FirstOrDefault(x => x.MaLHP == currentMaLHP && x.MaSV == maSV);
            if (checkExist != null)
            {
                MessageBox.Show("Sinh viên này đã có trong danh sách lớp rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                KetQuaHocTap kq = new KetQuaHocTap { MaSV = maSV, MaLHP = currentMaLHP };
                context.KetQuaHocTap.Add(kq);
                context.SaveChanges();

                MessageBox.Show($"Thêm sinh viên {txtTenSV.Text} vào lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboMaSV.SelectedIndex = -1;
                cboMaSV.Focus();
                LoadDanhSachLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================
        // 4. XÓA SINH VIÊN KHỎI LỚP (RÚT MÔN)
        // ===============================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;

            string maSV = dgvSinhVien.CurrentRow.Cells["MaSV"].Value.ToString();
            string hoTen = dgvSinhVien.CurrentRow.Cells["HoTen"].Value.ToString();

            var kq = context.KetQuaHocTap.FirstOrDefault(x => x.MaLHP == currentMaLHP && x.MaSV == maSV);
            if (kq != null && (kq.DiemGK != null || kq.DiemCK != null || kq.DiemTongKet != null))
            {
                MessageBox.Show($"Sinh viên {hoTen} ĐÃ CÓ ĐIỂM trong học phần này!\nKhông thể rút môn/xóa khỏi lớp.", "Cấm thao tác", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn rút sinh viên {hoTen} khỏi lớp học phần này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    context.KetQuaHocTap.Remove(kq);
                    context.SaveChanges();
                    LoadDanhSachLop();
                    MessageBox.Show("Rút môn thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // ===============================================
        // 5. IMPORT TỪ EXCEL VÀO LỚP
        // ===============================================
        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", Title = "Chọn file danh sách sinh viên" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook(ofd.FileName))
                        {
                            var worksheet = workbook.Worksheet(1);
                            var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                            int countThanhCong = 0;
                            int countLoi = 0;
                            int countSaiKhoa = 0;

                            var lhp = context.LopHocPhan.FirstOrDefault(x => x.MaLHP == currentMaLHP);
                            int siSoMax = lhp != null ? (int)lhp.SiSoToiDa : 0;
                            int hienTai = context.KetQuaHocTap.Count(x => x.MaLHP == currentMaLHP);

                            foreach (var row in rows)
                            {
                                if (hienTai >= siSoMax)
                                {
                                    MessageBox.Show($"Lớp đã đầy! Dừng import từ dòng thứ {countThanhCong + countLoi + countSaiKhoa + 2}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                                }

                                string maSV = row.Cell(1).Value.ToString().Trim();
                                if (string.IsNullOrEmpty(maSV)) continue;

                                // KIỂM TRA: Bị chặn nếu sinh viên không thuộc Khoa hợp lệ
                                if (!listMaSVHopLe.Contains(maSV))
                                {
                                    countSaiKhoa++;
                                    continue;
                                }

                                if (context.KetQuaHocTap.Any(x => x.MaLHP == currentMaLHP && x.MaSV == maSV))
                                {
                                    countLoi++; // Trùng trong lớp
                                    continue;
                                }

                                KetQuaHocTap kq = new KetQuaHocTap { MaSV = maSV, MaLHP = currentMaLHP };
                                context.KetQuaHocTap.Add(kq);
                                hienTai++;
                                countThanhCong++;
                            }

                            context.SaveChanges();
                            LoadDanhSachLop();

                            string thongBao = $"Import hoàn tất!\n- Thành công: {countThanhCong} sinh viên.\n- Bỏ qua do trùng lặp: {countLoi} sinh viên.";
                            if (countSaiKhoa > 0)
                                thongBao += $"\n- Bị chặn (Khác khoa/Không tồn tại): {countSaiKhoa} sinh viên.";

                            MessageBox.Show(thongBao, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi định dạng file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"DanhSachLop_{currentMaLHP}.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("SinhVien");
                    ws.Cell(1, 1).Value = "Mã Sinh Viên";
                    ws.Cell(1, 2).Value = "Họ Tên";

                    for (int i = 0; i < dgvSinhVien.Rows.Count; i++)
                    {
                        ws.Cell(i + 2, 1).Value = dgvSinhVien.Rows[i].Cells["MaSV"].Value?.ToString();
                        ws.Cell(i + 2, 2).Value = dgvSinhVien.Rows[i].Cells["HoTen"].Value?.ToString();
                    }

                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất file thành công!");
                }
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                string maSV = row.Cells["MaSV"].Value?.ToString();
                string hoTen = row.Cells["HoTen"].Value?.ToString();

                // Gán SelectedValue sẽ tự động hiển thị dạng [Mã SV - Họ tên] nhờ đã set DisplayMember = "HienThi"
                cboMaSV.SelectedValue = maSV;
                txtTenSV.Text = hoTen;
            }
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            LoadDanhSachLop(txtTuKhoa.Text.Trim());
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }
    }
}