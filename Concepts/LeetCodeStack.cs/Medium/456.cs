using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _456
    {


        public bool Find132pattern(int[] nums)
        {

            if (nums.Length <= 2)
                return false;
            //K is holding the second largest
            int k = int.MinValue;

            Stack<int> j = new Stack<int>();
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                if (nums[i] < k)
                {
                    return true;
                }
                //! monotonoic descreasing stack
                while (j.Count != 0 && nums[i] > j.Peek())
                {

                    k = j.Peek();
                    j.Pop();
                }

                j.Push(nums[i]);
            }
            return false;
        }



        /// <summary>
        //! Brute Force 
        /// </summary>
        public bool Find132pattern1(int[] nums)
        {

            for (int i = 0; i < nums.Length; ++i)
                for (int j = i + 1; j < nums.Length; ++j)
                    for (int k = j + 1; k < nums.Length; ++k)
                    {
                        if (nums[k] > nums[i] && nums[k] < nums[j])
                            return true;
                    }

            return false;
        }
    }
}
