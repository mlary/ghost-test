using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Rates.Queries.GetById;

public class GetRateByIdQueryHandler : HandlerBase<GetRateByIdQuery, RateDto>
{
    private readonly IRateRepository _rateRepository;

    public GetRateByIdQueryHandler(
        IRateRepository rateRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _rateRepository = rateRepository;
    }

    public override async Task<RateDto> Handle(GetRateByIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _rateRepository.FindByIdAsync(request.RateId, cancellationToken, true);

        return Mapper.Map<RateDto>(result);
    }
}
