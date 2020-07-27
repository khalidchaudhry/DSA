using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _37
    {
        public static void _37Main()
        {
           

        }
        public IList<double> AverageOfLevels(TreeNode root)
        {
            IList<double> result = new List<double>();

            LevelOrderTraversal(root,result);
            return result;
        }

        private void LevelOrderTraversal(TreeNode root, IList<double> result)
        {
            if (root == null)
                return ;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int totalElements, count;
                totalElements=count = queue.Count;
                double sum = 0;
               
                while (count != 0)
                {
                    TreeNode dequeue = queue.Dequeue();
                    sum += dequeue.val;

                    if (dequeue.left != null)
                    {
                        queue.Enqueue(dequeue.left);
                    }

                    if (dequeue.right != null)
                    {
                        queue.Enqueue(dequeue.right);
                    }
                    --count;
                }

                result.Add(sum/totalElements);
            }
        }
    }
}
