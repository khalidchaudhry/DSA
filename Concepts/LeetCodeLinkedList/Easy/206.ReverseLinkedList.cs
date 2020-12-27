using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Easy
{
    class _206
    {
        /// <summary>
        //! Using three pointers
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, next = null;
            ListNode curr = head;

            while (curr != null)
            {
                //! First move your need pointer to curr.next so that you have reference for the next node. 
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;

        }

        /// <summary>
        //! Using recursion to reverse  
        /// </summary>
        public ListNode ReverseList1(ListNode head)
        {
            return Helper(null, head);
        }

        /// <summary>
        //! Using stack to reverse it 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList2(ListNode head)
        {

            if (head == null) return null;
            Stack<ListNode> stk = new Stack<ListNode>();
            ListNode pointer = head;
            while (pointer != null)
            {
                stk.Push(pointer);
                pointer = pointer.next;
            }

            ListNode toReturn = stk.Peek();

            while (stk.Count != 0)
            {
                ListNode node = stk.Pop();
                if (stk.Count == 0)
                    node.next = null;
                else
                    node.next = stk.Peek();
            }

            return toReturn;

        }

        private ListNode Helper(ListNode prev, ListNode curr)
        {
            if (curr == null)
                return null;

            if (curr.next == null)
            {
                curr.next = prev;
                return curr;
            }

            //! Below line return the last node which will be the new head
            ListNode res = Helper(curr, curr.next);
            curr.next = prev;
            return res;
        }
    }
}
