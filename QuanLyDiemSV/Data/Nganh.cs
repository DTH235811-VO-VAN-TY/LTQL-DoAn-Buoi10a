using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

public partial class Nganh
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string MaNganh { get; set; } = null!;

    [StringLength(100)]
    public string TenNganh { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string MaKhoa { get; set; } = null!;

    [InverseProperty("MaNganhNavigation")]
    public virtual ICollection<LopHanhChinh> LopHanhChinh { get; set; } = new List<LopHanhChinh>();

    [ForeignKey("MaKhoa")]
    [InverseProperty("Nganh")]
    public virtual Khoa MaKhoaNavigation { get; set; } = null!;
   // [ForeignKey("MaKhoa")]
   // public virtual Khoa Khoa { get; set; }
}
