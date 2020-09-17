using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _1027
    {
        public static void _1027Main()
        {
            int[] A = new int[] { 20, 1, 15, 3, 10, 5, 8 };
            _1027 Target = new _1027();
            var ans = Target.LongestArithSeqLength(A);
            Console.ReadLine();
        }
        /// <summary>
        //!Brute force  
        //!Time limit excceded :) 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int LongestArithSeqLength(int[] A)
        {
            int max = 2;
            for (int i = 0; i < A.Length; ++i)
            {
                
                for (int j = i + 1; j < A.Length; ++j)
                {
                    int diff = A[j] - A[i];
                    int target = A[j] + diff;
                    int currentLongestLength = 2;
                    for (int k = j + 1; k < A.Length; ++k)
                    {
                        if (A[k] == target)
                        {
                            ++currentLongestLength;                            
                            target += diff;
                        }
                    }
                    max = Math.Max(currentLongestLength, max);
                }
            }
            return max;
        }
    }
}
