using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _442
    {
        /// <summary>
        //! the solution only works if numbers in array are all in the range of 1 to n 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDuplicates(int[] nums)
        {

            List<int> result = new List<int>();
            if (nums.Length == 0)
            {
                return result;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                //! Take the absolute value of array at current index
                int absValue = Math.Abs(nums[i]);
                //! array value where are we hop/jump to. 
                int value=nums[absValue-1];
                //! if value where we hopped to is negative than add them to the result 
                if (value < 0)
                {
                    result.Add(absValue);
                }
                else
                {
                    //! if where we hopped to is not negative than make it negative to detect duplicates 
                    nums[absValue - 1]= -value;
                }
            }

            return result;


        }


    }
}
