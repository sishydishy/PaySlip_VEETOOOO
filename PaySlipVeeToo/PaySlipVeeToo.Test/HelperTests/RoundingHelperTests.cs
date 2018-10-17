using System;
using ExtensionMethods;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class RoundingHelperTests
    {
        [Theory]
        [InlineData(0.99999, 1)]
        [InlineData(0.5, 1)]
        [InlineData(0.4, 0)]
        [InlineData(0.55, 1)]
        public void GivenANumberWhenCalculatingThenRoundToTheNearestCorrectDollar(decimal number, decimal expected)
        {
            Assert.Equal(expected, number.Rounds());
        }

        [Fact]
        public void GivenANegativeNumberWhenCalculatingThenThrowException()
        {
            const decimal number = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => number.Rounds());
        }
    }
}