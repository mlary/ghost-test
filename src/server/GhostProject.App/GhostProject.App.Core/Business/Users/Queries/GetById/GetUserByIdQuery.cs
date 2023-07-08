using GhostProject.App.Core.Business.Users.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Users.Queries.GetById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public int Id { get; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}
