

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _1060
    {

       
        /// <summary>
        //! Based on Roger's template 
        /// </summary>
        public int MissingElement2(int[] nums, int k)
        {
            int lo = 0;
            int hi = nums.Length;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(nums, mid, k))
                    lo = mid;
                else
                    hi = mid;
            }

            return nums[lo] + k - MissingNumbersCount(nums, lo);
        }


        /// <summary>
        //! TTT'T'F
        //! Are the missing number at the index are less then k 
        //! We are looking for largest number that is less than k
        /// </summary>
        private bool OK(int[] nums, int index, int k)
        {
            return MissingNumbersCount(nums, index) < k;
        }
        /// <summary>
        //! Mising Numbers=TotalNumbersCount-actualNumbersCount
        //! TotalNumbersCount=R-L+1=num[i]-nums[0]+1
        //! ActualNumbersCount=i+1
        //! Missing Numbers=nums[i]-nums[0]+1-(i+1);
        //! Missing Numbers=nums[i]-nums[0]+1-i-1
        //! Missing Numbers=nums[i]-nums[0]-i
        /// </summary>
        private int MissingNumbersCount(int[] nums, int index)
        {
            return nums[index] - nums[0] - index;
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=eLDT92Q0D9U
        /// https://leetcode.com/problems/missing-element-in-sorted-array/discuss/700495/Java-logn-solution-which-follows-regular-binary-search-template
        //!                 [1,2,4], K = 3
        //! Missing numbers [0,0,1]   To  find missing numbers here is the formula nums[i]-nums[0] -i    
        public int MissingElement0(int[] nums, int k)
        {
            int lo = 0;//! not valid candidate because k can't be 0 
            int hi = nums.Length - 1;  //! possible valid candidate 
            //! binary search only calculating the correct index. After we have correct index , we will do the processing to find the Kth misssing element
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                int missingNumbersSoFar = MissingNumbersCount(nums, mid);

                if (missingNumbersSoFar >= k)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }
            //! Why hi because we are looking for right most element(hi is in charge of right most element ) that satisfies the condition
            //! subtract missing numbers. Otherwise , it will be calculated twice
            return nums[hi] + k - MissingNumbersCount(nums, hi);
        }

        /// <summary>
        //! Brute Force 
        /// </summary>
        public int MissingElement1(int[] nums, int k)
        {
            int kth = 0;
            int num = nums[0];
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                num = nums[i];
                while (nums[i + 1] - num != 1)
                {
                    ++kth;
                    ++num;
                    if (kth == k)
                        return num;
                }
            }

            if (kth == k)
            {
                return num;
            }
            num = nums[nums.Length - 1];
            while (kth != k)
            {
                ++kth;
                ++num;
            }

            return num;

        }



    }
}
