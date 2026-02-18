using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TitleTrack.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCounties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Counties",
                columns: new[] { "CountyID", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Miami-Dade", "FL" },
                    { 2, "Broward", "FL" },
                    { 3, "Palm Beach", "FL" },
                    { 4, "Los Angeles", "CA" },
                    { 5, "Orange", "CA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Counties",
                keyColumn: "CountyID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Counties",
                keyColumn: "CountyID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Counties",
                keyColumn: "CountyID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Counties",
                keyColumn: "CountyID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Counties",
                keyColumn: "CountyID",
                keyValue: 5);
        }
    }
}
