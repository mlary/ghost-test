using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.Core.Business.Users.Primitives;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;
using MediatR;

namespace GhostProject.App.Core.Business.Users.Commands.Delete;

public class DeleteUserCommandHandler : HandlerBase<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(
        IUserRepository userRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public override async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);

        if (user != null)
        {
            if (user.RoleId == (int)Roles.Administrator)
            {
                throw new BadRequestException("You cannot remove Administrator");
            }

            _userRepository.Remove(user);
            await UnitOfWork.CommitAsync(cancellationToken);
        }

        return Unit.Value;
    }
}
