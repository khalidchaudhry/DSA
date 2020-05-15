using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _21
    {
        public LinkedList MakeLinkedList(int[] x, int n)
        {
            ListNode head = MakeLinkedListHelper(x, n);
            LinkedList list = new LinkedList();
            list.head = head;

            return list;

        }

        private ListNode MakeLinkedListHelper(int[] x, int n)
        {
            if (n == 0)
            {
                return null;
            }
            if ((n - 1) == 0)
            {
                return new ListNode(x[0]);
            }
            else
            {
                ListNode node = new ListNode(x[n - 1]);
                node.next = MakeLinkedListHelper(x, n - 1);
                return node;
            }
        }
    }
}
