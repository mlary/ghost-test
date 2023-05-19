using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;

namespace GhostProject.App.Core.Business.Companies.Queries.GetById;

public class GetCompanyByIdQueryHandler : HandlerBase<GetCompanyByIdQuery, CompanyDto>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyByIdQueryHandler(
        ICompanyRepository companyRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _companyRepository = companyRepository;
    }

    public override async Task<CompanyDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _companyRepository.FindByIdAsync(request.Id, cancellationToken);
        
        if (result == null)
        {
            throw new NotFoundException($"Company with Id {request.Id} was not found");
        }

        return Mapper.Map<CompanyDto>(result);
    }
}
