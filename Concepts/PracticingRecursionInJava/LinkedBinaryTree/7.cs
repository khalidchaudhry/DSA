using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _7
    {

        public int Product(Node root)
        {
            if (root == null)
            {
                return 1;
            }

            return root.data * Product(root.left) * Product(root.right);
        }
    }
}
