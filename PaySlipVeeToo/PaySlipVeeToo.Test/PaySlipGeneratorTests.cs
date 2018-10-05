using Xunit;

namespace PaySlipVeeToo.Test
{
    public class PaySlipGeneratorTests
    {
        private readonly ICalculator _calculator;
        private readonly CSVFileReader _csvFileReader;

        public PaySlipGeneratorTests()
        {
            _calculator = new IncomeTaxCalculator();
            _csvFileReader = new CSVFileReader();
        }
        [Fact]
        public void GivenCSVEmployeeDetailsWhenGeneratingIncomeTaxForPayPeriodThenReturnIncomeTax()
        {
            var employeeDetails = _csvFileReader.GetEmployeeDetails();
            var annualSalary = employeeDetails[0].AnnualSalary;
            var result = _calculator.GetMonthlyIncomeTax(annualSalary);
            
            Assert.Equal(922, result);
        }
        
    }
}