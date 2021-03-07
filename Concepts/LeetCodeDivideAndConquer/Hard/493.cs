using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Hard
{
    public class _493
    {

        public static void _493Main()
        {
            int[] nums = new int[] { 1, 3, 2, 3, 1 };
            var test = new _493();
            var result=test.ReversePairs(nums);

            Console.ReadLine();
        }

        public int ReversePairs(int[] nums)
        {
            return SortAndCount(nums, 0, nums.Length - 1);
        }
        private int SortAndCount(int[] a, int s, int e)
        {
            if (s >= e)
            {
                return 0;
            }

            int mid = s + ((e - s) / 2);

            int count = 0;
            count += SortAndCount(a, s, mid);
            count += SortAndCount(a, mid + 1, e);

            int j = mid + 1;
            for (int i = s; i <= mid; ++i)
            {
                while (j <= e && a[i] > (long)2 * a[j])
                {
                    ++j;
                }

                count += j - 1 - mid;
            }

            Merge(a, s, mid, e);
            return count;
        }

        private void Merge(int[] nums, int s, int m, int e)
        {
            int[] temp = new int[e - s + 1];

            int p1 = s;
            int p2 = m + 1;
            int index = 0;
            while (p1 <= m || p2 <= e)
            {
                bool chooseFromp1 = p2 > e || p1 <= m && nums[p1] <= nums[p2];

                if (chooseFromp1)
                {
                    temp[index++] = nums[p1++];
                }
                else
                {
                    temp[index++] = nums[p2++];
                }
            }
            index = 0;
            for (int i = s; i <= e; ++i)
            {
                nums[i] = temp[index++];
            }
        }

    }
}
