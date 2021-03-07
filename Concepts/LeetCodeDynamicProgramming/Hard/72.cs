using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Hard
{
    public class _72
    {
        public int MinDistance(string word1, string word2)
        {

            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            return MinDistance(word1, 0, word2, 0, memo);
        }

        private int MinDistance(string word1, int i, string word2, int j, Dictionary<(int, int), int> memo)
        {
            //! if word1="" and word2="abc"
            if (i == word1.Length)
            {
                return word2.Length - j;
            }
            //! if word1="abc" and word2=""
            if (j == word2.Length)
            {
                return word1.Length - i;
            }

            if (memo.ContainsKey((i, j)))
            {
                return memo[(i, j)];
            }

            if (word1[i] == word2[j])
            {
                return MinDistance(word1, i + 1, word2, j + 1, memo);
            }

            int insert = 1 + MinDistance(word1, i, word2, j + 1, memo);
            int update = 1 + MinDistance(word1, i + 1, word2, j + 1, memo);
            int delete = 1 + MinDistance(word1, i + 1, word2, j, memo);

            return memo[(i, j)] = Math.Min(insert, Math.Min(update, delete));
        }


    }
}
