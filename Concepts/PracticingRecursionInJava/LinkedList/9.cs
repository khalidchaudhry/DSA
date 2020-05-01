using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _9
    {
        public ListNode Return_N_Node(ListNode node, int n,int count)
        {
            
            if (n == count)
            {
                return node;
            }
            else
            {
                return Return_N_Node(node.next,n,count+1);
            }
        }

        public ListNode Return_N_Node2(ListNode node, int n )
        {

            if (n == 0 || node == null)
            {
                return null;
            }
            else if (n == 1)
            {
                return node;
            }
            else
            {
                return Return_N_Node2(node.next, n - 1);
            }
        }

    }
}
