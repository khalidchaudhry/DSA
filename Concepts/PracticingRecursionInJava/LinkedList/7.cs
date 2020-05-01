using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _7
    {
        public ListNode PointToItem(ListNode node, int item)
        {
            if (node == null)
                return null;
            else
            {
                if (node.val == item)
                    return node;
                else
                    return PointToItem(node.next, item);
            }
        }
    }
}
