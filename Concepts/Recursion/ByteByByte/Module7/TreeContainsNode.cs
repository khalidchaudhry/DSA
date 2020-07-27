using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module7
{
    class TreeContainsNode
    {

        public bool Contains(Node root, int val)
        {
            if (root == null) return false;

            bool left = Contains(root.left, val);
            bool right = Contains(root.right, val);
            return root.data == val || left || right;     
        }
    }
}
