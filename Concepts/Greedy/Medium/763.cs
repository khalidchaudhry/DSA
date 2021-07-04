using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _763
    {
        /// <summary>
        //! https://www.youtube.com/watch?v=nGWQlXracRM 
        /// </summary>
        public IList<int> PartitionLabels(string S)
        {

            int n = S.Length;
            Dictionary<char, int> charLastIdx = new Dictionary<char, int>();
            for (int i = 0; i < n; ++i)
            {
                char c = S[i];
                charLastIdx[c] = i;
            }

            IList<int> result = new List<int>();
            int left = 0;
            int right = 0;
            for (int i = 0; i < n; ++i)
            {
                char curr = S[i];
                right = Math.Max(right, charLastIdx[curr]);
                if (i == right)
                {
                    result.Add(right - left + 1);
                    left = i + 1;
                }
            }
            return result;
        }
    }
}
