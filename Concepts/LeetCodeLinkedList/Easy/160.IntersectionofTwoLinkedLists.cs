using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Easy
{
    class _160
    {


        /// <summary>
        //! Using hashset  
        /// </summary>
        public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
        {

            HashSet<ListNode> hs = new HashSet<ListNode>();

            while (headA != null)
            {
                hs.Add(headA);
                headA = headA.next;
            }

            while (headB != null)
            {
                if (hs.Contains(headB)) return headB;
                headB = headB.next;
            }

            return null;
        }

        /// <summary>
        //! Finding the length of two linked list. Move one  , one step 
        /// </summary>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            ListNode ptr = headA;
            int len1 = GetLength(ptr);
            ptr = headB;
            int len2 = GetLength(ptr);

            if (len1 == 0 || len2 == 0) return null;

            if (len1 > len2)
            {
                while (len1 != len2)
                {
                    headA = headA.next;
                    --len1;
                }
            }

            if (len2 > len1)
            {
                while (len2 != len1)
                {
                    headB = headB.next;
                    --len2;
                }
            }

            while (headA != null)
            {
                if (headA == headB)
                    return headA;

                headA = headA.next;
                headB = headB.next;
            }

            return null;
        }

        private int GetLength(ListNode ptr)
        {
            int len = 0;
            while (ptr != null)
            {
                ++len;
                ptr = ptr.next;
            }

            return len;
        }

        // Very good solution
        public ListNode getIntersectionNode2(ListNode headA, ListNode headB)
        {
            //boundary check
            if (headA == null || headB == null) return null;

            ListNode a = headA;
            ListNode b = headB;

            //if a & b have different len, then we will stop the loop after second iteration
            while (a != b)
            {
                //for the end of first iteration, we just reset the pointer to the head of another linkedlist
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;
        }
       
    }
}
