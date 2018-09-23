using PaySlipVeeTwo;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class TaxableIncomeBracketLoaderTests
    {
        private readonly string _filePath;

        public TaxableIncomeBracketLoaderTests()
        {
            _filePath = "/Users/saish.dharvotkar/Projects/src/Katas/PaySlip_VEETOOOO/PaySlipVeeToo/PaySlipVeeTwo/Resources/TaxableIncomeBrackets.json";
        }


        [Fact]
        public void GivenJSONFileWhenParsingThenReturnHighestAnnualIncomeThreshold()
        {
            var jsonFileReader = new JSONFileReader();
            var result = jsonFileReader.DeserialiseJSON(_filePath)[4].AnnualIncomeThreshold;

            Assert.Equal(180001, result);
        }
        
        [Fact]
        public void GivenJSONFileWhenParsingThenReturnHighestAdditionalTax()
        {
            var jsonFileReader = new JSONFileReader();
            var result = jsonFileReader.DeserialiseJSON(_filePath)[4].AdditionalTax;

            Assert.Equal(54232, result);
        }

        [Fact]
        public void GivenJSONFileWhenParsingThenReturnHighestTaxRate()
        {
            var jsonFileReader = new JSONFileReader();
            var result = jsonFileReader.DeserialiseJSON(_filePath)[4].TaxRate;

            Assert.Equal(45, result);
        }
        
        [Fact]
        public void GivenJSONFileWhenParsingThenReturnNumberOfElementsInListOfTaxBrackets()
        {
            var jsonFileReader = new JSONFileReader();
            var result = jsonFileReader.DeserialiseJSON(_filePath).Count;

            Assert.Equal(5, result);
        }
    }
}