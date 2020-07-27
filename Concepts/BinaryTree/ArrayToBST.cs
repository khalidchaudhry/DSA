using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class ArrayToBST
    {
        public Node ArrayToBSTConversion(int[] arr)
        {
            Node root = null;
            for (int i = 0; i < arr.Length; i++)
            {
                ArrayToBSTConversion(root, arr[i]);
            }

            return root;

        }
        private Node ArrayToBSTConversion(Node currentNode, int value)
        {
            if (currentNode == null)
            {
                return new Node(value);
            }
            else
            {
                if (value > currentNode.data)
                    currentNode.right = ArrayToBSTConversion(currentNode.right, value);
                else if (value < currentNode.data)
                    currentNode.left = ArrayToBSTConversion(currentNode.left, value);
            }

            return currentNode;
        }
    }
}
