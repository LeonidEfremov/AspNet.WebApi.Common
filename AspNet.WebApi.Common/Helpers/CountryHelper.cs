using System.Collections.Generic;
using System.Globalization;

namespace AspNet.WebApi.Common.Helpers
{
    /// <summary>Country Helper.</summary>
    public static class CountryHelper
    {
        /// <summary>Map of 2/3 Letters Region Names.</summary>
        public static Dictionary<string, string> Regions { get; }

        static CountryHelper()
        {
            Regions = GetRegionNames();
        }

        private static Dictionary<string, string> GetRegionNames()
        {
            var map = new Dictionary<string, string>();
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var culture in cultures)
            {
                var region = new RegionInfo(culture.Name);
                map[region.TwoLetterISORegionName] = region.ThreeLetterISORegionName;
            }

            return map;
        }
    }
}
