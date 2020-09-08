using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specification
{
    public class BaseSpecificationcs<T> : ISpecification<T>
    {

        public BaseSpecificationcs()
        {

        }
        public BaseSpecificationcs(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get;  set; }

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc  { get; private set; }

        public int NumberOfRows { get;  set; }
        public int PageNumber { get;  set; }

        public bool IsPagingEnable { get; set; } = false;

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }
        
    }
}
