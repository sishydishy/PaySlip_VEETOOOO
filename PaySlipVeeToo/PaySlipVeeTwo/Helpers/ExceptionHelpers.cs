using System;
using System.Linq;

namespace PaySlipVeeTwo
{
    public static class ExceptionHelpers
    {
        public static void CheckIfAnnualSalaryIsValid(decimal annualSalary)
        {
            if (annualSalary < 0) throw new ArgumentException("Invalid Annual Salary");
            if (annualSalary < 0) throw new ArgumentOutOfRangeException(nameof(annualSalary));
        }

        public static void ChecksIfNegativeDecimal(decimal number)
        {
            if (number <= -1) throw new ArgumentOutOfRangeException($"Invalid {number}");
        }

        public static decimal CheckIfSuperRateIsWithinAcceptableRange(string superRate)
        {
            var superInDecimal = decimal.Parse(superRate.Split('%').First());
            if (superInDecimal <= -1 || superInDecimal >= 51)
            {
                throw new ArgumentException("Invalid SuperRate");
            }

            return superInDecimal/100;
        }
    }
}