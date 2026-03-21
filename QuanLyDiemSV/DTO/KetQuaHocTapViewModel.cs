using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSV.DTO
{
    public class KetQuaHocTapViewModel
    {
        // 1. Thông tin để hiển thị (Lấy từ bảng MonHoc)
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int SoTinChi { get; set; }

        // 2. Các cột điểm thành phần
        public decimal? DiemCC { get; set; } // Chuyên cần
        public decimal? DiemGK { get; set; } // Giữa kỳ

        // 3. Điểm thi (Map từ DiemCK hoặc cột mở rộng)
        public decimal? DiemThiLan1 { get; set; }
        // Nếu sau này có cột DiemThiLan2 trong DB thì bỏ comment dòng dưới
         public decimal? DiemThiLan2 { get; set; } 

        // 4. Điểm tổng kết
        public decimal? DiemTongKet { get; set; } // Hệ 10
        public string DiemChu { get; set; }       // Hệ chữ (A, B, C...)

        // 5. Các cột ẩn (Dùng để xử lý logic Update/Delete nếu cần)
        public int MaKQ { get; set; }
    }
}
