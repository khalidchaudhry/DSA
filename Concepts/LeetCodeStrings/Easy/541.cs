using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _541
    {
        public string ReverseStr(string s, int k)
        {
            char[] charArray = s.ToCharArray();
            // for k=2
            //i=i+2k i=0, i=0+(2*2)=4, i=4+(2*2)=8, 
            for (int i = 0; i < charArray.Length; i = i + (2 * k))
            {
                //charArray.Length=7
                // for i=0, charLeft=7, for i=4,charLeft=3

                int charLeft = charArray.Length - i;
                //reverse the first k characters for every 2k characters 
                //counting from the start of the string

                if (charLeft >= (2 * k))
                {
                    //For i=0 & k=2,0+2-1=2
                    //For i=4 & k=2,4+2-1=5
                    Swap(charArray, i, i + k - 1);
                }
                //If there are less than 2k but greater than or equal to k characters, 
                // then reverse the first k characters and left the other as original
                else if (charLeft < (2 * k) && charLeft >= k)
                {
                    Swap(charArray, i, i + k - 1);
                }
                // If there are less than k characters left, reverse all of them
                else if (charLeft < k)
                {
                    Swap(charArray, i, charArray.Length - 1);
                }
            }
            return new string(charArray);
        }
        public String ReverseStr2(String s, int k)
        {
            /**************
            1. Reverse the first k characters for every 2k characters counting from the 
              start of the string
            2. If there are less than 2k but greater than or equal to k characters, 
               then reverse the first k characters and left the other as original
            3. If there are less than k characters left, reverse all of them
            */
            /*
            If character left K or greater reverse first K  
            If chracter left less than K reverse all  
            */
            char[] arr = s.ToCharArray();
            int n = arr.Length;
            int i = 0;
            while (i < n)
            {
                /*
                 It deals with the case when there are less than k characters left, 
                 reverse all of them, since i + k - 1 could be larger than n - 1, 
                 causing access violation at runtime.
                 j = i + k - 1 = When character left is >=k and <=2k reverse k characters
                 n-1 = When character left <k reverse all the characters
                */

                int j = Math.Min(i + k - 1, n - 1);
                Swap(arr, i, j);
                i += 2 * k;
            }
            return new string(arr);
        }
        private void Swap(char[] charArray, int start, int end)
        {
            while (start < end)
            {
                char temp = charArray[start];
                charArray[start++] = charArray[end];
                charArray[end--] = temp;
            }

        }

    }
}
