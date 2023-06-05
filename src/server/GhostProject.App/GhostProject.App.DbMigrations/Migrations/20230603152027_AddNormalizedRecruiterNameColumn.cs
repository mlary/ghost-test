using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class AddNormalizedRecruiterNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "NormalizedRecruiterName",
                table: "Recruiters",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedRecruiterName",
                table: "Recruiters");
        }
    }
}
