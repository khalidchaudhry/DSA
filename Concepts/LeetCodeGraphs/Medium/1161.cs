using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1161
    {
        public int MaxLevelSum(TreeNode root)
        {
            if (root == null)
                return 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            (int maximalSum, int minimalLevel) = (int.MinValue, int.MaxValue);

            int currLevel =0;

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                ++currLevel;
                int count = queue.Count;
                int levelSum = 0;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelSum += node.val;
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                //! if level sum is equal to the maximalSum 
                //! Pick the minimum level hence Math.Min(minimalLevel, currLevel)
                //! Question is to return the smallest level with maximal value
                if (maximalSum<levelSum)
                {
                    (maximalSum, minimalLevel) = (levelSum, currLevel);
                }

                //!! Below not needeed as we are going from top to bottom 
                //! and will replace maximalSum and levelSum only when we have maximal sum less then the level sum
                //else if (levelSum == maximalSum)
                //{
                //    minimalLevel = Math.Min(currLevel,minimalLevel);
                //}              
            }

            return minimalLevel;
        }


    }
}
