using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _314
    {
        public static void _314Main()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);

            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            _314 levelOrdder = new _314();

            levelOrdder.LevelOrder0(root);
        }
        /// <summary>
        //! We are going with BFS becuase of  requirment "If two nodes are in the same row and column, the order should be from left to right" 
        //!BFS will gurantee we will process left node first before right  
        //! Time complexity=O(n)+nlogn
        //! Number of nodes in the binary+Sorting dictionary
        //! Space Complexity=O(n)+O(n)=O(2N)=O(n)
        //! O(n) for Queue and O(n) for dictionary
        /// </summary>
        public IList<IList<int>> LevelOrder0(TreeNode root)
        {

            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Dictionary<int, List<int>> colIdxValues = new Dictionary<int, List<int>>();
            Queue<(TreeNode node, int colIdx)> queue = new Queue<(TreeNode node, int colIdx)>();
            queue.Enqueue((root, 0));
            while (queue.Count > 0)
            {
                int count = queue.Count;
                while (count > 0)
                {
                    (TreeNode curr, int colIdx) = queue.Dequeue();

                    if (!colIdxValues.ContainsKey(colIdx))
                    {
                        colIdxValues.Add(colIdx, new List<int>());
                    }
                    colIdxValues[colIdx].Add(curr.val);

                    if (curr.left != null)
                    {
                        queue.Enqueue((curr.left, colIdx - 1));
                    }
                    if (curr.right != null)
                    {
                        queue.Enqueue((curr.right, colIdx + 1));
                    }
                    --count;
                }
            }
            colIdxValues = colIdxValues.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var keyValue in colIdxValues)
            {
                result.Add(keyValue.Value);
            }
            return result;
        }
        /// <summary>
        //! Optimized version. No sorting needed. 
        //https://leetcode.com/problems/binary-tree-vertical-order-traversal/solution/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>

        public IList<IList<int>> LevelOrder1(TreeNode root)
        {

            List<IList<int>> result = new List<IList<int>>();
            //! important as  LevelByLevel1 method will return 0,0 which will throw run time excpetion. 
            if (root == null)
                return result;

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            (int min, int max) = LevelByLevel1(root, map);
            //! starting from min because this will give us order
            for (int i = min; i <= max; ++i)
            {
                result.Add(map[i]);
            }

            return result;
        }       

        private (int min, int max) LevelByLevel1(TreeNode root, Dictionary<int, List<int>> map)
        {
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            int min = 0;
            int max = 0;
            queue.Enqueue((root, 0));

            while (queue.Count != 0)
            {

                (TreeNode node, int index) = queue.Dequeue();

                min = Math.Min(min, index);
                max = Math.Max(max, index);

                if (map.ContainsKey(index))
                {
                    map[index].Add(node.val);
                }
                else
                {
                    map.Add(index, new List<int>() { node.val });
                }

                if (node.left != null)
                {
                    queue.Enqueue((node.left, index - 1));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, index + 1));
                }

            }

            return (min, max);
        }
    }
}
