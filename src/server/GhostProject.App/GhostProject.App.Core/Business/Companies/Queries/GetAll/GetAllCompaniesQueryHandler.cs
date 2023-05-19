using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Companies.Queries.GetAll;

public class GetAllCompaniesQueryHandler : HandlerBase<GetAllCompaniesQuery, CompanyDto[]>
{
    private readonly ICompanyRepository _companyRepository;

    public GetAllCompaniesQueryHandler(
        ICompanyRepository companyRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _companyRepository = companyRepository;
    }

    public override async Task<CompanyDto[]> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var result = await _companyRepository.GetAllAsync(cancellationToken, true);
        return Mapper.Map<CompanyDto[]>(result);
    }
}
