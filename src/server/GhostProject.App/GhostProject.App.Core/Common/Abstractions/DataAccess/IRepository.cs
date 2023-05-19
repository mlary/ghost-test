using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GhostProject.App.Core.Common.Abstractions.DataAccess;

public interface IRepository<T, in TKey> where T : BaseEntity<TKey>
{Task AddAsync(T entity, CancellationToken cancellationToken);

    void Add(T entity);

    Task<T> FindByIdAsync(TKey id, CancellationToken cancellationToken, bool noTracking = false);

    Task<T[]> GetAllAsync(CancellationToken cancellationToken, bool noTracking = false);

    void Remove(T entity);

    Task<T[]> GetAsync(ISpecification<T> specification = null, bool noTracking = false);

    Task<T[]> GetAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken,
        bool noTracking = false);

    Task<TEntity[]> GetAsync<TEntity>(
        ISpecification<T> specification,
        Expression<Func<T, TEntity>> selector,
        CancellationToken cancellationToken,
        bool noTracking = false);

    Task<int> CountAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken,
        bool noTracking = false);

    Task<T> FirstAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken,
        bool noTracking = false);

    Task<TEntity> FirstAsync<TEntity>(
        ISpecification<T> specification,
        Expression<Func<T, TEntity>> selector,
        CancellationToken cancellationToken,
        bool noTracking = false);

    Task<int> CountAsync(ISpecification<T> specification = null);
    
}
