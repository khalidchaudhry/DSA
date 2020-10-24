using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _1262
    {
        public int MaxSumDivThree(int[] nums)
        {
            int sum = 0;
            List<int> remainder1 = new List<int>();
            List<int> remainder2 = new List<int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];

                if (nums[i] % 3 == 1)
                {
                    remainder1.Add(nums[i]);
                }
                if (nums[i] % 3 == 2)
                {
                    remainder2.Add(nums[i]);
                }
            }

            if (sum % 3 == 0)
                return sum;

            remainder1.Sort();
            remainder2.Sort();

            if (sum % 3 == 1)
            {
                int min1 = remainder1[0];
                int min2 = remainder2.Count < 2 ? int.MaxValue : remainder2[0] + remainder2[1];
                return sum-Math.Min(min1, min2);
            }
            else
            {

                int min1 = remainder2[0];
                int min2 = remainder1.Count < 2 ? int.MaxValue : remainder1[0] + remainder1[1];
                return sum-Math.Min(min1, min2);
            }
        }
    }
}
