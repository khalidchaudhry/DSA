using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _16
    {
        public bool IsAscending(ListNode node)
        {
            if (node == null)
            {
                return true;
            }
            if (node.next == null)
            {
                return true;
            }
            

            if (IsAscending(node.next) && node.val < node.next.val)
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
