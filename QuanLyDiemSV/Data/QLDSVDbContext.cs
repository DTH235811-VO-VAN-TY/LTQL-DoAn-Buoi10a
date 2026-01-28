using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace QuanLyDiemSV.Data
{
    public class QLDSVDbContext:DbContext
    {
        public virtual DbSet<DieuKienMonHoc> DieuKienMonHoc { get; set; }

        public virtual DbSet<GiangVien> GiangVien { get; set; }

        public virtual DbSet<HocKy> HocKy { get; set; }

        public virtual DbSet<KetQuaHocTap> KetQuaHocTap { get; set; }

        public virtual DbSet<Khoa> Khoa { get; set; }

        public virtual DbSet<LopHanhChinh> LopHanhChinh { get; set; }

        public virtual DbSet<LopHocPhan> LopHocPhan { get; set; }

        public virtual DbSet<MonHoc> MonHoc { get; set; }

        public virtual DbSet<Nganh> Nganh { get; set; }

        public virtual DbSet<Role> Role { get; set; }

        public virtual DbSet<SinhVien> SinhVien { get; set; }

        public virtual DbSet<UserAccount> UserAccount { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=REDMI-11\\SQLEXPRESS01;Database=QLDSV;Trusted_Connection=True;TrustServerCertificate=True");
       */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chuỗi kết nối lấy từ App.config bạn gửi trước đó
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLDSVConnection"].ConnectionString);
                optionsBuilder.UseSqlServer("Server=REDMI-11\\SQLEXPRESS01;Database=QLDSV_;Integrated Security=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DieuKienMonHoc>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasOne(d => d.MaMonNavigation).WithMany(p => p.DieuKienMonHocMaMonNavigation)
                    .OnDelete(DeleteBehavior.ClientSetNull); // Chặn cascade
                entity.HasOne(d => d.MaMonTienQuyetNavigation).WithMany(p => p.DieuKienMonHocMaMonTienQuyetNavigation)
                    .OnDelete(DeleteBehavior.ClientSetNull); // Chặn cascade
            });

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.HasKey(e => e.MaGV);
                entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.GiangVien)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.User).WithMany(p => p.GiangVien)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<HocKy>(entity =>
            {
                entity.HasKey(e => e.MaHK);
            });

            modelBuilder.Entity<KetQuaHocTap>(entity =>
            {
                entity.HasKey(e => e.MaKQ);

                // --- ĐOẠN NÀY RẤT QUAN TRỌNG: TỰ TÍNH ĐIỂM ---
                entity.Property(e => e.DiemChu).HasComputedColumnSql("(case when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(8.5) then 'A' when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(7.0) then 'B' when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(5.5) then 'C' when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(4.0) then 'D' else 'F' end)", false);
                entity.Property(e => e.DiemTongKet).HasComputedColumnSql("(CONVERT([decimal](4,2),(isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6)))", true);
                // ---------------------------------------------

                entity.HasOne(d => d.MaLHPNavigation).WithMany(p => p.KetQuaHocTap)
                    .OnDelete(DeleteBehavior.ClientSetNull); // Chặn cascade gây lỗi
                entity.HasOne(d => d.MaSVNavigation).WithMany(p => p.KetQuaHocTap)
                    .OnDelete(DeleteBehavior.ClientSetNull); // Chặn cascade gây lỗi
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa);
            });

            modelBuilder.Entity<LopHanhChinh>(entity =>
            {
                entity.HasKey(e => e.MaLop);
                entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.LopHanhChinh)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LopHocPhan>(entity =>
            {
                entity.HasKey(e => e.MaLHP);
                entity.Property(e => e.SiSoToiDa).HasDefaultValue(60);
                entity.Property(e => e.TrangThai).HasDefaultValue(0);

                entity.HasOne(d => d.MaGVNavigation).WithMany(p => p.LopHocPhan)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.MaHKNavigation).WithMany(p => p.LopHocPhan)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.MaMonNavigation).WithMany(p => p.LopHocPhan)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMon);
                entity.Property(e => e.SoTietLyThuyet).HasDefaultValue(0);
                entity.Property(e => e.SoTietThucHanh).HasDefaultValue(0);
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(e => e.MaNganh);
                entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Nganh)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSV);
                entity.Property(e => e.TrangThai).HasDefaultValue(1); // Mặc định là đang học
                entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.SinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
                entity.HasOne(d => d.Role).WithMany(p => p.UserAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
