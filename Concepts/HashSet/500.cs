using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _500
    {
        public string[] FindWords(string[] words)
        {

            List<string> result = new List<string>();
            HashSet<Char> firstRow = new HashSet<char>()
            {
              'Q', 'W','E','R','T', 'Y','U','I','O', 'P'
            };

            HashSet<Char> secondRow = new HashSet<char>()
            {
              'A', 'S','D','F','G', 'H','J','K','L'
            };

            HashSet<Char> thirdRow = new HashSet<char>()
            {
              'Z', 'X','C','V','B', 'N','M'
            };
            
            foreach (string word in words)
            {
                int i = 0;
                string upperCaseWord = word.ToUpper();
                HashSet<char> rowToSearch = new HashSet<char>();
                bool addWord = true;

                if (firstRow.Contains(upperCaseWord[i]))
                {
                    rowToSearch = firstRow;
                }
                else if (secondRow.Contains(upperCaseWord[i]))
                {
                    rowToSearch = secondRow;
                }
                else
                {
                    rowToSearch = thirdRow;
                }

                for (int j = 1; j < upperCaseWord.Length; j++)
                {
                    if (!rowToSearch.Contains(upperCaseWord[j]))
                    {
                        addWord = false;
                        break;
                    }
                }
                if (addWord)
                {
                    result.Add(word);
                }
            }

            return result.ToArray();            
        }


    }
}
