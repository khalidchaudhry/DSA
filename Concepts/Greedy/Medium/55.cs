using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _55
    {

        /// <summary>
        //! Greedy algorithm
        //! Once we at index in array , we mark all other indexes that we can reach from that index to true
        //! Time complexity=O(n)
        //! Space=O(n)
        /// </summary>
        public bool CanJump(int[] nums)
        {

            int n = nums.Length;
            bool[] flag = new bool[n];
            flag[0] = true; //! think what if array contains only one value.. we can reach to it 

            int j = 0;
            for (int i = 0; i < n; ++i)
            {
                if (flag[i] == false) //! Since we  are initially positioned at the first index of the array.At any point if flag==false we can return false
                    return false;

                while (j < nums.Length && j <= nums[i] + i)
                {
                    flag[j] = true;
                    ++j;
                }
            }

            return flag[n - 1];
        }
        
        //! Recursion with memo
        //! Time complexity=O(n^2)
        //! Space Complexity=O(n)(recursion depth) +O(n^2)(function states)
        private bool CanJump2(int[] nums, int s, Dictionary<int, bool> memo)
        {
            if (s >= nums.Length)
            {
                return false;
            }
            if (s == nums.Length - 1)
            {
                return true;
            }

            if (memo.ContainsKey(s))
            {
                return memo[s];
            }

            for (int i = nums[s]; i > 0; --i)
            {
                if (CanJump2(nums, s + i, memo))
                {
                    memo[s] = true;
                    return memo[s];
                }
            }

            memo[s] = false;

            return memo[s];

        }


        /// <summary>
        /// Kuai class 09/04/2020
        /// </summary>
        public bool CanJump1(int[] nums)
        {
            int n = nums.Length;
            int dest = nums[n - 1];

            for (int i = n - 2; i >= 0; --i)
            {
                if (i + nums[i] >= dest)
                {
                    dest = i;
                }

            }

            return dest == 0 ? true : false;

        }

    }
}
