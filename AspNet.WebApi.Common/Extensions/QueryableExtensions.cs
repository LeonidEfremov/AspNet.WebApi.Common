using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNet.WebApi.Common.Extensions
{
    /// <summary>Queryable Extensions.</summary>
    public static class QueryableExtensions
    {
        /// <summary>Apply Where by condition.</summary>
        /// <typeparam name="T">Base Type.</typeparam>
        /// <param name="query">Query.</param>
        /// <param name="predicate">Predicate.</param>
        /// <param name="condition">Condition.</param>
        /// <returns><see cref="IQueryable{T}"/>.</returns>
        public static IQueryable<T> Where<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate, bool condition) => condition ? query.Where(predicate) : query;

        /// <summary>Apply paging.</summary>
        /// <typeparam name="T">Base Type.</typeparam>
        /// <param name="query">Query.</param>
        /// <param name="skipCount">Skip count.</param>
        /// <param name="takeCount">Take count.</param>
        /// <returns><see cref="IQueryable{T}"/>.</returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int takeCount) => query.Skip(skipCount).Take(takeCount);
    }
}
