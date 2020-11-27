using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _1019
    {

        /// <summary>
        //! Monotonic decreasing stack.
        //! Remember whenever we askked for next Larger/Greater , we go with monotonically decreasing stack 
        /// </summary>
        public int[] NextLargerNodes(ListNode head)
        {

            ListNode ptr = head;
            List<int> lst = new List<int>();
            PopulateList(ptr,lst);

            int[] result = new int[lst.Count];
            Stack<int> stk = new Stack<int>();
            for (int i = 0; i < lst.Count; ++i)
            {
                while (stk.Count != 0 && lst[i] > lst[stk.Peek()])
                {
                    int index = stk.Pop();
                    result[index] = lst[i];
                }
                stk.Push(i);
            }

            return result;
        }

        private void PopulateList(ListNode ptr, List<int> lst)
        {
            while (ptr != null)
            {
                lst.Add(ptr.val);
                ptr = ptr.next;
            }
        }
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
