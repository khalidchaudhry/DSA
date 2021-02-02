using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _334
    {
        //! O(n) Time and space
        public bool IncreasingTriplet(int[] nums)
        {

            int[] suffix = new int[nums.Length];

            int max = int.MinValue;
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                max = Math.Max(nums[i], max);
                suffix[i] = max;
            }

            int min = nums[0];
            for (int i = 1; i < nums.Length - 1; ++i)
            {
                 //!    i-1 i i+1
                if (nums[i] > min && nums[i] < suffix[i + 1])
                    return true;

                min = Math.Min(min, nums[i]);
            }
            return false;
        }

        /// <summary>
        //! O(n^2) time and space
        //! Based on idea of leetcode 300
        /// </summary>
        public bool IncreasingTriplet2(int[] nums)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; ++i)
            {

                int max = 0;
                foreach (var keyValue in map)
                {
                    if (keyValue.Key < nums[i])
                    {
                        max = Math.Max(keyValue.Value, max);
                    }
                }

                map[nums[i]] = 1 + max;

                if (map[nums[i]] == 3)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
