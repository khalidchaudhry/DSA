using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1498
    {

        public static void  _1498Main()
        {
            _1498 NumSeq = new _1498();
            int[] nums = new int[] { 3, 5, 6, 7 };
            int target = 9;
            NumSeq.NumSubseq(nums,target);
            Console.ReadLine();

        }

        /// <summary>
        //! Discuss in Kuai's class 
        /// </summary>
         public int NumSubseq(int[] nums, int target)
        {
            int[] pows = new int[nums.Length];
            int mod = (int)Math.Pow(10, 9) + 7;
            pows[0] = 1;
            for (int num = 1; num < nums.Length; ++num)
            {
                pows[num] = (pows[num - 1] * 2) % mod;
            }
            Array.Sort(nums);
            int i = 0;
            int j = nums.Length - 1;
            int ans = 0;
            while (i <= j)
            {
                if (nums[i] + nums[j] > target)
                {
                    --j;
                }
                else
                {
                    ans = (ans + pows[j - i]) % mod;
                    ++i;
                }
            }

            return ans;
        }

    }
}
