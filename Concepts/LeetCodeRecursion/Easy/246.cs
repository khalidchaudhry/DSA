using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Easy
{
    class _246
    {
        public bool IsStrobogrammatic1(string num)
        {

            Dictionary<char, char> map = new Dictionary<char, char>
            {
                { '0', '0' },
                { '1', '1' },
                { '6', '9' },
                { '8', '8' },
                { '9', '6' }
            };

            int i = 0;
            int j = num.Length - 1;
            while (i <= j)
            {
                if (!map.ContainsKey(num[j]) || num[i] != map[num[j]])
                    return false;
                ++i;
                --j;
            }
            return true;

        }

        public bool IsStrobogrammatic(string num)
        {
            Dictionary<char, char> map = new Dictionary<char, char>
            {
                { '0', '0' },
                { '1', '1' },
                { '6', '9' },
                { '8', '8' },
                { '9', '6' }
            };

            StringBuilder sb = new StringBuilder();
            for (int i = num.Length - 1; i >= 0; --i)
            {
                char c = num[i];
                if (!map.ContainsKey(c))
                    return false;

                sb.Append(map[c]);
            }

            return sb.ToString() == num ? true : false;
        }
    }
}
