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
            int[] ans = new int[2];
            for (int i = 0; i < nums.Length; ++i)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                {
                    ans[0] = Math.Abs(nums[i]);
                }
                else
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] > 0)
                {
                    ans[1] = i + 1;
                    break;
                }
            }

            return ans;

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
