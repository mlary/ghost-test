using GhostProject.App.Core.Business.Users.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Users.Queries.GetCurrent;

public class GetCurrentUserQuery : IRequest<UserDto>
{
    public string Email { get; }

    public GetCurrentUserQuery(string email)
    {
        Email = email;
    }
}
