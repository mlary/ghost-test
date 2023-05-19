using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class SetCompaniesToRecruitersNotRequiredRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Companies_CompanyId",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Recruiters_Companies_CompanyId",
                table: "Recruiters");

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_LinkedInUrl",
                table: "Recruiters",
                column: "LinkedInUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LinkedInUrl",
                table: "Companies",
                column: "LinkedInUrl",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Companies_CompanyId",
                table: "Rates",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiters_Companies_CompanyId",
                table: "Recruiters",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Companies_CompanyId",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Recruiters_Companies_CompanyId",
                table: "Recruiters");

            migrationBuilder.DropIndex(
                name: "IX_Recruiters_LinkedInUrl",
                table: "Recruiters");

            migrationBuilder.DropIndex(
                name: "IX_Companies_LinkedInUrl",
                table: "Companies");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Companies_CompanyId",
                table: "Rates",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiters_Companies_CompanyId",
                table: "Recruiters",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
