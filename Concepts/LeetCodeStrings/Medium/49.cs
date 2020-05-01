using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _49
    {

        /// <summary>
        //!N is length of strs array and K is the maximum length of a string in str
        //!Time complexity=O(N*KlogK) 
        //!Outerloop that iterates elements in string array of size N=O(N)
        //! Array.Sort time complexity KlogK where K is the length of a string
        //!The outer loop has complexity O(N) as we iterate through each string.
        //! Then, we sort each string in O(K \log K)O(KlogK) time.
        //!Space complexity=O(NK) 

        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            if (strs.Length == 0)
                return result;

            Dictionary<string, List<string>> hashTable = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                //! no sort function in string. Need to convert it into char array to sort
                char[] charArray = strs[i].ToCharArray();
                Array.Sort(charArray);
                string str = new string(charArray);

                if (hashTable.ContainsKey(str))
                {
                    hashTable[str].Add(strs[i]);
                }
                else
                {
                    List<string> value = new List<string>();
                    value.Add(strs[i]);
                    hashTable.Add(str, value);
                }
            }
            //! nice shortcut to avoid using loop
            return new List<IList<string>>(hashTable.Values);

        }
        /// <summary>
        //! Does not work for the input ["cab","tin","pew","duh","may","ill","buy","bar","max","doc"]
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            List<IList<string>> results = new List<IList<string>>();
            if (strs.Length == 0)
                return results;

            Dictionary<int, List<string>> hashTable = new Dictionary<int, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                int intValue = 0;
                for (int j = 0; j < strs[i].Length; j++)
                {
                    intValue += strs[i][j];
                }

                if (hashTable.ContainsKey(intValue))
                {
                    hashTable[intValue].Add(strs[i]);
                }
                else
                {
                    List<string> value = new List<string>();
                    value.Add(strs[i]);
                    hashTable.Add(intValue, value);
                }
            }

            foreach (List<string> values in hashTable.Values)
            {

                results.Add(values);

            }
            return results;
        }
        /// <summary>
        //!N is length of strs array and K is the maximum length of a string in str
        //!Time Complexity: O(NK)
        //!Counting each string is linear in the size of the string, and we count every string.
        //!Space Complexity: O(NK), the total information content stored in ans
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>

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
                //! essentially they will fall to the same group of anagrams whereas they are not

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
