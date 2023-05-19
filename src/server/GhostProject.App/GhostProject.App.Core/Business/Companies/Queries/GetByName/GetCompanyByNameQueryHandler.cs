using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Extensions;

namespace GhostProject.App.Core.Business.Companies.Queries.GetByName;

public class GetCompanyByNameQueryHandler : HandlerBase<GetCompanyByNameQuery, CompanyDto>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyByNameQueryHandler(
        ICompanyRepository companyRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _companyRepository = companyRepository;
    }

    public override async Task<CompanyDto> Handle(GetCompanyByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await _companyRepository.FirstAsync(
            new SpecificationBuilder<Company>().FilterBy(x =>
                x.CompanyNormalizedName == request.Name.ToNormalizedCompanyName()), cancellationToken);

        return Mapper.Map<CompanyDto>(result);
    }
}
