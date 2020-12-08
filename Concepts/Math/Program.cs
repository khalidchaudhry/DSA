using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths
{
    class Program
    {
        static void Main(string[] args)
        {

            Prime p = new Prime();

            //var ans=p.PrimeUpToN(29);
            var ans = p.SieveOfEratosthenes(29);
            GCD gcd = new GCD();
            var ans2 = gcd.CalculateGCD(8, 12);


            Console.ReadLine();           
        }       
    }
}
