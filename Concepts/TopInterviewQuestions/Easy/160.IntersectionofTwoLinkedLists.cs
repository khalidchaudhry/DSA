using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _160
    {

        public ListNode getIntersectionNode(ListNode headA, ListNode headB)
        {

            int listALength = 0;
            int listBLength = 0;
            ListNode temp1 = headA;
            ListNode temp2 = headB;
            //Calculate the lenght of list node A
            while (temp1 != null)
            {
                listALength++;
                temp1 = temp1.next;
            }
            //Calculate the lenght of list node B
            while (temp2 != null)
            {
                listBLength++;
                temp2 = temp2.next;
            }

            int lengthDiff = Math.Abs(listALength - listBLength);

            //temp1 holds the longer linked list
            //temp2 holds the shorter linked list

            if (listALength > listBLength)
            {
                temp1 = headA;
                temp2 = headB;
            }
            else
            {
                temp1 = headB;
                temp2 = headA;
            }
            int i = 0;
            while (i < lengthDiff)
            {
                temp1 = temp1.next;
                ++i;
            }
            //Pay special attention here 
            while (temp1 != temp2)
            {
                temp1 = temp1.next;
                temp2 = temp2.next;
            }

            return temp1;
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
        /*
         * Case 1 (Have Intersection & Same Len):
               a
        A:     a1 → a2 → a3
                           ↘
                             c1 → c2 → c3 → null
                           ↗            
        B:     b1 → b2 → b3
               b
                    a
        A:     a1 → a2 → a3
                           ↘
                             c1 → c2 → c3 → null
                           ↗            
        B:     b1 → b2 → b3
                    b
                         a
        A:     a1 → a2 → a3
                           ↘
                             c1 → c2 → c3 → null
                           ↗            
        B:     b1 → b2 → b3
                         b
        A:     a1 → a2 → a3
                           ↘ a
                             c1 → c2 → c3 → null
                           ↗ b
        B:     b1 → b2 → b3
        Since a == b is true, end loop while(a != b), return the intersection node a = c1.

        Case 2 (Have Intersection & Different Len):

                    a
        A:          a1 → a2
                           ↘
                             c1 → c2 → c3 → null
                           ↗            
        B:     b1 → b2 → b3
               b
                         a
        A:          a1 → a2
                           ↘
                             c1 → c2 → c3 → null
                           ↗            
        B:     b1 → b2 → b3
                    b
        A:          a1 → a2
                           ↘ a
                             c1 → c2 → c3 → null
                           ↗            
        B:     b1 → b2 → b3
                         b
        A:          a1 → a2
                           ↘      a
                             c1 → c2 → c3 → null
                           ↗ b
        B:     b1 → b2 → b3
        A:          a1 → a2
                           ↘           a
                             c1 → c2 → c3 → null
                           ↗      b
        B:     b1 → b2 → b3
        A:          a1 → a2
                           ↘                a = null, then a = b1
                             c1 → c2 → c3 → null
                           ↗           b
        B:     b1 → b2 → b3
        A:          a1 → a2
                           ↘ 
                             c1 → c2 → c3 → null
                           ↗                b = null, then b = a1
        B:     b1 → b2 → b3
               a
                    b
        A:          a1 → a2
                           ↘ 
                             c1 → c2 → c3 → null
                           ↗
        B:     b1 → b2 → b3
                    a
                         b
        A:          a1 → a2
                           ↘ 
                             c1 → c2 → c3 → null
                           ↗ 
        B:     b1 → b2 → b3
                         a
        A:          a1 → a2
                           ↘ b
                             c1 → c2 → c3 → null
                           ↗ a
        B:     b1 → b2 → b3
        */
    }
}
