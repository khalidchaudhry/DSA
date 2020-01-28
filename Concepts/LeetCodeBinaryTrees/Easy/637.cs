using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _637
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> avg = new List<double>();
            if (root == null)
                return avg;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int total, cnt;
            double sum;
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                total = cnt = queue.Count;
                sum = 0;
                while (cnt != 0)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    --cnt;
                }
                avg.Add(sum/total);

            }
            return avg;
        }


    }
}
