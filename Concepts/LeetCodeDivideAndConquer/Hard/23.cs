using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Hard
{
    class _23
    {
        //   # <image url="$(SolutionDir)\Images\23.png"  scale="0.5"/>
        //!K^2L=>Time complexity for merging two lists at a time solution
        //! L is the length of one linked list
        //! Number of iterations it take to merge 2 lists=2L(L+L) 
        //! Number of iterations it take to merge 3 lists=3L(2L+L)
        //!2L+3L+4L+KL=K((K+1)/2)=(K^2)/2+K/2=K^2        
        /// <summary>
        //! L = Number of nodes in one linked list 
        //! K*L = Total elements in the all K linked lists
        //! LogK=total levels
        //!Time=K*L*logK
        //!Space=logK
        /// </summary>
        public ListNode MergeKLists(ListNode[] lists)
        {

            return MergeKLists(lists, 0, lists.Length - 1);
        }

        private ListNode MergeKLists(ListNode[] lists, int s, int e)
        {
            if (s == e)
                return lists[s];
            if (s > e)
                return null;

            int m = s + ((e - s) / 2);

            ListNode l1 = MergeKLists(lists, s, m);
            ListNode l2 = MergeKLists(lists, m + 1, e);
            return Merge(l1, l2);
        }

        private ListNode Merge(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode tail = head;

            while (l1 != null || l2 != null)
            {
                bool chooseFroml1 = l2 == null || (l1 != null && l1.val <= l2.val);

                if (chooseFroml1)
                {
                    tail.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tail.next = l2;
                    l2 = l2.next;
                }

                tail = tail.next;
            }

            return head.next;
        }


    }
}
