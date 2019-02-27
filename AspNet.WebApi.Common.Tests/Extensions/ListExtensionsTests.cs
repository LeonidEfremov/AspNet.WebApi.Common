using AspNet.WebApi.Common.Extensions;
using System.Collections.Generic;
using Xunit;

namespace AspNet.WebApi.Common.Tests.Extensions
{
    public class ListExtensionsTests
    {
        [Fact]
        public void RandomDoubleNext()
        {
            var list = new List<string> { "a", "B", "c", "D" };
            var actual = list.RandomElement();

            Assert.Contains(actual, list);
        }
    }
}
