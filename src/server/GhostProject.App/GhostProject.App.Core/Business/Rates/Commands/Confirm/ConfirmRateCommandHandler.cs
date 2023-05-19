using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;
using MediatR;

namespace GhostProject.App.Core.Business.Rates.Commands.Confirm;

public class ConfirmRateCommandHandler : HandlerBase<ConfirmRateCommand, Unit>
{
    private readonly IRateRepository _rateRepository;

    public ConfirmRateCommandHandler(
        IRateRepository rateRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _rateRepository = rateRepository;
    }

    public override async Task<Unit> Handle(ConfirmRateCommand request, CancellationToken cancellationToken)
    {
        var rate = await _rateRepository.GetByConfirmationIdAsync(request.ConfirmationId, cancellationToken);
        if (rate == null)
        {
            throw new NotFoundException($"Rate with Id {request.ConfirmationId} was not found");
        }

        if (rate.IsConfirmed)
        {
            throw new BadRequestException("Your rate has already confirmed");
        }

        rate.IsConfirmed = true;
        await UnitOfWork.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
