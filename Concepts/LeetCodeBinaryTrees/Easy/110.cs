using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _110
    {

        public static void _110Main()
        {
            /*
            //        3
            //       / \
            //      9  20
            //     / \
            //    15  7                    

            */

            var p = new TreeNode(3);
            p.left = new TreeNode(9);
            p.left.left = new TreeNode(15);
            p.left.right = new TreeNode(7);

            p.right = new TreeNode(20);

            /*
                1
               / \
              2   2
             / \
            3   3
            / \
            4   4
            */
            var q = new TreeNode(1);

            q.left = new TreeNode(2);
            q.left.left = new TreeNode(3);
            q.left.right = new TreeNode(3);
            q.left.left.left = new TreeNode(4);
            q.left.left.right = new TreeNode(4);

            q.right = new TreeNode(2);

            _110 IsBalanced = new _110();

        }

        public bool IsBalanced1(TreeNode root)
        {
            if (root == null)
                return true;

            return Helper(root).isBalanced;
        }

        private static (int height, bool isBalanced) Helper(TreeNode node)
        {
            if (node == null)
            {
                return (0, true);
            }

            (int leftHeight, bool isLeftBalanced) = Helper(node.left);

            if (!isLeftBalanced)
            {
                return (leftHeight, isLeftBalanced);// Left subtree is not balanced. Bubble up failure.
            }

            (int rightHeight, bool isRightBalanced) = Helper(node.right);

            if (!isRightBalanced)
            {
                return (rightHeight, isRightBalanced);// Right subtree is not balanced. Bubble up failure.
            }

            /*
             * Our left and right subtrees are back and we have our results. Let us analyze
             * them here and bubble up our own answer.
             * 
             * 1.) Check if the subtreesAreBalanced 2.) Notate the height that this node
             * sits at (which is 1 plus the height of the larger of the left and right
             * subtrees coming off of this node)
             */
            int toReturnHeight = 1 + Math.Max(leftHeight, rightHeight);
            bool toReturnIsBalanced = Math.Abs(leftHeight - rightHeight) <= 1 &&
                                    isLeftBalanced &&
                                    isRightBalanced;

            return (toReturnHeight, toReturnIsBalanced);
        }
    }

}
