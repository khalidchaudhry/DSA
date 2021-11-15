using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie.Hard._140
{
    public class _140
    {
        public IList<string> WordBreak0(string s, IList<string> wordDict)
        {
            HashSet<string> words = new HashSet<string>();
            foreach (string word in wordDict)
            {
                words.Add(word);
            }
            List<string> result = new List<string>();
            Solve(s, 0, words, new StringBuilder(), result);
            return result;
        }
        private void Solve(string s, int start, HashSet<string> words, StringBuilder path, List<string> result)
        {
            if (start == s.Length)
            {
                //! important to reduce the length since when we reach here there would be ' ' as per line 38
                --path.Length;
                result.Add(path.ToString());
                return;
            }
            for (int i = start; i < s.Length; ++i)
            {
                string pre = s.Substring(start, i - start + 1);
                if (words.Contains(pre))
                {

                    int len = path.Length;
                    path.Append(pre);
                    path.Append(' ');
                    Solve(s, i + 1, words, path, result);
                    //! we need to backtrack hence resetting it to prev Length
                    path.Length = len;
                }
            }
        }
        /// <summary>
        //! Trie solution. Rather than searching in hashset for word , we can search them in Trie and replace hashset with trie 
        /// </summary>
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {

            Trie trie = new Trie();
            foreach (string word in wordDict)
            {
                trie.Insert(word);
            }
            List<string> result = new List<string>();
            trie.Search(s, 0, new StringBuilder(), result);
            return result;
        }
    }
    public class Trie
    {
        public TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
            _root.Children.Add('/', new TrieNode());

        }
        public void Insert(string word)
        {
            TrieNode curr = _root;

            foreach (char c in word)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    curr.Children.Add(c, new TrieNode());
                }
                curr = curr.Children[c];
            }
            ++curr.WordEnd;
        }

        public void Search(string word, int start, StringBuilder sb, List<string> result)
        {
            if (start == word.Length)
            {
                --sb.Length;
                result.Add(sb.ToString());
                return;
            }

            TrieNode curr = _root;

            for (int i = start; i < word.Length; ++i)
            {
                char c = word[i];
                //! If we don't find the characer in children of the curr than return immediately. Not point continue further 
                if (!curr.Children.ContainsKey(c))
                {
                    return;
                }
                curr = curr.Children[c];

                if (curr.WordEnd > 0)
                {
                    int len = sb.Length;
                    string pre = word.Substring(start, i - start + 1);
                    sb.Append(pre);
                    sb.Append(' ');
                    Search(word, i + 1, sb, result);
                    sb.Length = len;
                }

            }
        }
    }

   
}
