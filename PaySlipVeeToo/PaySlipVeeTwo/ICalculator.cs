namespace PaySlipVeeToo
{
    public interface ICalculator
    {
        decimal GetMonthlyIncomeTax(decimal annualSalary);
        decimal GetGrossIncome(decimal annualSalary);
        decimal GetSuper(decimal annualSalary, string superRate);
    }
}