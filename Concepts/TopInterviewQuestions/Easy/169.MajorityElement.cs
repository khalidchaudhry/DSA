using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _169
    {
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

        // Boyer–Moore majority vote algorithm
        public int MajorityElement2(int[] nums)
        {

            int majorityElement = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == majorityElement)
                {
                    ++count;
                }
                else
                {
                    --count;
                }

                if (count == 0)
                {
                    majorityElement = nums[i];
                    count = 1;
                }
            }


            return majorityElement;

        }


    }
}
