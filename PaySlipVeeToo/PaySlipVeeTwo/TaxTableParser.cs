using System;
using System.Linq;
using PaySlipVeeTwo;

namespace PaySlipVeeToo
{
    public class TaxTableParser 
    {
        private readonly TaxTable _taxTable;

        public TaxTableParser(ITaxTable getTaxBracket)
        {
            _taxTable = getTaxBracket.GetTaxTable();

        }

        public TaxBracket ReturnCorrectTaxBracket(decimal annualSalary)
        {
            CheckIfAnnualSalaryIsValid(annualSalary);
            return  _taxTable.TaxBrackets.Where(x => x.AnnualIncomeThreshold <= annualSalary).OrderByDescending(x => x.AnnualIncomeThreshold).First();
        }

        private static void CheckIfAnnualSalaryIsValid(decimal annualSalary)
        {
            if (annualSalary < 0) throw new ArgumentException("Invalid Annual Salary");
            if (annualSalary < 0) throw new ArgumentOutOfRangeException(nameof(annualSalary));
        }
    }
}