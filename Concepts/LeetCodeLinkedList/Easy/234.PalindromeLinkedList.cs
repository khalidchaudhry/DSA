using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Easy
{
    class _234
    {

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            ListNode ptr = head;
            ListNode midNode = GetMiddleNode(ptr);
            ListNode reversed = Reverse(midNode);
            ptr = head;
            while (reversed != null)
            {
                if (ptr.val != reversed.val)
                {
                    return false;
                }

                ptr = ptr.next;
                reversed = reversed.next;
            }

            return true;
        }

        private ListNode GetMiddleNode(ListNode node)
        {
            ListNode sp = node;
            ListNode fp = node;

            while (fp != null && fp.next != null)
            {
                sp = sp.next;
                fp = fp.next.next;
            }
            //! sp will always point to mid node in case of odd linked list 
            //! and start of halfed linked link for even e.g. 1->2->3->4 will give reference to 3 node. 
            return sp;
        }

        private ListNode Reverse(ListNode node)
        {
            ListNode curr = node;
            ListNode prev = null;
            //ListNode next = null;
            while (curr != null)
            {
                ListNode temp = curr.next;
                curr.next = prev;
                prev = curr;

                curr = temp;
            }

            return prev;
        }

        /// <summary>
        //! Recursively reversing the linked list 
        /// </summary>
        public bool IsPalindrome1(ListNode head)
        {

            ListNode sp = head;
            ListNode fp = head;

            while (fp != null && fp.next != null)
            {
                sp = sp.next;
                fp = fp.next.next;
            }

            ListNode firstList = head;
            ListNode secondList = Reverse(null, sp);

            while (secondList != null && firstList != null)
            {
                if (firstList.val != secondList.val)
                {
                    return false;
                }
                firstList = firstList.next;
                secondList = secondList.next;
            }
            return true;
        }
        private ListNode Reverse(ListNode prev, ListNode curr)
        {
            if (curr == null)
            {
                return null;
            }
            if (curr.next == null)
            {
                curr.next = prev;
                return curr;
            }
            ListNode toReturn = Reverse(curr, curr.next);
            curr.next = prev;
            return toReturn;
        }
    }
   

}
