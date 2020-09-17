using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeHasTable.Easy
{
    class _266
    {
        public static void _266Main()
        {

            _266 PermteString = new _266();

            var ans = PermteString.CanPermutePalindrome("aab");

            Console.ReadLine();
        }
        public bool CanPermutePalindrome(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;

                }
                else
                {
                    map[c] = 1;
                }
            }

            int oddCount = 0;

            foreach (KeyValuePair<char, int> keyVaule in map)
            {

                if (keyVaule.Value % 2 == 1)
                {
                    ++oddCount;
                }

                if (oddCount > 1)
                    return false;
            }

            return true;
        }
    }
}
