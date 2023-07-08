using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Users.Queries.GetAll;

public class GetAllUsersQueryHandler : HandlerBase<GetAllUsersQuery, UserDto[]>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public override async Task<UserDto[]> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return Mapper.Map<UserDto[]>(users);
    }
}
