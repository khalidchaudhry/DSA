using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTwoPointers.Medium
{
    public class _209
    {
        /// <summary>
        /// // # <image url="http://img.blog.csdn.net/20150512122602070" scale="0.6" />  
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int s, int[] nums)
        {

            if (nums.Length == 0)
                return 0;

            int result = int.MaxValue;
            int curr_sum = 0;
            
            for (int fastPointer = 0, slowPointer = 0; fastPointer < nums.Length; fastPointer++)
            {
                curr_sum += nums[fastPointer];
                if (curr_sum >= s)
                {
                    while (curr_sum>=s)
                    {
                        curr_sum -= nums[slowPointer];
                        ++slowPointer;
                    }
                    //!+2 =1(because slowPointer incremented by 1 in upper loop)+1(array is zero based)
                    result = Math.Min(result, (fastPointer - slowPointer+2));                   
                }
            }

            return result==int.MaxValue?0:result;
        }

    }
}
