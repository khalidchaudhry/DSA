using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _26
    {
        public bool IsSorted(ListNode node)
        {
            if (node == null)
                return true;

            if (node.next == null)
            {
                return true;
            }          

            if (node.val <= node.next.val && IsSorted(node.next))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
