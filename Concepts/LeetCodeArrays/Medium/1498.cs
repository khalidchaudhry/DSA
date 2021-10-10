using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1498
    {

        public static void _1498Main()
        {
            _1498 NumSeq = new _1498();
            int[] nums = new int[] { 3, 5, 6, 7 };
            int target = 9;
            NumSeq.NumSubseq(nums, target);
            Console.ReadLine();

        }

        /// <summary>
        //! Discuss in Kuai's class 
        //! The formula for subsequences in an array of size n is 2^n
        //https://www.youtube.com/watch?v=xCsIkPLS4Ls
        //  # <image url="$(SolutionDir)\Images\1498.png"  scale="0.5"/>
        /// </summary>
        public int NumSubseq(int[] nums, int target)
        {

            int mod = (int)Math.Pow(10, 9) + 7;
            int[] pows = new int[nums.Length];
            //! We are precomputing powers since in case of big nums size , it will go out of bound
            PreComputerPowers(pows, mod);

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


        /// <summary>
        //! 0  1  2  3  4   5 
        //  1  2  4  8  16  32
        /// </summary>
        private void PreComputerPowers(int[] pows, int mod)
        {
            pows[0] = 1;
            for (int num = 1; num < pows.Length; ++num)
            {
                pows[num] = (pows[num - 1] * 2) % mod;
            }
        }
    }
}
