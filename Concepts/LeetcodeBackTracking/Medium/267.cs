using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _267
    {
        public static void _267Main()
        {
            string s = "aabb";

            var test = new _267();
            var ans=test.GeneratePalindromes(s);
            Console.ReadLine();
        }

        /// <summary>
        //! Same idea as in 247 
        // //  # <image url="$(SolutionDir)\Images\267.jpg"  scale="0.4"/>
        /// </summary>
        public IList<string> GeneratePalindromes(string s)
        {
            List<string> result = new List<string>();
            Dictionary<char, int> map = new Dictionary<char, int>();
            BuildFrequencyMap(s, map);

            if (!IsPalindrome(map))
                return result;

            char oddCharacter = GetOddCharacter(map);           

            char[] path = new char[s.Length];
            GeneratePalindromes(map, path, 0, s.Length - 1,oddCharacter, result);
            return result;
        }
        private void GeneratePalindromes(Dictionary<char, int> map, char[] path, int start, int end, char oddChar, List<string> result)
        {
            //! incase the length is even , start will pass end and we can add char array to result
            if (start > end)
            {
                result.Add(new string(path));
                return;
            }
            //! in case length is odd, we need to add  characters in middle position 
            if (start == end)
            {
                path[start] = oddChar;
                result.Add(new string(path));
                return;
            }

            foreach (char key in map.Keys.ToList())
            {
                //! if character count >1 then only we will append at start and end
                //! in case there is character with count 1 than we will insert in the middle
                if (map[key] > 1)
                {
                    path[start] = key;
                    path[end] = key;
                    map[key] = map[key] - 2;
                    GeneratePalindromes(map, path, start + 1, end - 1, oddChar, result);
                    map[key] = map[key] + 2;
                }
            }
        }

        private void BuildFrequencyMap(string s, Dictionary<char, int> map)
        {
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 0);

                ++map[c];
            }
        }
        private bool IsPalindrome(Dictionary<char, int> map)
        {
            int oddsCount = 0;
            foreach (var keyValue in map)
            {
                if (keyValue.Value % 2 == 1)
                    ++oddsCount;

                if (oddsCount > 1)
                    return false;
            }

            return true;
        }
        private char GetOddCharacter(Dictionary<char, int> map)
        {
            foreach (var keyValue in map)
            {
                if (keyValue.Value % 2 == 1)
                    return keyValue.Key;
            }
            return ' ';
        }



    }
}
