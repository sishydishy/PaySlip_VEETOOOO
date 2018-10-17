using System.Collections.Generic;

namespace PaySlipVeeTwo
{
    public class TaxTable
    {
        public List<TaxBracket> TaxBrackets { get; set; }
    }
    public class TaxBracket
    {
        public decimal AnnualIncomeThreshold { get; set; } 
        public decimal AdditionalTax { get; set; }
        public decimal TaxRate { get; set; }
    }
}