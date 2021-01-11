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

        Dictionary<char, List<char>> map;
        public IList<string> LetterCombinations(string digits)
        {

            List<string> result = new List<string>();

            if (digits.Length == 0)
                return result;

            map = new Dictionary<char, List<char>>();
            InitMap();

            Helper(digits.ToCharArray(), 0, new StringBuilder(), result);

            return result;
        }
        //! Time Complexity=O(4 ^ n * n)
        //! Space Complexity=O(n) for recursion + 
        //!                 O(n) for path + 
        //!                 n*4 ^n for result=
        //!Total: O(n) + O(n) +O(n*4 ^ n)= O(2n) + O(n*4^n)=O(n)+O(n* 4^n)
        private void Helper(char[] charArray, int idx, StringBuilder path, List<string> result)
        {
            if (charArray.Length == path.Length)  //!recursion depth=n where n is the length of digits string/path length  
            {
                result.Add(path.ToString());     //! Time Complexity=O(n) 
                return;
            }
            foreach (char c in map[charArray[idx]])  //! Branching factor=4  
            {
                path.Append(c);
                Helper(charArray, idx + 1, path, result);
                --path.Length;
            }
        }

        private void InitMap()
        {
            map.Add('2', new List<char>() { 'a', 'b', 'c' });
            map.Add('3', new List<char>() { 'd', 'e', 'f' });
            map.Add('4', new List<char>() { 'g', 'h', 'i' });
            map.Add('5', new List<char>() { 'j', 'k', 'l' });
            map.Add('6', new List<char>() { 'm', 'n', 'o' });
            map.Add('7', new List<char>() { 'p', 'q', 'r', 's' });
            map.Add('8', new List<char>() { 't', 'u', 'v' });
            map.Add('9', new List<char>() { 'w', 'x', 'y', 'z' });
        }



    }
}
