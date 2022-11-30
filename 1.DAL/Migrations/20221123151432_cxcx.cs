using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class cxcx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SachChiTiet_Anh_IdAnh",
                table: "SachChiTiet");

            migrationBuilder.DropIndex(
                name: "IX_SachChiTiet_IdAnh",
                table: "SachChiTiet");

            migrationBuilder.AddColumn<Guid>(
                name: "AnhId",
                table: "SachChiTiet",
                type: "uniqueidentifier",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
