using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    class _226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            root.left = right;

            root.right = left;

            return root;
        }

        public TreeNode InvertTree2(TreeNode root)
        {
            if (root == null)
                return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                TreeNode dequeue = queue.Dequeue();
                TreeNode temp = dequeue.left;
                dequeue.left = dequeue.right;
                dequeue.right = temp;

                if (dequeue.left != null)
                {
                    queue.Enqueue(dequeue.left);
                }
                if (dequeue.right != null)
                {
                    queue.Enqueue(dequeue.right);
                }

            }

            return root;

        }




    }
}
