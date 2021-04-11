using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _229
    {
        //To figure out a O(1)O(1) space requirement, we would need to get this simple intuition first.
        //For an array of length n:
        //!There can be at most 1  majority element which is more than n/2 times.
        //!There can be at most 2  majority elements which are more than n/3 times.
        //!There can be at most 3 majority elements which are more than n/4 times.
        public IList<int> MajorityElement(int[] nums)
        {
            int c1 = 0;
            int c1Count = 0;
            int c2 = 1;
            int c2Count = 0;

            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {

                //conditions (nums[i] == c1) && (nums[i] == c2) needs to come first.Think of below test case
                //! [1,1].. in that case , c1 and c2 both will set to 1 which is wrong 
                if (nums[i] == c1)
                    ++c1Count;
                else if (nums[i] == c2)
                    ++c2Count;
                else if (c1Count == 0)
                {
                    c1 = nums[i];
                    c1Count = 1;
                }
                else if (c2Count == 0)
                {
                    c2 = nums[i];
                    c2Count = 1;
                }
                else
                {
                    --c1Count;
                    --c2Count;
                }
            }
            //!Above code will tell us the candidate but not the actual majority elements. 
            //!To get actual majority elemenents, we need to check their count 
            List<int> result = new List<int>();
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] == c1) ++count1;
                else if (nums[i] == c2) ++count2;
            }

            if (count1 > nums.Length / 3)
                result.Add(c1);
            if (count2 > nums.Length / 3)
                result.Add(c2);

            return result;
        }




    }
}
