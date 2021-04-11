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
        //! The moment they are different , we will copy current character to the array writeHead index and increment the writeHead index. 
        /// </summary>   
        public int Compress(char[] chars)
        {
            //! writeHead will point to the place where we will write character and frquency 
            //! readHead will use to scan the characters in the string. 
            int writeHead = 0;
            //! explorer will be incremented in inside loop 
            int readHead = 0;
            //Time complexity=O(n)
            while (readHead < chars.Length)
            {
                //! Store the currChar for comparison with characters of an array. 
                char currChar = chars[readHead];
                int count = 0;
                while (readHead < chars.Length && chars[readHead] == currChar)
                {
                    ++readHead;
                    ++count;
                }

                //! copying the current character and increment writeHead pointer 
                chars[writeHead++] = currChar;

                //! As per the question we don't need to add  character count  with 1
                if (count > 1)
                {     //! copy the digits. Below loop is needed if there are nore than 1 digit
                      //Time complexity=0(8)
                      //O(4) for count.ToString() since maxiumum char length we can have is 1000 that contains 4 digits 
                      // O(4) for loop since maxiumum char length we can have is 1000 that contains 4 digits 
                    foreach (char digit in count.ToString())
                    {
                        //! copy digit to array where writeHead is pointing and increment the pointer. 
                        chars[writeHead++] = digit;
                    }
                }
            }

            return writeHead;
        }
        // Time complexity=O(n) + O(4)+)(4)=O(n) as constant gets drop 
    }
}
