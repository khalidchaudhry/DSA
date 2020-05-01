using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _647
    {
        public int CountSubstrings(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            int row=s.Length ,column =s.Length;
            bool[,] dp = new bool[row, column];
            int count = 0;

            for (int i = 0; i < row; i++)
            {
                dp[i, i] = true;
                ++count;
            }

            for (int j = 1; j < column; j++)
            {

                for (int i = 0; i < j; i++)
                {
                  if(s[i] == s[j] && (dp[i+1,j-1]|| j-i<=2))
                    {
                        dp[i, j] = true;
                        ++count;
                    }
                }
            }
            return count;
        }


    }
}
