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
            List<int> uglyNumbers = new List<int>() { 1 };
            int i2 = 0;
            int i3 = 0;
            int i5 = 0;
            for (int i = 2; i <= n; ++i)  
            {
                int multipleOf2 = 2 * uglyNumbers[i2];
                int multipleOf3 = 3 * uglyNumbers[i3];
                int multipleOf5 = 5 * uglyNumbers[i5];

                int min = Math.Min(multipleOf2, Math.Min(multipleOf3, multipleOf5));

                uglyNumbers.Add(min);

                if (min == multipleOf2)
                    ++i2;

                if (min == multipleOf3)
                    ++i3;

                if (min == multipleOf5)
                    ++i5;

            }

            return uglyNumbers[uglyNumbers.Count - 1];

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
            int[] uglyNumbers = new int[1690];
            //! reason for long because large inout like (1407)  hashSet<long> will overflow
            SortedSet<long> ss = new SortedSet<long>();
            ss.Add(1);
            for (int i = 0; i < n; ++i)
            {
                //! O(1)
                long min = ss.Min;

                uglyNumbers[i] = (int)min;
                //! O(1) operation.
                ss.Remove(min);
                //! O(logn)
                ss.Add(min * 2);
                ss.Add(min * 3);
                ss.Add(min * 5);
            }

            return uglyNumbers[n - 1];

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
