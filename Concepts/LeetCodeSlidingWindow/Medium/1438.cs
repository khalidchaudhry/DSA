using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _1438
    {
        public static void _1438Main()
        {
            int[] nums = new int[] { 8, 2, 4, 7 };
            int limit = 4;
            _1438 Main = new _1438();
            var ans = Main.LongestSubarray1(nums, limit);

        }
        /// <summary>
        //! We will keep track of mins and max in monotically increasing queue/monotonically decreasing queue
        // # <image url="$(SolutionDir)\Images\1438.png"  scale="0.6"/>
        /// </summary>
        public int LongestSubarray(int[] nums, int limit)
        {
            //! Acting as monotonically increasing queue
            LinkedList<int> minQueue = new LinkedList<int>();
            //! Acting as monotonically descreasing queue
            LinkedList<int> maxQueue = new LinkedList<int>();
            int i = 0;
            int result = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                while (maxQueue.Count > 0 && nums[j] > maxQueue.Last.Value)
                {
                    maxQueue.RemoveLast();
                }
                maxQueue.AddLast(nums[j]);

                while (minQueue.Count > 0 && nums[j] < minQueue.Last.Value)
                {
                    minQueue.RemoveLast();
                }
                minQueue.AddLast(nums[j]);


                while (maxQueue.First.Value - minQueue.First.Value > limit)
                {
                    if (minQueue.First.Value == nums[i]) minQueue.RemoveFirst();
                    if (maxQueue.First.Value == nums[i]) maxQueue.RemoveFirst();
                    ++i;
                }

                result = Math.Max(j - i + 1, result);
            }

            return result;
        }




        /// <summary>
        //! nlog(n) solution 
        //! Window.Max() - Window.Min() >limit ---window becomes invalid
        /// </summary>
        public int LongestSubarray1(int[] nums, int limit)
        {

            int longestSubArray = 0;

            //! Java tree map equivalent in C# is sorted dictionary 
            SortedDictionary<int, int> treeMap = new SortedDictionary<int, int>();

            int i = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                Add(treeMap, nums[j]);
                while (Math.Abs(treeMap.ElementAt(treeMap.Count - 1).Key - treeMap.ElementAt(0).Key) > limit)
                {
                    Remove(treeMap, nums[i]);
                    ++i;
                }

                longestSubArray = Math.Max(j - i + 1, longestSubArray);
            }


            return longestSubArray;
        }
        private void Add(SortedDictionary<int, int> treeMap, int item)
        {
            if (!treeMap.ContainsKey(item))
                treeMap.Add(item, 0);

            ++treeMap[item];
        }
        private void Remove(SortedDictionary<int, int> treeMap, int item)
        {
            --treeMap[item];
            if (treeMap[item] == 0)
                treeMap.Remove(item);
        }


        /// <summary>
        //! Brute force 
        //! O(n^2) solution
        //! Window.Max() - Window.Min() >limit ---window becomes invalid
        /// </summary>
        public int LongestSubarray2(int[] nums, int limit)
        {

            int longestSubArray = 0;
            List<int> lst = new List<int>();

            int i = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                lst.Add(nums[j]);
                while (Math.Abs(lst.Max() - lst.Min()) > limit)
                {
                    lst.Remove(nums[i]);
                    ++i;
                }

                longestSubArray = Math.Max(longestSubArray, j - i + 1);
            }
            return longestSubArray;
        }

    }
}
