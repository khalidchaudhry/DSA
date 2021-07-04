using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _368
    {
        public static void _368Main()
        {
            int[] nums = new int[] { 546, 669 };

            _368 Largest = new _368();

            var result = Largest.LargestDivisibleSubset2(nums);

            Console.ReadLine();
        }

        /// <summary>
        //! Same as 300 
        /// </summary>
        public IList<int> LargestDivisibleSubset1(int[] nums)
        {
            if (nums.Length == 0)
                return new List<int>();
            Array.Sort(nums);
            List<int> result = new List<int>();

            Dictionary<int, int> numSubsetLen = new Dictionary<int, int>();

            numSubsetLen.Add(nums[0], 1);

            for (int i = 1; i < nums.Length; ++i)
            {
                int maxValue = 0;

                foreach (KeyValuePair<int, int> keyValue in numSubsetLen)
                {
                    if (nums[i] % keyValue.Key == 0)
                    {
                        maxValue = Math.Max(keyValue.Value, maxValue);
                    }
                }

                numSubsetLen[nums[i]] = maxValue + 1;
            }

            int previous = 0;

            numSubsetLen = numSubsetLen.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int maxLen = numSubsetLen.ElementAt(0).Value;

            foreach (var keyValue in numSubsetLen)
            {

                if (keyValue.Value == maxLen &&
                    previous % keyValue.Key == 0)
                {
                    result.Add(keyValue.Key);
                    --maxLen;
                    previous = keyValue.Key;
                }
            }

            return result;

        }

        public IList<int> LargestDivisibleSubset2(int[] nums)
        {
            if (nums.Length == 0)
                return new List<int>();
            Array.Sort(nums);

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            map.Add(nums[0], new List<int> { nums[0] });

            int largestSubSetKey = nums[0];
            int largestSubsetLen = 1;

            for (int i = 1; i < nums.Length; ++i)
            {
                int maxDivisor = 0;
                int maxDivisorLen = 0;
                List<int> lds = new List<int>();
                // max divisor among all the previous divisors having the longest length
                foreach (KeyValuePair<int, List<int>> keyValue in map)
                {
                    if (nums[i] % keyValue.Key == 0 && keyValue.Value.Count > maxDivisorLen)
                    {
                        maxDivisorLen = keyValue.Value.Count;
                        maxDivisor = keyValue.Key;
                    }
                }

                if (maxDivisor != 0)
                {
                    lds.AddRange(map[maxDivisor]);
                }

                lds.Add(nums[i]);
                map[nums[i]] = lds;

                if (lds.Count > largestSubsetLen)
                {
                    largestSubSetKey = nums[i];
                    largestSubsetLen = lds.Count;
                }
            }

            return map[largestSubSetKey];
        }
    }
}
