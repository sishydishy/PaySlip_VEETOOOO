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
        private readonly TaxTable _taxTable;

        public IncomeTaxTests()
        {
            _taxTable = new TaxTable(_jsonFileReader);
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void GivenAnnualSalaryWhenParsingThroughTaxBracketsThenReturnCorrectTaxBracket(object expected , decimal annualSalary)
        {
            var result = _taxTable.ReturnCorrectTaxBracket(annualSalary);

            expected.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void GivenInvalidAnnualSalaryWhenParsingThroughTaxBracketsThenReturnException()
        {
            Assert.Throws<ArgumentException>(() => _taxTable.ReturnCorrectTaxBracket(-1));
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