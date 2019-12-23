using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Count() == 0 || nums.Count() == 1)
                return false;
            HashSet<int> hs = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hs.Contains(nums[i]))
                {
                    return false;
                }
                else
                {
                    hs.Add(nums[i]);
                }
            }
            return true;
        }


    }
}
