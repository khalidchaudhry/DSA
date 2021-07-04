using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Easy
{
    public class _1299
    {

        public int[] ReplaceElements2(int[] arr)
        {

            int n = arr.Length;
            int[] greatest = new int[n];

            greatest[n - 1] = -1;

            int max = arr[n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                greatest[i] = max;
                max = Math.Max(arr[i], max);
            }

            return greatest;

        }


        /// <summary>
        //! Monotonically increasing stack from array end. Here we don't pop anything keep the current max 
        //! This question is very similar to 155. There we are maintaining monontonically decreasing stack. 
        //! Similar to this, in 155 we don't pop item from stack if we experirnce greater element. We simply pass 
        /// </summary>
        public int[] ReplaceElements(int[] arr)
        {
            Stack<int> stk = new Stack<int>();
            int[] result = new int[arr.Length];
            result[result.Length - 1] = -1;

            stk.Push(arr[arr.Length - 1]);
            for (int i = arr.Length - 2; i >= 0; --i)
            {
                result[i] = stk.Peek();

                if (arr[i] > stk.Peek())
                {
                    stk.Push(arr[i]);
                }
            }

            return result;

        }

    }
}
