using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Medium
{
    public class _1296
    {
        public static void _1296Main()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            int k = 3;
            _1296 Partitions = new _1296();
            var ans = Partitions.IsPossibleDivide(nums, k);
            Console.ReadLine();
        }

        //https://www.youtube.com/watch?v=r4VZCwHs4Zo
        /// <summary>
        //! Take Aways:
        //! Take away 1: Only reason we are building map is because we have duplicates in the input        
        /// </summary>
        public bool IsPossibleDivide(int[] nums, int k)
        {
            int n = nums.Length;
            //! If we are not able to partition then we can return false upfront
            if (n % k != 0)
                return false;

            Dictionary<int, int> map = new Dictionary<int, int>();
            BuildMap(nums, map);
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; ++i)
            {
                int number = nums[i];
                //! as we have processed the input in inside loop
                if (map[number] > 0)
                {
                    while (number < nums[i] + k)
                    {
                        if (!map.ContainsKey(number) || map[number] == 0)
                            return false;

                        --map[number];

                        ++number;
                    }
                }
            }

            return true;
        }
        private void BuildMap(int[] nums, Dictionary<int, int> map)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], 0);
                ++map[nums[i]];
            }
        }
    }
}
