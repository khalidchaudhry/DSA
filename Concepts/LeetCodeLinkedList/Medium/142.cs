using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Medium
{
    public class _142
    {

        public static void _142Main()
        {
            ListNode ls3 = new ListNode(3);
            ListNode ls2 = new ListNode(2);
            ListNode ls0 = new ListNode(0);
            ListNode ls4 = new ListNode(4);

            ls3.next = ls2;
            ls2.next = ls0;
            ls0.next = ls4;
            ls4.next = ls2;
            _142 Main = new _142();
            Main.DetectCycle(ls3);

            Console.ReadLine();


        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
                return null;

            ListNode intersect = ContainsCycle(head);
            if (intersect == null)
                return null;

            ListNode ptr1 = head;
            ListNode ptr2 = intersect;
            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            return ptr1;
        }
        /// <summary>
        //! Similar to below problem. In below problem we are detecting cycle in array. Here its linked list
        /// https://leetcode.com/problems/find-the-duplicate-number/
        /// </summary>
        private ListNode ContainsCycle(ListNode node)
        {
            //!  Floyd's Cycle Detection algorithm requires both 'fast' and 'slow' pointers to begin at the head.
            //! Setting one to head.next will not work in determining from where the cycle begins and results in infinite loop
            //https://leetcode.com/problems/linked-list-cycle-ii/discuss/236206/Need-help-Getting-time-out-error
            ListNode sp = node;
            ListNode fp = node;

            while (fp != null && fp.next != null)
            {
                sp = sp.next;
                fp = fp.next.next;
                if (fp == sp)
                    return fp;
            }

            return null;
        }


    }
}
