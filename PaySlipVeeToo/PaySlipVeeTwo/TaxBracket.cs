using System.Collections.Generic;
using Newtonsoft.Json;

namespace PaySlipVeeTwo
{
    public class TaxTable
    {
        public List<TaxBracket> TaxBrackets { get; set; }
    }
    
    public class TaxBracket
    {
        [JsonProperty("AnnualIncomeThreshold")]
        public decimal AnnualIncomeThreshold { get; set; } 
        [JsonProperty("AdditionalTax")]
        public decimal AdditionalTax { get; set; }
        [JsonProperty("TaxRate")]
        public decimal TaxRate { get; set; }
    }
}