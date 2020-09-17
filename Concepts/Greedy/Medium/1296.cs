using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Medium
{
    public class _1296
    {
        public static void _1296Main()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            int k = 3;
            _1296 Partitions = new _1296();
            var ans = Partitions.IsPossibleDivide(nums, k);
            Console.ReadLine();
        }
        //https://www.youtube.com/watch?v=r4VZCwHs4Zo
        public bool IsPossibleDivide(int[] nums, int k)
        {
            int n = nums.Length;
            //! If we are not able to partition then we can return false upfront
            if (n % k != 0)
                return false;

            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            CreateFrequencyMap(nums, frequencyMap);

            Array.Sort(nums);

            for (int i = 0; i < n; ++i)
            {
                int smallestNumber = nums[i];
                if (frequencyMap[smallestNumber] > 0)
                {
                    for (int j = smallestNumber; j < smallestNumber + k; ++j)
                    {
                        if (frequencyMap.ContainsKey(j) && frequencyMap[j] > 0)
                        {
                            --frequencyMap[j];
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void CreateFrequencyMap(int[] nums, Dictionary<int, int> frequencyMap)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                if (frequencyMap.ContainsKey(nums[i]))
                {
                    ++frequencyMap[nums[i]];
                }
                else
                {
                    frequencyMap[nums[i]] = 1;
                }
            }
        }
    }
}
