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
        private readonly TaxTableParser _taxTableParser;

        public IncomeTaxTests()
        {
            _taxTableParser = new TaxTableParser(_jsonFileReader);
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void GivenAnnualSalaryWhenParsingThroughTaxBracketsThenReturnCorrectTaxBracket(object expected , decimal annualSalary)
        {
            var result = _taxTableParser.ReturnCorrectTaxBracket(annualSalary);

            expected.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void GivenInvalidAnnualSalaryWhenParsingThroughTaxBracketsThenReturnException()
        {
            Assert.Throws<ArgumentException>(() => _taxTableParser.ReturnCorrectTaxBracket(-1));
        }
        
        

        public static IEnumerable<object[]> GetData =>
            new[]
            {
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[0], 10},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[1], 18201},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[2], 60000},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[3], 160000},
                new object[] {_jsonFileReader.GetTaxTable().TaxBrackets[4], 250000},
                
            };


    }
    
}