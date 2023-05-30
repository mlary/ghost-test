using GhostProject.App.Core.Business.Rates.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Rates.Queries.GetAll;

public class GetAllRatesQuery : IRequest<RateDto[]>
{
}
