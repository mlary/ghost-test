using GhostProject.App.Core.Business.Companies.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Companies.Queries.GetById;

public class GetCompanyByIdQuery : IRequest<CompanyDto>
{
    public int Id { get; }

    public GetCompanyByIdQuery(int id)
    {
        Id = id;
    }
}
