using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Companies.Queries.GetByRecruiterId;

public class GetCompaniesByRecruiterIdQueryHandler : HandlerBase<GetCompaniesByRecruiterIdQuery, CompanyDto[]>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompaniesByRecruiterIdQueryHandler(
        ICompanyRepository companyRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _companyRepository = companyRepository;
    }

    public override async Task<CompanyDto[]> Handle(GetCompaniesByRecruiterIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _companyRepository.GetByRecruiterIdAsync(request.RecruiterId, cancellationToken);
        return Mapper.Map<CompanyDto[]>(result.DistinctBy(x => x.Id).Take(4).ToArray());
    }
}
