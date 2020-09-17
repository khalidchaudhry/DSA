using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy._993
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
            var ans = Cousins.IsCousins0(root, 5, 4);

        }

        /// <summary>
        //! Breadth First Search
        /// </summary>
        /// <param name="root"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCousins0(TreeNode root, int x, int y)
        {
            if (root == null)
                return false;

            Queue<(TreeNode node, int depth, int parent)> queue = new Queue<(TreeNode node, int depth, int parent)>();

            (int xParent, int xLevel) = (int.MaxValue, int.MaxValue);
            (int yParent, int yLevel) = (int.MaxValue, int.MaxValue);

            queue.Enqueue((root, 0, -1));

            while (queue.Count != 0)
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

            }

            return false;
        }

        /// <summary>
        // !Depth First Search(Pre-Order traversal)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCousins1(TreeNode root, int x, int y)
        {
            if (root == null)
                return false;
            ResultWrapper resultWrapper = new ResultWrapper();
            DFS(root, x, y, 0, -1, resultWrapper);
            return resultWrapper.X.Depth == resultWrapper.Y.Depth && resultWrapper.X.Parent != resultWrapper.Y.Parent;
        }

        private void DFS(TreeNode root, int x, int y, int depth, int parent, ResultWrapper resultWrapper)
        {
            if (root == null)
                return;
            if (root.val == x)
            {
                resultWrapper.X.Depth = depth;
                resultWrapper.X.Parent = parent;
            }
            if (root.val == y)
            {
                resultWrapper.Y.Depth = depth;
                resultWrapper.Y.Parent = parent;
            }

            DFS(root.left, x, y, depth + 1, root.val, resultWrapper);
            DFS(root.right, x, y, depth + 1, root.val, resultWrapper);

        }
    }
    public class ResultWrapper
    {
        public ResultWrapper()
        {
            X = new NodeInfo();
            Y = new NodeInfo();
        }
        public NodeInfo X { get; set; }
        public NodeInfo Y { get; set; }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public int Parent { get; set; }
    }
}

