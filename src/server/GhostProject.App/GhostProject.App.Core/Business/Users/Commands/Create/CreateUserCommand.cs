using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Users.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Users.Commands.Create;

public class CreateUserCommand : IRequest<UserDto>
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string ConfirmPassword { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string CompanyName { get; set; }
}
