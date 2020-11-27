using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _946
    {
        
        
        /// <summary>
        //! Based on idea in Kuai's class
        //! The moment stack top item matching with popped item , we keep popping
        //! till we have mismatch
        //! End just check if  stack count is zero 
        /// </summary>
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {

            int poppedIndex = 0;
            Stack<int> stk = new Stack<int>();
            for (int i = 0; i < pushed.Length; ++i)
            {
                stk.Push(pushed[i]);

                while (stk.Count != 0 && stk.Peek() == popped[poppedIndex])
                {
                    stk.Pop();
                    ++poppedIndex;
                }
            }

            return stk.Count == 0 ? true : false;

        }


    }
}
