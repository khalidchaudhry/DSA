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

            List<Data> allNodes = new List<Data>();
            Queue<Data> queue = new Queue<Data>();
            queue.Enqueue(new Data(0, 0, root));
            while (queue.Count != 0)
            {
                Data curr = queue.Dequeue();
                allNodes.Add(curr);

                //!Question says that For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and (X+1, Y-1).
                //! Note that, we assign a higher row index value to a node's child node. 
                //!This convention is at odds with the denotation given in the problem description. 
                //! This is done intentionally, in order to keep the ordering of all coordinates consistent, i.e. a lower value in any specific coordinate represents a higher order. 
                //! As a result, a sorting operation in ascending order would work for each coordinate consistently. 
                if (curr.Node.left != null)
                {
                    queue.Enqueue(new Data(curr.Row + 1, curr.Col - 1, curr.Node.left));
                }
                if (curr.Node.right != null)
                {
                    queue.Enqueue(new Data(curr.Row + 1, curr.Col + 1, curr.Node.right));
                }
            }

            //!Sorting first on colums,If they are same sort based on rows , if they are same sort based on value
            //! We can also use custom comparer like below
            //! Custom comparer
            /*
                var comparer=Comparer<Data>.Create((a,b)=>{

                int res = a.Col.CompareTo(b.Col);
                if (res != 0)
                {
                    return res;
                }
                res= a.Row.CompareTo(b.Row);
                if (res != 0)
                {
                    return res;
                }
                return a.Node.Val.CompareTo(b.Node.Val);
            });

            nodes.Sort(comparer);
            */
            allNodes = allNodes.OrderBy(x => x.Col).ThenBy(x => x.Row).ThenBy(x => x.Node.val).ToList();

            int prevCol = allNodes[0].Col;
            List<int> row = new List<int>();
            foreach (Data node in allNodes)
            {
                int currCol = node.Col;
                if (prevCol == currCol)
                {
                    row.Add(node.Node.val);
                }
                else
                {
                    result.Add(new List<int>(row));
                    row = new List<int>();
                    row.Add(node.Node.val);
                }
                prevCol = currCol;
            }
            //! Need to add last row as above loop did not add it. 
            result.Add(new List<int>(row));

            return result;            
        }

        private void PrepareResult(List<(int column, int row, int value)> nodes, List<IList<int>> result)
        {
            //! Custom comparer
            /*
                var comparer=Comparer<Data>.Create((a,b)=>{

                int res = a.Col.CompareTo(b.Col);
                if (res != 0)
                {
                    return res;
                }
                res= a.Row.CompareTo(b.Row);
                if (res != 0)
                {
                    return res;
                }
                return a.Node.Val.CompareTo(b.Node.Val);
            });

            nodes.Sort(comparer);
            */
            nodes = nodes.OrderBy(x => x.column).ThenBy(y => y.row).ThenBy(z => z.value).ToList();
            List<int> level = new List<int>();           
            for (int i = 0; i < nodes.Count; ++i)
            {
                (int y, int x, int val) = nodes[i];
                //! if current node is same as previous simply add it to the existing level else create new level
                if (i == 0 || y == nodes[i - 1].column)
                {
                    level.Add(val);
                }
                else
                {
                    result.Add(level);
                    level = new List<int>();
                    level.Add(val);
                }
                //! This condiciton is for the last level since above if/else will not add it to the result
                if (i == nodes.Count - 1)
                    result.Add(level);
            }
            
        }       
    }
    public class Data
    {
        public int Row;
        public int Col;
        public TreeNode Node;
        public Data(int row, int col, TreeNode node)
        {
            Row = row;
            Col = col;
            Node = node;
        }
    }
}