using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _201
    {
        /// <summary>
        /// https://leetcode.com/problems/bitwise-and-of-numbers-range/solution/
        //! Longest common prefix between m and n is the core insight for this question 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RangeBitwiseAnd(int m, int n)
        {
            int shift = 0;
            while (m != n)
            {
                m = m >> 1;
                n = n >> 1;
                ++shift;
            }

            return m >> shift;

        }



    }
}
