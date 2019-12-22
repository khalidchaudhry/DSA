using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _5
    {
        public void ReverseString(char[] s)
        {
            if (s.Length == 0 || s.Length==1)
                return;

            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                Char temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                ++i;
                --j;
            }
        }

    }
}
