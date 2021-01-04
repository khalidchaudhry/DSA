using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    class _617
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            TreeNode node;
            if (t1 == null && t2 == null)
                return null;
            else if (t1 != null && t2 != null)
            {
                node = new TreeNode(t1.val + t2.val);
            }
            else if (t1 != null && t2 == null)
            {
                node = new TreeNode(t1.val);
            }
            else
            {
                node = new TreeNode(t2.val);
            }

            node.left = MergeTrees(t1?.left, t2?.left);

            node.right = MergeTrees(t1?.right, t2?.right);

            return node;

        }

        public TreeNode MergeTrees2(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            else if (t2 == null)
            {
                return t1;
            }
            t1.val += t2.val;

            t1.left = MergeTrees(t1.left, t2.left);

            t2.right = MergeTrees(t1.right, t2.right);

            return t1;

        }

    }
}
