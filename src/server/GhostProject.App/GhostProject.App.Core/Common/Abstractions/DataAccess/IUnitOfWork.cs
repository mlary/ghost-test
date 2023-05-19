using System.Threading;
using System.Threading.Tasks;

namespace GhostProject.App.Core.Common.Abstractions.DataAccess;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);

    void Commit();
}
