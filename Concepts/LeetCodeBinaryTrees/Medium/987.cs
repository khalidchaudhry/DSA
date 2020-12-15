using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _987
    {
        public static void _987Main()
        {
            TreeNode root = new TreeNode(3);

            root.left = new TreeNode(9);
            root.right = new TreeNode(20);

            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            _987 VerticalTraversal = new _987();

            var ans = VerticalTraversal.VerticalTraversal0(root);
        }

        /// <summary>
        /// # <image url="$(SolutionDir)\Images\987.png"  scale="0.4"/>
        /// </summary>

        public IList<IList<int>> VerticalTraversal0(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;

            List<(int column, int row, int value)> nodes = new List<(int column, int row, int value)>();
            Queue<(TreeNode node, int x, int y)> queue = new Queue<(TreeNode node, int x, int y)>();
            queue.Enqueue((root, 0, 0));
            while (queue.Count != 0)
            {
                (TreeNode node, int x, int y) = queue.Dequeue();
                //! we are pushing y then x simply to make sorting easier for us 
                nodes.Add((y, x, node.val));

                //!Question says that For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and (X+1, Y-1).
                //! Note that, we assign a higher row index value to a node's child node. 
                //!This convention is at odds with the denotation given in the problem description. 
                //! This is done intentionally, in order to keep the ordering of all coordinates consistent, i.e. a lower value in any specific coordinate represents a higher order. 
                //! As a result, a sorting operation in ascending order would work for each coordinate consistently. 
                if (node.left != null)

                    queue.Enqueue((node.left, x + 1, y - 1));
                if (node.right != null)
                    queue.Enqueue((node.right, x + 1, y + 1));
            }

            PrepareResult(nodes, result);
            return result;
        }

        private void PrepareResult(List<(int column, int row, int value)> nodes, List<IList<int>> result)
        {
            nodes = nodes.OrderBy(x => x.column).ThenBy(x => x.row).ThenBy(x => x.value).ToList();
            List<int> currColumn = new List<int>();
            int currColumnIndex = nodes[0].column;
            foreach ((int column, int row, int value) in nodes)
            {
                if (column == currColumnIndex)
                {
                    currColumn.Add(value);
                }
                else
                {
                    result.Add(currColumn);
                    currColumnIndex = column;
                    currColumn = new List<int>();
                    currColumn.Add(value);
                }
            }
            //! adding the last entry 
            result.Add(currColumn);
        }

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            Dictionary<int, List<(int, int)>> map = new Dictionary<int, List<(int, int)>>();

            (int minValue, int maxValue) = LevelOrderTraversal(root, map);

            for (int i = minValue; i <= maxValue; ++i)
            {
                List<int> level = new List<int>();
                if (map[i].Count > 1)
                {
                    //!reason for sorting. If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.
                    map[i].Sort();
                }
                foreach ((int x, int value) in map[i])
                {
                    level.Add(value);
                }
                result.Add(level);
            }

            return result;
        }

        private (int minValue, int maxValue) LevelOrderTraversal(TreeNode root, Dictionary<int, List<(int, int)>> map)
        {
            if (root == null)
                return (0, 0);


            Queue<(TreeNode node, int x, int y)> queue = new Queue<(TreeNode node, int x, int y)>();
            int yMin, yMax;
            yMin = yMax = 0;

            queue.Enqueue((root, 0, 0));

            while (queue.Count != 0)
            {

                (TreeNode node, int x, int y) = queue.Dequeue();

                //! Keeping the minimum and maximum value for y
                if (y > yMax) yMax = y;

                if (y < yMin) yMin = y;

                if (map.ContainsKey(y))
                {
                    map[y].Add((x, node.val));
                }
                else
                {
                    map[y] = new List<(int, int)>() { (x, node.val) };
                }
                //!Question says that For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and (X+1, Y-1).
                //! Note that, we assign a higher row index value to a node's child node. 
                //!This convention is at odds with the denotation given in the problem description. 
                //! This is done intentionally, in order to keep the ordering of all coordinates consistent, i.e. a lower value in any specific coordinate represents a higher order. 
                //! As a result, a sorting operation in ascending order would work for each coordinate consistently. 

                if (node.left != null)
                {
                    queue.Enqueue((node.left, x + 1, y - 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue((node.right, x + 1, y + 1));
                }
            }

            return (yMin, yMax);
        }
    }
}