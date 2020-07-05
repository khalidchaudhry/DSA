using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _199
    {
        //! Similar to question 107
        //! Intuition is to do level by level traversal . And level by level  done by BFS        
        //!Time complexity:O(n) since one has to visit each node.
        //! Space complexity:O(D) where D is a tree diameter. 
        //! Let's use the last level to estimate the queue size. 
        //!This level could contain up to N/2 tree nodes in the case of complete binary tree.
        public IList<int> RightSideView0(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode dequeue = queue.Dequeue();
                    //! To  add last node into the result. 
                    if (i == count - 1)
                    {
                        result.Add(dequeue.val);
                    }
                    if (dequeue.left != null)
                    {
                        queue.Enqueue(dequeue.left);
                    }
                    if (dequeue.right != null)
                    {
                        queue.Enqueue(dequeue.right);
                    }
                }               
            }          

            return result;
        }

        /// <summary>
        //! Similar to question 107
        //! Intuition is to do level order traversal 
        //! if tree is less than 
        //!Time complexity:O(n) since one has to visit each node.
        //! Space complexity:Not sure
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null)
            {
                return result;
            }

            List<List<int>> levelByLevel = new List<List<int>>();
            List<int> level = new List<int>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                level.Clear();
                int count = queue.Count;
                for (int i = 0; i < count; i++)
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
                }

                levelByLevel.Add(new List<int>(level));
            }

            for (int i = 0; i < levelByLevel.Count; i++)
            {
                int lastElementIndex = levelByLevel[i].Count - 1;
                int lastElement = levelByLevel[i][lastElementIndex];
                result.Add(levelByLevel[i][lastElementIndex]);
            }

            return result;
        }
    }
}
