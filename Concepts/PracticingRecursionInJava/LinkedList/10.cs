using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _10
    {
        public int Sum(ListNode node)
        {
            if (node == null)
                return 0;
            else
            {
                int sum= node.val + Sum(node.next);
                return sum;
            }
        }

    }
}
