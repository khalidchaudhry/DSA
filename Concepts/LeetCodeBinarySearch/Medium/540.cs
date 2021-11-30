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
            int n = nums.Length;
            //! Boundary cases
            if (nums.Length == 1)
            {
                return nums[0];
            }
            if (nums[0] != nums[1])
            {
                return nums[0];
            }
            if (nums[n - 1] != nums[n - 2])
            {
                //! we are returning n-1 not n-2 because if n-2 is the missing number , it will be tackled in above if condition
                return nums[n - 1];  
            }

            int lo = 0;
            int hi = n;

            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(nums, mid))
                    lo = mid;
                else
                    hi = mid;
            }
            //! we are interested in returning first invalid candidade
            return nums[hi];
        }


        /// <summary>
        //! Is the number at its correct index/position correspponding to its neighbor?
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
