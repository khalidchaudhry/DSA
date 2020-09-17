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

        public IList<int> LargestDivisibleSubset1(int[] nums)
        {
            if (nums.Length == 0)
                return new List<int>();
            Array.Sort(nums);
            List<int> result = new List<int>();

            Dictionary<int, int> map = new Dictionary<int, int>();

            map.Add(nums[0], 1);

            for (int i = 1; i < nums.Length; ++i)
            {
                int maxValue = 0;

                foreach (KeyValuePair<int, int> keyValue in map)
                {
                    if (nums[i] % keyValue.Key == 0)
                    {
                        maxValue = Math.Max(keyValue.Value, maxValue);
                    }
                }

                map[nums[i]] = maxValue + 1;
            }

            int previous = -1;

            IOrderedEnumerable<KeyValuePair<int, int>> sortedByValue = map.OrderByDescending(x => x.Value);
            int ldsLen = sortedByValue.ElementAt(0).Value;

            foreach (KeyValuePair<int, int> keyValuePair in sortedByValue)
            {

                if (keyValuePair.Value == ldsLen &&
                    previous % keyValuePair.Key == 0 || previous == -1)
                {
                    result.Add(keyValuePair.Key);
                    --ldsLen;
                    previous = keyValuePair.Key;
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


        /// <summary>
        //! does not work
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> LargestDivisibleSubset3(int[] nums)
        {
            if (nums.Length == 0)
                return new List<int>();

            List<int> result = new List<int>();
            Array.Sort(nums);

            result.Add(nums[0]);

            for (int i = 1; i < nums.Length; ++i)
            {
                bool isAdd = true;
                foreach (int item in result)
                {
                    if (nums[i] % item != 0 && item % nums[i] != 0)
                    {
                        isAdd = false;
                        break;
                    }
                }
                if (isAdd)
                {
                    result.Add(nums[i]);
                }
            }

            return result;

        }




    }
}
