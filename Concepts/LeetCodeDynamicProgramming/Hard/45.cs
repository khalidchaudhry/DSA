using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Hard
{
    class _45
    {

        public int Jump(int[] nums)
        {

            return Jump(nums, 0);
        }

        private int Jump(int[] nums, int s)
        {
            if (s >= nums.Length)
            {
                return -1;
            }
            if (s == nums.Length - 1)
            {
                return 0;
            }

            int minJumps = -1;
            for (int i = nums[s]; i > 0; --i)
            {
                int forwardJumps = Jump(nums, s + i);
                if (forwardJumps != -1)
                {
                    //! minJumps will be -1 for the first answer
                    //Otherwise minimum of minJumps & forwardsJumps+1  
                    minJumps = minJumps == -1 ? 1 + forwardJumps : Math.Min(minJumps, 1 + forwardJumps);
                }
            }

            return minJumps;
        }

    }
}
