using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSV
{
    public static class Session
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static int RoleID { get; set; } // Giả định: 1 = Admin, 2 = Giảng viên, 3 = Sinh viên
        public static string MaNguoiDung { get; set; } // Sẽ lưu Mã GV hoặc Mã SV tùy vào Role
    }
}
