using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Image_upload.Migrations
{
    public partial class addAnotherMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Gener", "Length", "PhotoPath", "RealeaseDate", "Title" },
                values: new object[] { 2, 6, "3hr 30min", "The Irishman.jpg", new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Local), "The Irishman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);
        }
    }
}
