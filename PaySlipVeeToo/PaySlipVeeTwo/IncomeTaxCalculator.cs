using ExtensionMethods;
using PaySlipVeeTwo;

namespace PaySlipVeeToo
{
    public class IncomeTaxCalculator
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