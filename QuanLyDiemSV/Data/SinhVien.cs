using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

[Index("CCCD", Name = "UQ__SinhVien__A955A0AA5F826F6E", IsUnique = true)]
public partial class SinhVien
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string MaSV { get; set; } = null!;

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [StringLength(255)]
    public string? DiaChi { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CCCD { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? SDT { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MaLop { get; set; } = null!;

    public int? TrangThai { get; set; }

    public int? UserID { get; set; }

    [InverseProperty("MaSVNavigation")]
    public virtual ICollection<KetQuaHocTap> KetQuaHocTap { get; set; } = new List<KetQuaHocTap>();

    [ForeignKey("MaLop")]
    [InverseProperty("SinhVien")]
    public virtual LopHanhChinh MaLopNavigation { get; set; } = null!;

    [ForeignKey("UserID")]
    [InverseProperty("SinhVien")]
    public virtual UserAccount? User { get; set; }

    //[ForeignKey("MaLop")]
   // public virtual LopHanhChinh LopHanhChinh { get; set; }
}
