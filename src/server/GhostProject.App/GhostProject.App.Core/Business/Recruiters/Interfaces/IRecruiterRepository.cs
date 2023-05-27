using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Common.Abstractions.DataAccess;

namespace GhostProject.App.Core.Business.Recruiters.Interfaces;

public interface IRecruiterRepository: IRepository<Recruiter, int>
{
    public Task<Recruiter> GetByProfileIdUrlAsync(string profileId, CancellationToken cancellationToken,
        bool asNoTracking = false);

}
