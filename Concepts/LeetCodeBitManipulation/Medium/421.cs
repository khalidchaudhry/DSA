using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _421
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=jCu-Pd0IjIA
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            int maxXOR = int.MinValue;
            TreeNode head = new TreeNode();
            for (int i = 0; i < nums.Length; ++i)
            {
                InsertNode(nums[i], head);

            }

            for (int i = 0; i < nums.Length; ++i)
            {
                int xor = FindXOR(nums[i], head);
                maxXOR = Math.Max(maxXOR, xor);
            }

            return maxXOR;
        }

        private int FindXOR(int num, TreeNode curr)
        {
            int currXOR = 0;

            for (int i = 31; i >= 0; --i)
            {
                //! bit from left side. Most significant bit
                int bit = num >> i & 1;
                if (bit == 0)
                {
                    if (curr.right != null)
                    {
                        currXOR = currXOR + (int)Math.Pow(2, i);
                        curr = curr.right;
                    }
                    else
                    {
                        curr = curr.left;
                    }
                }
                else
                {
                    if (curr.left != null)
                    {
                        currXOR = currXOR + (int)Math.Pow(2, i);
                        curr = curr.left;
                    }
                    else
                    {
                        curr = curr.right;
                    }
                }
            }
            return currXOR;
        }

        private void InsertNode(int nums, TreeNode curr)
        {
            for (int i = 31; i >= 0; --i)
            {
                int leftMostBit = nums >> i & 1;
                if (leftMostBit == 0)
                {
                    if (curr.left == null)
                    {
                        curr.left = new TreeNode();
                    }
                    curr = curr.left;
                }
                else
                {
                    if (curr.right == null)
                    {
                        curr.right = new TreeNode();
                    }
                    curr = curr.right;
                }
            }
        }



        /// <summary>
        /// https://www.youtube.com/watch?v=PTvFn17ZDRg
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR1(int[] nums)
        {
            int maxXOR = 0;
            int mask = 0;

            for (int i = 32; i >= 0; --i)
            {
                //! we are using the mask to find the most significant bit set for all array element
                mask = mask | (1 << i);
                HashSet<int> hs = new HashSet<int>();
                //! Checking if any element in the nums array s has the bit i set  
                foreach (int num in nums)
                {
                    hs.Add(num & mask);
                }
                //!Think of tempMax as the target we want to find 

                int tempMax = maxXOR | (1 << i);
                foreach (int prefix in hs)
                {
                    if (hs.Contains(prefix ^ tempMax))
                    {
                        maxXOR = tempMax;
                        break;
                    }
                }

            }

            return maxXOR;
        }





        /// <summary>
        // !Brute Force
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR2(int[] nums)
        {
            int maxXOR = 0;

            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    int xor = nums[i] ^ nums[j];

                    maxXOR = Math.Max(xor, maxXOR);
                }
            }

            return maxXOR;
        }


    }

    public class TreeNode
    {
        public TreeNode left;

        public TreeNode right;
    }
}
