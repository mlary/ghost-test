using GhostProject.App.Core.Business.Rates.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Rates.Queries.GetByRecruiterId;

public class GetRatesByRecruiterIdQuery : IRequest<RateDto[]>
{
    public int RecruiterId { get; }

    public GetRatesByRecruiterIdQuery(int recruiterId)
    {
        RecruiterId = recruiterId;
    }
}
