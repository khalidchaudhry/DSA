using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _22
    {
        public LinkedList MakeLinkedList(int firstData, int n, int inc)
        {

            LinkedList list = new LinkedList();
            list.head=MakeLinkedListHelper(firstData,0, n, inc);
            return list;
        }

        private ListNode MakeLinkedListHelper(int firstData,int multiplier, int n, int inc)
        {
            if (n == 0)
                return null;
            else
            {
                ListNode node = new ListNode(firstData);
                node.next = MakeLinkedListHelper(firstData+(inc*multiplier),multiplier+1, n - 1, inc);
                return node;

            }

        }
    }
}
