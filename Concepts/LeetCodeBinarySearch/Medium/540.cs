using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _540
    {


        /// <summary>
        //! Based on roger template 
        //! Same pattern as in question 1228
        //https://www.youtube.com/watch?v=fBrWR-4dXg8
        /// </summary>
        public int SingleNonDuplicate(int[] nums)
        {

            int lo = -1;
            int hi = nums.Length - 1;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(nums, mid))
                    //! When we want pattern like TTT'F' we need to invert. 
                    //! Usually we set one in OK  who is the potiential candidate (among lo and hi . One that is having valid value) 
                    lo = mid;  
                else
                    hi = mid;
            }

            return nums[hi];
        }


        /// <summary>
        //!TTTT'F'FFFF       
        /// </summary>
        private bool OK(int[] nums, int mid)
        {

            if (mid % 2 == 0 && nums[mid] == nums[mid + 1] ||  //! if mid ie even then we need to compare mid & mid +1
                mid % 2 == 1 && nums[mid] == nums[mid - 1])    //! if mid ie odd  then we need to compare mid & mid - 1
                return true;

            return false;
        }
        /// <summary>
        //! Brute Force 
        /// </summary>
        public int SingleNonDuplicate1(int[] nums)
        {
            int xor = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                xor = xor ^ nums[i];
            }

            return xor;
        }
    }
}
