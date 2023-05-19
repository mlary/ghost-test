using System;

namespace GhostProject.App.Core.Interfaces;

public interface IEmailTemplateBuilder
{
    public string CreateRateConfirmation(string email, int rateId, Guid confirmationId);
}
