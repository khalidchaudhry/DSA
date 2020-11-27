using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Medium
{
    public class _19
    {



        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {

            ListNode ptr = head;
            int length = GetLength(ptr);

            //! incase where we need to remove first node. 
            if (length == n)
                return head.next;

            ptr = head;
            int runningLength = 0;
            while (ptr != null)
            {
                ++runningLength;
                
                //! totalLength-currentLength+1 will give us the node we need to delete
                //! totalLength-currentLength will give us the node before it 
                //!We need to stop one node before the node that we need to delete.                
                if (runningLength == length-n)  
                {
                    ptr.next = ptr.next.next;
                    break;
                }

                ptr = ptr.next;
            }

            return head;
        }

        private int GetLength(ListNode head)
        {
            int length = 0;

            while (head != null)
            {
                ++length;
                head = head.next;
            }
            return length;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

}
