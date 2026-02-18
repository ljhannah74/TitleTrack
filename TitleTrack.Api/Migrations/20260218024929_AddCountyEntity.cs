using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TitleTrack.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCountyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    CountyID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.CountyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractReports_CountyID",
                table: "AbstractReports",
                column: "CountyID");

            migrationBuilder.CreateIndex(
                name: "IX_Counties_Name_State",
                table: "Counties",
                columns: new[] { "Name", "State" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractReports_Counties_CountyID",
                table: "AbstractReports",
                column: "CountyID",
                principalTable: "Counties",
                principalColumn: "CountyID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractReports_Counties_CountyID",
                table: "AbstractReports");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropIndex(
                name: "IX_AbstractReports_CountyID",
                table: "AbstractReports");
        }
    }
}
