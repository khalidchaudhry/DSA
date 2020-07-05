using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths
{
    class Prime
    {

        /// <summary>
        //! Time complexity =O(n√n)
        //! Space Complexity=O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PrimeUpToN(int n)
        {
            //prime numbers are 2,3,5,7..............
            if (n <= 1)
                return 0;

            int count = 0;
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    ++count;
                }
            }

            return count;
        }

        /// <summary>
        // !Using trial division method
        // https://www.youtube.com/watch?v=7VPA-HjjUmU      
        //! Time  Complexity=O(√n)
        //! Space complexity=O(1)
        /// </summary>
        /// <param name="n">Must be positive number</param>
        /// <returns></returns>
        public bool IsPrime(int n)
        {
            if (n == 2)
                return true;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(n));
            bool isPrime = true;
            for (int i = 2; i <= sqrt; ++i)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=eKp56OLhoQs
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SieveOfEratosthenes(int n)
        {
            bool[] IsPrime = new bool[n + 1];

            //! 1. First create list of numbers from 2 to n and make all Prime
            for (int i = 2; i <= n; ++i)
            {
                IsPrime[i] = true;
            }
            //! 2. Then we start with first element in the list(2). If 2 is prime all the  muliples of 2 will not be prime 
            //! We can do optimization of  rather than running till i<=n we can run till i<=sqrt(n)
            for (int i = 2; i <= n; ++i)
            {
                for (int j = 2; i * j <= n; ++j)
                {
                    //! 3. Strike off(Set false) all the multiples of the first number.  
                    IsPrime[i * j] = false;
                }
            }
            int count = 0;
            for (int i = 2; i <= n; ++i)
            {
                if (IsPrime[i])
                {
                    ++count;
                }
            }

            return count;
        }

    }
}
