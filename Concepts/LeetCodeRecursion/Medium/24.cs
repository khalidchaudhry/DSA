using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _24
    {

        public static void _24Main()
        {
            _24 Main = new _24();
            ListNode Head = new ListNode(1);
            ListNode two = new ListNode(2);
            ListNode three = new ListNode(3);
            ListNode four = new ListNode(4);

            Head.next = two;
            two.next = three;
            three.next = four;
            

            var ans=Main.SwapPairs(Head);

        }
        public ListNode SwapPairs(ListNode head)
        {
            return Helper(head, head.next);
        }

        private ListNode Helper(ListNode prev, ListNode curr)
        {
            //! in case list is odd length
            if (curr == null)
                return prev;
            //! in case list is of even length
            if (curr.next == null)
            {
                prev.next = curr.next;
                curr.next = prev;
                return curr;
            }

            prev.next = Helper(curr.next, curr.next.next);
            curr.next = prev;
            return curr;

        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
