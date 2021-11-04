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
            Stack<int> stk = new Stack<int>();
            int secondMax = int.MinValue;
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                int curr = nums[i];
                if (curr < secondMax)
                {
                    return true;
                }
                while (stk.Count > 0 && curr > stk.Peek())
                {
                    secondMax = stk.Pop();
                }
                stk.Push(curr);
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
