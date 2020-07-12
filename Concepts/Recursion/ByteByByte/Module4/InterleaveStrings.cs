using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    class InterleaveStrings
    {
        public List<string> Interleave(string s1, string s2)
        {
            int[] toCombine = new int[s1.Length + s2.Length];
            List<string> result = new List<string>();
            for (int i = 0; i < toCombine.Length; i++)
            {
                toCombine[i] = i;
            }
            int targetLen = s1.Length;
            int currentLen = 0;
            List<List<int>> positions = CombinationsOfLength(toCombine, 0, targetLen, currentLen);

            foreach (List<int> position in positions)
            {
                int i = 0;
                int j = 0;
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < (s1.Length + s2.Length); ++k)
                {
                    if (position.Contains(k))
                    {
                        sb.Append(s1[i++]);
                    }
                    else
                    {
                        sb.Append(s2[j++]);
                    }
                }

                result.Add(sb.ToString());
            }

            return result;
        }


        public List<string> Interleave2(string s1, string s2)
        {
            List<string> results = new List<string>();
            //! Passed Variable approach
            Interleave2(s1, s2, 0, 0, new StringBuilder(), results);

            return results;
        }

        private void Interleave2(string s1, string s2, int i, int j, StringBuilder path, List<string> results)
        {
            if (s1.Length == i && s2.Length == j)
            {
                results.Add(path.ToString());
                return;
            }

            if (i < s1.Length)
            {
                path.Append(s1[i]);
                Interleave2(s1, s2, i + 1, j, path, results);
                --path.Length; //backtracking
            }

            if (j < s2.Length)
            {
                path.Append(s2[j]);
                Interleave2(s1, s2, i, j + 1, path, results);
                --path.Length; //backtracking
            }
        }

        private static List<List<int>> CombinationsOfLength(int[] toCombine, int i, int targetLen, int currentLen)
        {
            List<List<int>> toReturn = new List<List<int>>();
            if (currentLen > targetLen)
            {
                return toReturn;
            }

            if (i == toCombine.Length && currentLen != targetLen)
            {
                return toReturn;
            }

            if (i == toCombine.Length)
            {
                toReturn.Add(new List<int>());
                return toReturn;
            }

            List<List<int>> include = CombinationsOfLength(toCombine, i + 1, targetLen, currentLen + 1);
            List<List<int>> exclude = CombinationsOfLength(toCombine, i + 1, targetLen, currentLen);

            foreach (List<int> result in include)
            {
                result.Insert(0, toCombine[i]);
                toReturn.Add(result);
            }

            toReturn.AddRange(exclude);

            return toReturn;
        }
    }
}
