using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Rates.Queries.GetAll;

public class GetAllRatesQueryHandler : HandlerBase<GetAllRatesQuery, RateDto[]>
{
    private readonly IRateRepository _rateRepository;

    public GetAllRatesQueryHandler(IRateRepository rateRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _rateRepository = rateRepository;
    }

    public override async Task<RateDto[]> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    {
        var result = await _rateRepository.GetAllAsync(cancellationToken);
        return Mapper.Map<RateDto[]>(result);
    }
}
