using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _283
    {
        public void MoveZeros(int[] nums)
        {
            for (int anchor = 0,explorer=0; explorer < nums.Length; explorer++)
            {
                if (nums[explorer] != 0)
                {
                    var temp = nums[explorer];
                    nums[explorer] =nums[anchor];
                    nums[anchor] = temp;
                    ++anchor;
                }
            }

        }

    }
}
