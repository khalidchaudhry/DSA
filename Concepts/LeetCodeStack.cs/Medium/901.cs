using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _901
    {

        public static void _901Main()
        {

          

        }

    }

    /// <summary>
    //! Monotonically decreasing stack
    //! Based on idea in Kuai's class
    /// </summary>
    public class StockSpanner
    {
        Stack<(int price, int span)> stk;
        public StockSpanner()
        {
            stk = new Stack<(int price, int span)>();
        }

        public int Next(int price)
        {
            int span = 1;
            while (stk.Count != 0 && price>=stk.Peek().price)
            {
                span += stk.Pop().span;
            }
            stk.Push((price, span));

            return stk.Peek().span;
        }
    }
}
