using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _234
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next==null)
            {
                return true;
            }
            List<int> values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }

            int i = 0;
            int j = values.Count-1;

            while (i < j)
            {
                if (values[i] != values[j])
                {
                    return false;
                }
                ++i;
                --j;
            }

            return true;                       
        }      
    }



    public class LinkedList
    {
        public ListNode head;
    }

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
