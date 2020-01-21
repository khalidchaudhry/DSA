using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _110
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            int lHeight = Height(root.left);
            int rHeight = Height(root.right);



            int diff = Math.Abs(lHeight - rHeight);
            if (diff > 1)
            {
                return false;
            }
            else
            {
                return true;
            }



        }

        public int Height(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int lHeight = Height(node.left);
            int rHeight = Height(node.right);
            return 1 + Math.Max(lHeight, rHeight);
        }



        public bool IsBalanced2(TreeNode root)
        {
            if (root == null)
                return true;

            return Math.Abs(Height(root.left) - Height(root.right)) < 2 &&
                IsBalanced2(root.left) &&
                IsBalanced2(root.right);
        }

        public int Height2(TreeNode node)
        {
            if (node == null)
            {
                return -1;
            }

            int lHeight = Height(node.left);
            int rHeight = Height(node.right);
            return 1 + Math.Max(lHeight, rHeight);
        }

        public bool IsBalanced3(TreeNode root)
        {
            if (root == null)
                return true;

            return BalanceTreeHelper(root).IsBalanced;
        }
        private static TreeInfo BalanceTreeHelper(TreeNode node)
        {
            if (node == null)
            {
                return new TreeInfo(true, -1);
            }

            TreeInfo leftTree = BalanceTreeHelper(node.left);
            if (!leftTree.IsBalanced)
            {
                return leftTree;
            }
            TreeInfo rightTree = BalanceTreeHelper(node.right);
            if (!rightTree.IsBalanced)
            {
                return rightTree;
            }

            return new TreeInfo(Math.Abs(leftTree.Height - rightTree.Height) < 2, Math.Max(leftTree.Height, rightTree.Height) + 1);
        }

    }

    public class TreeInfo
    {
        public bool IsBalanced;
        public int Height;
        public TreeInfo(bool isBalanced, int height)
        {
            IsBalanced = isBalanced;
            Height = height;
        }
    }
}
