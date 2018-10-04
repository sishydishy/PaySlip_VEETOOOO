using System.Linq;
using ExtensionMethods;
using static PaySlipVeeTwo.ExceptionHelpers;

namespace PaySlipVeeToo
{
    public class MinorIncomeCalculator : IMinorIncomeCalculator
    {
        public decimal GetGrossIncome(decimal annualSalary)
        {
            CheckIfAnnualSalaryIsValid(annualSalary);
            const int MONTHS_IN_A_YEAR = 12;
            var grossIncome = (annualSalary / MONTHS_IN_A_YEAR).Rounds();
            
            return grossIncome;
        }

        public decimal GetSuper(decimal annualSalary, string superRate)
        {
            var superRateInDecimal =CheckIfSuperRateIsWithinAcceptableRange(superRate);
            var grossIncome = GetGrossIncome(annualSalary);
            var super = (grossIncome * superRateInDecimal).Rounds();
            
            return super;
        }
    }
}