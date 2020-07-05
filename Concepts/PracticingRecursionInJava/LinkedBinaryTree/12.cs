using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    class _12
    {
        public int Minimum(Node node)
        {
            if (node == null)
            {
                return int.MaxValue;
            }

            return Math.Min(Math.Min(node.data,Minimum(node.left)),Minimum(node.right));
        }

    }
}
