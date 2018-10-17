using System;
using PaySlipVeeToo;

namespace PaySlipVeeTwo
{
    class Program
    {
        static void Main()
        {
            var paySlipGenerator = new PaySlipGenerator();
            
            paySlipGenerator.Execute();
        }
    }
}