using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSort.Medium
{
    public class _179
    {

        /// <summary>
        //!https://leetcode.com/problems/largest-number/discuss/53190/Simple-C-solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string LargestNumber(int[] nums)
        {
            if (nums.Length == 0)
                return string.Empty;
            //A 32-bit signed integer that indicates the lexical relationship between the two
            //comparands.
            //Value Condition Less than zero strA precedes(comes before) strB in the sort order.
            //Zero strA occurs in the same position as strB in the sort order. 
            //Greater than zero strA follows strB in the sort order.
            Array.Sort(nums, (a, b) => string.Compare($"{b}{a}", $"{a}{b}"));

            return nums[0] == 0 ? "0" : string.Join("", nums);
        }
    }
}
