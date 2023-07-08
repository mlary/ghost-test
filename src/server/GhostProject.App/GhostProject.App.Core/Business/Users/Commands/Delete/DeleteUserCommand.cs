using MediatR;

namespace GhostProject.App.Core.Business.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<Unit>
{
    public int Id { get; }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}
