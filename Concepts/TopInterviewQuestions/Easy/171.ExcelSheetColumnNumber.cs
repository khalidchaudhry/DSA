using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _171
    {
        public int TitleToNumber(string s)
        {

            if (s.Length == 0)
                return 0;
            int number=0;
            for (int i = 0; i < s.Length; i++)
            {
                int c = s[s.Length - 1 - i] - 'A' + 1;
                number += c *(int)Math.Pow(26, i);
            }

            return number;

        }

    }
}
