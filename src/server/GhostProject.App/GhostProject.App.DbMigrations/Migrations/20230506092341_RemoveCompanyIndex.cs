using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class RemoveCompanyIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_LinkedInUrl",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Companies_LinkedInUrl",
                table: "Companies",
                column: "LinkedInUrl",
                unique: true);
        }
    }
}
