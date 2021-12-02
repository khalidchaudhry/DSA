using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _979
    {
        int steps = 0;

        /// <summary>
        //! Intuition:  Every node needs to tell to its parent that either its  going to take the coin or give the coin
        //! We traverse childs first (post-order traversal), and return the ballance of coins. 
        //! For example, if we get '+3' from the left child, that means that the left subtree has 3 extra coins to move out. 
        //!If we get '-1' from the right child, we need to move 1 coin in. 
        //!So, we increase the number of moves by 4 (3 moves out left + 1 moves in right). 
        //!We then return the final ballance: r->val (coins in the root) + 3 (left) + (-1) (right) - 1 (keep one coin for the root).
        // # <image url="$(SolutionDir)\Images\979.png"  scale="0.7"/>
        /// </summary>
        public int DistributeCoins(TreeNode root)
        {
            Helper(root);
            return steps;
        }
        private int Helper(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            int left = Helper(node.left);
            int right = Helper(node.right);

            steps += Math.Abs(left) + Math.Abs(right);

            return left + right + node.val - 1;
        }
    }
}
