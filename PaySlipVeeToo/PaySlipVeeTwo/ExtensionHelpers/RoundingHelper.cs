using System;

namespace ExtensionMethods
{
    public static class RoundingHelper
    {
        public static decimal Rounds(this decimal number)
        {
            ChecksIfNegativeDecimal(number);
            return Math.Round(number, MidpointRounding.AwayFromZero);
        }

        private static void ChecksIfNegativeDecimal(decimal number)
        {
            if (number <= -1) throw new ArgumentOutOfRangeException(nameof(number));
        }
    }
}