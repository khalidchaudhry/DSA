using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{

    class _559
    {
        //! Recursive solution 
        //! Very similar to 364 and 104
        public int MaxDepth2(Node root)
        {
            if (root == null) { return 0; }

            int max = 0;

            if (root.children != null)
            {
                for (int i = 0; i < root.children.Count; i++)
                {
                    max = Math.Max(max, MaxDepth2(root.children[i]));
                }
            }

            return 1 + max;
        }

        //! Iterative DFS solution 
        //! Stack which contains the node and the corresponding depth
        public int MaxDepth3(Node root)
        {
            if (root == null) { return 0; }

            int depth = 0;
            Stack<Tuple<Node, int>> stk = new Stack<Tuple<Node, int>>();

            stk.Push(new Tuple<Node, int>(root, 1));

            while (stk.Count != 0)
            {
                Tuple<Node, int> poppedItem = stk.Pop();
                int currentDepth = poppedItem.Item2;

                if (poppedItem.Item1 != null)
                {
                    depth = Math.Max(depth, currentDepth);
                    foreach (Node child in poppedItem.Item1.children)
                    {
                        stk.Push(new Tuple<Node, int>(child, currentDepth + 1));
                    }
                }
            }
            return depth;
        }

        //! Iterative BFS solution 
        //! for loop removing nodes of the same level at once.
        //https://leetcode.com/problems/maximum-depth-of-n-ary-tree/discuss/183060/Java-BFS-Iterative-Solution
        public int MaxDepth4(Node root)
        {
            if (root == null) { return 0; }

            int depth = 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    Node dequeue = queue.Dequeue();
                    foreach (Node child in dequeue.children)
                    {
                        queue.Enqueue(child);
                    }
                }
                depth++;
            }

            return depth;
        }
    }
}


