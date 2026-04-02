using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSV.DTO
{
    public class SinhVienBaoCaoDTO
    {
        public int STT { get; set; }
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string TenLop { get; set; }
        public string TenKhoa { get; set; }
        public double DiemTrungBinh { get; set; }
        public int SoTinChi { get; set; }
    }
}
