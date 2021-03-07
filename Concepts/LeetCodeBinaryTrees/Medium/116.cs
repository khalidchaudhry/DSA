using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium._116
{
    public class _116
    {
        public static void _116Main()
        {

            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);

            root.left.left = new Node(4);
            root.left.right = new Node(5);

            root.right.left = new Node(6);
            root.right.right = new Node(7);

            _116 Connect = new _116();

            Connect.Connect1(root);

        }
        // ! Intuition here is to set next level from the current level.
        //! Exact same code as in 117
        public Node Connect0(Node root)
        {

            Node head = root;
            while (head != null)
            {
                //!using dummy node to move to the next level
                Node dummy = new Node(0);
                Node temp = dummy;
                while (head != null)
                {
                    if (head.left != null)
                    {
                        temp.next = head.left;
                        temp = temp.next;
                    }
                    if (head.right != null)
                    {
                        temp.next = head.right;
                        temp = temp.next;
                    }

                    head = head.next;
                }
                head = dummy.next;
            }
            return root;
        }

        /// <summary>
         //! Pay attention when  nodes don't have same parent 
        //https://leetcode.com/problems/populating-next-right-pointers-in-each-node/solution/
        /// <summary>
        public Node Connect1(Node root)
        {
            if (root == null)
            {
                return root;
            }

            // Start with the root node. There are no next pointers
            // that need to be set up on the first level
            Node leftmost = root;

            // Once we reach the final level, we are done
            while (leftmost.left != null)
            {

                // Iterate the "linked list" starting from the head
                // node and using the next pointers, establish the 
                // corresponding links for the next level
                Node head = leftmost;

                while (head != null)
                {

                    // CONNECTION 1
                    head.left.next = head.right;

                    // CONNECTION 2
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }

                    // Progress along the list (nodes on the current level)
                    head = head.next;
                }

                // Move onto the next level
                leftmost = leftmost.left;
            }

            return root;
        }

        /// <summary>
        //! Level order traversal. Using extra space for queue. 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect2(Node root)
        {
            if (root == null)
                return null;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int count = queue.Count;
                while (count != 0)
                {
                    Node dequeue = queue.Dequeue();

                    if (count != 1)
                        dequeue.next = queue.Peek();

                    if (dequeue.left != null)
                        queue.Enqueue(dequeue.left);

                    if (dequeue.right != null)
                        queue.Enqueue(dequeue.right);

                    --count;
                }
            }

            return root;
        }
    }



    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}