using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _110
    {

        // !Bottom up recursion 
        public bool IsBalanced3(TreeNode root)
        {
            if (root == null)
                return true;

            return BalanceTreeHelper(root).IsBalanced;
        }

        // !Top down recursion 
        public bool IsBalanced2(TreeNode root)
        {
            if (root == null)
                return true;
            // Check if subtrees have height within 1. If they do, check if the
            // subtrees are balanced
            return Math.Abs(Height(root.left) - Height(root.right)) < 2 &&
                IsBalanced2(root.left) &&
                IsBalanced2(root.right);
        }
        

        /// <summary>
        //! Not gives correct answer
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
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
        
      

        private static TreeInfo BalanceTreeHelper(TreeNode node)
        {
            /*
            * Base case, an empty subtree is balanced and has a height of -1 as we define
            * it (since it is technically below "sea level", weird analogy)
            */
            if (node == null)
            {
                return new TreeInfo(true, -1);
            }

            /*
             * Go deep into the left subtree and get a result back
             */

            TreeInfo leftTree = BalanceTreeHelper(node.left);

            if (!leftTree.IsBalanced)
            {
                return leftTree;// Left subtree is not balanced. Bubble up failure.
            }
            TreeInfo rightTree = BalanceTreeHelper(node.right);
            if (!rightTree.IsBalanced)
            {
                return rightTree;// Right subtree is not balanced. Bubble up failure.
            }

            /*
             * Our left and right subtrees are back and we have our results. Let us analyze
             * them here and bubble up our own answer.
             * 
             * 1.) Check if the subtreesAreBalanced 2.) Notate the height that this node
             * sits at (which is 1 plus the height of the larger of the left and right
             * subtrees coming off of this node)
             */

            return new TreeInfo(Math.Abs(leftTree.Height - rightTree.Height) > 1 ? false : true, Math.Max(leftTree.Height, rightTree.Height) + 1);
        }
        private int Height(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int lHeight = Height(node.left);
            int rHeight = Height(node.right);
            return 1 + Math.Max(lHeight, rHeight);
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
