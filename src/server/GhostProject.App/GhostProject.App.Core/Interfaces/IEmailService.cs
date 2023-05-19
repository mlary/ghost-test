using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Models;

namespace GhostProject.App.Core.Interfaces;

public interface IEmailService
{
    public Task<bool> SendAsync(EmailRequest request, CancellationToken cancellationToken);
}
