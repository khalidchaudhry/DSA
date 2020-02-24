using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _290
    {
        public bool WordPattern(string pattern, string str)
        {
            Dictionary<char, string> map = new Dictionary<char, string>();
            HashSet<string> hs = new HashSet<string>();
            string[] words = str.Split(' ');
            if (pattern.Length != words.Length)
                return false;

            for (int i = 0; i < pattern.Length; i++)
            {
                // if pattern character does not exist insert into the dictionary
                if (map.ContainsKey(pattern[i]))
                {
                    if (words[i] != map[pattern[i]])
                    {
                        return false;
                    }
                }
                else
                {
                    // if reach here than character does not exist in map.
                    // Check if the word has not already been mapped with some other character
                    if (hs.Contains(words[i]))
                    {
                        return false;
                    }
                    hs.Add(words[i]);
                    map.Add(pattern[i], words[i]);
                }
            }

            return true;
        }

    }
}
