using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _645
    {
        /// <summary>
        //! Using element marking technique. Another approach  is using XOR. See leetcode for discussion 
        /// </summary>
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[2];
            for (int i = 0; i < n; ++i)
            {
                int idx = Math.Abs(nums[i]) - 1;
                if (nums[idx] < 0)
                {
                    result[0] = idx + 1;
                }
                else
                {
                    nums[idx] = -nums[idx];
                }
            }

            for (int i = 0; i < n; ++i)
            {
                if (nums[i] > 0)
                {
                    result[1] = i + 1;
                }
            }
            return result;

        }

        /// <summary>
        //! Using hashset but requries extra space
        /// </summary>
        public int[] FindErrorNums2(int[] nums)
        {

            HashSet<int> hs = new HashSet<int>();
            for (int i = 1; i <= nums.Length; ++i)
            {
                hs.Add(i);
            }

            int[] result = new int[2];
            for (int i = 0; i < nums.Length; ++i)
            {
                if (hs.Contains(nums[i]))
                {
                    hs.Remove(nums[i]);
                }
                else
                {
                    result[0] = nums[i];
                }
            }


            result[1] = hs.First();

            return result;
        }
    }
}
