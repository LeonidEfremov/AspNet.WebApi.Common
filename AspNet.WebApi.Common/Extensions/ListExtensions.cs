using System.Collections.Generic;
using System.Linq;
using AspNet.WebApi.Common.Helpers;

namespace AspNet.WebApi.Common.Extensions
{
    /// <summary>Global Lists extension.</summary>
    public static class ListExtensions
    {
        /// <summary>Return random element from list.</summary>
        /// <typeparam name="T">Type of enumeration.</typeparam>
        /// <param name="enumerable">Enumeration.</param>
        /// <returns>Enumeration element.</returns>
        public static T RandomElement<T>(this List<T> enumerable)
        {
            var position = RandomHelper.Random.Next(0, enumerable.Count);

            return enumerable.ElementAt(position);
        }
    }
}
