using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _991
    {

        /// <summary>
        //! Rather than going from source to target, if we go  from target to source
        //!it will give us optimal(minimum number of operations) result. 
        /// </summary>    
        public int BrokenCalc(int startValue, int target)
        {
            int minOperations = 0;
            while (startValue < target)
            {
                if (target % 2 == 0)
                {
                    target = target / 2;
                }
                else
                {
                    target = target + 1;
                }
                ++minOperations;
            }
             
            return startValue - target + minOperations;
        }

    }
}
