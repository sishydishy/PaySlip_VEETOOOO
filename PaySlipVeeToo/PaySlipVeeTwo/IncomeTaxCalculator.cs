using System;
using System.Linq;
using PaySlipVeeTwo;

namespace PaySlipVeeToo.Test
{
    public class IncomeTaxCalculator 
    {
        private readonly TaxTable _taxTable;

        public IncomeTaxCalculator(ITaxTable getTaxBracket)
        {
            _taxTable = getTaxBracket.GetTaxTable();

        }

        public TaxBracket ReturnCorrectTaxBracket(decimal annualSalary)
        {
            CheckIfAnnualSalaryIsValid(annualSalary);
            return annualSalary > 180001 ? _taxTable.TaxBrackets[4] : _taxTable.TaxBrackets.Where(x => x.AnnualIncomeThreshold > annualSalary).OrderBy(x => x.AnnualIncomeThreshold).First();
        }

        private static void CheckIfAnnualSalaryIsValid(decimal annualSalary)
        {
            if (annualSalary < 0) throw new ArgumentException("Invalid Annual Salary");
            if (annualSalary < 0) throw new ArgumentOutOfRangeException(nameof(annualSalary));
        }
    }
}