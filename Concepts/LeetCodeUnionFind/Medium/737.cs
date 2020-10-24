using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnionFind.Medium
{
    public class _737
    {
        /// <summary>
        /// https://leetcode.com/problems/sentence-similarity-ii/discuss/109752/JavaC%2B%2B-Clean-Code-with-Explanation
        /// </summary>        
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, IList<IList<string>> pairs)
        {
            if (words1.Length != words2.Length)
            {
                return false;
            }

            Dictionary<string, string> parent = new Dictionary<string, string>();

            foreach (List<string> pair in pairs)
            {
                string x = FindParent(parent, pair[0]);
                string y = FindParent(parent, pair[1]);
                if (x != y)
                {
                    parent.Add(x, y);
                }
            }

            for (int i = 0; i < words1.Length; ++i)
            {
                if (!words1[i].Equals(words2[i]) &&
                     !FindParent(parent, words1[i]).Equals(FindParent(parent, words2[i]))
                   )
                {
                    return false;
                }
            }

            return true;
        }

        private string FindParent(Dictionary<string, string> map, string word)
        {
            if (map.ContainsKey(word))
            {
                string parent = map[word].Equals(word) ? word : FindParent(map, map[word]);
                return parent;
            }
            else
            {
                return word;
            }
        }
    }
}
