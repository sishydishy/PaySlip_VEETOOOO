using PaySlipVeeTwo;
using Xunit;

namespace PaySlipVeeToo.Test
{
    public class TaxableIncomeBracketLoaderTests
    {
        private readonly JSONFileReader _jsonFileReader;

        public TaxableIncomeBracketLoaderTests()
        {
            _jsonFileReader = new JSONFileReader();
        }


        [Fact]
        public void GivenJSONFileWhenParsingThenReturnHighestAnnualIncomeThreshold()
        {
            var result = _jsonFileReader.GetTaxTable().TaxBrackets[4].AnnualIncomeThreshold;

            Assert.Equal(180001, result);
        }
        
        [Fact]
        public void GivenJSONFileWhenParsingThenReturnHighestAdditionalTax()
        {
            var result = _jsonFileReader.GetTaxTable().TaxBrackets[4].AdditionalTax;

            Assert.Equal(54232, result);
        }

        [Fact]
        public void GivenJSONFileWhenParsingThenReturnHighestTaxRate()
        {
            var result = _jsonFileReader.GetTaxTable().TaxBrackets[4].TaxRate;

            Assert.Equal((decimal) 0.45, result);
        }
        
        [Fact]
        public void GivenJSONFileWhenParsingThenReturnNumberOfElementsInListOfTaxBrackets()
        {
            var result = _jsonFileReader.GetTaxTable().TaxBrackets.Count;

            Assert.Equal(5, result);
        }
    }
}