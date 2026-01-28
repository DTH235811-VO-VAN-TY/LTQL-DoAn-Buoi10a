using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

[Index("Email", Name = "UQ__GiangVie__A9D105342D7F3DF8", IsUnique = true)]
public partial class GiangVien
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string MaGV { get; set; } = null!;

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? SDT { get; set; }

    [StringLength(50)]
    public string? HocVi { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MaKhoa { get; set; } = null!;

    public int? UserID { get; set; }

    [InverseProperty("MaGVCNNavigation")]
    public virtual ICollection<LopHanhChinh> LopHanhChinh { get; set; } = new List<LopHanhChinh>();

    [InverseProperty("MaGVNavigation")]
    public virtual ICollection<LopHocPhan> LopHocPhan { get; set; } = new List<LopHocPhan>();

    [ForeignKey("MaKhoa")]
    [InverseProperty("GiangVien")]
    public virtual Khoa MaKhoaNavigation { get; set; } = null!;

    [ForeignKey("UserID")]
    [InverseProperty("GiangVien")]
    public virtual UserAccount? User { get; set; }
}
