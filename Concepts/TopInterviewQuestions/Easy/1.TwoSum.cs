using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int val = target - nums[i];
                if (dict.ContainsKey(val))
                {
                    result[0] = dict[val];
                    result[1] = i;
                }
                else
                {
                    // important line don't forget to add the check 
                    if (!dict.ContainsKey(nums[i]))

                        dict.Add(nums[i], i);
                }
            }

            return result;

        }

    }
}
