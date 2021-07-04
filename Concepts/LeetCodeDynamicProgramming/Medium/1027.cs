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
            int[] A = new int[] { 2,4,7,9,10 };
            _1027 Target = new _1027();
            var ans = Target.LongestArithSeqLength0(A);
            Console.ReadLine();
        }


        public int LongestArithSeqLength0(int[] A)
        {
            Dictionary<int, int> valueIndex = new Dictionary<int, int>();
            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
            int maxLength = 2;

            for (int j = 0; j < A.Length; ++j)
            {
                for (int k = j + 1; k < A.Length; ++k)
                {
                    dp[(j, k)] = 2;
                    int first = 2 * A[j] - A[k];
                    if (valueIndex.ContainsKey(first))
                    {
                        int i = valueIndex[first];
                        dp[(j, k)] = dp[(i, j)] + 1;
                        maxLength = Math.Max(dp[(j, k)], maxLength);
                    }
                }
                valueIndex[A[j]] = j;
            }

            return maxLength;
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
