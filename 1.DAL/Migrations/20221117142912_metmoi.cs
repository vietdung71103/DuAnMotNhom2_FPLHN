using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class metmoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdAnh",
                table: "SachChiTiet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AnhNhanVien",
                table: "NhanVien",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "NhanVien",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Anh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "varchar(20)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DuongDan = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anh", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SachChiTiet_IdAnh",
                table: "SachChiTiet",
                column: "IdAnh");

            migrationBuilder.AddForeignKey(
                name: "FK_SachChiTiet_Anh_IdAnh",
                table: "SachChiTiet",
                column: "IdAnh",
                principalTable: "Anh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SachChiTiet_Anh_IdAnh",
                table: "SachChiTiet");

            migrationBuilder.DropTable(
                name: "Anh");

            migrationBuilder.DropIndex(
                name: "IX_SachChiTiet_IdAnh",
                table: "SachChiTiet");

            migrationBuilder.DropColumn(
                name: "IdAnh",
                table: "SachChiTiet");

            migrationBuilder.DropColumn(
                name: "AnhNhanVien",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "NhanVien");
        }
    }
}
