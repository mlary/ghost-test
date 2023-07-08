using System;
using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Users.Primitives;

namespace GhostProject.App.Core.Business.Users.Dto;

public class UserDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string NormalizedEmail { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    
    public string CompanyName { get; set; }
    
    public bool Blocked { get; set; }

    [Required]
    public Roles Role { get; set; }

    [Required]
    public DateTimeOffset CreatedAt { get; set; }
}
