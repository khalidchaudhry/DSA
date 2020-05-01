using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    class _4
    {
        public int CountItems(ListNode node,int item)
        {
            if (node == null)
                return 0;
            else
            {
                int count = 0;
                count = node.val == item ? 1 + CountItems(node.next, item) : CountItems(node.next, item);
                return count;
            }
        }
    }
}
