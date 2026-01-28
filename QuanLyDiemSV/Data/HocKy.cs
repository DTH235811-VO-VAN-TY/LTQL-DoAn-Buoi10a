using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

public partial class HocKy
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string MaHK { get; set; } = null!;

    [StringLength(50)]
    public string TenHK { get; set; } = null!;

    public int? NamHocBatDau { get; set; }

    public int? NamHocKetThuc { get; set; }

    [InverseProperty("MaHKNavigation")]
    public virtual ICollection<LopHocPhan> LopHocPhan { get; set; } = new List<LopHocPhan>();
}
