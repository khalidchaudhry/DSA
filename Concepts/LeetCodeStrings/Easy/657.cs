using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _657
    {
        public bool JudgeCircle(string moves)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>()
            {
                { 'U',2 },
                { 'D',-2 },
                { 'R',1},
                { 'L',-1}
            };
            int sum = 0;
            foreach (char c in moves)
                sum += dict[c];

            if (sum != 0)
                return false;
            else
                return true;
        }

    }
}
