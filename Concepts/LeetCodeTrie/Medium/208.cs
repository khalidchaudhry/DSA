using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie.Medium
{
    public class _208
    {
        public static void _208Main()
        {
            string word1 = "word";
            string word2 = "work";
            string word3 = "problem";
            string word4 = "process";


            Trie obj = new Trie();
            obj.Insert("apple");
            //obj.Insert(word2);

            bool param_2 = obj.Search("apple");
            bool param_3 = obj.Search("app");

            //bool param_3 = obj.StartsWith("wor");
            Console.ReadLine();
        }





    }

    /// <summary>
    /// https://leetcode.com/problems/implement-trie-prefix-tree/discuss/347038/HasMap-base-java-solution-fo-Trie
    /// # <image url="https://64.media.tumblr.com/0115640d31399f8d00c17e785782b495/tumblr_inline_ovxxwnY5dO1u8bvyd_1280.png" scale="0.5" /> 



    ///  /// # <image url="https://www.adamk.org/wp-content/uploads/2019/12/whiteboard-leetcode208.jpg" scale="0.2" /> 
    /// </summary>
    public class Trie
    {

        /** Initialize your data structure here. */
        Node root;
        public Trie()
        {
            root = new Node();
        }

        /** Inserts a word into the trie. */
        //! Time complexity=O(M*N) where M is the maximum word length and N is the total words
       
        public void Insert(string word)
        {
            //! We will always starts with the root. 
            Node curr = root;

            for (int i = 0; i < word.Length; ++i)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    curr.Children.Add(word[i], new Node());
                }

                curr = curr.Children[word[i]];
            }
            //! Marks the current node is the word 
            curr.IsWord = true;
        }

        /// <summary>
        //! Time Complexity:O(M) where M is the length of the word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Search(string word)
        {
            //! We will always starts with the root. 
            Node curr = root;
            for (int i = 0; i < word.Length; ++i)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    return false;
                }

                curr = curr.Children[word[i]];
            }

            //! Returns true if and only if reached node returns true
            return curr.IsWord;
        }

        /// <summary>
        //! Time Complexity:O(M) where M is the length of the prefix
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public bool StartsWith(string prefix)
        {
            Node curr = root;

            for (int i = 0; i < prefix.Length; ++i)
            {
                if (!curr.Children.ContainsKey(prefix[i]))
                {
                    return false;
                }

                curr = curr.Children[prefix[i]];
            }
            return true;
        }
    }
    public class Node
    {
        public Dictionary<char, Node> Children { get; set; }

        public bool IsWord { get; set; }
        public Node()
        {
            Children = new Dictionary<char, Node>();
            IsWord = false;
        }
    }

}
