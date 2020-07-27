using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _429
    {

        public static void _429Main()
        {


        }
        public IList<IList<int>> LevelOrder(Node root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int count = queue.Count;
                List<int> levelNodes = new List<int>();
                while (count != 0)
                {
                    Node dequeue = queue.Dequeue();
                    levelNodes.Add(dequeue.val);

                    if (dequeue.children != null)
                    {
                        foreach (Node child in dequeue.children)
                        {
                            if (child != null) queue.Enqueue(child);
                        }
                    }
                    --count;
                }

                result.Add(levelNodes);
            }

            return result;
        }
    }
}
