using System;
using System.Collections.Generic;
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
        /// ////////////////////////////////////////////
        /// https://leetcode.com/problems/binary-tree-vertical-order-traversal/solution/
        //! Do level order traversal and store the result in sorted dictionary with index and values         
        //! 0(n)= Number of nodes in the binary* Work perform per node(logn)....logn for inserting into dictionary
        //! Time complexity=O(nlogn) 
        ///////////////////////////////////////////////
        //! O(d) space for queue  where d is the tree diameter
        //! O(n) space for holding nodes in dictionary 
        //! Space Complexity=O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder0(TreeNode root)
        {

            List<IList<int>> result = new List<IList<int>>();
            SortedDictionary<int, List<int>> map = new SortedDictionary<int, List<int>>();
            LevelByLevel0(root, map);


            foreach (KeyValuePair<int, List<int>> item in map)
            {
                result.Add(item.Value);
            }
            return result;
        }
        /// <summary>
        //! Optimized version. Not sorting needed. 
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

            for (int i = min; i <= max; ++i)
            {
                result.Add(map[i]);
            }

            return result;
        }
        private void LevelByLevel0(TreeNode root, SortedDictionary<int, List<int>> map)
        {
            if (root == null)
                return;

            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();

            queue.Enqueue((root, 0));

            while (queue.Count != 0)
            {
                (TreeNode node, int index) = queue.Dequeue();

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
