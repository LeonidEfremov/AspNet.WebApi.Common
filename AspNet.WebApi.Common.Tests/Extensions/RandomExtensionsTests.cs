using AspNet.WebApi.Common.Extensions;
using AspNet.WebApi.Common.Helpers;
using System;
using Xunit;

namespace AspNet.WebApi.Common.Tests.Extensions
{
    public class RandomExtensionsTests
    {
        [Fact]
        public void RandomDoubleNext()
        {
            var random = RandomHelper.Random;

            var minValue = Convert.ToDouble(0.1);
            var maxValue = Convert.ToDouble(1.5);

            var actual = random.Next(minValue, maxValue);

            Assert.True(actual <= maxValue);
            Assert.True(actual >= minValue);
        }
    }
}
