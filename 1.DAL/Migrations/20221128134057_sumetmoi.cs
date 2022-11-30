using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class sumetmoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SachChiTiet_Anh_AnhId",
                table: "SachChiTiet");

            migrationBuilder.DropIndex(
                name: "IX_SachChiTiet_AnhId",
                table: "SachChiTiet");

            migrationBuilder.DropColumn(
                name: "AnhId",
                table: "SachChiTiet");

            migrationBuilder.DropColumn(
                name: "IdAnh",
                table: "SachChiTiet");

            migrationBuilder.AddColumn<string>(
                name: "DuongDanAnh",
                table: "SachChiTiet",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ma",
                table: "SachChiTiet",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuongDanAnh",
                table: "SachChiTiet");

            migrationBuilder.DropColumn(
                name: "Ma",
                table: "SachChiTiet");

            migrationBuilder.AddColumn<Guid>(
                name: "AnhId",
                table: "SachChiTiet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdAnh",
                table: "SachChiTiet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SachChiTiet_AnhId",
                table: "SachChiTiet",
                column: "AnhId");

            migrationBuilder.AddForeignKey(
                name: "FK_SachChiTiet_Anh_AnhId",
                table: "SachChiTiet",
                column: "AnhId",
                principalTable: "Anh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
