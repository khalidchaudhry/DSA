using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie.Medium
{
    public class _421
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=jCu-Pd0IjIA
        //! Using Trie
        //! Time complexity:
        //! Searching: O(mn) where m is the length of the longest key and and n is the total number of keys. 
        //! O(32*n) where 32 is 32 bits of int and n is the total nums in array
        //! Insertion: Depends on the length of the word 'a' that’s being searched and the number of total words, n, making the runtime of these operations O(32n)
        //! O(32*n)+O(32*n)=O(n)
        //! Space Complexity: space complexity is O(m*n), where m  is the length of the longest key and and n is the total number of keys
        //! O(32*n)

        //// # <image url="https://bloggg-1254259681.cos.na-siliconvalley.myqcloud.com/5dhef.jpg" scale="0.3" />  
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            int maxXOR = int.MinValue;
            TreeNode root = new TreeNode();
            for (int i = 0; i < nums.Length; ++i)
            {
                InsertNode(nums[i], root);
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                int xor = FindMaxXORPair(nums[i], root);
                maxXOR = Math.Max(maxXOR, xor);
            }

            return maxXOR;
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
        private int FindMaxXORPair(int num, TreeNode curr)
        {
            int currXOR = 0;

            for (int i = 31; i >= 0; --i)
            {
                //! bit from left side. Most significant bit
                int bit = (num >> i) & 1;
                //! current bit can be 0 or 1 
                if (bit == 0)
                {
                    //! if bit is zero and curr.right is not null(it means we have 1) then we will take it as it will give maximum XOR
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
        /// <summary>
        //! Insert 0 on the left side and and insert 1 on the right side. 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="curr"></param>
        private void InsertNode(int nums, TreeNode curr)
        {
            for (int i = 31; i >= 0; --i)
            {
                int leftMostBit = (nums >> i) & 1;
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

    }

    public class TreeNode
    {
        public TreeNode left;

        public TreeNode right;
    }
}
