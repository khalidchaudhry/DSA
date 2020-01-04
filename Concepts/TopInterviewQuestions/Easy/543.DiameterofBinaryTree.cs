using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _543
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {

            if (root == null)
                return 0;

            int lHeight = Height(root.left);
            int rHeight = Height(root.right);

            int lDiameter = DiameterOfBinaryTree(root.left);
            int rDiameter = DiameterOfBinaryTree(root.right);

            return Math.Max((lHeight+rHeight),Math.Max(lDiameter ,rDiameter));            

        }

        private int Height(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftTreeHeight=Height(node.left);
            int rightTreeHeight=Height(node.right);

            return 1 + Math.Max(leftTreeHeight, rightTreeHeight);

        }

    }
}
