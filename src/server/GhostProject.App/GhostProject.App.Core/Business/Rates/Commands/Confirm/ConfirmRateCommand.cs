using System;
using MediatR;

namespace GhostProject.App.Core.Business.Rates.Commands.Confirm;

public class ConfirmRateCommand: IRequest<Unit>
{
    public Guid ConfirmationId { get; }

    public ConfirmRateCommand(Guid confirmationId)
    {
        ConfirmationId = confirmationId;
    }
}
