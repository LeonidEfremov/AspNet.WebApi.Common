using AspNet.WebApi.Common.Helpers;
using System.Linq;
using Xunit;

namespace AspNet.WebApi.Common.Tests.Helpers
{
    public class CountryManagerTests
    {
        [Fact]
        public void RegionNames()
        {
            var regionNamesCount = CountryHelper.Regions.Count;

            Assert.True(regionNamesCount > 240);
        }

        [Fact]
        public void GetBy2Letter()
        {
            var actual = CountryHelper.Regions["RU"];
            var expected = "RUS";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetBy3Letter()
        {
            var actual = CountryHelper.Regions.Single(_ => _.Value == "RUS").Key;
            var expected = "RU";

            Assert.Equal(expected, actual);
        }
    }
}
