using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    class _2
    {
        public void TraverseReverse(ListNode node)
        {
            if (node == null)
                return;
            TraverseReverse(node.next);
            Console.Write($"{node.val}");

        }
    }
}
