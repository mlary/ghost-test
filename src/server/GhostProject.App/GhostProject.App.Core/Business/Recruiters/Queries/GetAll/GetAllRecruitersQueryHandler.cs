using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Recruiters.Queries.GetAll;

public class GetAllRecruitersQueryHandler : HandlerBase<GetAllRecruitersQuery, RecruiterDto[]>
{
    private readonly IRecruiterRepository _recruiterRepository;

    public GetAllRecruitersQueryHandler(
        IRecruiterRepository recruiterRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _recruiterRepository = recruiterRepository;
    }

    public override async Task<RecruiterDto[]> Handle(GetAllRecruitersQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _recruiterRepository.GetAllAsync(cancellationToken, true);

        return Mapper.Map<RecruiterDto[]>(result);
    }
}
