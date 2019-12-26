using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _14
    {
        // ["flower","flow","flight"]
        public string LongestCommonPrefix(string[] strs)
        {

            if (strs.Length == 0)
            {
                return string.Empty;
            }
            string shortestString = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i].Length < shortestString.Length)
                {
                    shortestString = strs[i];
                }
            }
            for (int j = shortestString.Length; j > 0; j--)
            {
                string stringToSearch = shortestString.Substring(0, j);
                bool stringMatched = true;
                for (int i = 0; i < strs.Length; i++)
                {
                    if (!strs[i].Substring(0, j).Equals(stringToSearch))
                    {
                        stringMatched = false;
                        break;
                    }
                }

                if (stringMatched)
                {
                    return shortestString.Substring(0, j);
                }
            }          

            return string.Empty;
        }

    }
}
