using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _25
    {
        public int CountZeroNodes(ListNode node)
        {
            if (node == null)
                return 0;
            int count = node.val==0?1:0;
            count += CountZeroNodes(node);
            return count;
        }


    }
}
