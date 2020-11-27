using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Easy
{
    public class _876
    {

        /// <summary>
        //! using fast and slow pointer technique. 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head)
        {

            if (head == null) return null;
            ListNode sp = head;
            ListNode fp = head.next;

            while (sp != fp)
            {
                if (fp == null || fp.next == null)
                {
                    break;
                }

                sp = sp.next;
                fp = fp.next.next;

            }

            if (fp == null) //! incase linked list length is odd 
                return sp;
            else
                return sp.next; //! incase linked list length is even. 

        }


    }
}
