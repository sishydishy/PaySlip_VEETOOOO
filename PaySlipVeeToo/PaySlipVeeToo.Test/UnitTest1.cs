using System;
using PaySlipVeeTwo;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class TaxableIncomeBracketLoaderTests
    {
        [Fact]
        public void GivenJSONFileWhenParsingThenReturnNumberOfIncomeThresholds()
        {
            var jsonFileReader = new JSONFileReader();
            var result = jsonFileReader.DeserialiseJSON().Count;
               
           
                
            
            Assert.Equal(5, result );
        }

        [Fact]
        public void GivenJSONFileWhenParsingThenReturnHighestIncomeThreshold()
        {
            
            var jsonFileReader = new JSONFileReader();
            var result = jsonFileReader.DeserialiseJSON();
            


        }
    }
}