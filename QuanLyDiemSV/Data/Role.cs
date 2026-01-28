using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

[Index("RoleName", Name = "UQ__Role__8A2B61608B19F6E4", IsUnique = true)]
public partial class Role
{
    [Key]
    public int RoleID { get; set; }

    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [StringLength(255)]
    public string? MoTa { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<UserAccount> UserAccount { get; set; } = new List<UserAccount>();
}
