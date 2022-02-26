using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePrefixSum.Medium
{
    class _325
    {
        public int MaxSubArrayLen(int[] nums, int k)
        {
            /*
               nums=      [ 1,  -1,  5,  -2,  3]
               Sum=       [1,    0,  5,   3,  6]
                                     j  

               Sum[j]-Sum[i]=target
               Sum[j]-target=Sum[i]


            */
            Dictionary<int, int> sumIdx = new Dictionary<int, int>();
            sumIdx.Add(0, -1);

            int longest = 0;

            int sum = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                sum += nums[j];
                //! sum-k because we need to chop-off  
                if (sumIdx.ContainsKey(sum - k))
                {
                    longest = Math.Max(longest, j - sumIdx[sum - k]);
                }

                if (!sumIdx.ContainsKey(sum))
                {
                    sumIdx.Add(sum, j);
                }
            }
            return longest;
        }

    }
}
