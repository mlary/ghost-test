using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;

namespace GhostProject.App.Core.Business.Recruiters.Queries.GetByLinkedInLink;

public class GetRecruiterByLinkedInLinkQueryHandler : HandlerBase<GetRecruiterByLinkedInLinkQuery, RecruiterDto>
{
    private readonly IRecruiterRepository _recruiterRepository;

    public GetRecruiterByLinkedInLinkQueryHandler(
        IRecruiterRepository recruiterRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _recruiterRepository = recruiterRepository;
    }

    public override async Task<RecruiterDto> Handle(GetRecruiterByLinkedInLinkQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _recruiterRepository.FirstAsync(new SpecificationBuilder<Recruiter>()
            .FilterBy(x => x.LinkedInUrl == request.LinkedInUrl), cancellationToken);
        if (result == null)
        {
            throw new NotFoundException($"Recruiter with linkedId {request.LinkedInUrl} was not found");
        }

        return Mapper.Map<RecruiterDto>(result);
    }
}
