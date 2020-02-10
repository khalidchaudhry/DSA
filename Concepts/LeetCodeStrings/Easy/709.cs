using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _709
    {
        public string ToLowerCase(string str)
        {           
            if (str.Length == 1)
                return str;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 65 && str[i] <= 90) // upper case letter range
                {
                    // difference between lower case and upper case letters are 32
                    sb.Append((char)(str[i] + 32));
                }
                else
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }


    }
}
