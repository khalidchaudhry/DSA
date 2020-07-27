using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class PathToNode
    {
        public List<Node> FindPath(Node root, int val)
        {
            List<Node> path = new List<Node>();
            if (root == null)
                return path;

            List<Node> left = FindPath(root.left,val);
            List<Node> right = FindPath(root.right, val);

            if (root.data == val || left.Count != 0 || right.Count != 0)
            {
                path.Add(root);
            }
            path.AddRange(left);
            path.AddRange(right);

            return path;
        }


    }
}
