using System;
using System.Linq;
using PaySlipVeeTwo;
using static PaySlipVeeTwo.ExceptionHelpers;

namespace PaySlipVeeToo
{
    public class TaxTableParser 
    {
        private readonly TaxTable _taxTable;

        public TaxTableParser(ITaxTable getTaxBracket)
        {
            _taxTable = getTaxBracket.GetTaxTable();

        }

        public TaxBracket GetCorrectTaxBracket(decimal annualSalary)
        {
            CheckIfAnnualSalaryIsValid(annualSalary);
            return  _taxTable.TaxBrackets.Where(x => x.AnnualIncomeThreshold <= annualSalary).OrderByDescending(x => x.AnnualIncomeThreshold).First();
        }
    }
}