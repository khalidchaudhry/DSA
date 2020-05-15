using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _20
    {

        public ListNode Insert0(ListNode node, int item)
        {
            if (node == null || item < node.val)
            {
                ListNode newNode= new ListNode(item);
                newNode.next = node;
                return newNode;
            }
            else
            {
                node.next = Insert0(node.next, item);
                return node;
            }
        }

        public void Insert(ListNode node, int item)
        {
            ListNode newNode = new ListNode(item);
            if (node == null)
            {
                node = newNode;
                return;
            }
            if (node.next == null)
            {
                if (item >= node.val)
                {

                    node.next = newNode;
                }
                else
                {
                    newNode.next = node;
                }
                return;
            }

            if (item >= node.val)
            {

                if (item <= node.next.val)
                {
                    ListNode temp = node.next;
                    node.next = newNode;
                    newNode.next = temp;
                    return;
                }
                else
                {
                    Insert(node.next, item);
                }

            }
            else
            {
                Insert(node.next, item);
            }
        }
    }
}
