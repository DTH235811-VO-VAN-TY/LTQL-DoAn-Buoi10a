using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

public partial class LopHanhChinh
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string MaLop { get; set; } = null!;

    [StringLength(100)]
    public string TenLop { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? NienKhoa { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MaNganh { get; set; } = null!;
  //  [ForeignKey("MaNganh")]
   // public virtual Nganh Nganh { get; set; } // Để link tới bảng Ngành

    [StringLength(20)]
    [Unicode(false)]
    public string? MaGVCN { get; set; }

    [ForeignKey("MaGVCN")]
    [InverseProperty("LopHanhChinh")]
    public virtual GiangVien? MaGVCNNavigation { get; set; }

    [ForeignKey("MaNganh")]
    [InverseProperty("LopHanhChinh")]
    public virtual Nganh MaNganhNavigation { get; set; } = null!;

    [InverseProperty("MaLopNavigation")]
    public virtual ICollection<SinhVien> SinhVien { get; set; } = new List<SinhVien>();

    
}
