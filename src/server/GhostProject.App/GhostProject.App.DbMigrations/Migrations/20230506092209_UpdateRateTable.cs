using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class UpdateRateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommonRating",
                table: "Rates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewRound",
                table: "Rates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionSeniorityLevel",
                table: "Rates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisitedLinkedInProfile",
                table: "Rates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyNormalizedName",
                table: "Companies",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommonRating",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "InterviewRound",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "PositionSeniorityLevel",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "VisitedLinkedInProfile",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CompanyNormalizedName",
                table: "Companies");
        }
    }
}
