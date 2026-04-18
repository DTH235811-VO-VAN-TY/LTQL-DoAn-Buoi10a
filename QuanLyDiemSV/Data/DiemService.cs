using System;
using System.Collections.Generic;

namespace QuanLyDiemSV.Data
{
    public class ScaleConfig
    {
        public string Grade { get; set; }
        public double MinScore { get; set; }
        public double Points { get; set; }
        public string Description { get; set; }
    }

    public static class DiemService
    {
        // Danh sách các ngưỡng điểm chữ và hệ 4
        // Sau này bạn có thể đọc danh sách này từ database hoặc file JSON
        private static List<ScaleConfig> GradeScales = new List<ScaleConfig>
        {
            new ScaleConfig { Grade = "A", MinScore = 8.5, Points = 4.0, Description = "Xuất sắc" },
            new ScaleConfig { Grade = "B", MinScore = 7.0, Points = 3.0, Description = "Giỏi/Khá" },
            new ScaleConfig { Grade = "C", MinScore = 5.5, Points = 2.0, Description = "Trung bình" },
            new ScaleConfig { Grade = "D", MinScore = 4.0, Points = 1.0, Description = "Trung bình yếu" },
            new ScaleConfig { Grade = "F", MinScore = 0.0, Points = 0.0, Description = "Kém" }
        };

        // Ngưỡng điểm xếp loại học lực học kỳ (Hệ 4)
        public static string LayXepLoai(double dtb4)
        {
            if (dtb4 >= 3.6) return "Xuất sắc";
            if (dtb4 >= 3.2) return "Giỏi";
            if (dtb4 >= 2.5) return "Khá";
            if (dtb4 >= 2.0) return "Trung bình";
            return "Yếu";
        }

        public static string LayDiemChu(double tk)
        {
            foreach (var scale in GradeScales)
            {
                if (tk >= scale.MinScore) return scale.Grade;
            }
            return "F";
        }

        public static double LayDiemHe4(double tk)
        {
            foreach (var scale in GradeScales)
            {
                if (tk >= scale.MinScore) return scale.Points;
            }
            return 0.0;
        }

        // Tính điểm tổng kết theo quy chế 0.1, 0.3, 0.6 (hoặc 0.4, 0.6 tùy môn)
        // Hiện tại code của bạn đang dùng 0.4 và 0.6
        public static decimal TinhDiemTongKet(decimal gk, decimal ck)
        {
            return Math.Round((gk * 0.4m) + (ck * 0.6m), 1);
        }

        public static string XepLoaiHe10(decimal diem)
        {
            if (diem >= 9.0m) return "Xuất sắc";
            if (diem >= 8.0m) return "Giỏi";
            if (diem >= 7.0m) return "Khá";
            if (diem >= 5.0m) return "Trung bình";
            if (diem >= 4.0m) return "Yếu";
            return "Kém";
        }

        public static decimal QuyDoiHe4(decimal diem10)
        {
            if (diem10 >= 8.5m) return 4.0m;
            if (diem10 >= 7.0m) return 3.0m;
            if (diem10 >= 5.5m) return 2.0m;
            if (diem10 >= 4.0m) return 1.0m;
            return 0.0m;
        }
    }
}
