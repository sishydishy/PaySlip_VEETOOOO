using System.Runtime.InteropServices;
using PaySlipVeeTwo;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class IncomeTaxCalculatorTests
    {

        [Theory]
        [InlineData(0, 0)]
        [InlineData(18201, 0)]
        [InlineData(40220, 385)]
        [InlineData(60050, 922)]
        [InlineData(180000, 4519)]
        public void GivenAnnualSalaryWhenApplyingTheRightTaxBracketThenReturnTheCorrectIncomeTax(decimal annualSalary, decimal expected)
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();
            var result = incomeTaxCalculator.GetMonthlyIncomeTax(annualSalary);
            
            Assert.Equal(expected, result);
        }
    }
}