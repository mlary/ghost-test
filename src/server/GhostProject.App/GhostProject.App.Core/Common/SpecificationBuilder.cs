using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Models.Primitives;

namespace GhostProject.App.Core.Common;

 public class SpecificationBuilder<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Predicate { get; private set; }

        public IList<Expression<Func<T, object>>> Includes { get; }
            = new List<Expression<Func<T, object>>>();

        public IList<string> IncludeStrings { get; }
            = new List<string>();

        public IList<(Expression<Func<T, object>> expression, EnumSortTypes sortType)> OrderByExpressions { get; } =
            new List<(Expression<Func<T, object>> expression, EnumSortTypes sortType)>();

        public int TakeAmount { get; private set; } = -1;
        public int SkipAmount { get; private set; } = -1;
        
        public bool IgnoreQueryFiltersFlag { get; private set; }

        public ISpecification<T> And(Expression<Func<T, bool>> predicate)
        {
            if (Predicate == null)
            {
                Predicate = predicate;
            }
            else
            {
                var visitor = new ParameterReplaceVisitor()
                {
                    Target = predicate.Parameters[0],
                    Replacement = Predicate.Parameters[0],
                };
                var rewrittenRight = visitor.Visit(predicate.Body);
                var andExpression = Expression.AndAlso(Predicate.Body, rewrittenRight);
                Predicate = Expression.Lambda<Func<T, bool>>(andExpression, Predicate.Parameters);
            }

            return this;
        }

        public ISpecification<T> Or(Expression<Func<T, bool>> predicate)
        {
            if (Predicate == null)
            {
                Predicate = predicate;
            }
            else
            {
                var visitor = new ParameterReplaceVisitor()
                {
                    Target = predicate.Parameters[0],
                    Replacement = Predicate.Parameters[0],
                };
                var rewrittenRight = visitor.Visit(predicate.Body);
                var andExpression = Expression.OrElse(Predicate.Body, rewrittenRight);
                Predicate = Expression.Lambda<Func<T, bool>>(andExpression, Predicate.Parameters);
            }

            return this;
        }

        public ISpecification<T> FilterBy(Expression<Func<T, bool>> predicate)
        {
            if (Predicate == null)
            {
                Predicate = predicate;
            }
            else
            {
                var visitor = new ParameterReplaceVisitor()
                {
                    Target = predicate.Parameters[0],
                    Replacement = Predicate.Parameters[0],
                };
                var rewrittenRight = visitor.Visit(predicate.Body);
                var andExpression = Expression.AndAlso(Predicate.Body, rewrittenRight);
                Predicate = Expression.Lambda<Func<T, bool>>(andExpression, Predicate.Parameters);
            }

            return this;
        }

        public ISpecification<T> Take(int amount)
        {
            this.TakeAmount = amount;
            return this;
        }

        public ISpecification<T> Skip(int amount)
        {
            this.SkipAmount = amount;
            return this;
        }

        public ISpecification<T> AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
            return this;
        }

        public ISpecification<T> AddInclude(params string[] includeString)
        {
            foreach (var str in includeString)
            {
                IncludeStrings.Add(str);
            }

            return this;
        }

        public ISpecification<T> OrderBy(Expression<Func<T, object>> expression,
            EnumSortTypes sortType = EnumSortTypes.Asc)
        {
            OrderByExpressions.Add((expression, sortType));

            return this;
        }

        public ISpecification<T> IgnoreQueryFilters()
        {
            IgnoreQueryFiltersFlag = true;
            return this;
        }
    }
