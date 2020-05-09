using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _18
    {
        public void AddOne(ListNode node)
        {
            if (node == null)
                return;

            AddOne(node.next);
            node.val += 1;

        }


    }
}
