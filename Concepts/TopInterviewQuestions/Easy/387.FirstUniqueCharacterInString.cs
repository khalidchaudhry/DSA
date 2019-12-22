using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    public static class FirstUniqueCharacterInString
    {


        //Runtime: 124 ms, faster than 54% of C# online submissions for First Unique Character in a String.
        // Memory Usage: 32.9 MB, less than 10.00% of C# online submissions for First Unique Character in a String.

        public static int FirstUniqCharApproach1(string s)
        {
            if (string.IsNullOrEmpty(s))
                return -1;

            if (s.Length == 1)
                return 0;

            Char[] charArray = s.ToLower().ToCharArray();
            Dictionary<Char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (dict.ContainsKey(charArray[i]))
                {
                    dict[charArray[i]] = -1;
                }
                else
                {
                    dict.Add(charArray[i], i);
                }
            }

            foreach (var one in dict)
            {
                if (one.Value != -1)
                {
                    return one.Value;
                }
            }

            return -1;

        }
        //Runtime: 76 ms, faster than 98.73% of C# online submissions for First Unique Character in a String.
        // Memory Usage: 32.9 MB, less than 10.00% of C# online submissions for First Unique Character in a String.
        public static int FirstUniqCharApproach2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return -1;

            if (s.Length == 1)
                return 0;

            Char[] charArray = s.ToCharArray();
            int[] letters = new int[1 << 8];

            for (int i = 0; i < charArray.Length; i++)
                letters[charArray[i]]++;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (letters[charArray[i]] == 1)
                    return i;
            }


            return -1;

        }

    }
}
