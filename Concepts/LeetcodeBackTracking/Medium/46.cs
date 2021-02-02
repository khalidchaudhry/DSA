using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _46
    {
        public static void _46Main()
        {




        }
        public IList<IList<int>> Permute0(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            bool[] used = new bool[nums.Length];
            Permute0(nums, used, new List<int>(), result);
            return result;


        }
        /// <summary>
        //! Takeaways
        //! Takeaway1: Chooose --> explore ---> unchoose
        ///https://www.youtube.com/watch?v=8t7bIHIr9JY
        // # <image url="$(SolutionDir)\Images\46(0).jpg"  scale="0.4"/>


        //  # <image url="$(SolutionDir)\Images\46.jpg"  scale="0.5"/>
        /// </summary>

        private void Permute0(int[] nums, bool[] used, List<int> path, List<IList<int>> result)
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (used[i]) continue;
                used[i] = true;//choose
                path.Add(nums[i]);
                Permute0(nums, used, path, result);//Explore
                path.RemoveAt(path.Count - 1);
                used[i] = false;//unchoose
            }
        }
        /// <summary>
        //! Using frequency map 
        /// </summary>
        public IList<IList<int>> Permute(int[] nums)
        {

            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            PopulateFrequencyMap(nums, freqMap);
            List<IList<int>> result = new List<IList<int>>();
            Permute(freqMap, nums.Length, new List<int>(), result);
            return result;
        }

        private void Permute(Dictionary<int, int> freqMap, int n, List<int> path, List<IList<int>> result)
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
                    Permute(freqMap, n, path, result);
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
                    freqMap.Add(nums[i], 1);
                }
            }
        }

        /// <summary>
        //! Sams byte by byte
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute1(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Permute1(nums, 0, new List<int>(), result);

            return result;
        }

        private void Permute1(int[] nums, int i, List<int> path, List<IList<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(new List<int>(path));
            }

            for (int j = i; j < nums.Length; ++j)
            {
                Swap(nums, i, j);
                path.Add(nums[i]);
                Permute1(nums, j, path, result);
                Swap(nums, i, j);
                path.RemoveAt(path.Count - 1);
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];

            nums[i] = nums[j];
            nums[j] = temp;
        }


    }
}
