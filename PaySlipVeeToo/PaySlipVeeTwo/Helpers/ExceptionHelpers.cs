using System;

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
    }
}