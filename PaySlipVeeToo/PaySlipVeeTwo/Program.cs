using System;
using PaySlipVeeToo;

namespace PaySlipVeeTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var paySlipGenerator = new PaySlipGenerator();
            
            paySlipGenerator.Execute();
        }
    }
}