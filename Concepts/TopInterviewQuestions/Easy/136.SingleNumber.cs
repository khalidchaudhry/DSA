using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _136
    {
        public int SingleNumber(int[] nums)
        {
            int number = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                number ^= nums[i];
            }
            return number;

        }
    }
}
