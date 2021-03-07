using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Hard
{
    class _315
    {


        public static void _315Main()
        {

            int[] nums = new int[] {5,2,6,1 };
            var _315 = new _315();
            var ans=_315.CountSmaller(nums);

        }
        public IList<int> CountSmaller(int[] nums)
        {
            int[] ans = new int[nums.Length];
            CountSmaller(nums, 0, nums.Length - 1, ans);

            return ans.ToList();
        }

        private int CountSmaller(int[] nums, int s, int e, int[] ans)
        {
            if (s >= e)
            {
                return 0;
            }
            int m = s + ((e - s) / 2);
            int count = 0;
            count += CountSmaller(nums, s, m, ans);
            count += CountSmaller(nums, m + 1, e, ans);

            int j = m + 1;
            for (int i = s; i <= m; ++i)
            {
                while (j <= e && nums[i] > nums[j])
                {
                    ++j;
                    ++count;
                }

            }
            ans[s] = count;
            Merge(nums, s, m, e);
            return count;
        }
        private void Merge(int[] nums, int s, int m, int e)
        {
            int[] temp = new int[e - s + 1];
            int index = 0;
            int p1 = s;
            int p2 = m + 1;
            while (p1 <= m || p2 <= e)
            {
                bool chooseFromp1 = p2 > e || (p1 <= m && nums[p1] <= nums[p2]);
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
