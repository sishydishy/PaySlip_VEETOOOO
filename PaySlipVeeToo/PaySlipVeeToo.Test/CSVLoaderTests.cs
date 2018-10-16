using FluentAssertions;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class CSVLoaderTests
    {
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnNumberOfIndexes()
        {
            var csvFileReader = new CSVFileReader();
            var employeeDetails = csvFileReader.GetEmployeeDetails();
            var result = employeeDetails.Count;
            var expected = 2;
            
            expected.Should().Be(result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnEmployeeName()
        {
            var csvFileReader = new CSVFileReader();
            var employeeDetails = csvFileReader.GetEmployeeDetails();
            var result = employeeDetails[1].FullName;
            
            Assert.Equal("Ryan Chen", result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnAnnualSalary()
        {
            var csvFileReader = new CSVFileReader();
            var employeeDetails = csvFileReader.GetEmployeeDetails();
            var result = employeeDetails[0].AnnualSalary;
            
            Assert.Equal(60050, result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnSuperRate()
        {
            var csvFileReader = new CSVFileReader();
            var employeeDetails = csvFileReader.GetEmployeeDetails();
            var result = employeeDetails[0].SuperRate;
            
            Assert.Equal("9%", result);
        }
        
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnPayPeriod()
        {
            var csvFileReader = new CSVFileReader();
            var employeeDetails = csvFileReader.GetEmployeeDetails();
            var result = employeeDetails[0].PayPeriod;
            
            Assert.Equal("01 March – 31 March", result);
        }
    }
}