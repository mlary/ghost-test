using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class UpdateNormalizedRecruiterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE \"Recruiters\" SET \"NormalizedRecruiterName\"=UPPER(CONCAT(\"FirstName\", ' ', \"Surname\"))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
