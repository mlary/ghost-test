using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using GhostProject.App.Core.Models.Primitives;

namespace GhostProject.App.Core.Common.Abstractions.DataAccess;

public interface ISpecification<T> where T : class
{
    Expression<Func<T, bool>> Predicate { get; }

    IList<Expression<Func<T, object>>> Includes { get; }

    IList<string> IncludeStrings { get; }

    IList<(Expression<Func<T, object>> expression, EnumSortTypes sortType)> OrderByExpressions { get; }

    [DefaultValue(-1)]
    int TakeAmount { get; }

    [DefaultValue(-1)]
    int SkipAmount { get; }

    ISpecification<T> And(Expression<Func<T, bool>> predicate);

    ISpecification<T> Or(Expression<Func<T, bool>> predicate);

    ISpecification<T> FilterBy(Expression<Func<T, bool>> predicate);

    ISpecification<T> Take(int amount);

    ISpecification<T> Skip(int amount);

    ISpecification<T> AddInclude(Expression<Func<T, object>> includeExpression);

    ISpecification<T> AddInclude(params string[] includeStrings);

    ISpecification<T> OrderBy(
        Expression<Func<T, object>> expression,
        EnumSortTypes sortType = EnumSortTypes.Asc);

    [DefaultValue(false)]
    bool IgnoreQueryFiltersFlag { get; }

    ISpecification<T> IgnoreQueryFilters();
}
