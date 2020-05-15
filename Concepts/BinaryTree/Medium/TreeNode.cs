using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Medium
{
    public class TreeNode
    {
        private TreeNode left;
        private TreeNode right;
        private int value;

        public TreeNode(TreeNode left,TreeNode right,int value)
        {
            this.left = left;
            this.right = right;
            this.value = value;
        }

        public TreeNode Left
        {
            get => left;
            set => left = value;
        }
        public TreeNode Right
        {
            get => right;
            set => right = value;
        }
        public int Value
        {
            get => value;
            set => this.value = value;
        }

    }
}
