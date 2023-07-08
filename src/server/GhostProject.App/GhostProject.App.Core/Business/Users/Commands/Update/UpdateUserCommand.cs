using GhostProject.App.Core.Business.Users.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Users.Commands.Update;

public class UpdateUserCommand : IRequest<UserDto>
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string CompanyName { get; set; }
}
