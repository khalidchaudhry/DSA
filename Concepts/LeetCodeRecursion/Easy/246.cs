using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Easy
{
    class _246
    {


        public bool IsStrobogrammatic(string num)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();

            map.Add('0', '0');
            map.Add('1', '1');
            map.Add('6', '9');
            map.Add('8', '8');
            map.Add('9', '6');

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
