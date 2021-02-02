using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Hard
{
    class _23
    {
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
