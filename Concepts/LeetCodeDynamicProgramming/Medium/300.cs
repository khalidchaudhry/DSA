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
        /// https://www.youtube.com/watch?v=6iY6kX4np5w
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS0(int[] nums)
        {
            int lis = 0;
            int[] dp = new int[nums.Length];
            
            for (int i = 0; i < nums.Length; ++i)
            {
                int index = Array.BinarySearch(dp,0,lis,nums[i]);
                if (index < 0)
                {
                    index = index + 1;
                }
                dp[index] = nums[i];
                if (index == lis)
                {
                    ++lis;
                }
            }

           

            return lis;
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


        /// <summary>
        //! wrong implementation . Does not work for below input
        //[10,9,2,5,3,4]
        //! because at element 3 its not considering element 2 which contributes to longest increasing sequence
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public int LengthOfLIS2(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int lisGlobal = 1;

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                int lisLocal = 1;
                int max = nums[i];

                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (nums[j] > max)
                    {
                        ++lisLocal;
                        max = nums[j];
                    }
                }

                lisGlobal = Math.Max(lisLocal, lisGlobal);
            }

            return lisGlobal;
        }


    }
}
