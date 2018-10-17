using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlipVeeTwo
{
    public class JSONFileReader:ITaxTable
    {
        
        public TaxTable DeserialiseJSON()
        {
            
            var filePath = "/Users/saish.dharvotkar/Projects/src/Katas/PaySlip_VEETOOOO/PaySlipVeeToo/PaySlipVeeTwo/Resources/TaxableIncomeBrackets.json";
            var streamReader = new StreamReader(filePath);
            var json = streamReader.ReadToEnd();
            TaxTable taxTable = JsonConvert.DeserializeObject<TaxTable>(json);

            return taxTable;
        }

        public TaxTable GetTaxTable()
        {
            return DeserialiseJSON();
        }
    }
}