using System;
using static PaySlipVeeTwo.ExceptionHelpers;

namespace ExtensionMethods
{
    public static class RoundingHelper
    {
        public static decimal Rounds(this decimal number)
        {
            ChecksIfNegativeDecimal(number);
            return Math.Round(number, MidpointRounding.AwayFromZero);
        }
    }
}