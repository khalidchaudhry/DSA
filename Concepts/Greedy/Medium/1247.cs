using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _1247
    {
        public static void _1247Main()
        {
            string s1 = "xx";
            string s2 = "yy";

            _1247 MinimumSwaps = new _1247();

            var result = MinimumSwaps.MinimumSwap(s1, s2);

            Console.ReadLine();
        }
        public int MinimumSwap(string s1, string s2)
        {

            Dictionary<(char, char), int> mismatches = new Dictionary<(char, char), int>();
            for (int i = 0; i < s1.Length; ++i)
            {
                if (s1[i] == s2[i])
                    continue;
                if (mismatches.ContainsKey((s1[i], s2[i])))
                {
                    ++mismatches[(s1[i], s2[i])];
                }
                else
                {
                    mismatches[(s1[i], s2[i])] = 1;
                }
            }
            int sum = 0;
            int minimumSwaps = 0;
            foreach (var mismatch in mismatches)
            {
                int count = mismatch.Value;
                sum += count;
                minimumSwaps += count / 2 + count % 2;
            }

            return (sum % 2 == 0) ? minimumSwaps : -1;

        }

    }
}
