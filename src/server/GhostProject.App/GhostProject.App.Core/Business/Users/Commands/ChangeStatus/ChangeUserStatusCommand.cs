using MediatR;

namespace GhostProject.App.Core.Business.Users.Commands.ChangeStatus;

public class ChangeUserStatusCommand : IRequest<Unit>
{

    public ChangeUserStatusCommand(int id, bool blocked)
    {
        Id = id;
        Blocked = blocked;
    }
    
    public int Id { get; }

    public bool Blocked { get; }
}
