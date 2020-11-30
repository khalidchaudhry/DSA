using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{


    public class _1234
    {



        public static void _1234Main()
        {
            string s = "QQWE";

            _1234 main = new _1234();
            var result = main.BalancedString(s);
            Console.ReadLine();
        }

        /// <summary>
        //!Based on idea in Kuai's class
        /// </summary>
        public int BalancedString(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            BuildFrequency(s, map);

            Dictionary<char, int> toBeChanged = new Dictionary<char, int>();
            ToBeChanged(map, toBeChanged, s.Length);
            if (toBeChanged.Count == 0) return 0;

            int shortest = s.Length;
            Dictionary<char, int> current = new Dictionary<char, int>();
            int i = 0;
            for (int j = 0; j < s.Length; ++j)
            {
                if (!current.ContainsKey(s[j]))
                {
                    current.Add(s[j], 0);
                }
                ++current[s[j]];

                while (i <= j && AllFound(current, toBeChanged))
                {
                    shortest = Math.Min(shortest, j - i + 1);
                    --current[s[i]];
                    ++i;
                }
            }

            return shortest;
        }

        private bool AllFound(Dictionary<char, int> current, Dictionary<char, int> toBeChanged)
        {
            //! If current window not contains all the characters that we need to change 
            //! or the character count is < the desired character count than return false. Else return true  
            foreach (var keyValue in toBeChanged)
            {
                if (!current.ContainsKey(keyValue.Key) || current[keyValue.Key] < keyValue.Value)
                    return false;
            }
            return true;
        }

        private void ToBeChanged(Dictionary<char, int> map, Dictionary<char, int> needToChange, int n)
        {
            foreach (var keyValue in map)
            {
                if (keyValue.Value > n / 4)
                    needToChange.Add(keyValue.Key, map[keyValue.Key] - n / 4);
            }
        }

        private void BuildFrequency(string s, Dictionary<char, int> frequency)
        {
            for (int i = 0; i < s.Length; ++i)
            {
                if (!frequency.ContainsKey(s[i]))
                {
                    frequency.Add(s[i], 0);
                }
                ++frequency[s[i]];
            }
        }
    }
}
