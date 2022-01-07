using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Easy
{
    class _160
    {

        public static void _160Main()
        {
            ListNode four = new ListNode(4);
            ListNode one = new ListNode(1);
            ListNode eight = new ListNode(8);
            ListNode four2 = new ListNode(4);
            ListNode five = new ListNode(4);

            ListNode five2 = new ListNode(5);
            ListNode six = new ListNode(6);
            ListNode one2 = new ListNode(1);


            four.next = one;
            one.next = eight;
            eight.next = four;
            four.next = five;

            five2.next = six;
            six.next = one2;
            one2.next = eight;

            _160 main = new _160();
            main.getIntersectionNode2(four, five2);


        }
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

        //! Start both the linked list at same length
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

        //!Same as above approach but we don't need to upfront calculate length of two linked list
        //! Two linked list starting of the same length
        public ListNode getIntersectionNode2(ListNode headA, ListNode headB)
        {
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
