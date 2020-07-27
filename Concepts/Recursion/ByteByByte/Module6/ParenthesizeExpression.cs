using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module6
{
    public class ParenthesizeExpression
    {
        public static List<string> Parentheses(string s)
        {
            if (s.Length == 1)
            {
                List<string> result = new List<string>();
                return result;
            }

            List<string> results = new List<string>();

            for (int i = 1; i < s.Length; ++i)
            {
                List<string> left = Parentheses(s.Substring(0, 1));
                List<string> right = Parentheses(s.Substring(i + 1));

                foreach (string s1 in left)
                {
                    foreach (string s2 in right)
                    {
                        results.Add("(" + s1 + s2 + ")");
                    }
                }
            }

            return results;

        }
    }
}

