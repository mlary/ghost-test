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
        builder.Append($"<h2>Hi There,</h2>");
        builder.Append(@"<div>Thank you for providing a rating for your recruiter/interviewer. 
There's just one more step: please click the link below to confirm.</div>");
        builder.Append("<br>");
        builder.Append($"<p><a href=\"{confirmationUrl}\" target=\"_blank\">CONFIRM YOUR RATING</a><p>");
        builder.Append("<br>");
        builder.Append($"<p>Thank you,<p>");
        builder.Append($"<p>Ghost Lookup Team<p>");
        
        return builder.ToString();
    }
}
