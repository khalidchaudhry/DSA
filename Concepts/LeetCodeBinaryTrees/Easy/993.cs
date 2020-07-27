using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _993
    {
        public static void _993Main()
        {



            TreeNode root = new TreeNode(1);

            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            //root.right.right = new TreeNode(5);
            _993 Cousins = new _993();
            var ans = Cousins.IsCousins(root, 5, 4);

        }

        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (root == null)
                return false;

            Queue<(TreeNode, int, int)> queue = new Queue<(TreeNode, int, int)>();

            (int xParent, int xLevel) = (int.MaxValue, int.MaxValue);
            (int yParent, int yLevel) = (int.MaxValue, int.MaxValue);

            queue.Enqueue((root, 0, -1));

            while (queue.Count != 0)
            {
                int count = queue.Count;

                while (count != 0)
                {
                    (TreeNode node, int level, int parent) = queue.Dequeue();

                    if (node.val == x) (xParent, xLevel) = (parent, level);

                    if (node.val == y) (yParent, yLevel) = (parent, level);

                    if (xParent != int.MaxValue && yParent != int.MaxValue)
                    {

                        if (xParent != yParent && xLevel == yLevel)
                            return true;
                        else
                            return false;
                    }

                    if (node.left != null) queue.Enqueue((node.left, level + 1, node.val));

                    if (node.right != null) queue.Enqueue((node.right, level + 1, node.val));
                    --count;
                }
            }

            return false;
        }
    }
}

