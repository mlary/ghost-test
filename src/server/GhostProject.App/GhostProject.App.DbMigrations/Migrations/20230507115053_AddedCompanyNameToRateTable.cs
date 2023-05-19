using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class AddedCompanyNameToRateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Rates",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Rates");
        }
    }
}
