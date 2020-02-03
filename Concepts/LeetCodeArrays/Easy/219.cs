using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            bool result = false;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    //difference between i and j is at most k.
                    
                    if ((Math.Abs(map[nums[i]] - i)) <= k)
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        map[nums[i]] = i;
                    }
                }
                else
                {
                    map.Add(nums[i], i);
                }
            }

            return result;

        }

    }
}
