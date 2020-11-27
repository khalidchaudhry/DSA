using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _739
    {
        public static void _739Main()
        {
            _739 Main = new _739();
            int[] temp = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            Main.DailyTemperatures(temp);


        }


        /// <summary>
        //! Monotonically decreasing stack from left to right. 
        //! Pushing an index into stack as we need to calculate how many days we need to wait
        //! We can just take the difference between current index and popped out index
        /// </summary>
        public int[] DailyTemperatures0(int[] T)
        {
            int[] result = new int[T.Length];
            Stack<int> stk = new Stack<int>();
            for (int i = 0; i < T.Length; ++i)
            {
                while (stk.Count != 0 && T[stk.Peek()] < T[i])
                {
                    int index = stk.Pop();
                    result[index] = i - index;
                }
                stk.Push(i);
            }
            return result;
        }
        /// <summary>
        //! Monotonically decreasing stack going from right to left
        //! https://www.youtube.com/watch?v=WGm4Kj3lhRI

        /// </summary>
        public int[] DailyTemperatures(int[] T)
        {

            Stack<(int temp, int index)> stk = new Stack<(int temp, int index)>();
            int n = T.Length;
            int[] ans = new int[n];

            for (int i = n - 1; i >= 0; --i)
            {
                while (stk.Count != 0 && T[i] >= stk.Peek().temp)
                {
                    stk.Pop();
                }
                if (stk.Count != 0)
                {
                    int days = stk.Peek().index - i;
                    ans[i] = days;
                }

                stk.Push((T[i], i));
            }

            return ans;

        }


    }
}
