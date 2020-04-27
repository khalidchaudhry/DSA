using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _1143
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            string shortString = string.Empty;
            string longString = string.Empty;
            if (text1.Length > text2.Length)
            {
                shortString = text2;
                longString = text1;
            }
            else if (text1.Length < text2.Length)
            {
                shortString = text1;
                longString = text2;
            }
            else
            {
                shortString = text1;
                longString = text2;
            }

            int previousIndex = int.MinValue;
            int currentLength = 0;
            int maxLength = 0;
            for (int i = 0; i < shortString.Length; i++)
            {
                int currentIndex = longString.IndexOf(shortString[i]);

                if (currentIndex != -1)
                {
                    if (currentIndex > previousIndex)
                    {
                        previousIndex = currentIndex;
                        ++currentLength;
                    }
                    else
                    {
                        currentLength = 1;
                        previousIndex = currentIndex;

                    }

                    maxLength = Math.Max(currentLength, maxLength);
                }
                //else
                //{
                //    previousIndex = currentIndex;
                //}           
            }

            return maxLength;

        }

        public int LongestCommonSubsequence2(string text1, string text2)
        {
            int rowLength =text1.Length;
            int columnLength = text2.Length;
            int[,] dp = new int[rowLength + 1, columnLength + 1];

            for (int row = 1; row <= rowLength; row++)
                for (int column = 1; column <= columnLength; column++)
                {
                    if (text1[row-1].Equals(text2[column-1]))
                    {
                        dp[row, column] = dp[row - 1, column - 1] + 1;
                    }
                    else
                    {
                        dp[row, column] = Math.Max(dp[row - 1, column], dp[row, column - 1]);
                    }
                }
            return dp[rowLength, columnLength];
        }
    }
}
