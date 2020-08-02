using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specification.SpecificationOperators
{
    //public static class AndSpecificationExtension
    //{
    //    public static Expression<Func<T, bool>> AndAlso<T>(
    //   this Expression<Func<T, bool>> left,
    //   Expression<Func<T, bool>> right)
    //    {
    //        var param = Expression.Parameter(typeof(T), "x");
    //        var body = Expression.AndAlso(
    //                Expression.Invoke(left, param),
    //                Expression.Invoke(right, param)
    //            );
    //        var lambda = Expression.Lambda<Func<T, bool>>(body, param);
    //        return lambda;
    //    }
    //}

    public static class AndSpecificationExtension
    {
        //Error
        // public static Expression<Func<T, bool>> AndAlso<T>(
        //this ISpecification<T> left,
        //ISpecification<T> right )
        // {
        //     var param = Expression.Parameter(typeof(T), "x");        
        //     var body =  Expression.AndAlso(left.Criteria.Body, right.Criteria.Body);


        //     var lambda = Expression.Lambda<Func<T, bool>>(body, param);
        //     return lambda;
        // }

        //  public static Expression<Func<T, bool>> AndAlso<T>(
        // this ISpecification<T> left,
        //ISpecification<T> right)
        //  {
        //      var param = Expression.Parameter(typeof(T), "x");
        //      var body = Expression.AndAlso(
        //              Expression.Invoke(left.Criteria, left.Criteria.Parameters[0]),
        //              Expression.Invoke(right.Criteria, right.Criteria.Parameters[0])
        //          );
        //      var lambda = Expression.Lambda<Func<T, bool>>(body, param);
        //      return lambda;
        //  }

        public static Expression<Func<T, bool>> AndAlso<T>(
this ISpecification<T> expr1,
ISpecification<T> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var exprBody = Expression.OrElse(expr1.Criteria.Body, expr2.Criteria.Body);
             exprBody = (BinaryExpression)new ParameterReplacer(parameter).Visit(exprBody);
            return  Expression.Lambda<Func<T, bool>>(exprBody, parameter);

            //var body = Expression.AndAlso(expr1.Criteria.Body, expr2.Criteria.Body);
            //return Expression.Lambda<Func<T, bool>>(body, expr1.Criteria.Parameters[0]);
        }

        //// work
        //public static Expression<Func<T, bool>> AndAlso<T>(
        //this ISpecification<T> expr1,
        //ISpecification<T> expr2)
        //{
        //    var parameter = Expression.Parameter(typeof(T));

        //    var leftVisitor = new ReplaceExpressionVisitor(expr1.Criteria.Parameters[0], parameter);
        //    var left = leftVisitor.Visit(expr1.Criteria.Body);

        //    var rightVisitor = new ReplaceExpressionVisitor(expr2.Criteria.Parameters[0], parameter);
        //    var right = rightVisitor.Visit(expr2.Criteria.Body);

        //    return Expression.Lambda<Func<T, bool>>(
        //        Expression.AndAlso(left, right), parameter);


        //    //var body = Expression.AndAlso(expr1.Criteria.Body, expr2.Criteria.Body);
        //    //return Expression.Lambda<Func<T, bool>>(body, expr1.Criteria.Parameters[0]);
        //}

        // Error
        //public static Expression<Func<T, bool>> AndAlso<T>(
        //this ISpecification<T> expr1,
        //ISpecification<T> expr2)
        //{
        //    var parameter = Expression.Parameter(typeof(T),"x");


        //    return Expression.Lambda<Func<T, bool>>(
        //        Expression.AndAlso(expr1.Criteria.Body, expr2.Criteria.Body), expr1.Criteria.Parameters[0]);

        //}



    }
}
