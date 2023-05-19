using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Rates.Queries.GetByRecruiterId;

public class GetRatesByRecruiterIdQueryHandler : HandlerBase<GetRatesByRecruiterIdQuery, RateDto[]>
{
    private readonly IRateRepository _rateRepository;

    public GetRatesByRecruiterIdQueryHandler(
        IRateRepository rateRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _rateRepository = rateRepository;
    }

    public override async Task<RateDto[]> Handle(GetRatesByRecruiterIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _rateRepository.GetAsync(
            new SpecificationBuilder<Rate>().FilterBy(x => x.RecruiterId == request.RecruiterId),
            cancellationToken, true);

        return Mapper.Map<RateDto[]>(result);
    }
}
