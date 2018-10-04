using Xunit;

namespace PaySlipVeeToo.Test
{
    public class CSVLoaderTests
    {
        [Fact]
        public void GivenCSVInputWhenParsingThenReturnEmployeeName()
        {
            var csvFileReader = new CSVFileReader();
            var employeeDetails = csvFileReader.GetEmployeeDetails();
            var result = employeeDetails[0].FullName;
            
            Assert.Equal("David Rudd", result);
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