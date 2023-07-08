using System;
using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.Core.Business.Users.Primitives;
using GhostProject.App.Core.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhostProject.App.DbMigrations.Migrations
{
    public partial class AddAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Users", new string[]
            {
                nameof(User.Email),
                nameof(User.NormalizedEmail),
                nameof(User.FirstName),
                nameof(User.LastName),
                nameof(User.PasswordHash),
                nameof(User.CompanyName),
                nameof(User.RoleId),
                nameof(User.CreatedAt),
            }, new object[]
            {
                "verification@ghostlookup.com",
                "verification@ghostlookup.com".ToUpper(),
                "Pavel",
                "Asanov",
                "111qqqAAA!".ToHashPassword(),
                "Ghost Lookup",
                (int)Roles.Administrator,
                DateTimeOffset.UtcNow,
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
