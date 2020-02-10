using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _383
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            bool result = true;
            Dictionary<char, int> map = new Dictionary<char, int>();
            // Create map that will contain characters with their count
            for (int i = 0; i < magazine.Length; i++)
            {
                if (map.ContainsKey(magazine[i]))
                {
                    ++map[magazine[i]];
                }
                else
                {
                    map.Add(magazine[i], 1);
                }
            }
            // Check value in map if not exists return false. If exists  
            // check if count !=0 . If count zero returns false. If not decrement by 1
            for (int j = 0; j < ransomNote.Length; j++)
            {
                if (map.ContainsKey(ransomNote[j]))
                {
                    if (map[ransomNote[j]] == 0)
                    {
                        return false;
                    }
                    else
                    {
                        --map[ransomNote[j]];
                    }
                }
                else
                    return false;

            }
            return result;
        }

        //https://leetcode.com/problems/ransom-note/discuss/85783/Java-O(n)-Solution-Easy-to-understand
        public bool CanConstruct2(string ransomNote, string magazine)
        {
            int[] arr = new int[26];
            for (int i = 0; i < magazine.Length; i++)
            {
                ++arr[magazine[i] - 'a'];
            }

            for (int j = 0; j < ransomNote.Length; j++)
            {
                if (arr[ransomNote[j] - 'a']-- == 0)
                {
                    return false;
                }      
            }
            return true;
        }
    }
}
