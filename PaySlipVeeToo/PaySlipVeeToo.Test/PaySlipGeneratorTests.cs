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
        
        [Fact]
        public void GivenCSVEmployeeDetailsWhenGeneratingGrossIncomeForPayPeriodThenReturnGrossIncome()
        {
            var employeeDetails = _csvFileReader.GetEmployeeDetails();
            var annualSalary = employeeDetails[0].AnnualSalary;
            var result = _calculator.GetGrossIncome(annualSalary);
            
            Assert.Equal(5004, result);
        }
        
        [Fact]
        public void GivenCSVEmployeeDetailsWhenGeneratingSuperRateForPayPeriodThenReturnSuper()
        {
            var employeeDetails = _csvFileReader.GetEmployeeDetails();
            var paySlipGenerator = new PaySlipGenerator();
            var result = paySlipGenerator.GetPaySlipDetails(employeeDetails[0]);
            var annualSalary = employeeDetails[0].AnnualSalary;
            var superRate = employeeDetails[0].SuperRate;
            var result = _calculator.GetSuper(annualSalary, superRate);
            
            Assert.Equal(450, result);
        }
    }
}