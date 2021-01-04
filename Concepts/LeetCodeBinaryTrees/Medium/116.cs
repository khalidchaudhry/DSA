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

        /// <summary>
        // ! Intuition here is to set next level from the current level.
        //! Pay attention when  nodes don't have same parent 

        //https://leetcode.com/problems/populating-next-right-pointers-in-each-node/solution/
        //! Below solution  is for second part of the problem but i used the simiary idea here 
        //https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/discuss/37828/O(1)-space-O(n)-complexity-Iterative-Solution
        //! 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect0(Node root)
        {
            Node curr = root;
            Node head = null; // points to the first node of the next level

            while (curr != null)   //! for current level
            {
                while (curr != null) //! for next level
                {
                    if (curr.left != null)
                    {
                        if (head == null) 
                        {
                            head = curr.left; //! setting only for left node(curr.left!=null)  because tree is perfectly balanced. Left most ndoe will always be present. 
                        }

                        curr.left.next = curr.right;  // !when nodes have same parent
                    }
                    //! Case When nodes have  different parents
                    //! head!=null for leaf nodes 
                    if (curr.next != null && head != null)
                    {
                        curr.right.next = curr.next.left;
                    }

                    curr = curr.next;
                }

                curr = head;
                head = null;
            }

            return root;
        }

        /// <summary>
        //! Level order traversal. Using extra space for queue. 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect1(Node root)
        {
            if (root == null)
                return root;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node prev = null;
                int count = queue.Count;
                while (count != 0)
                {
                    Node dequeue = queue.Dequeue();
                    if (prev != null)
                    {
                        prev.next = dequeue;
                    }

                    if (dequeue.left != null)
                    {
                        queue.Enqueue(dequeue.left);
                    }

                    if (dequeue.right != null)
                    {
                        queue.Enqueue(dequeue.right);
                    }

                    prev = dequeue;
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