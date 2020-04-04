using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy2
{
    public class _13
    {
        public int RomanToInt(string s)
        {
            int answer = 0;
            Dictionary<Char, int> map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                {

                    if (s[i].Equals('I') && (s[i + 1].Equals('V') || s[i + 1].Equals('X')))
                    {
                        answer += (map[s[i + 1]] - map[s[i]]);
                        ++i;
                    }
                    else if (s[i].Equals('X') && (s[i + 1].Equals('L') || s[i + 1].Equals('C')))
                    {
                        answer += (map[s[i + 1]] - map[s[i]]);
                        ++i;
                    }
                    else if (s[i].Equals('C') && (s[i + 1].Equals('D') || s[i + 1].Equals('M')))
                    {
                        answer += (map[s[i + 1]] - map[s[i]]);
                        ++i;
                    }
                    else
                    {
                        answer += map[s[i]];
                    }
                }
                else
                {
                    answer += map[s[i]];
                }
            }

            return answer;
        }

    }
}
