using System;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class MinorIncomeCalculatorTests
    {
        private readonly MinorIncomeCalculator _minorIncomeCalculator;

        public MinorIncomeCalculatorTests()
        {
            _minorIncomeCalculator = new MinorIncomeCalculator();
        }

        [Theory]
        [InlineData(18201, 1517)]
        [InlineData(37001, 3083)]
        [InlineData(60050, 5004)]
        [InlineData(87001, 7250)]
        [InlineData(180001, 15000)]
        public void GivenAnnualSalaryThenReturnGrossIncome(decimal annualSalary, decimal expected)
        {
            var result = _minorIncomeCalculator.GetGrossIncome(annualSalary);
            
            Assert.Equal(expected,result);
        }

        [Theory]
        [InlineData(18201, 152, "10%")]
        [InlineData(37001, 617, "20%")]
        [InlineData(60050, 1501, "30%")]
        [InlineData(87001, 2900, "40%")]
        [InlineData(180001, 7500, "50%")]
        public void GivenGrossIncomeWhenApplyingSuperRateThenReturnSuper(decimal annualSalary, decimal expected, string superRate)
        {
            var result = _minorIncomeCalculator.GetSuper(annualSalary, superRate);
            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(60050, "-1%")]
        [InlineData(60050, "55%")]
        public void GivenANotValidSuperRateThenThrowException(decimal annualSalary, string superRate)
        {
            Assert.Throws<ArgumentException>(() => _minorIncomeCalculator.GetSuper(annualSalary, superRate));
        }

        [Fact]
        public void GivenANotValidAnnualSalaryThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => _minorIncomeCalculator.GetGrossIncome(-1));
        }

        
    }
}