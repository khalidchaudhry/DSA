using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _287
    {
        /// <summary>
        /// https://leetcode.com/problems/find-the-duplicate-number/solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindDuplicate0(int[] nums)
        {

            int tortise = nums[0];
            int hare = nums[0];
            do
            {
                //!tortoise will take just one jump
                tortise = nums[tortise];
                //! hare with take two jumps
                hare = nums[nums[hare]];


            } while (tortise != hare);

            hare = nums[0];
            while (tortise != hare)
            {
                //!Both hair and tortoise will take one jump
                tortise = nums[tortise];
                hare = nums[hare];
            }

            return tortise;

        }

        //! does not satisfy requirement of  not modifying the orional array. 
        public int FindDuplicate(int[] nums)
        {
            int duplicate = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i])] < 0) //negative number 
                {
                    duplicate = nums[i];
                    break;
                }
                else
                {
                    nums[Math.Abs(nums[i])] = -nums[Math.Abs(nums[i])];
                }
            }

            return duplicate;

        }

    }
}
