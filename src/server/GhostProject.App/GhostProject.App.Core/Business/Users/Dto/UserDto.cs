using System;
using GhostProject.App.Core.Business.Users.Primitives;

namespace GhostProject.App.Core.Business.Users.Dto;

public class UserDto
{
    public string Email { get; set; }

    public string NormalizedEmail { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string CompanyName { get; set; }
    
    public bool Blocked { get; set; }

    public Roles Role { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
}
