using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class LongestSubstringwithAtMostTwoDistinctCharacters
    {

        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            int begin = 0, end = 0, len = 0, counter = 0;
            while (end < s.Length)
            {
                char current = s[end];
                if (!table.ContainsKey(current))
                {
                    table.Add(current, 1);
                }
                else
                {
                    table[current]++;
                }
                if (table[current] == 1)
                    counter++;


                end++;
                //!When characters in HashMap greater than 2 , its moment to start incrementing begin 
                //! Kepp incremeting begin untill you have 2 characters with count > 0  
                while (counter > 2)
                {
                    char startchar = s[begin];
                    table[startchar]--;
                    if (table[startchar] == 0)
                    {

                        if (table[startchar] == 0) counter--;
                    }

                    begin++;
                }
                len = Math.Max(len, end - begin);
            }

            return len;
        }

        public int LengthOfLongestSubstringTwoDistinct2(string s)
        {
            int n = s.Length;
            if (n < 3) return n;

            // sliding window left and right pointers
            int left = 0;
            int right = 0;
            // hashmap character -> its rightmost position 
            // in the sliding window
            Dictionary<char, int> hashmap = new Dictionary<char, int>();

            int max_len = 2;

            while (right < n)
            {
                // slidewindow contains less than 3 characters
                if (hashmap.Count < 3)
                {
                    if (hashmap.ContainsKey(s[right]))
                    {
                        hashmap[s[right]] = right;
                    }
                    else
                    {
                        hashmap.Add(s[right], right);
                    }
                    ++right;

                }
                // slidewindow contains 3 characters
                if (hashmap.Count == 3)
                {
                   //!left most based on min value in hash map e.g {e=2,c=1,b=3} the last most is c and not e
                    int leftMostIndex = hashmap.Values.Min();
                    KeyValuePair<char, int> keyValuePair = hashmap.FirstOrDefault(x => x.Value == leftMostIndex);
                    //!delete the leftmost character
                    hashmap.Remove(keyValuePair.Key);
                    //! move left pointer of the slidewindow
                    left = keyValuePair.Value + 1;
                }

                max_len = Math.Max(max_len, right - left);
            }
            return max_len;
        }

        //!issue with below code. Does not work for eceba as it will delete e when count==3 for first time.
        //! Rather then deleting c
        //! so below line is not correct 
        //!char del_Key = table.ElementAt(0).Key;
        public int LengthOfLongestSubstringTwoDistinct3(string s)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            int begin = 0, end = 0, len = 0;
            while (end < s.Length)
            {
                char current = s[end];
                if (!table.ContainsKey(current))
                {
                    table.Add(current, 1);
                }
                else
                {
                    table[current]++;
                }

                end++;

                if (table.Count == 3)
                {
                    // delete the leftmost character
                    char del_Key = table.ElementAt(0).Key;
                    int del_value = table.ElementAt(0).Value;
                    table.Remove(del_Key);
                    // move begin  pointer of the slidewindow
                    begin = begin + del_value;
                }

                len = Math.Max(len, end - begin);
            }

            return len;
        }




    }

}
