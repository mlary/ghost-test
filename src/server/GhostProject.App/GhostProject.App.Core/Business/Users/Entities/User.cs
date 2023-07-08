using System;
using GhostProject.App.Core.Common;

namespace GhostProject.App.Core.Business.Users.Entities;

public class User : BaseEntity<int>
{
    public string Email { get; set; }

    public string NormalizedEmail { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string CompanyName { get; set; }

    public int RoleId { get; set; }

    public string PasswordHash { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    
    public bool Blocked { get; set; }

}