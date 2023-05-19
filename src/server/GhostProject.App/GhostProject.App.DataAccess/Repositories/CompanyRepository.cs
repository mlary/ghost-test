using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.DataAccess.Common;
using Microsoft.EntityFrameworkCore;

namespace GhostProject.App.DataAccess.Repositories
{
    public class CompanyRepository : BaseRepository<Company, int>, ICompanyRepository
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> GetByLinkedInUrlAsync(string linkedInUrl, CancellationToken cancellationToken,
            bool asNoTracking = false)
        {
            var query = _dbContext.Companies.Where(x => x.LinkedInUrl == linkedInUrl);
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Company[]> GetByRecruiterIdAsync(int recruiterId, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Rates.Where(x => x.RecruiterId == recruiterId && x.CompanyId != null)
                .Include(x => x.Company)
                .Select(x => x.Company)
                .ToArrayAsync(cancellationToken);
            return result;
        }
    }
}
