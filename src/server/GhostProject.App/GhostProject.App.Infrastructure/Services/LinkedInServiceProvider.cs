using GhostProject.App.Core.Interfaces;
using GhostProject.App.Core.Models;

namespace GhostProject.App.Infrastructure.Services;

public class LinkedInServiceProvider : ILinkedInServiceProvider
{
    public Task<LinkedInProfile> GetProfileAsync(string url, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
