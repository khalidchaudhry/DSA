using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _104
    {

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int leftTreeDepth = MaxDepth(root.left);
            int rightTreeDepth = MaxDepth(root.right);

            return Math.Max(leftTreeDepth, rightTreeDepth) + 1;
        }
    }  
}
