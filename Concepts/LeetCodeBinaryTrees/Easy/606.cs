using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _606
    {
        public string Tree2str(TreeNode t)
        {
            StringBuilder sb = new StringBuilder();

            Helper(sb, t);

            return sb.ToString();
        }
        private void Helper(StringBuilder sb, TreeNode node)
        {
            if (node != null)
            {
                sb.Append(node.val);

                if (node.left != null || node.right != null)
                {

                    // left side will be having brackets even they are empty 
                    sb.Append("(");    
                    Helper(sb, node.left);
                    sb.Append(")");
                    // if right side is null then no brackets 
                    if (node.right != null)
                    {
                        sb.Append("(");
                        Helper(sb, node.right);
                        sb.Append(")");
                    }
                }
            }
        }
    }
}
