using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class AllSubStrings
    {
        public static void AllSubstrings(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j <= s.Length; j++)
                {
                     int len = j - i;
                    Console.WriteLine(s.Substring(i, len));
                }
            }

        }
    }
}
