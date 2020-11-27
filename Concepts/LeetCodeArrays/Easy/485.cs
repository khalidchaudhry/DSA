using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _485
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxConsecutiveOnes = 0;
            int consecutiveOnesCount = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] == 1)
                    ++consecutiveOnesCount;
                else
                    consecutiveOnesCount = 0;
                maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, consecutiveOnesCount);
            }

            return maxConsecutiveOnes;
        }

    }
}
