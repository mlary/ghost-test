using System;
using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.DataAccess.Common;
using Microsoft.EntityFrameworkCore;

namespace GhostProject.App.DataAccess.Repositories
{
    public class RateRepository : BaseRepository<Rate, int>, IRateRepository
    {
        private readonly AppDbContext _dbContext;

        public RateRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rate> GetByConfirmationIdAsync(Guid confirmationId, CancellationToken cancellationToken) =>
            await _dbContext.Rates.FirstOrDefaultAsync(x => x.ConfirmationId == confirmationId, cancellationToken);

        public async Task<Rate[]> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Rates.Include(x => x.Recruiter)
                .Include(x => x.Company).ToArrayAsync(cancellationToken);
        }
    }
}
