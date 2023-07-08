using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Users.Queries.GetById;

public class GetUserByIdQueryHandler : HandlerBase<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(
        mapper, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public override async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);
        return Mapper.Map<UserDto>(user);
    }
}
