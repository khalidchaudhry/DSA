using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _1175
    {
        readonly int MOD = (int)Math.Pow(10, 9) + 7;
        public static void _1175Main()
        {
            _1175 PrimeNumbers = new _1175();
            var ans = PrimeNumbers.NumPrimeArrangements(1);
            Console.ReadLine();

        }



        /// <summary>
        /// https://leetcode.com/problems/prime-arrangements/discuss/371884/Simple-Java-With-comment-sieve_of_eratosthenes
        //! Thought process: 
        //! Calculate all the prime numbers up to the given number
        //! Permutations of prime numbers * Permutations of non-prime numbers give the result. 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumPrimeArrangements(int n)
        {         
            int primeNumbersCount = PrimeNumbersCount(n);
            // prime numbers are allowed to only shuffle in the prime positions            
            long primeNumberArrangements = Factorial(primeNumbersCount);
            // Non - prime numbers are allowed to only shuffle in the non-prime positions
            long nonPrimeNumberArrangements = Factorial(n - primeNumbersCount);
            long answer = primeNumberArrangements * nonPrimeNumberArrangements;

            return (int)(answer % MOD);
        }

        private long Factorial(int n)
        {
            long factorial = 1;
            while (n > 1)
            {
                factorial = factorial * n % MOD;
                n = n - 1;
            }

            return factorial;
        }

        /// <summary>
        //! Sieve of Erathosthenis algorithm
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int PrimeNumbersCount(int n)
        {
            int count = 0;
            bool[] primeNumbers = new bool[n + 1];

            for (int i = 0; i < primeNumbers.Length; ++i)
            {
                primeNumbers[i] = true;
            }

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

            for (int i = 2; i < primeNumbers.Length; ++i)
            {
                if (primeNumbers[i])
                {
                    ++count;
                }
            }


            return count;
        }
    }
}
