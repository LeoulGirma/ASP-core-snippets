using Microsoft.EntityFrameworkCore.Migrations;

namespace Image_upload.Migrations
{
    public partial class insertPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "PhotoPath",
                value: "Avengers.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "PhotoPath",
                value: null);
        }
    }
}
