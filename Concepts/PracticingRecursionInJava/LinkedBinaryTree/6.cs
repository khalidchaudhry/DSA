using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _6
    {
        public int SumData(Node root)
        {
            if (root == null)
                return 0;

            int sum=root.data+SumData(root.left)+SumData(root.right);

            return sum;
        }

    }
}
