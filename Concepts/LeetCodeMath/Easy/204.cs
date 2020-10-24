using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _204
    {



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

            //! Assume all the numbers are the prime numbers 
            for (int i = 0; i < primeNumbers.Length; ++i)
            {
                primeNumbers[i] = true;
            }
            //! Take multiple 
            for (int i = 2; i * i < primeNumbers.Length; ++i)
            {
                if (primeNumbers[i])
                {
                    for (int j = 2; i * j < primeNumbers.Length; ++j)
                    {
                        primeNumbers[i * j] = false;
                    }
                }
            }
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


        /// <summary>
        //! Using trial division method
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
