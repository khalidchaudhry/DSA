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
            int c1 = 0;
            int c1Count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (c1Count == 0)
                {
                    c1 = nums[i];
                    c1Count = 1;
                }
                else if (nums[i] == c1)
                    ++c1Count;
                else
                    --c1Count;

            }

            return c1;
        }


        // Boyer–Moore majority vote algorithm
        public int MajorityElement2(int[] nums)
        {

            int maj_index = 0, count = 1;
            int i;
            for (i = 1; i < nums.Length; i++)
            {
                if (nums[maj_index] == nums[i])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    maj_index = i;
                    count = 1;
                }
            }

            return nums[maj_index];
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
