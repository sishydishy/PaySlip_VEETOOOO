namespace PaySlipVeeToo
{
    public class EmployeeDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + " "+ LastName;

        public decimal AnnualSalary { get; set; }
        public string SuperRate { get; set; }
        public string PayPeriod { get; set; }
    }
}