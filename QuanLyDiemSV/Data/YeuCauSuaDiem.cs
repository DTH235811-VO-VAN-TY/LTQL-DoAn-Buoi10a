using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDiemSV.Data
{
    [Table("YeuCauSuaDiem")]
    public class YeuCauSuaDiem
    {
        [Key]
        public int MaYC { get; set; }

        [StringLength(20)]
        public string MaGV { get; set; }

        public int MaLHP { get; set; }

        [Required]
        public string LyDo { get; set; }

        public DateTime NgayGui { get; set; }

        // 0: Chờ duyệt, 1: Đã duyệt (Mở khóa), 2: Từ chối
        public int TrangThai { get; set; }

        public string? PhanHoiAdmin { get; set; }

        [ForeignKey("MaGV")]
        public virtual GiangVien GiangVien { get; set; }

        [ForeignKey("MaLHP")]
        public virtual LopHocPhan LopHocPhan { get; set; }
    }
}
