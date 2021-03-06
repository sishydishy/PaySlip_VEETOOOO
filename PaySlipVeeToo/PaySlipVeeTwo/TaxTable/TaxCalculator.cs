﻿using System.Net.NetworkInformation;
using ExtensionMethods;
using PaySlipVeeTwo;
using static PaySlipVeeTwo.ExceptionHelpers;

namespace PaySlipVeeToo
{
    public class TaxCalculator : ICalculator
    {
        public decimal GetMonthlyIncomeTax(decimal annualSalary)
        {
            var getTaxBracket = new TaxTableParser(new JSONFileReader());
            
            var additionalTax = getTaxBracket.GetCorrectTaxBracket(annualSalary).AdditionalTax;
            var annualIncomeThreshold = getTaxBracket.GetCorrectTaxBracket(annualSalary).AnnualIncomeThreshold;
            var taxRate = getTaxBracket.GetCorrectTaxBracket(annualSalary).TaxRate;
            
            var monthlyIncomeTax = CalculateMonthlyIncomeTax(annualSalary, annualIncomeThreshold, taxRate, additionalTax);

            return monthlyIncomeTax.Rounds(); 
            
        }

        public decimal GetGrossIncome(decimal annualSalary)
        {
            CheckIfAnnualSalaryIsValid(annualSalary);
            const int MONTHS_IN_A_YEAR = 12;
            var grossIncome = (annualSalary / MONTHS_IN_A_YEAR).Rounds();
            
            return grossIncome;
        }

        public decimal GetSuper(decimal annualSalary, string superRate)
        {
            var superRateInDecimal =CheckIfSuperRateIsWithinAcceptableRange(superRate);
            var grossIncome = GetGrossIncome(annualSalary);
            var super = (grossIncome * superRateInDecimal).Rounds();
            
            return super;
        }

        public decimal GetNetIncome(decimal annualSalary)
        {
            return GetGrossIncome(annualSalary) - GetMonthlyIncomeTax(annualSalary);
        }


        private static decimal CalculateMonthlyIncomeTax(decimal annualSalary, decimal annualIncomeThreshold, decimal taxRate,
            decimal additionalTax)
        {
            var taxedDisposableIncome = (annualSalary - annualIncomeThreshold) * taxRate;
            var yearlyIncomeTax = taxedDisposableIncome + additionalTax;
            var monthlyIncomeTax = yearlyIncomeTax / 12;
            return monthlyIncomeTax;
        }
    }
}