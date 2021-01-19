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
        /*
          https://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/
          //We iterate an array
            1. If nums[i] < All array elements ....We start a new susequence of length 1
               Array.BinarySearch will give us insertion point. 
               After (index = -(index + 1)),we will get 0 as our insertion point, so we override what is there  
            2. If  nums[i] > All array elements, we extend the subsequence by 1
            3. If A[i] is in between, we will find a list with 
               largest end element that is smaller than A[i]. 
               Clone and extend this list by A[i]. We will discard all
               other lists of same length as that of this modified list.  
         */
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS0(int[] nums)
        {
            int lis = 0;
            int[] dp = new int[nums.Length];

            for (int i = 0; i < nums.Length; ++i)
            {

                //! Array.binarySearch() method returns index of the search key, 
                //! if it is contained in the array, 
                //! else it returns(-(insertion point) -1)

                int index = Array.BinarySearch(dp, 0, lis, nums[i]);

                //! for index less then zero , it returns the insertion point. 

                if (index < 0)
                {
                    index = -(index + 1);
                }

                if (index == lis)
                {
                    ++lis;
                }

                dp[index] = nums[i];

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
    }
}
