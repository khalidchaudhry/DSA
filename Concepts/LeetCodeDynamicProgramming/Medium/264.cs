using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _264
    {

        public static void _264Main()
        {
            _264 NthUglyNumber = new _264();

            var ans = NthUglyNumber.NthUglyNumber0(1407);

            Console.ReadLine();

        }
        /// <summary>
        /// https://www.youtube.com/watch?v=IoqqgfZfiRA
        ///   /// # <image url="https://miro.medium.com/max/700/1*uQl2uxnGSBNhLb79U1yvbQ.jpeg" scale="0.5" /> 

        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>

        public int NthUglyNumber0(int n)
        {
            int[] uglyNumbers = new int[n];
            uglyNumbers[0] = 1;
            int p2, p3, p5;
            p2 = p3 = p5 = 0;
            for (int idx = 1; idx < n; ++idx)
            {
                int next2 = uglyNumbers[p2] * 2;
                int next3 = uglyNumbers[p3] * 3;
                int next5 = uglyNumbers[p5] * 5;
                int min = Math.Min(next5, Math.Min(next2, next3));
                uglyNumbers[idx] = min;
                if (next2 == min)
                {
                    ++p2;
                }
                if (next3 == min)
                {
                    ++p3;
                }
                if (next5 == min)
                {
                    ++p5;
                }
            }
            return uglyNumbers[n - 1];
        }

        /// <summary>
        /// https://leetcode.com/problems/ugly-number-ii/solution/
        //! Time complexity: O(nlogn)
        //!Space : O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber1(int n)
        {
            long nthUglyNumber = 1;
            SortedSet<long> uglyNumbers = new SortedSet<long>();
            uglyNumbers.Add(1);
            for (int i = 0; i < n; ++i)
            {
                nthUglyNumber = uglyNumbers.Min;
                uglyNumbers.Remove(nthUglyNumber);

                uglyNumbers.Add(nthUglyNumber * 2);
                uglyNumbers.Add(nthUglyNumber * 3);
                uglyNumbers.Add(nthUglyNumber * 5);
            }

            return (int)nthUglyNumber;

        }
        /// <summary>
        /// https://www.youtube.com/watch?v=IoqqgfZfiRA
        //!Brute force
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber2(int n)
        {
            List<int> uglyNumbers = new List<int>() { 1 };
            //Top N ugly numbers for 2
            InsertTopNUglyNumbers(2, n, uglyNumbers);
            //Top N ugly numbers for 3
            InsertTopNUglyNumbers(3, n, uglyNumbers);
            //Top N ugly numbers for 5
            InsertTopNUglyNumbers(5, n, uglyNumbers);

            List<int> distinctOrderedUglyNumbers = uglyNumbers.Distinct().OrderBy(x => x).ToList();

            return distinctOrderedUglyNumbers[n - 1];
        }

        private void InsertTopNUglyNumbers(int factor, int n, List<int> uglyNumbers)
        {
            int uglyNumbersCount = 0;
            int i = 1;
            while (uglyNumbersCount != n)
            {
                if (IsUgly(factor * i))
                {
                    uglyNumbers.Add(factor * i);
                    ++uglyNumbersCount;
                }
                ++i;
            }
        }
        /// <summary>
        //! We will keep dividing number from choosen factor till we have 0 remainder 
        //! Once we have zero remainder , we will try another factor.
        //! If num is 1 then itsugly number , otherwise its not an ugly number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool IsUgly(int num)
        {
            int[] factors = new int[] { 2, 3, 5 };

            for (int i = 0; i < factors.Length; ++i)
            {
                while (num % factors[i] == 0)
                {
                    num = num / factors[i];
                }
            }

            if (num == 1)
                return true;
            else
                return false;
        }
    }
}
