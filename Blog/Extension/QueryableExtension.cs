using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Blog.Extension
{
    public static class QueryableExtension
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source.Take(0);
            }

            string command = "OrderBy";

            if (orderBy[0] == '-')
            {
                command = "OrderByDescending";
                command = orderBy.Substring(1);
            }

            var type = typeof(TEntity);
            var property = type.GetProperty(orderBy);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}