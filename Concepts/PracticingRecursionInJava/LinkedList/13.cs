using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _13
    {
        public ListNode ReferenceToMin(ListNode currentNode)
        {
            if (currentNode == null)
                return null;
            if (currentNode.next == null)
                return currentNode;
            ListNode nextNode = ReferenceToMin(currentNode.next);

            if (nextNode.val < currentNode.val)
            {
                return nextNode;
            }
            else
                return currentNode;
        }

    }
}
