using System;

namespace QuanLyDiemSV.DTO
{
    // Class chứa dữ liệu cho danh sách sinh viên (Màn hình Container)
    public class SinhVienTraCuuDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string TenLop { get; set; }
        public string TenKhoa { get; set; }
        public double DiemTrungBinh { get; set; }
        public int TinChiTichLuy { get; set; }
    }

    // Class chứa dữ liệu chi tiết từng môn (Màn hình Chi tiết)
    public class DiemChiTietDTO
    {
        public int STT { get; set; } // Số thứ tự
        public string MaHK { get; set; }
        public string TenHK { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int SoTinChi { get; set; }
        public decimal? DiemQT { get; set; }
        public decimal? DiemThi { get; set; }
        public decimal? DiemThiLan1 { get; set; }
        public decimal? DiemThiLan2 { get; set; }

        public decimal? DiemTongKet { get; set; } // Hệ 10
        public decimal? DiemHe4 { get; set; }     // Hệ 4
        public string DiemChu { get; set; }       // Điểm chữ (A, B, C...)
    }
}