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
        ///https://www.youtube.com/watch?v=yl-fdkyQD8A 
        // # <image url="$(SolutionDir)\Images\117.png"  scale="0.5"/>
        /// </summary>      
        public Node Connect0(Node root)
        {

            Node curr = root;
            while (curr != null)
            {
                //!using dummy node to move to the next level
                Node future = new Node(0);
                Node temp = future;
                while (curr != null)
                {
                    if (curr.left != null)
                    {
                        temp.next = curr.left;
                        temp = temp.next;
                    }
                    if (curr.right != null)
                    {
                        temp.next = curr.right;
                        temp = temp.next;
                    }

                    curr = curr.next;
                }
                curr = future.next;
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
