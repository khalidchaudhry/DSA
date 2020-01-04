using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _13
    {
        public int RomanToInt(string s)
        {
            int romanNumeral = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            for (int i = 0; i < s.Length; i++)
            {
   
                if (i + 1 < s.Length)
                {
                    if (s[i] == 'I' && (s[i + 1] == 'V' || s[i + 1] == 'X'))
                    {
                        romanNumeral += (dict[s[i + 1]] - dict[s[i]]);
                        ++i;
                        continue;
                    }
                    else if (s[i] == 'X' && (s[i + 1] == 'L' || s[i + 1] == 'C'))
                    {
                        romanNumeral += (dict[s[i + 1]] - dict[s[i]]);
                        ++i;
                        continue;
                    }
                    else if (s[i] == 'C' && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                    {
                        romanNumeral += (dict[s[i + 1]] - dict[s[i]]);
                        ++i;
                        continue;
                    }
                }

                romanNumeral += dict[s[i]];
            }

            return romanNumeral;

        }
    }
}

