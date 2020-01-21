using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCIQEasy
{
    class _819
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            if (string.IsNullOrEmpty(paragraph))
            {
                return paragraph;
            }
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] paragraphWords = paragraph.Split(new char[] {' ',',' });

            for (int i = 0; i < banned.Length; i++)
            {
                banned[i] = banned[i].ToLower();
            }

            for (int i = 0; i < paragraphWords.Length; i++)
            {
                //!?',;.
                var word = paragraphWords[i].Replace("!", "")
                   .Replace("?", "")
                   .Replace("'", "")
                   .Replace(",", "")
                   .Replace(";", "")
                   .Replace(".", "").ToLower();

                if (!banned.Contains(word) && word!=string.Empty)
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        ++wordsCount[word];
                    }
                    else
                    {
                        wordsCount.Add(word,1);
                    }
                }
            }

            return wordsCount.OrderByDescending(x => x.Value).First().Key;
        }
        public string MostCommonWord2(string paragraph, string[] banned)
        {
            int highestFreq = 0;
            string highestWord = null;
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            paragraph = paragraph.Replace(",", " ");
            paragraph = paragraph.Replace(".", " ");
            paragraph = paragraph.Replace("!", " ");
            paragraph = paragraph.Replace("?", " ");
            paragraph = paragraph.Replace(";", " ");
            paragraph = paragraph.Replace("'", " ");

            string[] paragraphWords = paragraph.ToLower().Split(' ');

            for (int i = 0; i < paragraphWords.Length; i++)
            {                     
                if (!banned.Contains(paragraphWords[i]) && paragraphWords[i]!="")
                {
                    if (wordsCount.ContainsKey(paragraphWords[i]))
                    {
                        ++wordsCount[paragraphWords[i]];                                          
                    }
                    else
                    {
                        wordsCount.Add(paragraphWords[i], 1);
                    }

                    if (wordsCount[paragraphWords[i]] > highestFreq)
                    {
                        highestFreq = wordsCount[paragraphWords[i]];
                        highestWord = paragraphWords[i];
                    }
                }
            }

            return highestWord;
        }

    }
}
