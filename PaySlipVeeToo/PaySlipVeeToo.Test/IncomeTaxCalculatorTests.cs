using Xunit;

namespace PaySlipVeeToo.Test
{
    public class IncomeTaxCalculatorTests
    {
        [Fact]
        public void GivenAnnualSalaryWhenApplyingTheRightTaxBracketThenReturnTheCorrectIncomeTax()
        {
            var incomeTaxCalculator = new IncomeTaxCalculator();
        }
    }
}