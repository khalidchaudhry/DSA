using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _754
    {

        /// <summary>
        // https://leetcode.com/problems/reach-a-number/discuss/357047/With-Full-explanation-and-approach-to-reach-solution-or-Mathematical-solution-w
        //! Intution is 
        //! We keep increasing steps and sum till sum < target or difference between sum and target is not even 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ReachNumber(int target)
        {
            target = Math.Abs(target);
            int steps = 0;
            int sum = 0;


            while ((sum < target || (sum - target) % 2 != 0))
            {
                ++steps;
                sum += steps;
            }

            return steps;
        }


    }
}
