using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _101
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            return Check(root.left, root.right);
        }
          /*
              1
             / \
            2   2
           / \ / \
          3  4 4  3
          */
        public bool Check(TreeNode leftSubTree, TreeNode rightSubTree)
        {
            //If both nodes passed in are null, by default we have a symmetric tree.

            if (leftSubTree == null && rightSubTree == null)
            {
                return true;
            }
            //If one node is null and the other is not, then we have incongruence, the tree is not symmetric since a pair failed.
            // If both nodes are not null, then compare values.If values are equal, then good.Go left and go right.
            else if (leftSubTree != null && rightSubTree != null)
            {
                return leftSubTree.val == rightSubTree.val &&
                    Check(leftSubTree.left, rightSubTree.right) &&
                    Check(leftSubTree.right, rightSubTree.left);
            }
          

            return false;

        }

    }
}
