using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;
using GhostProject.App.Core.Extensions;

namespace GhostProject.App.Core.Business.Users.Commands.Update;

public class UpdateUserCommandHandler : HandlerBase<UpdateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public override async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);
        Mapper.Map<User>(request);
        if (!string.IsNullOrEmpty(request.Password) && !string.IsNullOrEmpty(request.ConfirmPassword))
        {
            user.PasswordHash = request.Password.ToHashPassword();
        }

        var existingUser = await _userRepository.FirstAsync(new SpecificationBuilder<User>()
            .FilterBy(x => x.NormalizedEmail == request.Email.ToUpper() && x.Id != request.Id), cancellationToken);
        if (existingUser != null)
        {
            throw new BadRequestException("User with the same name already exists");
        }

        return Mapper.Map<UserDto>(user);
    }
}
