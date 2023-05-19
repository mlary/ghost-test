using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;

namespace GhostProject.App.Core.Business.Companies.Commands.Create;

public class CreateCompanyCommandHandler : HandlerBase<CreateCompanyCommand, CompanyDto>
{
    private readonly ICompanyRepository _companyRepository;

    public CreateCompanyCommandHandler(
        ICompanyRepository companyRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _companyRepository = companyRepository;
    }

    public override async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _companyRepository.GetByLinkedInUrlAsync(request.LinkedInUrl, cancellationToken);
        if (result != null)
        {
            throw new BadRequestException("Company with the linkedIn profile already exists");
        }

        var company = Mapper.Map<Company>(request);
        await _companyRepository.AddAsync(company, cancellationToken);

        await UnitOfWork.CommitAsync(cancellationToken);

        return Mapper.Map<CompanyDto>(company);
    }
}
