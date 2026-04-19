using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuanLyDiemSV.Data;

/// <summary>
/// Bảng Khung chương trình đào tạo: Quy định các môn học bắt buộc/tự chọn cho từng Ngành.
/// Mỗi dòng = 1 môn học trong khung CT của 1 ngành, dự kiến học ở học kỳ thứ mấy.
/// </summary>
public partial class KhungChuongTrinh
{
    [Key]
    public int ID { get; set; }

    /// <summary> Mã ngành liên kết </summary>
    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string MaNganh { get; set; } = null!;

    /// <summary> Mã môn học trong khung CT </summary>
    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string MaMon { get; set; } = null!;

    /// <summary> Học kỳ dự kiến (1-8) </summary>
    public int HocKyDuKien { get; set; }

    /// <summary> Loại môn: "Bắt buộc" hoặc "Tự chọn" </summary>
    [StringLength(20)]
    public string LoaiMon { get; set; } = "Bắt buộc";

    // ========= Navigation Properties =========
    [ForeignKey("MaNganh")]
    public virtual Nganh? MaNganhNavigation { get; set; }

    [ForeignKey("MaMon")]
    public virtual MonHoc? MaMonNavigation { get; set; }
}
