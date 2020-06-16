using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _4
    {
        public int CountNonLeaves(Node root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 0;

            return 1 + CountNonLeaves(root.left) + CountNonLeaves(root.right);

        }


    }
}
