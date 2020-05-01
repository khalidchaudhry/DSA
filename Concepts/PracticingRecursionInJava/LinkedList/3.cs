using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    class _3
    {
        public int CountNodes(ListNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int ans = 1 + CountNodes(node.next);
                return ans;
            }
        }

    }
}
