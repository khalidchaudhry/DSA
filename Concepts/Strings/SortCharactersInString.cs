using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public static class SortCharactersInString
    {
        public static string SortCharacters(String s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;

            //Space Complexity=O(m)

            int[] letters = new int[1 << 8];//1<8 equals to 256
            StringBuilder sb = new StringBuilder();
            var charArray = s.ToCharArray(); // TimeComplexity O(n)
            for (int i = 0; i < charArray.Length; i++)  //Time complexity O(n)
                letters[charArray[i]]++;

            for (int i = 0; i < letters.Length; i++)  // Time complexity O(m)
            {
                for (int j = 0; j < letters[i]; j++) //Time Complexity  O(k)
                {
                    sb.Append(Convert.ToChar(i));  // O(1)
                }
            }
           
            return sb.ToString();  //O(n) ? using string.ArrayCopy

            // Time complexity=O(n)
            // Space Complexity=O(k)


        }

    }
}
