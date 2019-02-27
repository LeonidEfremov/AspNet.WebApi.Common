using AspNet.WebApi.Common.Helpers;
using System;
using Xunit;

namespace AspNet.WebApi.Common.Tests.Helpers
{
    public class RandomizationTests
    {
        private enum Chars { A = 0, B, C }

        [Fact]
        public void Random()
        {
            var result = RandomHelper.Random;

            Assert.IsType<Random>(result);
        }

        [Fact]
        public void RandomBool()
        {
            var result = RandomHelper.GetBool();

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void RandomStringArray()
        {
            var length = 3;
            var result = RandomHelper.GetStringArray("mark", length);

            Assert.IsType<string[]>(result);
            Assert.Equal(1, result.Rank);
            Assert.Equal(length, result.Length);
        }

        [Fact]
        public void RandomFromEnum()
        {
            var result = RandomHelper.GetRandom<Chars>();

            Assert.IsType<Chars>(result);
        }
    }
}
