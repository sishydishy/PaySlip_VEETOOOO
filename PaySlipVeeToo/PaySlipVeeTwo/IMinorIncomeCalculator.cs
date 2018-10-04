namespace PaySlipVeeToo
{
    public interface IMinorIncomeCalculator
    {
        decimal GetGrossIncome(decimal annualSalary);
        decimal GetSuper(decimal grossIncome, string superRate);
    }
}