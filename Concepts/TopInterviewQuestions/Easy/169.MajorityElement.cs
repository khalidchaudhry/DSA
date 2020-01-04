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
        // Function to check if the candidate  
        // occurs more than n/2 times 
        static bool isMajority(int[] a, int size, int cand)
        {
            int i, count = 0;
            for (i = 0; i < size; i++)
            {
                if (a[i] == cand)
                    count++;
            }
            if (count > size / 2)
                return true;
            else
                return false;
        }


    }
}
