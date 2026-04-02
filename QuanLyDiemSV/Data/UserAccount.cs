using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

[Index("Username", Name = "UQ__UserAcco__536C85E4511305A8", IsUnique = true)]
public partial class UserAccount
{
    [Key]
    public int UserID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;

    public int RoleID { get; set; }

    public bool? IsActive { get; set; }
    public string? MaGV { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayTao { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<GiangVien> GiangVien { get; set; } = new List<GiangVien>();

    [ForeignKey("RoleID")]
    [InverseProperty("UserAccount")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<SinhVien> SinhVien { get; set; } = new List<SinhVien>();
}
