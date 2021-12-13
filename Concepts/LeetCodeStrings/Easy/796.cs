using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _796
    {

        //! Time Complexity =O(m*n) where m is length of string A and n is the length of string n
        //! Space Complexity=O(m+m) where m is the length of string
        public bool RotateString(string A, string B)
        {
            if (A.Length != B.Length)
                return false;
            //! All rotations of A are contained in A+A. Thus, we can simply check whether B is a substring of A+A
            string s = A + A;

            //After concatinating , if s contains B then A shift on A consists of taking string A 
            //and moving the leftmost character to the rightmost position.
            if (s.Contains(B))  //! Time complexity O(m*n) where m is length of s and n is length of B
                return true;
            else
                return false;
        }

    }
}
