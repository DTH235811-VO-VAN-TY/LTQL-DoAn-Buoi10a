using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyDiemSV.Data; // Đảm bảo namespace này đúng với project của bạn (chứa DbContext và Models)

namespace GUI
{
    public partial class UC_MonHoc : UserControl
    {
        // Khởi tạo Context
        QLDSVDbContext context = new QLDSVDbContext();

        // BindingSource cho Môn học
        BindingSource bsMonHoc = new BindingSource();

        // Biến cờ kiểm tra trạng thái Thêm/Sửa
        bool xuLyThem = false;

        public UC_MonHoc()
        {
            InitializeComponent();
            this.Load += UC_MonHoc_Load;
        }

        private void UC_MonHoc_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadDuLieuKhoa();
            LoadDuLieuMonHoc();
            //LoadCboMonTienQuyetTheoKhoa(); // Tải danh sách môn vào ComboBox chọn tiên quyết

            txtTuKhoa.Enter += (s, ev) =>
            {
                if (txtTuKhoa.Text == "Vui lòng nhập tên môn")
                {
                    txtTuKhoa.Text = "";
                    txtTuKhoa.ForeColor = System.Drawing.Color.Black; // Đổi lại màu đen khi gõ
                }
            };

            txtTuKhoa.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtTuKhoa.Text))
                {
                    txtTuKhoa.Text = "Vui lòng nhập tên môn";
                    txtTuKhoa.ForeColor = System.Drawing.Color.Gray; // Mờ lại khi để trống
                }
            };
        }
        private void LocVaTimKiem()
        {
            try
            {
                var query = context.MonHoc.AsQueryable();

                // 1. Lọc theo Khoa (nếu có chọn khoa)
                if (cboLoc.SelectedValue != null)
                {
                    string maKhoa = cboLoc.SelectedValue.ToString();
                    query = query.Where(m => m.MaKhoa == maKhoa);
                }

                // 2. Tìm kiếm theo Tên môn học
                string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

                // Bỏ qua nếu từ khóa rỗng hoặc đang là dòng chữ mặc định
                if (!string.IsNullOrEmpty(tuKhoa) && tuKhoa != "vui lòng nhập tên môn")
                {
                    query = query.Where(m => m.TenMon.ToLower().Contains(tuKhoa));
                }

                // 3. Gán dữ liệu đã lọc vào BindingSource
                bsMonHoc.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        #region 1. HÀM HỖ TRỢ & LOAD DỮ LIỆU

        private void BatTatChucNang(bool giaTri)
        {
            // Các nút thao tác chính
            btnLuu.Enabled = giaTri;
            btnLamLai.Enabled = giaTri;

            // Các ô nhập liệu
            txtMaMon.Enabled = giaTri;
            txtTenMon.Enabled = giaTri;
            txtSTC.Enabled = giaTri;
            txtSoTietLT.Enabled = giaTri;
            txtSoTietTH.Enabled = giaTri;
            cboKhoa.Enabled = giaTri;

            // Các nút chức năng
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;

            // Phần môn tiên quyết chỉ cho phép thao tác khi KHÔNG ở chế độ Thêm/Sửa môn học
            // Để tránh lỗi logic dữ liệu chưa lưu
            groupBox3.Enabled = !giaTri;
            groupBox4.Enabled = !giaTri;
        }

        private void LoadDuLieuKhoa()
        {
            var listKhoa = context.Khoa.ToList();

            // 1. Fill cho ComboBox Lọc (comboBox1 ở panel trên cùng)
            cboLoc.DataSource = new List<Khoa>(listKhoa); // Tạo bản sao list để tránh conflict binding
            cboLoc.DisplayMember = "TenKhoa";
            cboLoc.ValueMember = "MaKhoa";
            cboLoc.SelectedIndex = -1; // Mặc định không chọn gì

            // 2. Fill cho ComboBox Chi tiết (cboKhoa ở GroupBox nhập liệu)
            cboKhoa.DataSource = listKhoa;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
        }

        private void LoadDuLieuMonHoc()
        {
            try
            {
                // Tắt tự tạo cột để grid đẹp hơn (nếu bạn đã design cột)
                dgvDSMon.AutoGenerateColumns = false;

                // Lấy danh sách môn học
                var listMon = context.MonHoc.ToList();

                // Gán vào BindingSource
                bsMonHoc.DataSource = listMon;

                // Xóa binding cũ
                txtMaMon.DataBindings.Clear();
                txtTenMon.DataBindings.Clear();
                txtSTC.DataBindings.Clear();
                txtSoTietLT.DataBindings.Clear();
                txtSoTietTH.DataBindings.Clear();
                cboKhoa.DataBindings.Clear();

                // Binding dữ liệu
                txtMaMon.DataBindings.Add("Text", bsMonHoc, "MaMon", true, DataSourceUpdateMode.Never);
                txtTenMon.DataBindings.Add("Text", bsMonHoc, "TenMon", true, DataSourceUpdateMode.Never);
                txtSTC.DataBindings.Add("Text", bsMonHoc, "SoTinChi", true, DataSourceUpdateMode.Never);
                txtSoTietLT.DataBindings.Add("Text", bsMonHoc, "SoTietLyThuyet", true, DataSourceUpdateMode.Never);
                txtSoTietTH.DataBindings.Add("Text", bsMonHoc, "SoTietThucHanh", true, DataSourceUpdateMode.Never);

                // Binding ComboBox Khoa (Quan trọng)
                cboKhoa.DataBindings.Add("SelectedValue", bsMonHoc, "MaKhoa", true, DataSourceUpdateMode.Never);

                // Gán BindingSource vào Grid
                dgvDSMon.DataSource = bsMonHoc;

                // Đăng ký sự kiện khi dòng chọn thay đổi -> Load môn tiên quyết tương ứng
                bsMonHoc.CurrentChanged += BsMonHoc_CurrentChanged;

                // Gọi lần đầu để load tiên quyết cho dòng đầu tiên
                BsMonHoc_CurrentChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện: Khi chọn Môn học khác -> Load lại Môn tiên quyết & Label
        private void BsMonHoc_CurrentChanged(object sender, EventArgs e)
        {
            if (bsMonHoc.Current == null) return;

            // Lấy đối tượng MonHoc đang chọn
            var curMon = (MonHoc)bsMonHoc.Current;

            // Hiển thị lên Label ở GroupBox Tiên quyết
            lblMaMon.Text = curMon.MaMon;
            lblTenMon.Text = curMon.TenMon;

            // Load danh sách môn tiên quyết của môn này
            LoadMonTienQuyet(curMon.MaMon);

            LoadCboMonTienQuyetTheoKhoa(curMon.MaKhoa, curMon.MaMon);
        }

        private void LoadMonTienQuyet(string maMon)
        {
            // Join bảng DieuKienMonHoc với MonHoc để lấy tên môn tiên quyết
            var listTQ = from dk in context.DieuKienMonHoc
                         join mh in context.MonHoc on dk.MaMonTienQuyet equals mh.MaMon
                         where dk.MaMon == maMon
                         select new
                         {
                             ID = dk.ID, // ID của bảng điều kiện (để xóa)
                             MaMonTQ = dk.MaMonTienQuyet,
                             TenMonTQ = mh.TenMon,
                             SoTinChi = mh.SoTinChi
                         };

            dgvMonTienQuyet.DataSource = listTQ.ToList();
        }

        // Thay đổi hàm: Truyền thêm mã khoa vào để lọc
        private void LoadCboMonTienQuyetTheoKhoa(string maKhoa, string maMonHienTai)
        {
            if (string.IsNullOrEmpty(maKhoa)) return;

            // Chỉ lấy các môn học thuộc cùng Khoa với môn đang chọn
            var listMon = context.MonHoc.Where(m => m.MaKhoa == maKhoa
                                                && m.MaMon != maMonHienTai).ToList();

            cbboMonTienQuyet.DataSource = listMon;
            cbboMonTienQuyet.DisplayMember = "TenMon";
            cbboMonTienQuyet.ValueMember = "MaMon";
            cbboMonTienQuyet.SelectedIndex = -1; // Để trống cho đẹp
        }

        #endregion

        #region 2. XỬ LÝ NÚT BẤM - QUẢN LÝ MÔN HỌC (CRUD)

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            // Xóa trắng input
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtSTC.Text = "0";
            txtSoTietLT.Text = "0";
            txtSoTietTH.Text = "0";
            cboKhoa.SelectedIndex = -1;

            txtMaMon.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (bsMonHoc.Current == null) return;

            xuLyThem = false;
            BatTatChucNang(true);
            txtMaMon.Enabled = false; // Không cho sửa khóa chính
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bsMonHoc.Current == null) return;
            var curMon = (MonHoc)bsMonHoc.Current;

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa môn {curMon.TenMon}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Cần kiểm tra ràng buộc khóa ngoại (Điểm, Lớp học phần...)
                    // Ở đây xóa thử, nếu lỗi catch sẽ báo
                    context.MonHoc.Remove(curMon);
                    context.SaveChanges();
                    LoadDuLieuMonHoc();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (Môn này đang có lớp học hoặc điểm số): " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text) || string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã môn và Tên môn!");
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    // Check trùng mã
                    if (context.MonHoc.Any(x => x.MaMon == txtMaMon.Text.Trim()))
                    {
                        MessageBox.Show("Mã môn đã tồn tại!");
                        return;
                    }

                    MonHoc mh = new MonHoc();
                    mh.MaMon = txtMaMon.Text.Trim();
                    mh.TenMon = txtTenMon.Text.Trim();
                    mh.SoTinChi = int.Parse(txtSTC.Text);
                    mh.SoTietLyThuyet = int.Parse(txtSoTietLT.Text);
                    mh.SoTietThucHanh = int.Parse(txtSoTietTH.Text);
                    mh.MaKhoa = cboKhoa.SelectedValue?.ToString();

                    context.MonHoc.Add(mh);
                }
                else // Sửa
                {
                    var mh = context.MonHoc.Find(txtMaMon.Text);
                    if (mh != null)
                    {
                        mh.TenMon = txtTenMon.Text.Trim();
                        mh.SoTinChi = int.Parse(txtSTC.Text);
                        mh.SoTietLyThuyet = int.Parse(txtSoTietLT.Text);
                        mh.SoTietThucHanh = int.Parse(txtSoTietTH.Text);
                        mh.MaKhoa = cboKhoa.SelectedValue?.ToString();

                        context.MonHoc.Update(mh);
                    }
                }

                context.SaveChanges();
                LoadDuLieuMonHoc(); // Tải lại để cập nhật list
                //LoadCboMonTienQuyet(); // Cập nhật lại combo môn tiên quyết nếu có môn mới
                BatTatChucNang(false);
                MessageBox.Show("Lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            bsMonHoc.ResetBindings(false); // Reset lại giá trị cũ
        }

        #endregion

        #region 3. XỬ LÝ MÔN TIÊN QUYẾT (ADD/REMOVE PREREQUISITES)

        private void btnThemMonTienQuyet_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra môn hiện tại
            if (bsMonHoc.Current == null)
            {
                MessageBox.Show("Chưa chọn môn học để thêm điều kiện!");
                return;
            }
            var monHocHienTai = (MonHoc)bsMonHoc.Current;

            // 2. Kiểm tra môn tiên quyết được chọn trong ComboBox
            if (cbboMonTienQuyet.SelectedValue == null) return;
            string maMonTQ = cbboMonTienQuyet.SelectedValue.ToString();

            // 3. Validate logic
            if (monHocHienTai.MaMon == maMonTQ)
            {
                MessageBox.Show("Môn tiên quyết không được trùng với môn học chính!");
                return;
            }

            // Kiểm tra xem đã tồn tại chưa
            var checkExist = context.DieuKienMonHoc
                .FirstOrDefault(x => x.MaMon == monHocHienTai.MaMon && x.MaMonTienQuyet == maMonTQ);

            if (checkExist != null)
            {
                MessageBox.Show("Môn tiên quyết này đã được thêm rồi!");
                return;
            }

            try
            {
                // 4. Thêm vào DB
                DieuKienMonHoc dk = new DieuKienMonHoc();
                dk.MaMon = monHocHienTai.MaMon;
                dk.MaMonTienQuyet = maMonTQ;

                context.DieuKienMonHoc.Add(dk);
                context.SaveChanges();

                // 5. Load lại lưới bên dưới
                LoadMonTienQuyet(monHocHienTai.MaMon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm môn tiên quyết: " + ex.Message);
            }
        }

        private void btnXoaMonTienQuyet_Click(object sender, EventArgs e)
        {
            if (dgvMonTienQuyet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn môn tiên quyết cần xóa khỏi danh sách!");
                return;
            }

            // Lấy ID của dòng điều kiện (Cần cột ID ẩn hoặc hiện trên Grid)
            // Giả sử trong LoadMonTienQuyet mình đã select ID
            int idDieuKien = Convert.ToInt32(dgvMonTienQuyet.CurrentRow.Cells["ID"].Value);

            try
            {
                var dk = context.DieuKienMonHoc.Find(idDieuKien);
                if (dk != null)
                {
                    context.DieuKienMonHoc.Remove(dk);
                    context.SaveChanges();

                    // Load lại grid
                    string currentMaMon = lblMaMon.Text;
                    LoadMonTienQuyet(currentMaMon);
                    MessageBox.Show("Đã xóa điều kiện!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        #endregion

        // Lọc danh sách môn theo Khoa (ComboBox ở trên cùng)


        // Khi đổi Khoa -> Gọi hàm lọc chung
        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cần kiểm tra để tránh lỗi khi Form vừa Load (chưa có dữ liệu)
            if (cboLoc.Focused)
            {
                LocVaTimKiem();
            }
        }

        // Khi bấm nút Tìm Kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LocVaTimKiem();
        }

        // Khi bấm nút Bỏ Lọc / Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset ComboBox lọc Khoa
            cboLoc.SelectedIndex = -1;

            // Reset TextBox tìm kiếm về mặc định
            txtTuKhoa.Text = "Vui lòng nhập tên môn";
            txtTuKhoa.ForeColor = System.Drawing.Color.Gray;

            // Load lại toàn bộ dữ liệu ban đầu
            bsMonHoc.DataSource = context.MonHoc.ToList();
        }
    }
}