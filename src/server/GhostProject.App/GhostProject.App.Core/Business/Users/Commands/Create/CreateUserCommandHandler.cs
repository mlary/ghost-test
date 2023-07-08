using System;
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

namespace GhostProject.App.Core.Business.Users.Commands.Create;

public class CreateUserCommandHandler : HandlerBase<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(
        IUserRepository userRepository, 
        IMapper mapper, 
        IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public override async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<User>(request);
        user.CreatedAt = DateTimeOffset.UtcNow;
        if (request.Password != request.ConfirmPassword)
        {
            throw new BadRequestException("Password does not match");
        }

        var existingUser = await _userRepository.FirstAsync(new SpecificationBuilder<User>()
            .FilterBy(x => x.NormalizedEmail == request.Email.ToUpper()), cancellationToken);
        if (existingUser != null)
        {
            throw new BadRequestException("User with the same name already exists");
        }
        user.PasswordHash = request.Password.ToHashPassword();
        await _userRepository.AddAsync(user, cancellationToken);

        await UnitOfWork.CommitAsync(cancellationToken);
        return Mapper.Map<UserDto>(user);
    }
}
