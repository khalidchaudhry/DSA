using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module2
{
    public class GenerateAllSubstrings
    {

        public List<string> IterativeTwoLoop(string s)
        {
            List<string> result = new List<string>();

            if (s.Length == 0)
                return result;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    result.Add(s.Substring(i, j - i + 1));
                }
            }

            return result;
        }
        public List<string> Recursive(string s)
        {
            List<string> result = new List<string>();

            IterativeOverFirstCharacters(s, 0, result);

            return result;
        }

        private void IterativeOverFirstCharacters(string s, int i, List<string> result)
        {
            if (i == s.Length)
            {
                return;
            }

            IterativeOverSecondCharacters(s, i, i, result);
            IterativeOverFirstCharacters(s, i + 1, result);

        }

        private void IterativeOverSecondCharacters(string s, int i, int j, List<string> result)
        {
            if (j == s.Length)
                return;
            result.Add(s.Substring(i, j - i + 1));

            IterativeOverSecondCharacters(s, i, j + 1, result);
        }
    }
}
