using System.Net.NetworkInformation;
using ExtensionMethods;
using PaySlipVeeTwo;
using static PaySlipVeeTwo.ExceptionHelpers;

namespace PaySlipVeeToo
{
    public class IncomeTaxCalculator : ICalculator
    {
        public decimal GetMonthlyIncomeTax(decimal annualSalary)
        {
            var getTaxBracket = new TaxTableParser(new JSONFileReader());
            
            var additionalTax = getTaxBracket.ReturnCorrectTaxBracket(annualSalary).AdditionalTax;
            var annualIncomeThreshold = getTaxBracket.ReturnCorrectTaxBracket(annualSalary).AnnualIncomeThreshold;
            var taxRate = getTaxBracket.ReturnCorrectTaxBracket(annualSalary).TaxRate;
            
            var monthlyIncomeTax = CalculateMonthlyIncomeTax(annualSalary, annualIncomeThreshold, taxRate, additionalTax);

            return monthlyIncomeTax.Rounds(); 
            
        }

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


        private static decimal CalculateMonthlyIncomeTax(decimal annualSalary, decimal annualIncomeThreshold, decimal taxRate,
            decimal additionalTax)
        {
            var taxedDisposableIncome = (annualSalary - annualIncomeThreshold) * taxRate;
            var yearlyIncomeTax = taxedDisposableIncome + additionalTax;
            var monthlyIncomeTax = yearlyIncomeTax / 12;
            return monthlyIncomeTax;
        }
    }
}