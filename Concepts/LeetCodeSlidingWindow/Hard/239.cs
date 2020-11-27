using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Hard
{
    public class _239
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            LinkedList<int> maxHeap = new LinkedList<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < k; ++i)
            {
                MaxHeap(maxHeap, nums[i]);
            }
            result.Add(maxHeap.Last.Value);

            for (int i = k; i < nums.Length; ++i)
            {
                maxHeap.RemoveFirst();
                maxHeap.AddLast(nums[i]);
                
            }


            return result.ToArray();
        }

        private void MaxHeap(LinkedList<int> maxHeap, int val)
        {

            while (maxHeap.Count > 0 && maxHeap.Last.Value < val)
            {
                maxHeap.RemoveLast();
            }
            maxHeap.AddLast(val);
        }


    }
}
