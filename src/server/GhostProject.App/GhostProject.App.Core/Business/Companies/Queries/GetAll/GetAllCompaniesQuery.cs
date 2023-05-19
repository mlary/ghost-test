using GhostProject.App.Core.Business.Companies.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Companies.Queries.GetAll;

public class GetAllCompaniesQuery : IRequest<CompanyDto[]>
{
}
