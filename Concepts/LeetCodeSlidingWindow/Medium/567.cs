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
            var ans = test.CheckInclusion(s1, s2);
            Console.ReadLine();
        }





        public bool CheckInclusion(string s1, string s2)
        {

            if (s1.Length > s2.Length) return false;

            int[] s1Map = new int[26];
            int[] s2Map = new int[26];
            BuildMap(s1, s1.Length, s1Map);
            // ! calculating the first window of s2 
            BuildMap(s2, s1.Length, s2Map);
            //!s2Length - s1Length because we already calculated the first window 
            for (int i = 0; i < s2.Length - s1.Length; ++i)
            {
               
                if (AreEqual(s1Map, s2Map))
                    return true;
                //! left most character in the sliding window
                char leftChar = s2[i];
                //! right most character in sliding window
                char rightChar = s2[s1.Length + i];
                //! decreasing the window from  the left side. 
                --s2Map[leftChar - 'a'];
                //! increasing the window from  the right side. 
                ++s2Map[rightChar - 'a'];
            }

            //! in case both the strings are of equal length 
            return AreEqual(s1Map,s2Map);

        }

        private bool AreEqual(int[] s1Map, int[] s2Map)
        {
            for (int i = 0; i < 26; ++i)
            {
                if (s1Map[i] != s2Map[i])
                    return false;
            }

            return true;
        }
        private void BuildMap(string str, int end, int[] sMap)
        {
            for (int i = 0; i < end; ++i)
            {
                ++sMap[str[i] - 'a'];
            }
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
