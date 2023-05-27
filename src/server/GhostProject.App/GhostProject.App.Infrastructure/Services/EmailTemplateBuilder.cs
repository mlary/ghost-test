using System.Text;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace GhostProject.App.Infrastructure.Services;

public class EmailTemplateBuilder: IEmailTemplateBuilder
{
    private readonly ConfirmationSettings _confirmationSettings;

    public EmailTemplateBuilder(IOptions<ConfirmationSettings> confirmationSettings)
    {
        _confirmationSettings =
            confirmationSettings.Value ?? throw new ArgumentNullException(nameof(ConfirmationSettings));
    }
    public string CreateRateConfirmation(string email, int rateId, Guid confirmationId)
    {
        var confirmationUrl = $"{_confirmationSettings.RateConfirmationAddress}/{rateId}/{confirmationId}";
        var builder = new StringBuilder();
        builder.Append($"<h2>Please click the link to confirm</h2>");
        builder.Append($"<p><a href=\"{confirmationUrl}\" target=\"_blank\">Please confirm your request</a><p>");
        return builder.ToString();
    }
}
