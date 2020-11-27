using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _205
    {
        //https://leetcode.com/problems/isomorphic-strings/discuss/57796/My-6-lines-solution

        /*
       The idea is that we need to map a char to another one, 
       for example, "egg" and "add", we need to construct the mapping 'e' -> 'a' and 'g' -> 'd'. 
       Instead of directly mapping 'e' to 'a', another way is to mark them with same value, 
       for example, 'e' -> 1, 'a'-> 1, and 'g' -> 2, 'd' -> 2, this works same.
       */
        public bool IsIsomorphic(string s, string t)
        {
            //Arrays here m1 and m2, initialized space is 256 
            //(Since the whole ASCII size is 256, 128 also works here)

            int[] m1 = new int[256];
            int[] m2 = new int[256];

            for (int i = 0; i < s.Length; i++)
            {
                // if  mapping values in m1 and m2 are different, means they are not mapping correctly
                // for example Foo and bar. 
                //Now o-->2 and a-->2
                // next o returns 2 but corresponding character r returns 0 hence returns false 
                if (m1[s[i]] != m2[t[i]])
                {
                    return false;
                }
                // Each character is mapped with their corresponding position in the string
                // Adding 1 since when create array, all array elements are 0
                // "+1" is to exclude 0 from valid index
                m1[s[i]] = i + 1;
                m2[t[i]] = i + 1;
            }

            return true;
        }
        public bool IsIsomorphic2(string s, string t)
        {

            Dictionary<Char, Char> map = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    if (map[s[i]] == t[i])
                        continue;
                    else
                        return false;
                }
                else
                {
                    // To handle the case where no two characters may map to the same char
                    // e.g. s="ab", t = "aa", 
                    //when we check 'b' in s, although the key 'b' has not been in the map 
                    //, its value 'a' has already been used previously.
                    if (map.ContainsValue(t[i]))
                    {
                        return false;
                    }
                    else
                    {
                        map.Add(s[i], t[i]);
                    }
                }
            }

            return true;
        }
    }
}
