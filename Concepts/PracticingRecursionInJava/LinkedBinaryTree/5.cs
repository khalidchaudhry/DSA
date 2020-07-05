using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedBinaryTree
{
    public class _5
    {
        public Node PointToItem(Node root, int item)
        {

            if (root == null)
                return null;

            else if (root.data == item)
            {
                return root;
            }
            else
            {
                Node left = PointToItem(root.left, item);
                if (left != null)
                {
                    return left;
                }
                else
                {
                    return PointToItem(root.right, item);
                }
            }
        }

    }
}
