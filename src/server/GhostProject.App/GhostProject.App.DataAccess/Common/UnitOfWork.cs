using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Common.Abstractions.DataAccess;

namespace GhostProject.App.DataAccess.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Implementation of IUnitOfWork

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
