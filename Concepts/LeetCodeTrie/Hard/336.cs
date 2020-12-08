using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie.Hard
{
    class _336
    {

        public static void _336Main()
        {
            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            _336 Pali = new _336();
            var ans = Pali.PalindromePairs1(words);

            Console.ReadLine();
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=9G0Tme4w04s       
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<int>> PalindromePairs1(string[] words)
        {
            List<IList<int>> results = new List<IList<int>>();

            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; ++i)
            {
                char[] charArray = words[i].ToCharArray();
                Array.Reverse(charArray);
                map.Add(new string(charArray), i);
            }

            for (int i = 0; i < words.Length; ++i)
            {
                //! suffix(actually prefix but since we reversed the word , it becomes suffix)
                string word = words[i];
                for (int j = 0; j < word.Length; ++j)
                {
                    if (IsPalindrome(word, j, word.Length - 1))
                    {
                        string suffix = word.Substring(0, j);
                        if (map.ContainsKey(suffix))
                        {
                            AddToResult(i, map[suffix], results);
                        }
                    }
                }
                //Prefix
                for (int j = word.Length - 1; j >= 0; --j)
                {
                    if (IsPalindrome(word, 0, j))
                    {
                        string prefix = word.Substring(j+1);
                        if (map.ContainsKey(prefix))
                        {
                            AddToResult(map[prefix], i, results);                                                      
                        }
                    }
                }
                //Complete
                if (map.ContainsKey(word))
                {                    
                    AddToResult(i, map[word], results);
                }
            }

            return results;


        }

        private bool IsPalindrome(string word, int i, int j)
        {
            while (i < j)
            {
                if (word[i] != word[j])
                    return false;
                ++i;
                --j;
            }

            return true;
        }


        private void AddToResult(int left, int right, List<IList<int>> results)
        {
            if (left != right)
            {
                List<int> result = new List<int>() { left, right };
                results.Add(result);
            }
        }

        /// <summary>
        //! Brute Force (Time limit excceeded on leetcode)
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<int>> PalindromePairs2(string[] words)
        {
            List<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < words.Length; ++i)
            {
                for (int j = 0; j < words.Length; ++j)
                {
                    if (i == j) continue;
                    if (IsPalindrome(words[i], words[j]))
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }
            return result;
        }

        private bool IsPalindrome(string word1, string word2)
        {
            string concateWord = word1 + word2;
            int i = 0;
            int j = concateWord.Length - 1;
            while (i < j)
            {
                if (concateWord[i] != concateWord[j])
                    return false;

                ++i;
                --j;
            }

            return true;
        }
    }
}
