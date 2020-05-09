using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _11
    {
        public long Product(ListNode node)
        {
            if (node == null)
                return 1;

            return node.val * Product(node.next);
        }


    }
}
