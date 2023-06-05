using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Common;
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
        var specification = new SpecificationBuilder<Recruiter>();
        if (!string.IsNullOrEmpty(request.ProfileId))
        {
            specification.FilterBy(x => x.LinkedInProfileId == request.ProfileId);
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            var parameters = request.Name.Split(" ");
            foreach (var item in parameters)
            {
                specification.Or(x => x.NormalizedRecruiterName.Contains(item.ToUpper()));
            }
        }

        var result = await _recruiterRepository.GetAsync(specification, cancellationToken, true);

        return Mapper.Map<RecruiterDto[]>(result);
    }
}
