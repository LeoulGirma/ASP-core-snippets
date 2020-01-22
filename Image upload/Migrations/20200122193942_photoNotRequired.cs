using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Image_upload.Migrations
{
    public partial class photoNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Gener", "Length", "PhotoPath", "RealeaseDate", "Title" },
                values: new object[] { 1, 6, "3hr", null, new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Local), "Avengers End Game" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
