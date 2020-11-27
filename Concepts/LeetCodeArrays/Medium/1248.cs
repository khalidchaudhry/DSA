using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1248
    {


        public static void _1248Main()
        {

            _1248 Main = new _1248();

            int[] nums = new int[] { 1, 1, 2, 1, 1 };
            int k = 3;
            var ans = Main.NumberOfSubarrays(nums, k);
            Console.ReadLine();



        }

        /// <summary>
        //! Based on idea in Kuai's class
        //! Same  pattern as in 930,1248,560,974
        //https://leetcode.com/problems/count-number-of-nice-subarrays/discuss/419502/Java-PrefixSum-1pass-10line-7ms
        //! 
        /// </summary>
        public int NumberOfSubarrays(int[] nums, int k)
        {
            int cur = 0, ans = 0;

            //! Key is the odd number count(or odd numbers we have seen so far) and 
            //! value is the number of subarrays that has that many number of odd numbers in them
            //! e.g. 3:1 means that there is one subarray with 3 odd numbers in them 
            Dictionary<int, int> map = new Dictionary<int, int>();
            //! there is 1 subarray that has 0 odd number count which comes before all array  elements 
            map.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                cur += nums[i] % 2 == 1 ? 1 : 0;

                if (map.ContainsKey(cur - k))
                    ans += map[cur - k];

                if (!map.ContainsKey(cur))
                    map.Add(cur, 1);
                else
                    ++map[cur];
     
            }

            return ans;



        }



    }
}
