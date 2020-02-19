using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _771
    {
        public int NumJewelsInStones(string J, string S)
        {
            int count = 0;
            HashSet<Char> hs = new HashSet<char>();
            for (int i = 0; i < J.Length; i++)
            {
                hs.Add(J[i]);
            }

            for (int i = 0; i < S.Length; i++)
            {
                if (hs.Contains(S[i]))
                {
                    ++count;
                }
            }

            return count;
        }

    }
}
