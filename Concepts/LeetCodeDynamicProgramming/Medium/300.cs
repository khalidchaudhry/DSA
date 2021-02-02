using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _300
    {

        public static void _300Main()
        {
            _300 LongestIncreasingSequence = new _300();
            int[] nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };

            var ans = LongestIncreasingSequence.LengthOfLIS0(nums);

            Console.ReadLine();
        }
        /// <summary>
        //! Using binary search
        /// https://www.youtube.com/watch?v=6iY6kX4np5w
        /// <summary>
        /// 
        public int LengthOfLIS0(int[] nums)
        {
            int ans = 0;
            List<int> lis = new List<int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                int index = lis.BinarySearch(nums[i]);

                if (index < 0)
                {
                    index = -(index + 1);
                }

                if (index >= lis.Count)
                {
                    lis.Add(nums[i]);
                }
                else
                {

                    lis[index] = nums[i];
                }

            }

            return lis.Count;
        }


        /// <summary>
        //! Approach discussed in Kai's class
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS1(int[] nums)
        {
            int lis = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                int max = 0;
                //! Max value among  all keys less then the key
                foreach (KeyValuePair<int, int> keyValue in map)
                {
                    if (keyValue.Key < nums[i])
                    {
                        max = Math.Max(max, keyValue.Value);
                    }
                }

                map[nums[i]] = max + 1;
            }

            foreach (KeyValuePair<int, int> keyValue in map)
            {
                lis = Math.Max(keyValue.Value, lis);

            }

            return lis;
        }
    }
}
