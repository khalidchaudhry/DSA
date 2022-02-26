using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _1497
    {

        /// <summary>
        //!Key Take aways
        //! Key takeaway 1: Complement is not only negative of the number.
        /// </summary>
        public bool CanArrange(int[] arr, int k)
        {
            Dictionary<int, int> remainderCount = new Dictionary<int, int>();
            BuildMap(arr, remainderCount, k);
            foreach (var keyValue in remainderCount)
            {   //! numbers having remainder 0 can only be pair with other numbers have remainder 0 
                if (keyValue.Key == 0)
                {
                    if (keyValue.Value % 2 == 0)
                        continue;
                    else
                        return false;
                }

                int complement = k - keyValue.Key;

                if (remainderCount.ContainsKey(complement) && remainderCount[complement] == keyValue.Value)
                    continue;
                else
                    return false;
            }
            return true;

        }
        private void BuildMap(int[] arr, Dictionary<int, int> map, int k)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int remainder = (arr[i] % k + k) % k;
                if (!map.ContainsKey(remainder))
                {
                    map.Add(remainder, 0);
                }
                ++map[remainder];
            }
        }
    }
}