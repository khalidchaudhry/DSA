using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeArrays.Medium
{
    class _169
    {
        // Boyer–Moore majority vote algorithm
        //!Similar apprach followed in question 229
        public int MajorityElement0(int[] nums)
        {
            int n = nums.Length;
            int c1 = 0;
            int c1Count = 0;

            for (int i = 0; i < n; ++i)
            {

                if (c1 == nums[i])
                {
                    ++c1Count;
                }
                else if (c1Count == 0)
                {
                    c1 = nums[i];
                    ++c1Count;
                }
                else
                {
                    --c1Count;
                }
            }
            return c1;
        }

        public int MajorityElement(int[] nums)
        {

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int majorityElement = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }

            foreach (var item in dict)
            {
                if (item.Value > nums.Length / 2)
                {
                    majorityElement = item.Key;
                    break;
                }
            }

            return majorityElement;

        }





    }
}
