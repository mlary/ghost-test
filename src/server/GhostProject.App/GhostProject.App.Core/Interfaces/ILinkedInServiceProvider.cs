using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Models;

namespace GhostProject.App.Core.Interfaces;

public interface ILinkedInServiceProvider
{
    public Task<LinkedInProfile> GetProfileAsync(string url, CancellationToken cancellationToken);
}
