using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

public partial class LopHocPhan
{
    [Key]
    public int MaLHP { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MaMon { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string MaHK { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string MaGV { get; set; } = null!;

    [StringLength(100)]
    public string? TenLopHP { get; set; }

    [StringLength(50)]
    public string? PhongHoc { get; set; }

    public int? SiSoToiDa { get; set; }

    public int? TrangThai { get; set; }

    [InverseProperty("MaLHPNavigation")]
    public virtual ICollection<KetQuaHocTap> KetQuaHocTap { get; set; } = new List<KetQuaHocTap>();

    [ForeignKey("MaGV")]
    [InverseProperty("LopHocPhan")]
    public virtual GiangVien MaGVNavigation { get; set; } = null!;

    [ForeignKey("MaHK")]
    [InverseProperty("LopHocPhan")]
    public virtual HocKy MaHKNavigation { get; set; } = null!;

    [ForeignKey("MaMon")]
    [InverseProperty("LopHocPhan")]
    public virtual MonHoc MaMonNavigation { get; set; } = null!;
}
