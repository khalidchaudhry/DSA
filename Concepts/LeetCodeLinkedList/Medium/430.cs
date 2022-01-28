using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Medium
{
    public class _430
    {

        public static void _430Main()
        {
            Node node1 = new Node();
            node1.val = 1;
            Node node2 = new Node();
            node2.val = 2;
            Node node3 = new Node();
            node3.val = 3;

            node1.child = node2;
            node2.child = node3;

            _430 test = new _430();
            var result= test.Flatten(node1);
            Console.ReadLine();
        }
        public Node Flatten(Node head)
        {
            /*
               doubly linked list 
                 Additional child pointer points to other linked list or can be null
                      Nesting
                 curr ----------------  curr.next
                 All child nodes must set to null          
            */
            if (head == null)
                return null;
            return Solve(head);
        }
        private Node  Solve(Node head)
        {
            Node curr = head;
            Node tail = head;
            while (curr != null)
            {
                Node next = curr.next;
                Node child = curr.child;
                if (child != null)
                {
                    tail = Solve(child);
                    tail.next = next;
                    if (next != null)
                    {
                        next.prev = tail;
                    }
                    curr.next = child;
                    curr.child = null;
                    child.prev = curr;
                }
                curr = next;
                if (curr != null)
                {
                    tail = curr;
                }
            }

            return tail;
        }
        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;
        }
    }
    

}
