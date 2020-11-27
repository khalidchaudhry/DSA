using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Easy
{
    class _141
    {
        /// <summary>
        //! Similar to below problem. In below problem we are detecting cycle in array. Here its linked list
        /// https://leetcode.com/problems/find-the-duplicate-number/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;
            //!  Floyd's Cycle Detection algorithm requires both 'fast' and 'slow' pointers to begin at the head.
            ListNode sp = head;
            ListNode fp = head;

            while (fp != null || fp.next != null)
            {
                sp = sp.next;
                fp = fp.next.next;

                if (sp == fp)
                    return true;
            }

            return false;
        }


    }


    /*** Definition for singly-linked list.***/
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

}
