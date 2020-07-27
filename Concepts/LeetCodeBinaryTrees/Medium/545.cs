using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _545
    {
        public static void _545Main()
        {
            TreeNode root = new TreeNode(1);

            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(4);

            _545 Boundary = new _545();

            var result = Boundary.BoundaryOfBinaryTree1(root);
        }

        /// <summary>
        /// https://leetcode.com/problems/boundary-of-binary-tree/discuss/101280/Java(12ms)-left-boundary-left-leaves-right-leaves-right-boundary
        /// https://leetcode.com/problems/boundary-of-binary-tree/solution/
        //! Break the problem into three subproblems
        //! 1. Add left boundary
        //! 2. Add leaves 
        //! 3. Add right boundary
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> BoundaryOfBinaryTree0(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null)
                return result;

            //Adding root to the result
            result.Add(root.val);

            //left boundary
            LeftBoundary(root.left, result);
            // Add leaves 
            AddLeaves(root.left, result);
            AddLeaves(root.right, result);
            // right boundary 
            RightBoundary(root.right, result);

            return result;
        }

        private void LeftBoundary(TreeNode root, List<int> result)
        {
            if (root == null || (root.left == null && root.right == null))
                return;
            result.Add(root.val);
            if (root.left != null) LeftBoundary(root.left, result);
            else LeftBoundary(root.right, result);
        }
        private void AddLeaves(TreeNode root, List<int> result)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
                result.Add(root.val);

            AddLeaves(root.left, result);
            AddLeaves(root.right, result);
        }

        private void RightBoundary(TreeNode root, List<int> result)
        {
            if (root == null || (root.left == null && root.right == null))
                return;

            if (root.right != null) RightBoundary(root.right, result);
            else LeftBoundary(root.left, result);

            result.Add(root.val);
        }

        public IList<int> BoundaryOfBinaryTree1(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            result.Add(root.val);

            List<List<int>> leftSide = new List<List<int>>();
            LevelByLevel(root.left, leftSide);

            for (int i = 0; i < leftSide.Count; ++i)
            {
                if (i == leftSide.Count - 1)
                {
                    result.AddRange(leftSide[i]);

                    if (i != 0 && leftSide[i - 1].Count == 2)
                    {
                        result.Add(leftSide[i - 1][leftSide[i - 1].Count - 1]);
                    }

                }
                else
                {
                    result.Add(leftSide[i][0]);
                }
            }

            List<List<int>> rightSide = new List<List<int>>();
            LevelByLevel(root.right, rightSide);

            for (int i = rightSide.Count - 1; i >= 0; --i)
            {
                if (i == rightSide.Count - 1)
                {
                    result.AddRange(rightSide[i]);
                }
                else
                {
                    int lastElementIndex = rightSide[i].Count - 1;
                    result.Add(rightSide[i][lastElementIndex]);
                }
            }

            return result;
        }

        public void LevelByLevel(TreeNode node, List<List<int>> result)
        {
            if (node == null)
                return;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                int count = queue.Count;
                List<int> levelNodes = new List<int>();
                while (count != 0)
                {
                    TreeNode dequeue = queue.Dequeue();

                    levelNodes.Add(dequeue.val);
                    if (dequeue.left != null)
                        queue.Enqueue(dequeue.left);
                    if (dequeue.right != null)
                        queue.Enqueue(dequeue.right);

                    --count;
                }

                result.Add(levelNodes);
            }
        }


    }
}
