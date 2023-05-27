using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class ClearDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from \"Recruiters\"");
            migrationBuilder.Sql("Delete from \"Companies\"");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
