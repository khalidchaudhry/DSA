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
        //! 
        /// </summary>
        public int DistributeCoins(TreeNode root)
        {
            Helper(root);
            return steps;
        }
        private int Helper(TreeNode node)
        {
            if (node == null)
                return 0;
            int count = Helper(node.left) + Helper(node.right);

            //! if current node does not have any coins then -1 as it will use it
            if (node.val == 0)
            {
                count += -1;
            }
            //! if current node have coins than take 1 coin for it and return the rest to the parent node
            else
            {
                count += node.val - 1;
            }

            //! taking absolute to determine number of steps needed 
            steps += Math.Abs(count);

            return count;
        }
    }
}
