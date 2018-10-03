using System;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class IncomeTaxCalculatorTests
    {
        private readonly IncomeTaxCalculator _incomeTaxCalculator;

        public IncomeTaxCalculatorTests()
        {
            _incomeTaxCalculator = new IncomeTaxCalculator();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(18201, 0)]
        [InlineData(40220, 385)]
        [InlineData(60050, 922)]
        [InlineData(180000, 4519)]
        public void GivenAnnualSalaryWhenApplyingTheRightTaxBracketThenReturnTheCorrectIncomeTax(decimal annualSalary, decimal expected)
        {
            var result = _incomeTaxCalculator.GetMonthlyIncomeTax(annualSalary);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenANotValidAnnualSalaryThenThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _incomeTaxCalculator.GetMonthlyIncomeTax(-1));
        }
    }
}