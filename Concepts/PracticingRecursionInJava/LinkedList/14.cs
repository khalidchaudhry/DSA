using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _14
    {
        public ListNode ReferenceToMin2(ListNode currentNode)
        {
            if (currentNode == null)
                return null;
            if (currentNode.next == null)
                return currentNode;
            ListNode nextNode = ReferenceToMin2(currentNode.next);

            if (nextNode.val <= currentNode.val)
            {
                return nextNode;
            }
            else
                return currentNode;

        }

    }
}
