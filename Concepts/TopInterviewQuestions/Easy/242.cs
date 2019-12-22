using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    public class _242
    {
        public bool IsAnagram(string s, string t)
        {

            if (s.Length!=t.Length)
                return false;

            Dictionary<Char,int> dict = new Dictionary<char, int>();

            for (int i=0;i<s.Length;i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i],1);
                }                
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (dict.ContainsKey(t[i]))
                {
                    dict[t[i]]--;
                }
                else
                {
                    return false;
                }
            }

            foreach (var item in dict)
            {
                if (item.Value!=0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsAnagram2(string s, string t)
        {

            if (s.Length != t.Length)
                return false;

            int[] letters = new int[1 << 8];

            for (int i = 0; i < s.Length; i++)
                letters[s[i]]++;

            for (int i = 0; i < t.Length; i++)
                letters[t[i]]--;

            for (int i = 0; i < letters.Length; i++)
                if (letters[i] != 0)
                    return false;
            return true;
        }
    }
}
