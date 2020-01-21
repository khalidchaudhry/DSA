using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCIQEasy
{
    public class _572
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            // Pre order Traversal 
            List<int> sNodes = new List<int>();
            List<int> tNodes = new List<int>();
            PreOrderTraversal(s, sNodes);
            PreOrderTraversal(t, tNodes);

            int index = sNodes.LastIndexOf(tNodes.First());

            if (index == -1)
            {
                return false;
            }
            else
            {
                List<int> lst = sNodes.GetRange(index, tNodes.Count);

                if (lst.SequenceEqual(tNodes))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private void PreOrderTraversal(TreeNode s, List<int> nodesList)
        {
            if (s == null)
            {
                nodesList.Add(int.MaxValue);
                return;
            }
            nodesList.Add(s.val);
            PreOrderTraversal(s.left, nodesList);
            PreOrderTraversal(s.right, nodesList);
        }


    }
}
