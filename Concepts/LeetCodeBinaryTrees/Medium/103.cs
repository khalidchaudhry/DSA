using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    class _103
    {
        public static void _103Main()
        {

        }
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            LevelOrderTraversal(root, result);

            for (int i = 1; i < result.Count; i += 2)
            {
                Reverse(result[i]);

            }

            return result;
        }

        private void Reverse(IList<int> lst)
        {
            int i = 0;
            int j = lst.Count - 1;
            while (i < j)
            {
                int temp = lst[i];
                lst[i] = lst[j];
                lst[j] = temp;

                ++i;
                --j;
            }
        }

        private void LevelOrderTraversal(TreeNode node, List<IList<int>> result)
        {
            if (node == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                int count = queue.Count;
                IList<int> level = new List<int>();
                while (count != 0)
                {
                    TreeNode dequeue = queue.Dequeue();
                    level.Add(dequeue.val);

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

                result.Add(level);
            }

        }



    }
}
