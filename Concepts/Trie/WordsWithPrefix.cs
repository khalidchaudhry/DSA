using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    public class WordsWithPrefix
    {
        public void WordsWithPrefixMain()
        {

            string[] words = new string[] { "apk", "app", "apple", "arp", "array" };

            string prefix = "a";
            int count= WordsWithPrefixCount(words, prefix);

        }
        private int WordsWithPrefixCount(string[] words, string prefix)
        {
            Trie trie = new Trie();
            foreach (string word in words)
            {
                trie.Insert(word);
            }

            return trie.PrefixCount(prefix);
        }
    }
}
