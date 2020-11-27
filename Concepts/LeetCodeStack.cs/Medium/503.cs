using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _503
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=sYINIANAFBY
        //! Monotonically decreasing stack.
        //! Trick is to think of it as regular array and code for next greater element. 
        //! After words change the loop to run till 2*n and replace i with i%n every where in the code. Pretty cool.         
        /// </summary>

        public int[] NextGreaterElements(int[] nums)
        {
            Stack<int> stk = new Stack<int>();
            int n = nums.Length;
            int[] ans = new int[n];
            Fill(ans);
            for (int i = 0; i < 2 * n; ++i)
            {
                while (stk.Count != 0 && nums[stk.Peek()] < nums[i % n])
                {
                    int index = stk.Pop();
                    ans[index] = nums[i % n];
                }

                stk.Push(i % n);
            }

            return ans;

        }

        private void Fill(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = -1;
            }
        }


    }
}
