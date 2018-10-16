using PaySlipVeeTwo;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class PaySlipDetailsTests
    {
        private readonly ICalculator _calculator;
        private readonly IEmployeeDetails _csvFileReader;

        public PaySlipDetailsTests()
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
            var annualSalary = employeeDetails[0].AnnualSalary;
            var superRate = employeeDetails[0].SuperRate;
            var result = _calculator.GetSuper(annualSalary, superRate);
            
            Assert.Equal(450, result);
        }
    }
}