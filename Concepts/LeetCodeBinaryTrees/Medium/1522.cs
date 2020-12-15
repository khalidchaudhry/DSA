using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _1522
    {

        public static void _1522Main()
        {
            _1522 Diameter = new _1522();

            Node root = new Node(1);
            Node three = new Node(3);
            Node two = new Node(2);
            Node four = new Node(4);
            Node five = new Node(5);
            Node six = new Node(6);

            root.children = new List<Node> {three,two,four};
            three.children = new List<Node> {five,six };

            Diameter.Diameter(root);                               



        }
        public int Diameter(Node root)
        {
            ResultWrapper wrapper = new ResultWrapper();

            Diameter(root, wrapper);

            return wrapper.Result;

        }

        private int Diameter(Node root, ResultWrapper wrapper)
        {
            if (root == null)
                return 0;
            //! Storing first max and last maximum because max path length will be the path length between firstMaximum and second Maximum
            int firstMaxLength = 0;
            int secondMaxLength = 0;
            if (root.children != null)
            {
                foreach (Node child in root.children)
                {
                    //! +1 because the node we are on is connected with the its leaf. If its leaf node than it will never come inside the loop
                    int length = Diameter(child, wrapper) + 1;

                    if (length > firstMaxLength)
                    {
                        secondMaxLength = firstMaxLength;
                        firstMaxLength = length;
                    }
                    else if (length > secondMaxLength)
                    {
                        secondMaxLength = length;
                    }
                }
            }
            //! Max length will always be sum as together it makes the length 
            wrapper.Result = Math.Max(wrapper.Result, firstMaxLength + secondMaxLength);

            return Math.Max(firstMaxLength, secondMaxLength);

        }

        class ResultWrapper
        {
            public int Result { get; set; }

        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
            val = 0;
            children = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, List<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
