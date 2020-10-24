using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _453
    {

        //https://leetcode.com/problems/minimum-moves-to-equal-array-elements/discuss/93879/Simple-O(n)-Java-solution-with-explanation
        public int MinMoves(int[] nums)
        {
            int min = nums[0];
            foreach (int num in nums)
            {
                min = Math.Min(min,num);
            }
            int steps = 0;

            foreach (int num in nums)
            {
                steps += num - min;
            }

            return steps;

        }


    }
}
