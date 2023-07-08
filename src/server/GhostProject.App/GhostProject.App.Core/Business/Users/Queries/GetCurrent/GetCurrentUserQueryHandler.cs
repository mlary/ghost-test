using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Users.Queries.GetCurrent;

public class GetCurrentUserQueryHandler : HandlerBase<GetCurrentUserQuery, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetCurrentUserQueryHandler( IUserRepository userRepository, 
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public override async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FirstAsync(
            new SpecificationBuilder<User>().FilterBy(x => x.NormalizedEmail == request.Email),
            cancellationToken);

        return Mapper.Map<UserDto>(user);
    }
}
