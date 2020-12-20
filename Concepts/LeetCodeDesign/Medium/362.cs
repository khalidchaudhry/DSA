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
    ///  /// # <image url="$(SolutionDir)\Images\362(2).png"  scale="0.5"/>A
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
                if (_time[i] > timestamp - 300)
                {
                    value += _counter[i];
                }
            }

            return value;
        }
    }

    ///  /// # <image url="$(SolutionDir)\Images\362.png"  scale="0.4"/>A

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

            int time = timestamp - 300;
            while (queue.Count != 0)
            {
                int diff = timestamp - queue.Peek();
                if (diff >= 300)
                    queue.Dequeue();
                else
                    break;
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
