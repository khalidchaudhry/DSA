using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _1497
    {
        public bool CanArrange(int[] arr, int k)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; ++i)
            {
                //! to counter negative integers in the array.
                int rem = arr[i] % k;
                rem = rem < 0 ? rem + k : rem;

                if (map.ContainsKey(rem))
                {
                    ++map[rem];
                }
                else
                {
                    map.Add(rem, 1);
                }
            }

            foreach (var KeyValue in map)
            {
                if (KeyValue.Key == 0)
                {
                    if (KeyValue.Value % 2 == 0)
                    {
                        continue;
                    }
                    else
                        return false;
                }

                int complement = k - KeyValue.Key;

                if (map.ContainsKey(complement) && map[complement] == KeyValue.Value)

                    continue;
                else
                    return false;
            }

            return true;
        }
    }
}