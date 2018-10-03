using ExtensionMethods;
using PaySlipVeeTwo;

namespace PaySlipVeeToo.Test
{
    public class IncomeTaxCalculator
    {
        public decimal GetIncomeTax(decimal annualSalary)
        {
            var getTaxBracket = new TaxTableParser(new JSONFileReader());
            var additionalTax = getTaxBracket.ReturnCorrectTaxBracket(annualSalary).AdditionalTax;
            var annualIncomeThreshold = getTaxBracket.ReturnCorrectTaxBracket(annualSalary).AnnualIncomeThreshold;
            var taxRate = getTaxBracket.ReturnCorrectTaxBracket(annualSalary).TaxRate;
            var @decimal = (annualSalary - annualIncomeThreshold) * taxRate;
            var dec = @decimal + additionalTax;
                
            return (dec/12).Rounds(); 
            
        }
    }
}