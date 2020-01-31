using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    public class _572
    {
        TreeNode nodeIns;
        public bool IsSubTree2(TreeNode s, TreeNode t)
        {
            nodeIns = null;

            if (s == null && t == null)
                return true;
            if (s == null && t != null)
                return false;
            if (s != null && t == null)
                return true;

            FoundNode(s, t);

            if (s != null)
            {
                return IsIdentical(nodeIns, t);
            }
            else
            {
                return false;
            }

        }

        private void FoundNode(TreeNode s, TreeNode t)
        {
            if (s == null)
                return;
            if (s.val == t.val)
            {
                nodeIns = s;
            }

            FoundNode(s.left, t);
            FoundNode(s.right, t);

        }

        private bool IsIdentical(TreeNode t1, TreeNode t2)
        {
            if (t1 != null && t2 != null)
            {
                return t1.val == t2.val && IsIdentical(t1.left, t2.left) && IsIdentical(t1.right, t2.right);

            }

            return false;

        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            // In order Traversal 
            List<int> sNodes = new List<int>();
            List<int> tNodes = new List<int>();
            InOrderTraversal(s, sNodes);
            InOrderTraversal(t, tNodes);

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
        private void InOrderTraversal(TreeNode s, List<int> nodesList)
        {
            if (s == null)
            {
                //nodesList.Add(int.MaxValue);
                return;
            }

            InOrderTraversal(s.left, nodesList);
            nodesList.Add(s.val);
            InOrderTraversal(s.right, nodesList);
        }


    }
}
