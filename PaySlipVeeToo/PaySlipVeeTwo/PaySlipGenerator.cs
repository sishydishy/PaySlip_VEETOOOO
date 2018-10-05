namespace PaySlipVeeToo.Test
{
    public class PaySlipGenerator
    {
        private readonly ICalculator _calculator;
        private readonly CSVFileReader _csvFileReader;

        public PaySlipGenerator()
        {
            _calculator = new IncomeTaxCalculator();
            _csvFileReader = new CSVFileReader();
        }
        public PaySlipDetials GetPaySlipDetails(EmployeeDetails employeeDetail)
        {
            
            
        }
    }

    public class PaySlipDetials
    {
        public string FullName { get; set; }
        public string PayPeriod { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal Super { get; set; }
    }
}