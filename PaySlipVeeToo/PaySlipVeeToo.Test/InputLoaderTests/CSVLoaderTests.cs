using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class CSVLoaderTests
    {
        private readonly CSVFileReader _csvFileReader;
        private readonly List<EmployeeDetails> _employeesDetails;

        public CSVLoaderTests()
        {
            _csvFileReader = new CSVFileReader();
            _employeesDetails = _csvFileReader.GetEmployeeDetails();
        }

        [Fact]
        public void GivenCSVInputWhenParsingThenReturnNumberOfIndexes()
        {
            var result = _employeesDetails.Count;
            var expected = 2;
            
            expected.Should().Be(result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnEmployeeName()
        {
            var result = _employeesDetails[1].FullName;
            
            Assert.Equal("Ryan Chen", result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnAnnualSalary()
        {
            var result = _employeesDetails[0].AnnualSalary;
            
            Assert.Equal(60050, result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnSuperRate()
        {
            var result = _employeesDetails[0].SuperRate;
            
            Assert.Equal("9%", result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnPayPeriod()
        {
            var result = _employeesDetails[0].PayPeriod;
            
            Assert.Equal("01 March – 31 March", result);
        }
    }
}