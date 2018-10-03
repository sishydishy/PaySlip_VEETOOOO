using System;

namespace ExtensionMethods
{
    public static class RoundingHelper
    {
        public static decimal Rounds(this decimal num)
        {
            return Math.Round(num, MidpointRounding.AwayFromZero);
        }
    }
}