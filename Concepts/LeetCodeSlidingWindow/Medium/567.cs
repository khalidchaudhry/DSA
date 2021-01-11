using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _567
    {

        public static void _567Main()
        {
            string s1 = "ab";
            string s2 = "eidbaooo";
            _567 test = new _567();
            var ans = test.CheckInclusion0(s1, s2);
            Console.ReadLine();
        }


        /// <summary>
        //! Fixed size window pattern 
        //! Using dictionary
        //! Same pattern used in 1343 and many other fixed size window
        /// </summary>
        public bool CheckInclusion0(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            Dictionary<char, int> s1Map = new Dictionary<char, int>();
            Dictionary<char, int> s2Map = new Dictionary<char, int>();
            int k = s1.Length;
            //! Calculating for first window
            BuildFrequencyMap(s1, k, s1Map);
            BuildFrequencyMap(s2, k, s2Map);
            //! check if first window satisifies the check
            if (AreEqual(s1Map, s2Map))
                return true;

            for (int i = k; i < s2.Length; ++i)
            {
                //! removing the first element from window
                Remove(s2Map, s2[i - k]);
                //! Adding the next element to the window
                Add(s2Map, s2[i]);
                if (AreEqual(s1Map, s2Map))
                    return true;
            }
            return false;
        }

        private void BuildFrequencyMap(string s, int k, Dictionary<char, int> map)
        {
            for (int i = 0; i < k; ++i)
            {
                char c = s[i];
                if (!map.ContainsKey(c))
                    map.Add(c, 0);

                ++map[c];
            }
        }

        private bool AreEqual(Dictionary<char, int> map1, Dictionary<char, int> map2)
        {
            foreach (var keyValue in map1)
            {
                if (!map2.ContainsKey(keyValue.Key) || map2[keyValue.Key] != keyValue.Value)
                    return false;
            }

            return true;
        }
        private void Remove(Dictionary<char, int> map, char c)
        {
            --map[c];
            if (map[c] == 0)
                map.Remove(c);
        }
        private void Add(Dictionary<char, int> map, char c)
        {
            if (!map.ContainsKey(c))
                map.Add(c, 0);

            ++map[c];
        }

        //! Fixed size window pattern 
        //! Using int array to map characters to them
        //! Same pattern used in 1343 and many other fixed size window        
        public bool CheckInclusion(string s1, string s2)
        {

            if (s1.Length > s2.Length) return false;

            int[] s1Map = new int[26];
            int[] s2Map = new int[26];
            int k = s1.Length;
            BuildFrequencyMap(s1, k, s1Map);
            BuildFrequencyMap(s2, k, s2Map);
            if (AreEqual(s1Map, s2Map))
                return true;

            for (int i = k; i < s2.Length; ++i)
            {
                Remove(s2Map, s2[i - k]);
                Add(s2Map, s2[i]);
                if (AreEqual(s1Map, s2Map))
                    return true;
            }
            return false;
        }

        private void BuildFrequencyMap(string s, int k, int[] map)
        {
            for (int i = 0; i < k; ++i)
            {
                char c = s[i];

                ++map[c - 'a'];
            }
        }
        private bool AreEqual(int[] map1, int[] map2)
        {
            for (int i = 0; i < map1.Length; ++i)
            {

                if (map1[i] != map2[i])
                    return false;
            }
            return true;
        }
        private void Remove(int[] map, char c)
        {
            --map[c - 'a'];
        }
        private void Add(int[] map, char c)
        {
            ++map[c - 'a'];
        }

        /// <summary>
        //! Brute Force 
        /// </summary>
        public bool CheckInclusion2(string s1, string s2)
            {
                for (int i = 0; i <= s2.Length - s1.Length; ++i)
                {
                    if (IsSubStringEqual2(s1, s2.Substring(i, s1.Length)))
                        return true;
                }
                return false;
            }


            private bool IsSubStringEqual2(string s1, string s2)
            {
                string ss1 = string.Concat(s1.OrderBy(c => c));
                string ss2 = string.Concat(s2.OrderBy(c => c));

                if (ss1.Equals(ss2)) return true;
                return false;

            }

        }
    }
