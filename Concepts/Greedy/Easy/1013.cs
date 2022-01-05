using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Easy
{
    public class _1013
    {
        public bool CanThreePartsEqualSum(int[] arr)
        {

            int sum = arr.Sum();

            if (sum % 3 != 0)
            {
                return false;
            }

            int target = sum / 3;
            int count = 0;
            int runningSum = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                runningSum += arr[i];
                if (runningSum == target)
                {
                    runningSum = 0;
                    ++count;
                }
            }
            //!>= for edege case when all numbers are 0 .e..g [0,0,0,0] 
            //! If count>3 we can always include  partitions more than 3 in 3rd partition
            return count >= 3;

        }

    }
}
