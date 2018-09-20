using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaySlipVeeTwo
{
    public class JSONFileReader
    {
        
        public List<TaxBracket> DeserialiseJSON()
        {
            
            var filePath =
                "/Users/saish.dharvotkar/Projects/src/Katas/PaySlip_VEETOOOO/PaySlipVeeToo/PaySlipVeeTwo/Resources/TaxableIncomeBrackets.json";
            var streamReader = new StreamReader(filePath);
            var json = streamReader.ReadToEnd();
            var taxTable = JsonConvert.DeserializeObject<List<TaxBracket>>(json);

            return taxTable;


        }
    }
}