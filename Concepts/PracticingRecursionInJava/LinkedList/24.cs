using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _24
    {
        public int CountNodes(ListNode nodes)
        {
            if (nodes == null)
                return 0;
            int count = 1+CountNodes(nodes.next);

            return count;
        }

    }
}
