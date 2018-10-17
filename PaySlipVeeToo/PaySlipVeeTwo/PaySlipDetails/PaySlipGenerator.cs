using System;
using System.Collections.Generic;
using System.Threading;
using PaySlipVeeTwo;
using static System.Environment;

namespace PaySlipVeeToo
{
    public class PaySlipGenerator
    {
        private readonly IEmployeeDetails _employeeDetails;
        private readonly ICalculator _calculator;

        public PaySlipGenerator()
        {
            _employeeDetails = new CSVFileReader();
            _calculator = new TaxCalculator();
        }


        public void Execute()
        {
            Console.WriteLine("Welcome to the payslip generator!" + NewLine);

            Console.WriteLine("Payslip being generated from CSV ..." + NewLine);
            
            Thread.Sleep(3000);
            
            GetPaySlipDetails();
        }

        private void GetPaySlipDetails()
        {
            foreach (var employee in _employeeDetails.GetEmployeeDetails())
            {
                Console.WriteLine("Name: " + employee.FullName);
                Console.WriteLine("Pay Period: " + employee.PayPeriod);
                Console.WriteLine("Gross Income: " + _calculator.GetGrossIncome(employee.AnnualSalary));
                Console.WriteLine("Income Tax: " + _calculator.GetMonthlyIncomeTax(employee.AnnualSalary));
                Console.WriteLine("Net Income: " + _calculator.GetNetIncome(employee.AnnualSalary));
                Console.WriteLine("Super: " + _calculator.GetSuper(employee.AnnualSalary, employee.SuperRate) + NewLine);
            }
        }
    }
}