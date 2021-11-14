using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    class _1055
    {
        public int ShortestWay(string source, string target)
        {

            HashSet<char> sourceChars = new HashSet<char>();
           
            foreach (char c in source)
            {
                sourceChars.Add(c);
            }

            //! We need to look target chars in source map 
            //! e.g source=abc   target=abcd
            foreach (char c in target)
            {
                if (!sourceChars.Contains(c))
                {
                    return -1;
                }
            }
            //!we need atleast one subsequence e.g. 
            //! source="abc"  and target="abc" then we need atleast one subsequence of source to make target
            int subsequences = 1;

            int sIdx = 0;
            int tIdx = 0;
            while (tIdx < target.Length)
            {
                if (sIdx == source.Length)
                {
                    ++subsequences;
                    sIdx = 0;
                }

                if (source[sIdx] == target[tIdx])
                {
                    ++sIdx;
                    ++tIdx;
                }
                else
                {
                    ++sIdx;
                }
            }
            return subsequences;
        }
    }
}
