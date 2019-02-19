using System.Linq;
using AspNet.WebApi.Common.Extensions;
using Xunit;

namespace AspNet.WebApi.Common.Tests.Extensions
{
    public class QueryableExtensionsTests
    {
        [Fact]
        public void Where()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }.AsQueryable();

            var actual = data.Where(_ => _ < 5, true).ToArray();
            Assert.Equal(new[] { 1, 2, 3, 4, 0 }, actual);

            actual = data.Where(_ => _ < 5, false).ToArray();
            Assert.Equal(data, actual);
        }

        [Fact]
        public void PageBy()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }.AsQueryable();

            var actual = data.PageBy(1, 2).ToArray();
            Assert.Equal(new[] { 2, 3 }, actual);
        }
    }
}