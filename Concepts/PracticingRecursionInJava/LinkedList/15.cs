using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _15
    {
        int count = 0;
        public double Average(ListNode node)
        {
            double total = Helper(node);
            if (count == 0)
                return 0;
            else
            {
                return total / count;
            }
        }


        public double Helper(ListNode node)
        {
            if (node == null)
                return 0;
            ++count;
            double total = node.val + Helper(node.next);
            return total;
        }

    }
}
