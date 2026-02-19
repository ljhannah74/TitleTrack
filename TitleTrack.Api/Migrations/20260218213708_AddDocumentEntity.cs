using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TitleTrack.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AbstractReportId = table.Column<int>(type: "INTEGER", nullable: false),
                    DocumentType = table.Column<string>(type: "TEXT", nullable: false),
                    InstrumentNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RecordingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Grantor = table.Column<string>(type: "TEXT", nullable: false),
                    Grantee = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: true),
                    Book = table.Column<string>(type: "TEXT", nullable: false),
                    Page = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_AbstractReports_AbstractReportId",
                        column: x => x.AbstractReportId,
                        principalTable: "AbstractReports",
                        principalColumn: "ReportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AbstractReportId",
                table: "Documents",
                column: "AbstractReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
