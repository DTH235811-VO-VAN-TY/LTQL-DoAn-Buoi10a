using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

public partial class MonHoc
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string MaMon { get; set; } = null!;

    [StringLength(100)]
    public string TenMon { get; set; } = null!;

    public int SoTinChi { get; set; }

    public int? SoTietLyThuyet { get; set; }

    public int? SoTietThucHanh { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? MaKhoa { get; set; }

    [InverseProperty("MaMonNavigation")]
    public virtual ICollection<DieuKienMonHoc> DieuKienMonHocMaMonNavigation { get; set; } = new List<DieuKienMonHoc>();

    [InverseProperty("MaMonTienQuyetNavigation")]
    public virtual ICollection<DieuKienMonHoc> DieuKienMonHocMaMonTienQuyetNavigation { get; set; } = new List<DieuKienMonHoc>();

    [InverseProperty("MaMonNavigation")]
    public virtual ICollection<LopHocPhan> LopHocPhan { get; set; } = new List<LopHocPhan>();

    [ForeignKey("MaKhoa")]
    [InverseProperty("MonHoc")]
    public virtual Khoa? MaKhoaNavigation { get; set; }
}
