using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePrefixSum.Medium
{
    public class _523
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {

            int n = nums.Length;
            Dictionary<int, int> remIndex = new Dictionary<int, int>();
            remIndex.Add(0, -1);

            int sum = 0;
            for (int i = 0; i < n; ++i)
            {
                sum += nums[i];
                if (remIndex.ContainsKey(sum % k))
                {
                    if (i - remIndex[sum % k] > 1)
                        return true;
                }

                if (!remIndex.ContainsKey(sum % k))
                {
                    remIndex.Add(sum % k, i);
                }
            }
            return false;
        }
    }
}
