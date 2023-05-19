using GhostProject.App.Core.Business.Rates.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Rates.Queries.GetById;

public class GetRateByIdQuery : IRequest<RateDto>
{
    public int RateId { get; }

    public GetRateByIdQuery(int rateId)
    {
        RateId = rateId;
    }
}
