using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class InsertLevelOrder
    {
        // Function to insert nodes in level order 
        public Node insertLevelOrder(int[] arr,
                                Node root, int i)
        {
            // Base case for recursion 
            if (i < arr.Length)
            {
                Node temp = new Node(arr[i]);
                root = temp;

                // insert left child 
                root.left = insertLevelOrder(arr,
                                root.left, 2 * i + 1);

                // insert right child 
                root.right = insertLevelOrder(arr,
                                root.right, 2 * i + 2);
            }
            return root;
        }
    }
}
