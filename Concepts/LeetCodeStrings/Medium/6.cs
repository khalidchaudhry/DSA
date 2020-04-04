using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    class _6
    {
        /*
        P   A   H   N
        A P L S I I G
        Y   I   R
        */
        public string Convert(string s, int numRows)
        {
            StringBuilder[] sbArray = new StringBuilder[numRows];
            int i = 0;
            // Create number of StringBuilder as number of rows(numRows) needed in result
            for (i = 0; i < numRows; i++)
            {
                sbArray[i] = new StringBuilder();
            }
            int j = 0;
            while (j < s.Length)
            {
                // Below loop to copy character  from string to corresponding string builder in string builder array
                for (int idx= 0; idx < numRows && j<s.Length; idx++) // vertically down
                {
                    sbArray[idx].Append(s[j++]);
                }
                // 
                for (int idx = numRows-2; idx >0 && j < s.Length; idx--) // obliquely up

                {
                    sbArray[idx].Append(s[j++]);
                }
            }
            // To copy string builder elements from 1 till end to first element of the string builder
            for (int idx = 1; idx < numRows; idx++)
            {
                sbArray[0].Append(sbArray[idx]);
            }

            return sbArray[0].ToString();
        }
    }
}
