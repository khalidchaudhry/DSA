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
        //! Time=O(N)
        //! Space=O(N)
        /// </summary>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            LinkedList<int> ll = new LinkedList<int>();
            int[] result = new int[n - k + 1];
            int rsultIdx = 0;
            for (int i = 0; i < n; ++i)
            {
                //!Maintain dequeue in increasing order(monotonically increasing stack). This will give quick access to max element of the window               
                while (ll.Count != 0 && nums[ll.Last.Value] < nums[i])
                {
                    ll.RemoveLast();
                }
                ll.AddLast(i);

                //! Pop an item from window if its outside of the window
                int windowStart = i - k + 1;
                if (ll.Count != 0 && ll.First.Value < windowStart)
                {
                    ll.RemoveFirst();
                } 
                //! Window becomes valid
                if (i >= k - 1)
                {
                    //! l.First.Value will give the index of max  value of curr window  
                    result[rsultIdx++] = nums[ll.First.Value];
                }
            }

            return result;
        }

        /// <summary>
        //! we need quick access to max element so  max heap gives us that ability in O(1) time
       //! Time complexity=O(NlogN)
       //! Space Complexity=O(N)
        /// </summary>
        public int[] MaxSlidingWindow0(int[] nums, int k)
        {
            int n = nums.Length;
            var comparer = Comparer<PQData>.Create((x, y) => {
                if (x.Val == y.Val)
                {
                    return x.Idx.CompareTo(y.Idx);//! If value are same then we need to sort by idx and remove item from heap which is comming first  
                }
                return y.Val.CompareTo(x.Val);//! Because of max heap we need to sort based on value.  
            });

            PQ<PQData> pq = new PQ<PQData>(comparer);
            int[] result = new int[n - k + 1];
            int start = 0;
            for (int i = 0; i < n; ++i)
            {
                pq.Add(new PQData(i, nums[i]));
                //! Below condition is when we hit our required window length=k
                if (i >= k - 1)
                {
                    //! we only pop an element from heap if its going to effect our answer i.e. top of heap contains max outside of window
                    //! Heap can contain elements outside of the window as well if its not going to effect our answer
                    int ws = i - k + 1;//Window start
                    while (pq.Peek().Idx < ws)
                    {
                        pq.Poll();
                    }
                    result[start++] = pq.Peek().Val;
                }
            }

            return result;
        }
        public class PQData
        {
            public int Idx;
            public int Val;
            public PQData(int idx, int val)
            {
                Idx = idx;
                Val = val;
            }
        }


        /// <summary>
        //! Time  complexity=O(N*K) where N are number of elements and K is the window size
        //! Space=O(1)
        /// </summary>
        public int[] MaxSlidingWindow3(int[] nums, int k)
        {
            int n = nums.Length;
            int[] result = new int[n - k + 1];
            int idx = 0;
            for (int i = 0; i < n - k + 1; ++i)
            {                
                int currWdMax = nums[i];
                for (int j = i; j <= i + k - 1; ++j)
                {
                    currWdMax = Math.Max(nums[j], currWdMax);
                }
                result[idx++] = currWdMax;
            }
            return result;
        }

    }
}

