using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

[Index("MaSV", "MaLHP", Name = "UQ_SinhVien_LopHP", IsUnique = true)]
public partial class KetQuaHocTap
{
    [Key]
    public int MaKQ { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MaSV { get; set; } = null!;

    public int MaLHP { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemCC { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemGK { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemCK { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? DiemTongKet { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string DiemChu { get; set; } = null!;

    [StringLength(200)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaLHP")]
    [InverseProperty("KetQuaHocTap")]
    public virtual LopHocPhan MaLHPNavigation { get; set; } = null!;

    [ForeignKey("MaSV")]
    [InverseProperty("KetQuaHocTap")]
    public virtual SinhVien MaSVNavigation { get; set; } = null!;
}
