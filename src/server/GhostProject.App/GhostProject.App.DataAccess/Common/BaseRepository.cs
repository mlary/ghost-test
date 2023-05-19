using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Models.Primitives;
using Microsoft.EntityFrameworkCore;

namespace GhostProject.App.DataAccess.Common;

public abstract class BaseRepository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
{
    private readonly DbContext _dbContext;

    protected BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region Implementation of IRepository<T,Tkey>

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(entity, cancellationToken);
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }

    public async Task<T> FindByIdAsync(TKey id, CancellationToken cancellationToken, bool noTracking = false)
    {
        var result = await _dbContext.FindAsync<T>(new object[] { id }, cancellationToken);
        if (noTracking && result!=null)
        {
            _dbContext.Entry(result).State = EntityState.Detached;
        }

        return result;
    }

    public async Task<T[]> GetAllAsync(CancellationToken cancellationToken, bool noTracking = false)
    {
        var queryableResult = _dbContext.Set<T>().AsQueryable();
        queryableResult = noTracking ? queryableResult.AsNoTracking() : queryableResult;

        return await queryableResult.ToArrayAsync(cancellationToken);
    }

    public void Remove(T entity)
    {
        _dbContext.Remove(entity);
    }

    public async Task<T[]> GetAsync(ISpecification<T> specification = null, bool noTracking = false)
    {
        IQueryable<T> query = ApplySpecification(specification);
        query = noTracking ? query.AsNoTracking() : query;
        return await query.ToArrayAsync();
    }

    public async Task<T[]> GetAsync(ISpecification<T> specification, CancellationToken cancellationToken,
        bool noTracking = false)
    {
        return await GetAsync(specification, x => x, cancellationToken, noTracking);
    }

    public async Task<TEntity[]> GetAsync<TEntity>(ISpecification<T> specification,
        Expression<Func<T, TEntity>> selector, CancellationToken cancellationToken,
        bool noTracking = false)
    {
        IQueryable<T> query = ApplySpecification(specification);
        query = noTracking ? query.AsNoTracking() : query;
        return await query.Select(selector).ToArrayAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken,
        bool noTracking = false)
    {
        IQueryable<T> query = ApplySpecificationCount(specification);
        return await query.CountAsync(cancellationToken);
    }

    public async Task<T> FirstAsync(ISpecification<T> specification, CancellationToken cancellationToken,
        bool noTracking = false)
    {
        return await FirstAsync(specification, x => x, cancellationToken, noTracking);
    }

    public async Task<TEntity> FirstAsync<TEntity>(ISpecification<T> specification,
        Expression<Func<T, TEntity>> selector, CancellationToken cancellationToken,
        bool noTracking = false)
    {
        IQueryable<T> query = ApplySpecification(specification);
        query = noTracking ? query.AsNoTracking() : query;
        return await query.Select(selector).FirstOrDefaultAsync(cancellationToken);
    }

    private IQueryable<T> ApplySpecificationCount(ISpecification<T> specification)
    {
        IQueryable<T> query = GetQuery();
        if (specification != null)
        {
            if (specification.Predicate != null)
            {
                query = query.Where(specification.Predicate);
            }

            if (specification.Includes?.Count > 0)
            {
                foreach (var include in specification.Includes)
                {
                    query = query.Include(include);
                }
            }

            if (specification.IncludeStrings?.Count > 0)
            {
                foreach (var include in specification.IncludeStrings)
                {
                    query = query.Include(include);
                }
            }
        }

        return query;
    }

    public async Task<int> CountAsync(ISpecification<T> specification = null)
    {
        IQueryable<T> query = ApplySpecificationCount(specification);
        return await query.CountAsync();
    }

    #endregion

    protected IQueryable<T> GetQuery()
    {
        return _dbContext.Set<T>();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        IQueryable<T> query = GetQuery();
        if (specification == null)
        {
            return query;
        }

        if (specification.Predicate != null)
        {
            query = query.Where(specification.Predicate);
        }

        if (specification.Includes?.Count > 0)
        {
            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }
        }

        if (specification.IncludeStrings?.Count > 0)
        {
            foreach (var include in specification.IncludeStrings)
            {
                query = query.Include(include);
            }
        }

        if (specification.SkipAmount >= 0)
        {
            query = query.Skip(specification.SkipAmount);
        }

        if (specification.TakeAmount >= 0)
        {
            query = query.Take(specification.TakeAmount);
        }

        if (specification.OrderByExpressions?.Count > 0)
        {
            foreach (var order in specification.OrderByExpressions)
            {
                query = order.sortType switch
                {
                    EnumSortTypes.Desc => query.OrderByDescending(order.expression),
                    _ => query.OrderBy(order.expression)
                };
            }
        }

        if (specification.IgnoreQueryFiltersFlag)
        {
            query = query.IgnoreQueryFilters();
        }

        return query;
    }
}
