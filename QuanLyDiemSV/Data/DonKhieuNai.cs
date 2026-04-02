using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSV.Data
{
    [Table("DonKhieuNai")]
    public class DonKhieuNai
    {
        [Key]
        public int MaKN { get; set; }

        public string MaSV { get; set; }

        public int MaLHP { get; set; }

        public string LyDo { get; set; }

        public DateTime NgayGui { get; set; }

        public int TrangThai { get; set; }

        public string? PhanHoi { get; set; }
        public bool? DaXem { get; set; }

        // Khai báo kết nối khóa ngoại (Rất quan trọng để bạn dùng lệnh .Include() sau này)
        [ForeignKey("MaSV")]
        public virtual SinhVien MaSVNavigation { get; set; }

        [ForeignKey("MaLHP")]
        public virtual LopHocPhan MaLHPNavigation { get; set; }
    }
}
