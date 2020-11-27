using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _1438
    {
        public int LongestSubarray(int[] nums, int limit)
        {
            LinkedList<int> minHeap = new LinkedList<int>();
            LinkedList<int> maxHeap = new LinkedList<int>();
            int i = 0;
            int result = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                while (maxHeap.Count > 0 && maxHeap.Last.Value < nums[j])
                {
                    maxHeap.RemoveLast();
                }
                maxHeap.AddLast(nums[j]);

                while (minHeap.Count > 0 && minHeap.Last.Value > nums[j])
                {
                    minHeap.RemoveLast();
                }
                minHeap.AddLast(nums[j]);


                while (maxHeap.First.Value - minHeap.First.Value > limit)
                {
                    if (minHeap.First.Value == nums[i]) minHeap.RemoveFirst();
                    if (maxHeap.First.Value == nums[i]) maxHeap.RemoveFirst();
                    ++i;
                }

                result = Math.Max(j - i + 1, result);
            }

            return result;
        }



    }
}
