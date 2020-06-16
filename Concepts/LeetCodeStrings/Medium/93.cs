using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _93
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=JfB3BugMht8
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            int n = s.Length;
            //!why start at 1 because we want to place dot after ATLEAST one digit
            for (int i = 1; i < n && i < 4; i++)
            {
                string first = s.Substring(0, i);
                if (!IsValidPart(first))
                {
                    continue;
                }
                for (int j = 1; i + j < n && j < 4; ++j)
                {
                    string second = s.Substring(i, j);
                    if (!IsValidPart(second))
                    {
                        continue;
                    }

                    for (int k = 1; i + j + k < n && k < 4; ++k)
                    {
                        string third = s.Substring(i + j, k);
                        string fourth = s.Substring(i + j + k);
                        if (!IsValidPart(third) || !IsValidPart(fourth))
                        {
                            continue;
                        }
                        result.Add(first + "." + second + "." + third + "." + fourth);
                    }
                }
            }

            return result;
        }

        private bool IsValidPart(string s)
        {
            if (s.Length > 3)
            {
                return false;
            }
            //0 is valid but 00,01,000 are not valid
            if (s.StartsWith("0") && s.Length > 1)
            {
                return false;
            }

            int val = int.Parse(s);

            return val >= 0 && val <= 255;
        }
    }
}
