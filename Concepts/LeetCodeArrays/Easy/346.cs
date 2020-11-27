using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _346
    {
               
    }

    public class MovingAverage
    {

        /** Initialize your data structure here. */
        Queue<int> queue;
        int sum;
        int windowSize;
        public MovingAverage(int size)
        {
            queue = new Queue<int>();
            sum = 0;
            windowSize = size;

        }
        public double Next(int val)
        {

            queue.Enqueue(val);
            sum += val;
            if (queue.Count > windowSize)
            {
                int dequeue = queue.Dequeue();
                sum = sum - dequeue;
            }

            return (double)sum / queue.Count;

        }
    }

    /**
     * Your MovingAverage object will be instantiated and called as such:
     * MovingAverage obj = new MovingAverage(size);
     * double param_1 = obj.Next(val);
     */
}
