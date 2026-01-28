using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyDiemSV.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTaoCSDL_Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocKy",
                columns: table => new
                {
                    MaHK = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenHK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NamHocBatDau = table.Column<int>(type: "int", nullable: true),
                    NamHocKetThuc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKy", x => x.MaHK);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayThanhLap = table.Column<DateOnly>(type: "date", nullable: true),
                    TruongKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: true),
                    SoTietLyThuyet = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    SoTietThucHanh = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    MaKhoa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MaMon);
                    table.ForeignKey(
                        name: "FK_MonHoc_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "Nganh",
                columns: table => new
                {
                    MaNganh = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenNganh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaKhoa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganh", x => x.MaNganh);
                    table.ForeignKey(
                        name: "FK_Nganh_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_UserAccount_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "DieuKienMonHoc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaMonTienQuyet = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieuKienMonHoc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DieuKienMonHoc_MonHoc_MaMon",
                        column: x => x.MaMon,
                        principalTable: "MonHoc",
                        principalColumn: "MaMon");
                    table.ForeignKey(
                        name: "FK_DieuKienMonHoc_MonHoc_MaMonTienQuyet",
                        column: x => x.MaMonTienQuyet,
                        principalTable: "MonHoc",
                        principalColumn: "MaMon");
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    HocVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.MaGV);
                    table.ForeignKey(
                        name: "FK_GiangVien_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa");
                    table.ForeignKey(
                        name: "FK_GiangVien_UserAccount_UserID",
                        column: x => x.UserID,
                        principalTable: "UserAccount",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "LopHanhChinh",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NienKhoa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MaNganh = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaGVCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHanhChinh", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_LopHanhChinh_GiangVien_MaGVCN",
                        column: x => x.MaGVCN,
                        principalTable: "GiangVien",
                        principalColumn: "MaGV");
                    table.ForeignKey(
                        name: "FK_LopHanhChinh_Nganh_MaNganh",
                        column: x => x.MaNganh,
                        principalTable: "Nganh",
                        principalColumn: "MaNganh");
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhan",
                columns: table => new
                {
                    MaLHP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMon = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaHK = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaGV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenLopHP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhongHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiSoToiDa = table.Column<int>(type: "int", nullable: true, defaultValue: 60),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhan", x => x.MaLHP);
                    table.ForeignKey(
                        name: "FK_LopHocPhan_GiangVien_MaGV",
                        column: x => x.MaGV,
                        principalTable: "GiangVien",
                        principalColumn: "MaGV");
                    table.ForeignKey(
                        name: "FK_LopHocPhan_HocKy_MaHK",
                        column: x => x.MaHK,
                        principalTable: "HocKy",
                        principalColumn: "MaHK");
                    table.ForeignKey(
                        name: "FK_LopHocPhan_MonHoc_MaMon",
                        column: x => x.MaMon,
                        principalTable: "MonHoc",
                        principalColumn: "MaMon");
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CCCD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    MaLop = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_LopHanhChinh_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHanhChinh",
                        principalColumn: "MaLop");
                    table.ForeignKey(
                        name: "FK_SinhVien_UserAccount_UserID",
                        column: x => x.UserID,
                        principalTable: "UserAccount",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "KetQuaHocTap",
                columns: table => new
                {
                    MaKQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaLHP = table.Column<int>(type: "int", nullable: false),
                    DiemCC = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    DiemGK = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    DiemCK = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    DiemTongKet = table.Column<decimal>(type: "decimal(4,2)", nullable: true, computedColumnSql: "(CONVERT([decimal](4,2),(isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6)))", stored: true),
                    DiemChu = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, computedColumnSql: "(case when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(8.5) then 'A' when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(7.0) then 'B' when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(5.5) then 'C' when ((isnull([DiemCC],(0))*(0.1)+isnull([DiemGK],(0))*(0.3))+isnull([DiemCK],(0))*(0.6))>=(4.0) then 'D' else 'F' end)", stored: false),
                    GhiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaHocTap", x => x.MaKQ);
                    table.ForeignKey(
                        name: "FK_KetQuaHocTap_LopHocPhan_MaLHP",
                        column: x => x.MaLHP,
                        principalTable: "LopHocPhan",
                        principalColumn: "MaLHP");
                    table.ForeignKey(
                        name: "FK_KetQuaHocTap_SinhVien_MaSV",
                        column: x => x.MaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DieuKienMonHoc_MaMon",
                table: "DieuKienMonHoc",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_DieuKienMonHoc_MaMonTienQuyet",
                table: "DieuKienMonHoc",
                column: "MaMonTienQuyet");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaKhoa",
                table: "GiangVien",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_UserID",
                table: "GiangVien",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UQ__GiangVie__A9D105342D7F3DF8",
                table: "GiangVien",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaHocTap_MaLHP",
                table: "KetQuaHocTap",
                column: "MaLHP");

            migrationBuilder.CreateIndex(
                name: "UQ_SinhVien_LopHP",
                table: "KetQuaHocTap",
                columns: new[] { "MaSV", "MaLHP" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHanhChinh_MaGVCN",
                table: "LopHanhChinh",
                column: "MaGVCN");

            migrationBuilder.CreateIndex(
                name: "IX_LopHanhChinh_MaNganh",
                table: "LopHanhChinh",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_MaGV",
                table: "LopHocPhan",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_MaHK",
                table: "LopHocPhan",
                column: "MaHK");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhan_MaMon",
                table: "LopHocPhan",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaKhoa",
                table: "MonHoc",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_Nganh_MaKhoa",
                table: "Nganh",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "UQ__Role__8A2B61608B19F6E4",
                table: "Role",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_UserID",
                table: "SinhVien",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UQ__SinhVien__A955A0AA5F826F6E",
                table: "SinhVien",
                column: "CCCD",
                unique: true,
                filter: "[CCCD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_RoleID",
                table: "UserAccount",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "UQ__UserAcco__536C85E4511305A8",
                table: "UserAccount",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DieuKienMonHoc");

            migrationBuilder.DropTable(
                name: "KetQuaHocTap");

            migrationBuilder.DropTable(
                name: "LopHocPhan");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "HocKy");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "LopHanhChinh");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "Nganh");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
