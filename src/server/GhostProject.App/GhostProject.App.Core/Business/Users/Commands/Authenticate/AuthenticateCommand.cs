using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GhostProject.App.Core.Business.Users.Commands.Authenticate;

public class AuthenticateCommand : IRequest<string>
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
