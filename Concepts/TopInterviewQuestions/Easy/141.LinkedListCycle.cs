using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _141
    {

        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;

            ListNode fp=head, sp = head;

            while (fp.next != null && fp.next.next != null)
            {
                sp = sp.next;
                fp = fp.next.next;

                if (fp == sp)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasCycle2(ListNode head)
        {

            if (head == null || head.next == null) return false;
            ListNode fast = head.next;
            ListNode slow = head;

            while (slow != null && fast != null && fast.next != null)
            {
                if (slow == fast) return true;

                slow = slow.next;
                fast = fast.next.next;
            }
            return false;
        }
    }
}
