using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using MediatR;

namespace GhostProject.App.Core.Business.Companies.Commands.Delete;

public class DeleteCompanyCommandHandler : HandlerBase<DeleteCompanyCommand, Unit>
{
    private readonly ICompanyRepository _companyRepository;

    public DeleteCompanyCommandHandler(
        ICompanyRepository companyRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _companyRepository = companyRepository;
    }

    public override async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.FindByIdAsync(request.Id, cancellationToken);
        if (company != null)
        {
            _companyRepository.Remove(company);
            await UnitOfWork.CommitAsync(cancellationToken);
        }

        return Unit.Value;
    }
}
