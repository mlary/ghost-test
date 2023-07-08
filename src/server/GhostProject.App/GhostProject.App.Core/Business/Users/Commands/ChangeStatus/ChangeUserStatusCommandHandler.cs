using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using MediatR;

namespace GhostProject.App.Core.Business.Users.Commands.ChangeStatus;

public class ChangeUserStatusCommandHandler : HandlerBase<ChangeUserStatusCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public ChangeUserStatusCommandHandler(IUserRepository userRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public override async Task<Unit> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);
        user.Blocked = request.Blocked;
        await UnitOfWork.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
