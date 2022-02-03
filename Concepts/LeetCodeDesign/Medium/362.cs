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
    //! if the number of hits per second is huge? Does your design scale?
    //! Yes below solution scales but if we need to count hit for a day than it will not work 
    //! Scaling to multiple machines
    //http://blog.gainlo.co/index.php/2016/09/12/dropbox-interview-design-hit-counter/
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
                //!If time falls within the window(i-k+1), consider it
                //! How will you reverse this equation queue.Peek() < timestamp - 300 + 1
                //! queue.Peek() >=timestamp - 300 + 1
                if (_time[i] >= timestamp - 300 + 1)
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
            //! start of the window ending at i
            //! i-k+1
            //! timestamp-windowSize+1=Any elenent before this window will be removed from queue. 
            while (queue.Count != 0 && queue.Peek() < timestamp - 300 + 1)
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
