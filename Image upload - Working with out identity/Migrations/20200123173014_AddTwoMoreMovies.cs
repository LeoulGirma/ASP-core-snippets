using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Image_upload.Migrations
{
    public partial class AddTwoMoreMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "RealeaseDate",
                value: new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Gener", "Length", "PhotoPath", "RealeaseDate", "Title" },
                values: new object[] { 3, 3, "2hr 22min", "Star wars.jpg", new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "Star Wars: The Rise of Skywalker" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Gener", "Length", "PhotoPath", "RealeaseDate", "Title" },
                values: new object[] { 2, 6, "3hr 30min", "The Irishman.jpg", new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "The Irishman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "RealeaseDate",
                value: new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
