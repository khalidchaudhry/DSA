using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _204
    {
        public int CountPrimes(int n)
        {
            bool[] primes = new bool[n];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i * i < primes.Length; i++)
            {
                if (primes[i])
                {
                    for (int j = 2; i * j < primes.Length; j++)
                    {
                        primes[i * j] = false;
                    }
                }
            }
            int primesCount = 0;

            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    ++primesCount;
                }
            }

            return primesCount;


        }

    }
}
