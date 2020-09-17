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
        /// https://www.youtube.com/watch?v=9gG1Aaekq00
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MissingElement0(int[] nums, int k)
        {

            int lo = 0;
            int hi = nums.Length - 1;

            if (k > GetMissingNumbersCount(nums, hi))
                return nums[hi] + k - GetMissingNumbersCount(nums, hi);
            while (lo < hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (GetMissingNumbersCount(nums, mid) < k)
                {
                    lo = mid + 1;
                }
                else
                {
                    //! hi=mid becuase MissingNumbersCount canbe equal to k
                    hi = mid;
                }
            }
                  //! go back to one previous element add k and subtract number of missing elements from it 
                  // ! we need to subtract because we already have some missing elements up to hi-1 so we need to subtract it from k
            return nums[hi - 1] + k - GetMissingNumbersCount(nums, hi - 1);


        }
        private int GetMissingNumbersCount(int[] nums, int idx)
        {
            return nums[idx] - nums[0] - idx;

        }


    }
}
