using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _1457
    {

        int _count;
        public int PseudoPalindromicPaths0(TreeNode root)
        {
            _count = 0;
            int[] freqCount = new int[10];
            PseudoPalindromicPaths0(root, freqCount);
            return _count;
        }
        private void PseudoPalindromicPaths0(TreeNode node, int[] freqCount)
        {
            if (node == null)
            {
                return;
            }

            if (node.left == null && node.right == null)
            {
                ++freqCount[node.val];
                if (IsPalindromicPath(freqCount))
                    ++_count;
                --freqCount[node.val];
                return;
            }
            ++freqCount[node.val];
            PseudoPalindromicPaths0(node.left, freqCount);
            PseudoPalindromicPaths0(node.right, freqCount);
            --freqCount[node.val];
        }

        private bool IsPalindromicPath(int[] freqCount)
        {
            int oddsCount = 0;
            foreach (int num in freqCount)
            {
                if (num % 2 == 1)
                    ++oddsCount;
                if (oddsCount > 1)
                    return false;
            }
            return true;
        }
        int count;
        public int PseudoPalindromicPaths(TreeNode root)
        {
            count = 0;
            int mask = 0;
            Helper(root, mask);
            return count;
        }
        private void Helper(TreeNode node, int mask)
        {
            if (node == null)
                return;

            mask = Flip(mask, node.val);

            if (node.left == null && node.right == null)
            {
                int ans = mask & mask - 1;
                if (ans == 0) ++count;
                return;
            }

            Helper(node.left, mask);
            Helper(node.right, mask);

        }

        private int Flip(int mask, int nodeVal)
        {
            return (1 << nodeVal) ^ mask;
        }




    }
}
