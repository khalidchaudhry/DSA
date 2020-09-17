using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium._117
{
    public class _117
    {
        public static void _117Main()
        {



        }
        /// <summary>
        /// https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/discuss/37828/O(1)-space-O(n)-complexity-Iterative-Solution
        //! Three pointers . One pointer(curr) is for current level . Two pointers(last and head) is for next levels
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect0(Node root)
        {

            Node curr = root;
            Node last = null;//! points to the leading node(last node) of next level
            Node head = null; //! points to the first node of the next level

            while (curr != null)
            {
                while (curr != null)
                {

                    if (curr.left != null)
                    {
                        if (last != null)
                        {
                            last.next = curr.left;
                        }
                        else
                        {
                            head = curr.left;
                        }
                        last = curr.left;
                    }

                    if (curr.right != null)
                    {
                        if (last != null)
                        {
                            last.next = curr.right;
                        }
                        else
                        {
                            head = curr.right;
                        }

                        last = curr.right;
                    }

                    curr = curr.next; //! Move to the next node in the level
                }
                //! reseting pointers for the next level. Setting head of next level to the curr
                curr = head;
                head = null;
                last = null;
            }

            return root;
        }

        public Node Connect1(Node root)
        {
            LevelOrderTraversal(root);

            return root;
        }

        private void LevelOrderTraversal(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            if (root != null)
            {
                queue.Enqueue(root);
            }
            while (queue.Count != 0)
            {
                int count = queue.Count;
                while (count != 0)
                {
                    Node dequeue = queue.Dequeue();

                    if (count != 1)
                    {
                        dequeue.next = queue.Peek();
                    }

                    if (dequeue.left != null)
                        queue.Enqueue(dequeue.left);
                    if (dequeue.right != null)
                        queue.Enqueue(dequeue.right);
                    --count;
                }
            }
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
