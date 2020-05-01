using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _1
    {
        public void Traverse(ListNode node)
        {
            if (node == null)
                return;
            Console.Write($"{node.val}");
            Traverse(node.next);
        }

    }
}
