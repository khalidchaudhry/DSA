using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _3
    {
        public int CountLeaves(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }

            return CountLeaves(root.left) + CountLeaves(root.right);

        }

    }
}
