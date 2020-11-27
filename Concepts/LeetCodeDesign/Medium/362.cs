using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    class _362
    {
    }

    /// <summary>
    /// https://www.youtube.com/watch?v=vMB0XjFpt_s
    // </summary>
    public class HitCounter
    {

        /** Initialize your data structure here. */
        int[] _counter;
        int[] _time;
        public HitCounter()
        {
            _counter = new int[300];
            _time = new int[300];
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp)
        {
            int index = timestamp % 300;
            if (_time[index] != timestamp)
            {
                _time[index] = timestamp;
                _counter[index] = 1;
            }
            else
            {
                ++_counter[index];
            }

        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp)
        {
            int value = 0;
            for (int i = 0; i < 300; ++i)
            {
                if (timestamp - _time[i] < 300)
                {
                    value += _counter[i];
                }
            }

            return value;
        }
    }

    public class HitCounter2
    {

        /** Initialize your data structure here. */
        Queue<int> queue;
        public HitCounter2()
        {
            queue = new Queue<int>();
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp)
        {
            queue.Enqueue(timestamp);

        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp)
        {
            //! Why >= 300 and not 300 
            //!Example: timestamp = 301 and t = 1.
            //!Valid Range: [1 to 300], [2 to 301], [3,303]. So 301-1 >= 300. 
            //!Hence 1 should be popped since it doesnt belong to range 2 to 301.
            while (queue.Count != 0 && timestamp - queue.Peek() >= 300)
            {
                queue.Dequeue();
            }

            return queue.Count;
        }
    }

    /**
     * Your HitCounter object will be instantiated and called as such:
     * HitCounter obj = new HitCounter();
     * obj.Hit(timestamp);
     * int param_2 = obj.GetHits(timestamp);
     */
}
