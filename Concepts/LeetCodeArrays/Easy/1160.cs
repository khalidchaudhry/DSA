using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1160
    {

        public static void _1160Main()
        {

        }

        public int CountCharacters(string[] words, string chars)
        {

            int result = 0;
            Dictionary<char, int> charsMap = new Dictionary<char, int>();

            for (int i = 0; i < chars.Length; ++i)
            {

                if (!charsMap.ContainsKey(chars[i]))
                {
                    charsMap.Add(chars[i], 1);
                }
                else
                {
                    ++charsMap[chars[i]];
                }
            }

            foreach (string word in words)
            {
                int count = 0;
                bool found = true;
                Dictionary<char, int> clonedCharsMap = new Dictionary<char, int>(charsMap);

                foreach (char c in word)
                {
                    if (clonedCharsMap.ContainsKey(c) && clonedCharsMap[c] >= 1)
                    {

                        --clonedCharsMap[c];
                        ++count;
                    }
                    else
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    result += count;
            }

            return result;

        }


    }
}
