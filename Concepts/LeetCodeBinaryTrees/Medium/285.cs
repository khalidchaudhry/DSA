using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _285
    {
        public static void _285Main()
        {



        }


        /// <summary>
        ///! https://leetcode.com/problems/inorder-successor-in-bst/discuss/72653/Share-my-Java-recursive-solution
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public TreeNode InorderSuccessor0(TreeNode root, TreeNode p)
        {
            if (root == null)
                return null;

            if (root.val <= p.val)
            {
                return InorderSuccessor0(root.right, p);
            }
            else
            {
                TreeNode left = InorderSuccessor0(root.left, p);
                //! if nothing on left side then node sitting on will be the value greter than the node
                //! if left is not null return left else return root
                return left ?? root;
            }
        }

        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            if (p == null)
                return null;

            List<TreeNode> nodes = new List<TreeNode>();
            TreeNode toReturn = null;

            InOrderTraversal(root, nodes);

            int lo = 0;
            int hi = nodes.Count - 1;

            while (lo <= hi)
            {

                int mid = lo + ((hi - lo) / 2);

                if (nodes[mid].val == p.val)
                {
                    //!not the last node
                    if (mid + 1 <= nodes.Count - 1)
                    {
                        toReturn = nodes[mid + 1];
                    }

                    break;
                }
                else if (nodes[mid].val > p.val)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }

            }

            return toReturn;
        }

        private void InOrderTraversal(TreeNode root, List<TreeNode> nodes)
        {
            if (root == null)
                return;

            InOrderTraversal(root.left, nodes);
            nodes.Add(root);
            InOrderTraversal(root.right, nodes);
        }

    }
}
