using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class FindSubstring
    {
        public List<int> SubstringWithAllConcatenateWords(string s, List<string> words)
        {
            Dictionary<string, int> wordsNeeded = new Dictionary<string, int>();

            List<int> ans = new List<int>();

            if (words.Count == 0)

                return ans;

            int window_size = 0;
            int word_size = words[0].Length;

            // building frequency table
            foreach (string word in words)
            {
                window_size += word.Length;
                if (wordsNeeded.ContainsKey(word))
                {
                    wordsNeeded[word]++;
                }
                else
                {
                    wordsNeeded.Add(word,1);
                }
            }

            Dictionary<string, int> reference = wordsNeeded;

            int begin = 0, end = 0, wordsNeededCount = wordsNeeded.Count;

            List<string> tokens = new List<string>();

            if (s.Length < window_size) return ans;

            // we increment begin and end only in word_size 
            // there are only word_size possible start points for our window. 
            // end is actually the start of the last word in window or put in other words
            // the real end of window is actually at end + word_size
            for (int i = 0; i < word_size; i++)
            {
                begin = i; end = i;
                wordsNeeded = reference; // reset to original frequency table after every iteration
                wordsNeededCount = wordsNeeded.Count;

                while (end + word_size - 1 < s.Length)
                {
                    string lastword = s.Substring(end, word_size);

                    if (wordsNeeded.ContainsKey(lastword))
                    {
                        wordsNeeded[lastword]--;
                        if (wordsNeeded[lastword] == 0) wordsNeededCount--;
                    }

                    if (end + word_size - begin == window_size)
                    {
                        // counter == 0, valid answer !
                        if (wordsNeededCount == 0)
                        {
                            ans.Add(begin);
                        }

                        string firstword = s.Substring(begin, word_size);

                        if (wordsNeeded.ContainsKey(firstword))
                        {
                            wordsNeeded[firstword]++;
                            if (wordsNeeded[firstword] > 0) wordsNeededCount++;
                        }

                        begin += word_size;
                    }

                    end += word_size;
                }
            }

            return ans;

        }

    }
}
