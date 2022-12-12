using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class lonnnnnnnnnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenKhuyenMai",
                table: "KhuyenMais",
                type: "nvarchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChiTiet",
                table: "KhuyenMais",
                type: "nvarchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenKhuyenMai",
                table: "KhuyenMais",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChiTiet",
                table: "KhuyenMais",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldNullable: true);
        }
    }
}
