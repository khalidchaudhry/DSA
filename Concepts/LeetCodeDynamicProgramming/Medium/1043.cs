using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _1043
    {
        /// <summary>
        /// https://leetcode.com/problems/partition-array-for-maximum-sum/discuss/485342/C-easy-to-understand-with-comments-(100-Time-and-100-space)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int MaxSumAfterPartitioning(int[] A, int K)
        {
            if (A.Length == 0) return 0;

            int length = A.Length;
            int[] dp = new int[length + 1];

            for (int i = 1; i <= length; i++)
            {
                int max = int.MinValue;
                /* From index i to i - K range, take out the maxSum value for dp[i] */
                for (int k = 0; k < K; k++)
                {
                    // To overcome index out of bound excpetion . 
                    if (i - k - 1 < 0)
                        continue;
                    //! compare current max with all the elements of the current partition.                    
                    max = Math.Max(max, A[i - k - 1]);
                    //dp[i - k -1] global sum beyond our current K range index backwards. 
                    //Here for this i, we only bother about computing maxSum for  i - K ranges */
                    dp[i] = Math.Max(dp[i], dp[i - k - 1] + (k + 1) * max);
                }
            }
            return dp[length];
        }

    }
}
