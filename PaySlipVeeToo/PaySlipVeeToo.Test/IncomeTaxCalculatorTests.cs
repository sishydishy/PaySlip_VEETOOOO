using PaySlipVeeTwo;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class IncomeTaxCalculatorTests
    {

        [Fact]
        public void GivenAnnualSalaryWhenApplyingTheRightTaxBracketThenReturnTheCorrectIncomeTax()
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();
            var result = incomeTaxCalculator.GetIncomeTax(60050);
            
            Assert.Equal(922, result);
        }
    }
}