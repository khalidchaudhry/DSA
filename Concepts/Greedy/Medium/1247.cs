using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _1247
    {
        public static void _1247Main()
        {
            string s1 = "xx";
            string s2 = "yy";

            _1247 MinimumSwaps = new _1247();

            var result = MinimumSwaps.MinimumSwap(s1, s2);

            Console.ReadLine();
        }
        public int MinimumSwap(string s1, string s2)
        {
            Dictionary<(char, char), int> mismatches = new Dictionary<(char, char), int>();
            BuildMap(mismatches, s1, s2);

            int sum = 0;
            int minimumSwaps = 0;
            foreach (var mismatch in mismatches)
            {
                int count = mismatch.Value;
                sum += count;
                //! Why Math.Ceiling         
                //! s1=xy 
                //! s2=yx 
                //! we need one swap 
                //! in case of even,we need 1 swaps and for odd we need 1 more swap  hence Math.Ceiling
                //  {
                //!  (x,y):5  =>(4+1) 2 swaps for even and 1 swap for the odd
                //!  (y,x):3  =>(2+1) 1 swaps for even and 1 swap for the odd
                //  }
                minimumSwaps += (int)Math.Ceiling((decimal)count / 2);
            }

            return (sum % 2 == 0) ? minimumSwaps : -1;
        }

        private void BuildMap(Dictionary<(char, char), int> map, string s1, string s2)
        {
            for (int i = 0; i < s1.Length; ++i)
            {
                char x = s1[i];
                char y = s2[i];
                if (x != y)
                {
                    if (!map.ContainsKey((x, y)))
                        map.Add((x, y), 0);
                    ++map[(x, y)];
                }
            }
        }



    }
}
