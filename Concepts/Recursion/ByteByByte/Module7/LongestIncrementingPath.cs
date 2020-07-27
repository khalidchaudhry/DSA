using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module7
{
    public class LongestIncrementingPath
    {
        public static void LongestIncrementingPathMain()
        {
            //Node root = new Node(6);
            //root.right = new Node(9);
            //root.right.right = new Node(10);
            //root.right.left = new Node(7);
            //root.right.right.right = new Node(11);


            Node root = new Node(1);
            root.left = new Node(2);
            root.left.left = new Node(3);

            root.right = new Node(4);
            root.right.left = new Node(5);

            root.right.right = new Node(6);
            root.right.right.left = new Node(7);



            LongestIncrementingPath path = new LongestIncrementingPath();

            var result = path.LongestPath(root);

        }
        /// <summary>
        //! PreOrder traversal 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestPath(Node root)
        {

            return LongestPath(root, 1, root);

        }

        private int LongestPath(Node node, int pathLength, Node parent)
        {
            if (node == null)
                return pathLength;

            if (node.data == parent.data + 1)
            {
                //! Which path gives the best result . Left or right and take the maximum of it 
                return Math.Max(LongestPath(node.left, pathLength + 1, node), LongestPath(node.right, pathLength + 1, node));
            }
            //! either return the curr path or reset the path length and start DFS from there 
            return Math.Max(pathLength, Math.Max(LongestPath(node.left, 1, node), LongestPath(node.right, 1, node)));
        }

        /// <summary>
        //! Post Order traversal 
        //https://leetcode.com/problems/binary-tree-longest-consecutive-sequence/solution/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestPath2(Node root)
        {
            ResultWrapper wrapper = new ResultWrapper();
            LongestPath2(root, wrapper);

            return wrapper.Result;
        }

        private int LongestPath2(Node node, ResultWrapper wrapper)
        {
            if (node == null)
            {
                return 0;
            }

            int left = LongestPath2(node.left, wrapper) + 1;    //!Adding 1 for the current node 
            int right = LongestPath2(node.right, wrapper) + 1;  //! Adding 1 for the current node 

            if (node.left != null && node.data + 1 != node.left.data)
            {
                left = 1;//! reset the left side
            }


            if (node.right != null && node.data != node.right.data)
            {
                right = 1;//! reset the right side. 
            }
            int length = Math.Max(left, right);
            wrapper.Result = Math.Max(wrapper.Result, length);

            return length;

        }
    }



    public class ResultWrapper
    {
        public int Result { get; set; }
    }
}
