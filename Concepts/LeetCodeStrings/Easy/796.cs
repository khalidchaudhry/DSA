using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _796
    {
        public bool RotateString(string A, string B)
        {
            if (A.Length != B.Length)
                return false;
            string s = A + A;

            //After concatinating , if s contains B then A shift on A consists of taking string A 
            //and moving the leftmost character to the rightmost position.
            if (s.Contains(B))
                return true;
            else
                return false;
        }

    }
}
