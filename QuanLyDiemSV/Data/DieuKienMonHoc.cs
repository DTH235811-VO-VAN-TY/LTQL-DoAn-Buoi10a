using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

public partial class DieuKienMonHoc
{
    [Key]
    public int ID { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MaMon { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string MaMonTienQuyet { get; set; } = null!;

    [ForeignKey("MaMon")]
    [InverseProperty("DieuKienMonHocMaMonNavigation")]
    public virtual MonHoc MaMonNavigation { get; set; } = null!;

    [ForeignKey("MaMonTienQuyet")]
    [InverseProperty("DieuKienMonHocMaMonTienQuyetNavigation")]
    public virtual MonHoc MaMonTienQuyetNavigation { get; set; } = null!;
}
