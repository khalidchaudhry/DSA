using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _763
    {
        public IList<int> PartitionLabels(string S)
        {
            List<int> result = new List<int>();

            int[] charArray = new int[26];
            //! fill in the array for last see index of the character
            for (int i = 0; i < S.Length; i++)
            {
                charArray[S[i] - 'a'] = i;
            }

            //! helps in finding the next partition. Also length of the substring
            int start = 0;
            //! To expand the sliding window from the right side. 
            int j = 0;
            for (int i = 0; i < S.Length; i++)
            {

                j = Math.Max(j,charArray[S[i]-'a']);
                //! When they meet it means we get one substring. 
                if (i == j)
                {
                    int length = i - start + 1;
                    result.Add(length);
                    start = i + 1;
                }
            }

            return result;

        }


    }
}
