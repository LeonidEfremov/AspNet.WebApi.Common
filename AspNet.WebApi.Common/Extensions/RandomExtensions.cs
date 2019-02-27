using System;

namespace AspNet.WebApi.Common.Extensions
{
    /// <summary>Global String extension.</summary>
    public static class RandomExtensions
    {
        /// <summary>Returns a random double that is within a specified range.</summary>
        /// <param name="value"><see cref="Random"/> instance.</param>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A double greater than or equal to minValue and less than maxValue.</returns>
        public static double Next(this Random value, double minValue, double maxValue)
        {
            var min = Convert.ToInt32(minValue * 100.0);
            var max = Convert.ToInt32(maxValue * 100.0);

            return Convert.ToDouble(value.Next(min, max) / 100.0);
        }
    }
}