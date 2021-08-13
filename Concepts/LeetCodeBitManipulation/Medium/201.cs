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
        //! Given two integer numbers, we are asked to find the common prefix of their binary strings
        /// </summary>

        public int RangeBitwiseAnd(int m, int n)
        {
            int shift = 0;
            //! The number are being reduced into their common prefix
            while (m != n)
            {                
                m = m >> 1;
                n = n >> 1;
                ++shift;
            }
            //we append zeros to the common prefix in order to obtain the desired result, by shifting the common prefix to the left.
            return m << shift;

        }



    }
}
