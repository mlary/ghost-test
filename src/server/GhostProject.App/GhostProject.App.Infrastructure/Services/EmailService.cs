using GhostProject.App.Core.Common;
using GhostProject.App.Core.Interfaces;
using GhostProject.App.Core.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace GhostProject.App.Infrastructure.Services;

public class EmailService: IEmailService
{
    private readonly MailSettings _mailSettings;

    public EmailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value ?? throw new ArgumentNullException(nameof(mailSettings));
    }
    public async Task<bool> SendAsync(EmailRequest request, CancellationToken cancellationToken)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.AddRange(request.Addresses.Select(MailboxAddress.Parse).ToArray());
        email.Subject = request.Subject;
        var builder = new BodyBuilder
        {
            HtmlBody = request.Body 
        };  

        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        
        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls, cancellationToken);
        await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password, cancellationToken);
        await smtp.SendAsync(email, cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
        return true;
    }
}
