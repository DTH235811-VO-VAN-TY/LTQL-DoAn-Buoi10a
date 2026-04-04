using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSV.Data
{
    [Table("NhatKyHoatDong")]
    public partial class NhatKyHoatDong
    {
        [Key]
        public int MaLog { get; set; }

        [StringLength(50)]
        public string NguoiDung { get; set; }

        public DateTime? ThoiGian { get; set; }

        [StringLength(100)]
        public string HanhDong { get; set; }

        public string ChiTiet { get; set; }
    }
}
