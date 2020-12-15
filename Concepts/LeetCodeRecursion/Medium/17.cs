using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _17
    {

        public static void _17Main()
        {

            string digits = "23";
            _17 Main = new _17();
            var ans=Main.LetterCombinations(digits);


        }
        public IList<string> LetterCombinations(string digits)
        {


            IList<string> result = new List<string>();
            Dictionary<char, List<string>> map = new Dictionary<char, List<string>>();

            map.Add('2', new List<string> { "a", "b", "c" });
            map.Add('3', new List<string> { "d", "e", "f" });

            Helper(digits, 0, map, new StringBuilder(), result);

            return result;
        }


        private void Helper(string digits, int i, Dictionary<char, List<string>> map, StringBuilder path, IList<string> result)
        {
            if (i >= digits.Length)
                return;

            if (path.Length == digits.Length)
            {
                Console.WriteLine(path.ToString());
                result.Add(path.ToString());
            }

            else
            {
                for (int j = 0; j < 3; ++j)
                {
                    string str = map[digits[i]][j];
                    path.Append(str);
                    Helper(digits, i + 1, map, path, result);
                }
            }
        }


    }
}
