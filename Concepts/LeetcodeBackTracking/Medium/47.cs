using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _47
    {

        public static void _47Main()
        {
            int[] nums = new int[3] { 1, 1, 2 };
            _47 Permute = new _47();

            Permute.PermuteUnique(nums);

        }

        public IList<IList<int>> PermuteUnique0(int[] nums)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            PopulateFrequencyMap(nums, freqMap);
            List<IList<int>> result = new List<IList<int>>();
            PermuteUnique(freqMap, nums.Length, new List<int>(), result);
            return result;
        }

        private void PermuteUnique(Dictionary<int, int> freqMap, int n, List<int> path, List<IList<int>> result)
        {
            if (path.Count == n)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < freqMap.Count; ++i)
            {
                var item = freqMap.ElementAt(i);
                int key = item.Key;
                int value = item.Value;
                if (value > 0)
                {
                    --freqMap[key];
                    path.Add(key);
                    PermuteUnique(freqMap, n, path, result);
                    path.RemoveAt(path.Count - 1);
                    ++freqMap[key];
                }
            }
        }

        private void PopulateFrequencyMap(int[] nums, Dictionary<int, int> freqMap)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                if (!freqMap.ContainsKey(nums[i]))
                {
                    freqMap.Add(nums[i], 0);
                }
                freqMap[nums[i]]++;
            }
        }


        /// <summary>
        /// https://www.youtube.com/watch?v=A3ge2mdQi4g
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {

            Array.Sort(nums);
            List<IList<int>> result = new List<IList<int>>();
            PermuteUnique(nums, new bool[nums.Length], new List<int>(), result);

            return result;
        }

        private void PermuteUnique(int[] nums, bool[] used, List<int> path, List<IList<int>> result)
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                //! If item choose continue. 
                //! If previous item not choose and current element=previous element than continue
                //! If previous item not choosen ,it means we used it before and then unused it. so we can continue and don't consider it.
                if (used[i] ||
                     (i > 0 &&
                      !used[i - 1] &&
                       nums[i] == nums[i - 1]))
                    continue;

                used[i] = true;
                path.Add(nums[i]);
                PermuteUnique(nums, used, path, result);
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }




    }
}
