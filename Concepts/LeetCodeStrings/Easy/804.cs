using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _804
    {
        public int UniqueMorseRepresentations(string[] words)
        {
            HashSet<string> hs = new HashSet<string>();
            Dictionary<Char, string> dict = new Dictionary<char, string>()
            {
                { 'a',".-" },
                { 'b',"-..." },
                {'c', "-.-." },
                { 'd',"-.." },
                { 'e',"." },
                { 'f',"..-." },
                { 'g',"--." },
                { 'h',"...." },
                { 'i',".." },
                { 'j',".---" },
                { 'k',"-.-" },
                { 'l',".-.." },
                { 'm',"--" },
                { 'n',"-." },
                { 'o',"---" },
                { 'p',".--." },
                {'q', "--.-" },
                { 'r',".-." },
                { 's',"..." },
                { 't',"-" },
                { 'u',"..-" },
                { 'v',"...-" },
                { 'w',".--" },
                { 'x',"-..-" },
                { 'y',"-.--" },
                { 'z',"--.." }
            };
            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                sb.Clear();

                foreach (char c in word)
                {
                    sb.Append(dict[c]);
                }

                string s = sb.ToString();

                if (!hs.Contains(s))
                {
                    hs.Add(s);
                }
            }

            return hs.Count;
        }
    }
}
