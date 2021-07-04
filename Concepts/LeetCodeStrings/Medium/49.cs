using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _49
    {
        /// <summary>
        //! Below function uses Dictionary explicitly 
        //!N is length of strs array and K is the maximum length of a string in str
        //!Time Complexity: O(NK)
        //!Counting each string is linear in the size of the string, and we count every string.
        //!Space Complexity: O(NK), the total information content stored in ans
        /// </summary>

        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; ++i)
            {
                Dictionary<char, int> map = new Dictionary<char, int>();
                CreateMap(strs[i], map);
                string key = CreateKey(map);
                if (!result.ContainsKey(key))
                {
                    result.Add(key, new List<string>());
                }
                result[key].Add(strs[i]);
            }

            return new List<IList<string>>(result.Values);
        }
        private void CreateMap(string s, Dictionary<char, int> map)
        {
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 0);
                ++map[c];
            }
        }
        private string CreateKey(Dictionary<char, int> map)
        {
            StringBuilder sb = new StringBuilder();
            //! Constant time operation because  map consists of lower-case English letters only
            map = map.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var keyValue in map)
            {
                //! Not needed
                //sb.Append('#');
                sb.Append(keyValue.Key);
                sb.Append(keyValue.Value);
            }

            return sb.ToString();
        }

        /// <summary>
        //!N is length of strs array and K is the maximum length of a string in strs
        //!Time complexity=O(N*KlogK) 
        //!Outerloop that iterates elements in string array of size N=O(N)
        //! Array.Sort time complexity KlogK where K is the length of a string
        //!The outer loop has complexity O(N) as we iterate through each string.
        //! Then, we sort each string in O(K \log K)O(KlogK) time.
        //!Space complexity=O(NK) 
        /// </summary>

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs.Length == 0)
            {
                return new List<IList<string>>();
            }

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                char[] charArray = str.ToCharArray();
                //! No sort function in string. Need to convert it into char array to sort
                Array.Sort(charArray);
                string sortedString = new string(charArray);
                if (!map.ContainsKey(sortedString))
                {
                    map.Add(sortedString, new List<string>());
                }
                
                map[sortedString].Add(str);
            }
            //! nice shortcut to avoid using loops
            return new List<IList<string>>(map.Values);

        }

       



        /// <summary>
        //! Below function uses int char array
        //!N is length of strs array and K is the maximum length of a string in str
        //!Time Complexity: O(NK)
        //!Counting each string is linear in the size of the string, and we count every string.
        //!Space Complexity: O(NK), the total information content stored in ans
        /// </summary>

        public IList<IList<string>> groupAnagrams3(string[] strs)
        {
            if (strs.Length == 0) return new List<IList<string>>();
            Dictionary<string, List<string>> ans = new Dictionary<string, List<string>>();
            int[] count = new int[26];
            foreach (string s in strs)
            {

                foreach (char c in s.ToCharArray())
                {
                    count[c - 'a']++;
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');
                    sb.Append(count[i]);
                }
                //! reason for making key based on all 26 characters is becuase it will help group them seperately
                //!e.g abc and def. They will not be different  if we don't consider all the 26 characters 
                //! hey will fall to the same group of anagrams whereas they are not

                string key = sb.ToString();

                if (!ans.ContainsKey(key))
                {
                    ans.Add(key, new List<string>());
                }

                ans[key].Add(s);
            }
            return new List<IList<string>>(ans.Values);
        }
    }
}
