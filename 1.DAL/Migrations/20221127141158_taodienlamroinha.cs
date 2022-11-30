using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class taodienlamroinha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "NhanVien",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "NhanVien");
        }
    }
}
