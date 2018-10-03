using System;
using System.Threading;
using FluentAssertions.Execution;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class GrossIncomeCalculatorTests
    {
        private readonly GrossIncomeCalculator _grossIncomeCalculator;

        public GrossIncomeCalculatorTests()
        {
            _grossIncomeCalculator = new GrossIncomeCalculator();
        }

        [Theory]
        [InlineData(18201, 1517)]
        [InlineData(37001, 3083)]
        [InlineData(60050, 5004)]
        [InlineData(87001, 7250)]
        [InlineData(180001, 15000)]
        public void GivenAnnualSalaryThenReturnGrossIncome(decimal annualSalary, decimal expected)
        {
            var result = _grossIncomeCalculator.GetGrossIncome(annualSalary);
            
            Assert.Equal(expected,result);
        }

        [Fact]
        public void GivenANotValidAnnualSalaryThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => _grossIncomeCalculator.GetGrossIncome(-1));
        }

        
    }
}