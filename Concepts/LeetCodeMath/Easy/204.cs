using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _204
    {
        public static void _204Main()
        {

            _204 Test = new _204();
            var test = Test.IsPrimeNumber(10);
            Console.ReadLine();
        }

        /// <summary>
        //! Sieve of erithothenis algorithms 
        //!  Thought process: 
        //!  Assume all the numbers <Given numbers are prime numbers 
        //!  Starting from 2 , make multiples of them(2*2,2*3,2*4.....) non-prime till i*i<GivenPrimeNumber.   
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes0(int n)
        {
            bool[] primeNumbers = new bool[n];

            Initialize(primeNumbers);

            //! Take multiple 
            for (int i = 2; i * i < primeNumbers.Length; ++i) //!optimization i * i 
            {
                if (primeNumbers[i])  //! Optimization
                {
                    for (int j = 2; i * j < primeNumbers.Length; ++j)
                    {
                        primeNumbers[i * j] = false;
                    }
                }
            }

            return Prepare(primeNumbers);
        }

        private int Prepare(bool[] primeNumbers)
        {
            int primeNumbersCount = 0;
            for (int i = 2; i < primeNumbers.Length; ++i)
            {
                if (primeNumbers[i])
                {
                    ++primeNumbersCount;
                }
            }
            return primeNumbersCount;
        }

        private void Initialize(bool[] primeNumbers)
        {
            //! Assume all the numbers are the prime numbers 
            for (int i = 0; i < primeNumbers.Length; ++i)
            {
                primeNumbers[i] = true;
            }
        }

        /// <summary>
        //! Using trial division method
        //! Divide number by <= √ of it starting from 2. If divisble, then its not prime number
        //! e.g. 100 try divide it by 2,3,4,5,6...till  10(√100) 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes(int n)
        {
            int primeNumbersCount = 0;
            for (int i = 2; i < n; ++i)
            {
                if (IsPrimeNumber(i))
                {
                    ++primeNumbersCount;
                }
            }

            return primeNumbersCount;
        }

        private bool IsPrimeNumber(int n)
        {
            int sqrt = (int)Math.Sqrt(n);

            for (int i = 2; i <= sqrt; ++i)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
