using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _264
    {

        public static void _264Main()
        {
            _264 NthUglyNumber = new _264();

            var ans=NthUglyNumber.NthUglyNumber(10);

            Console.ReadLine();

        }

        /// <summary>
        //! Brute force approach 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            List<int> nUglyNumbers = new List<int>();
            //! first 10 ugly numbers :) 
            nUglyNumbers.AddRange(new List<int> { 1, 2, 3, 5, 6, 8, 9, 10, 12 });
            if (n <= 10)
                return nUglyNumbers[n - 1];

            int[] factors = new int[] {2,3,5};
            for (int i = 11; i <= 1690; ++i)
            {
                int number = i;
                for (int j = 0; j < factors.Length; ++j)
                {
                    while (number % factors[j] == 0)
                    {
                        number = number / factors[j];
                    }                    
                }
                if (number == 1)
                    nUglyNumbers.Add(i);
            }

            return nUglyNumbers[n - 1];
        }
    }
}
