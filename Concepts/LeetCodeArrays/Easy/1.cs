using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _1
    {
        //x+y=target;
         //x=target-y;
        // Need to store target-y in dictionary to get indices. 
        // Otherwise need to look dictionary based on the value which is not efficient. 
        // However when we look up in dictionary  , we will look it up based on the array element. 
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int num = target - nums[i];
                // Looking up based on the aray element
                if (dict.ContainsKey(nums[i]))
                {
                    result[0] =dict[nums[i]];
                    result[1] = i;
                    break;
                }
                else
                {
                    // This check is very important in case if there are repeated elements in array
                    // like // [2,2,7,11,5] without it code will throw an error that element already exists

                    if (!dict.ContainsKey(num))
                    {
                        dict.Add(num, i);
                    }
                }               
            }
            return result;
        }

        //! Below approach/template can help solve the 3Sum/4Sum problem 
        //https://leetcode.com/problems/3sum/
        //https://leetcode.com/problems/4sum/
        public int[] TwoSum2(int[] nums, int target)
        {
            int[] result = new int[2];

            Array.Sort(result);

            int left = 0;
            int right =nums.Length-1;
            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum < target)
                {
                    ++left;
                }
                else if (sum > target)
                {
                    --right;
                }
                else
                {
                    result[0] = nums[left];
                    result[1] = nums[right];
                }
            }

            return result;
        }
    }
}
