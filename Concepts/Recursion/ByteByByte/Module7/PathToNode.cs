using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module7
{
    public class PathToNode
    {
        public static void PathToNodeMain()
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(10);

            root.left.left = new Node(5);
            root.left.right = new Node(9);

            root.right.left = new Node(11);
            root.right.right = new Node(14);

            root.right.left.left = new Node(20);


            PathToNode pathToNode = new PathToNode();
            var ans = pathToNode.FindPath(root, 100);

        }
        public static List<Node> PathToNode2(Node root, int val)
        {
            if (root == null) return null;
            if (root.data == val)
            {
                List<Node> toReturn = new List<Node>();
                toReturn.Add(root);
                return toReturn;
            }
            List<Node> left = PathToNode2(root.left, val);
            if (left != null)
            {
                left.Insert(0, root);
                return left;
            }
            List<Node> right = PathToNode2(root.right, val);
            if (right != null)
            {
                right.Insert(0, root);
                return right;
            }
            return null;
        }
        public List<Node> FindPath(Node root, int val)
        {
            List<Node> path = new List<Node>();
            if (root == null)
                return path;

            List<Node> left = FindPath(root.left, val);
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
