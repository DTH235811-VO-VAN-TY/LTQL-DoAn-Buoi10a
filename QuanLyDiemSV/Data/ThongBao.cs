using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSV.Data
{
    [Table("ThongBao")]
    public class ThongBao
    {
        [Key] // Đánh dấu đây là Khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Khóa chính tự tăng
        public int MaThongBao { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNguoiGui { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNguoiNhan { get; set; }

        [StringLength(200)]
        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        [StringLength(50)]
        public string LoaiThongBao { get; set; }

        [StringLength(50)]
        public string ThamChieuID { get; set; }

        public DateTime? NgayGui { get; set; } // Dấu ? cho phép nhận giá trị null nếu cần

        public bool? DaDoc { get; set; }
    }
}
