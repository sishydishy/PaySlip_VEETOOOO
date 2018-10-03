using ExtensionMethods;
using static PaySlipVeeTwo.ExceptionHelpers;

namespace PaySlipVeeToo
{
    public class GrossIncomeCalculator
    {
        public decimal GetGrossIncome(decimal annualSalary)
        {
            CheckIfAnnualSalaryIsValid(annualSalary);
            const int MONTHS_IN_A_YEAR = 12;
            return (annualSalary / MONTHS_IN_A_YEAR).Rounds();
        }
    }
}