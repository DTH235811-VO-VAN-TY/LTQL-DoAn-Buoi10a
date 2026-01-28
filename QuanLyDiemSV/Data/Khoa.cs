using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

public partial class Khoa
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string MaKhoa { get; set; } = null!;

    [StringLength(100)]
    public string TenKhoa { get; set; } = null!;

    public DateOnly? NgayThanhLap { get; set; }

    [StringLength(100)]
    public string? TruongKhoa { get; set; }

    [InverseProperty("MaKhoaNavigation")]
    public virtual ICollection<GiangVien> GiangVien { get; set; } = new List<GiangVien>();

    [InverseProperty("MaKhoaNavigation")]
    public virtual ICollection<MonHoc> MonHoc { get; set; } = new List<MonHoc>();

    [InverseProperty("MaKhoaNavigation")]
    public virtual ICollection<Nganh> Nganh { get; set; } = new List<Nganh>();
}
