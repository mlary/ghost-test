using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.DataAccess.Common;
using Microsoft.EntityFrameworkCore;

namespace GhostProject.App.DataAccess.Repositories;

public class RecruiterRepository : BaseRepository<Recruiter, int>, IRecruiterRepository
{
    private readonly AppDbContext _dbContext;

    public RecruiterRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Recruiter> GetByProfileIdUrlAsync(string profileId, CancellationToken cancellationToken, bool asNoTracking = false)
    {
        var query = _dbContext.Recruiters.Where(x => x.LinkedInProfileId == profileId);
        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(cancellationToken);
    }
}
