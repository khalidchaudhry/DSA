using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _443
    {
        public static void _443Main()
        {
            _443 Compression = new _443();
            //char[] chars = new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'};
            //char[] chars = new char[] { 'a' };
            char[] chars=new char[]{'a','a','b','b','c','c','c'};
            var ans = Compression.Compress(chars);

        }

        /// <summary>
        //https://leetcode.com/problems/string-compression/discuss/92559/Simple-Easy-to-Understand-Java-solution
        //! idea is to have two pointers . We will move one pointer until consective pointers are same.
        //! The moment they are different , we will copy current character to the array anchor index and increment the anchor index. 
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public int Compress(char[] chars)
        {
            //! anchor will point to the place where we will put character and count 
            //! anchor will be equal to the lenght we will return at the end. 
            int anchor = 0;
            //! explorer will be incremented in inside loop 
            int explorer = 0;
            //Time complexity=O(n)
            while (explorer < chars.Length)
            {
                //! Store the currChar for comparison with characters of an array. 
                char currChar = chars[explorer];
                int count = 0;
                while (explorer < chars.Length && chars[explorer] == currChar)
                {
                    ++explorer;
                    ++count;
                }

                //! copying the current character and increment anchor pointer 
                chars[anchor++] = currChar;

                //! As per the question we don't need to add  character count  with 1
                if (count > 1)
                {     //! copy the digits. Below loop is needed if there are nore than 1 digit
                      //Time complexity=0(8)
                      //O(4) for count.ToString() since maxiumum char length we can have is 1000 that contains 4 digits 
                      // O(4) for loop since maxiumum char length we can have is 1000 that contains 4 digits 
                    foreach (char digit in count.ToString())
                    {
                        //! copy digit to array where anchor is pointing anc increment the pointer. 
                        chars[anchor++] = digit;
                    }
                }
            }

            return anchor;
        }
        // Time complexity=O(n) + O(4)+)(4)=O(n) as constant gets drop 
    }
}
