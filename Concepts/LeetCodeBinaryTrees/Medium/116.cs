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
        //! Level order traversal but not using any additional space for storing levels. Assigning next pointer as we tarverse the level
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect1(Node root)
        {
            List<List<Node>> allLevelNodes = new List<List<Node>>();
            LevelOrderTraversal0(root);

            return root;
        }
        /// <summary>
        //! Using extra memory to store levels in List and later on establish the connections  
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>

        public Node Connect2(Node root)
        {
            List<List<Node>> allLevelNodes = new List<List<Node>>();
            LevelOrderTraversal(root, allLevelNodes);
            for (int i = 1; i < allLevelNodes.Count; ++i)
            {
                for (int j = 0; j < allLevelNodes[i].Count - 1; ++j)
                {
                    allLevelNodes[i][j].next = allLevelNodes[i][j + 1];
                }
            }
            return root;
        }

        private void LevelOrderTraversal0(Node root)
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

        private void LevelOrderTraversal(Node root, List<List<Node>> allLevelNodes)
        {
            Queue<Node> queue = new Queue<Node>();
            if (root != null)
            {
                queue.Enqueue(root);
            }

            while (queue.Count != 0)
            {
                int count = queue.Count;
                List<Node> levelNodes = new List<Node>();
                while (count != 0)
                {
                    Node dequeue = queue.Dequeue();
                    levelNodes.Add(dequeue);

                    if (dequeue.left != null)
                        queue.Enqueue(dequeue.left);
                    if (dequeue.right != null)
                        queue.Enqueue(dequeue.right);

                    --count;
                }

                allLevelNodes.Add(levelNodes);
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