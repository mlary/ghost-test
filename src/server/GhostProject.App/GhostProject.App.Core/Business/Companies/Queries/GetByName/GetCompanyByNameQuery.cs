using GhostProject.App.Core.Business.Companies.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Companies.Queries.GetByName;

public class GetCompanyByNameQuery : IRequest<CompanyDto>
{
    public string Name { get; }

    public GetCompanyByNameQuery(string name)
    {
        Name = name;
    }
}
