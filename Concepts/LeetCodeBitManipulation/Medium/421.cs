using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _421
    {

        public static void _421Main()
        {
            _421 test = new _421();

            int[] arr = new int[] { 3, 10, 5, 25, 2, 8 };
            var ans=test.FindMaximumXOR3(arr);
            Console.WriteLine(ans);

        }       
        /// <summary>
        /// https://www.youtube.com/watch?v=jCu-Pd0IjIA
        //! Using Trie
        //! Time complexity:
        //! Searching: O(mn) where m is the length of the longest key and and n is the total number of keys. O(32*n) where 32 is 32 bits of int and n is the total nums in array
        //! Insertion: Depends on the length of the word 'a' that’s being searched and the number of total words, n, making the runtime of these operations O(32n)
        //! O(32*n)+O(32*n)=O(n)
        //! Space Complexity: space complexity is O(m*n), where m  is the length of the longest key and and n is the total number of keys
        //! O(32*n)
        //// # <image url="https://bloggg-1254259681.cos.na-siliconvalley.myqcloud.com/5dhef.jpg" scale="0.3" />  
       
           //! We are representing 0 as left and 1 as right in Trie 
            /// </summary>
       
        public int FindMaximumXOR(int[] nums)
        {
            Trie trie = new Trie();
            for (int i = 0; i < nums.Length; ++i)
            {
                trie.Insert(nums[i]);
            }

            int maxXOR = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                int xor = trie.Search(nums[i]);
                maxXOR = Math.Max(xor, maxXOR);
            }

            return maxXOR;
        }
        
        public int FindMaximumXOR3(int[] nums)
        {

            int maxXor = 0;
            //!Starting from most significant bit and moving towards least significant bit
            //! why because we need to increase the window size(bits we select) from  1,2,3........31
            for (int b = 31; b >= 0; --b)
            {
                int test = b;
                HashSet<int> prefix = new HashSet<int>();                
               
                //! We are extracting 1 bit when b=31 then 2 bits when b=30 then 3 bits so on ...untill 32 bits 
                for (int i = 0; i < nums.Length; ++i)
                {                    
                    int numPrefix = nums[i] >> b;
                    prefix.Add(numPrefix);
                }

                maxXor = maxXor << 1;
                int target = maxXor | 1;

                //! target=a^b
                //! target^a=a^b^a
                //! target^a=b
                foreach (int a in prefix)
                {
                    if (prefix.Contains(target ^ a))
                    {
                        maxXor = target;
                        break;
                    }
                }
            }

            return maxXor;
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
    public class Trie
    {
        TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        /// <summary>
        //! Insert 0 on the left side and and insert 1 on the right side.  
        /// </summary>
        public void Insert(int number)
        {

            TrieNode curr = root;
            for (int i = 31; i >= 0; --i)
            {
                int leftMostBit = (number >> i) & 1;
                if (leftMostBit == 0)
                {
                    if (curr.Left == null)
                    {
                        curr.Left = new TrieNode();
                    }
                    curr = curr.Left;
                }
                else
                {
                    if (curr.Right == null)
                    {
                        curr.Right = new TrieNode();
                    }
                    curr = curr.Right;
                }
            }
        }
        public int Search(int number)
        {
            int maxXOR = 0;

            TrieNode curr = root;
            for (int bitPos = 31; bitPos >= 0; --bitPos)
            {
                //! current bit can be 0 or 1 
                int leftMostBit = (number >> bitPos) & 1;
                if (leftMostBit == 0)
                {
                    //!curr.right is not null(it means we have 1) then we will take it as it will give maximum XOR
                    if (curr.Right != null)
                    {
                        maxXOR = maxXOR + (int)Math.Pow(2, bitPos); //! or we can use 1<<bitPos to acheive the same
                        curr = curr.Right;
                    }
                    else
                        curr = curr.Left;
                }
                else
                {
                    if (curr.Left != null)
                    {
                        maxXOR = maxXOR + (int)Math.Pow(2, bitPos);
                        curr = curr.Left;
                    }
                    else
                        curr = curr.Right;
                }
            }

            return maxXOR;
        }
    }


    public class TrieNode
    {
        public TrieNode Left { get; set; }
        public TrieNode Right { get; set; }
    }
}
