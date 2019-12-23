using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _206
    {

        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, next = null;
            ListNode curr = head;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;

        }

        public class LinkedList
        {
            public ListNode head;
        }

        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }



    }
}
