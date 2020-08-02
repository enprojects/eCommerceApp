using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class SpecificationEvaluater<Tentity>  where Tentity : BaseEntity
    {
     
        public static IQueryable<Tentity> GetQuery(IQueryable<Tentity> inputQuery, ISpecification<Tentity> spec)
        {
            var query = inputQuery;
           
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
             
            foreach (var item in spec.Includes)
            {
                query = query.Include(item);
            }
         
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDesc != null)
            {
                query = query.OrderBy(spec.OrderByDesc);
            }

            if (spec.IsPagingEnable)
            {
                query = query.Skip((spec.PageNumber - 1) * spec.NumberOfRows).Take(spec.NumberOfRows);
            }

            return query;

            #region test
            //var arr = new int[] { 1,2,3};
            //var res = arr.Aggregate<int,double>(4, (x, w) => x/w);

            //query = spec.Includes.Aggregate<Expression<Func<Tentity, object>>, IQueryable<Tentity>>(query, (current, include) =>
            //{
            //    var includedQuery = current.Include(include);
            //    return includedQuery;

            //});
            #endregion
        }
         
        public static IQueryable<Tentity> GetQuery(IQueryable<Tentity> inputQuery, Expression<Func<Tentity, bool>> expression)
        {
            var query = inputQuery;
            if (expression != null)
            {
                query = query.Where(expression);
            } 
            return query;
        }

        
    }
}
