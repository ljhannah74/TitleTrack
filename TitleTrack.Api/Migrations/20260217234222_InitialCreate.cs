using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TitleTrack.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbstractReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SearchDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PropertyAddress = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    ProductType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CountyID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractReports", x => x.ReportID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractReports_OrderNumber",
                table: "AbstractReports",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbstractReports_PropertyAddress",
                table: "AbstractReports",
                column: "PropertyAddress");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractReports_SearchDate",
                table: "AbstractReports",
                column: "SearchDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbstractReports");
        }
    }
}
