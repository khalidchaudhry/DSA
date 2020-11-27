using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _659
    {
        public static void _659Main()
        {
            int[] arr = new int[8] { 1, 2, 3, 3, 4, 4, 5, 5 };

            _659 partition = new _659();

            var ans = partition.IsPossible(arr);
            Console.ReadLine();

        }

        /// <summary>
        /// https://leetcode.com/problems/split-array-into-consecutive-subsequences/discuss/106496/Java-O(n)-Time-O(n)-Space
        /// </summary>       
        public bool IsPossible(int[] nums)
        {

            Dictionary<int, int> fMap = new Dictionary<int, int>();
            Dictionary<int, int> appendfreq = new Dictionary<int, int>();
            CreateFrequencyMap(nums, fMap);

            for (int i = 0; i < nums.Length; ++i)
            {
                int number = nums[i];
                if (fMap[number] == 0) continue;
                //if number  can be appended to a previously constructed consecutive sequence or 
                //if it can be the start of a new consecutive sequence.If neither are true, then we return false.
                else if (appendfreq.ContainsKey(number) && appendfreq[number] > 0)
                {
                    --appendfreq[number];

                    if (appendfreq.ContainsKey(number + 1))
                    {
                        ++appendfreq[number + 1];
                    }
                    else
                    {
                        appendfreq[number + 1] = 1;
                    }
                }
                else if (fMap.ContainsKey(number + 1) && fMap[number + 1] > 0 &&
                         fMap.ContainsKey(number + 2) && fMap[number + 2] > 0)
                {
                    --fMap[number + 1];
                    --fMap[number + 2];
                    if (appendfreq.ContainsKey(number + 3))
                    {
                        ++appendfreq[number + 3];
                    }
                    else
                    {
                        appendfreq[number + 3] = 1;
                    }
                }
                else
                    return false;

                --fMap[number];
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
