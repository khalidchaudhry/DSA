using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRandom.Medium
{
    public class _528
    {


    }

    /// <summary>
    /// https://www.youtube.com/watch?v=v-_aEMtgnkIs
    /// </summary>
    public class Solution
    {
        int[] sum;
        Random random;
        public Solution(int[] w)
        {
            sum = new int[w.Length];
            random = new Random();
            int runningSum = 0;
            for (int i = 0; i < w.Length; ++i)
            {
                runningSum += w[i];
                sum[i] = runningSum;
            }

        }

        public int PickIndex()
        {
            //
            var nextNumber = random.Next(1, sum[sum.Length - 1] + 1);
            return BinarySearch(nextNumber);

        }

        private int BinarySearch(int target)
        {
            int lo = 0;
            int hi = sum.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (sum[mid] == target)
                    return mid;
                else if (sum[mid] > target)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }

            return lo;

        }
    }



}
