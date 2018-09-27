using System;
using System.Collections.Generic;
using System.Net;
using PaySlipVeeTwo;
using Xunit;
using FluentAssertions;

namespace PaySlipVeeToo.Test
{
    public class IncomeTaxTests
    {
        private static readonly JSONFileReader _jsonFileReader = new JSONFileReader();

        [Theory]
        [MemberData(nameof(GetData))]
        public void GivenAnnualSalaryWhenParsingThroughTaxBracketsThenReturnCorrectTaxBracket(object expected , decimal annualSalary)
        {
            var incomeTaxCalculator = new IncomeTaxCalculator(_jsonFileReader);
            var result = incomeTaxCalculator.ReturnCorrectTaxBracket(annualSalary);

            expected.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void GivenInvalidAnnualSalaryWhenParsingThroughTaxBracketsThenReturnException()
        {
            var incomeTaxCalculator = new IncomeTaxCalculator(_jsonFileReader);
            Assert.Throws<ArgumentException>(() => incomeTaxCalculator.ReturnCorrectTaxBracket(-1));
        }
        
        

        public static IEnumerable<object[]> GetData =>
            new[]
            {
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[1], 0},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[2], 25000},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[3], 60000},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[4], 160000},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[4], 250000},
                
            };


    }
    
}