using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Hard
{
    public class _239
    {

        public static void _239Main()
        {

            int[] nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;

            _239 test = new _239();
            var ans = test.MaxSlidingWindow(nums, k);
            Console.ReadLine();
        }
        /// <summary>
        //! Using monotonically decreasing stack  
        /// </summary>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            LinkedList<int> ll = new LinkedList<int>();
            int[] result = new int[n - k + 1];
            int start = 0;
            for (int i = 0; i < n; ++i)
            {

                while (ll.Count != 0 && nums[ll.Last.Value] < nums[i])
                {
                    ll.RemoveLast();
                }
                ll.AddLast(i);

                int windowStart = i - k + 1;
                if (ll.Count != 0 && ll.First.Value < windowStart)
                {
                    ll.RemoveFirst();
                }

               

                if (i >= k - 1)
                {
                    result[start++] = nums[ll.First.Value];
                }
            }

            return result;
        }

        /// <summary>
        //! Based on priority queue implementation 
        /// </summary>
        public int[] MaxSlidingWindow0(int[] nums, int k)
        {
            int n = nums.Length;
            var comparer = Comparer<(int val, int index)>.Create((x, y) =>
            {
                if (y.val != x.val)
                {
                    return y.val.CompareTo(x.val); //! sorting in descending order for value
                }
                return x.index.CompareTo(y.index);   //!sorting in ascending order based on idex
            });

            PQ<(int val, int index)> pq = new PQ<(int value, int index)>(comparer);
            int[] result = new int[n - k + 1];
            int start = 0;
            for (int i = 0; i < n; ++i)
            {
                pq.Add((nums[i], i));

                if (i >= k - 1)
                {
                    while (pq.Peek().index < start)
                    {
                        pq.Poll();
                    }
                    result[start++] = pq.Peek().val;
                }
            }

            return result;
        }
    }
}

