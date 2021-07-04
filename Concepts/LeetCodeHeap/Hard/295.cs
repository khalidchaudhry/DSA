using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHeap.Hard
{
    public class _295
    {
    }
    public class MedianFinder
    {

        /** initialize your data structure here. */
        PQ<int> _minHeap;
        PQ<int> _maxHeap;

        public MedianFinder()
        {

            _minHeap = new PQ<int>();

            var comparer = Comparer<int>.Create((x, y) => {
                return y.CompareTo(x);
            });
            _maxHeap = new PQ<int>(comparer);


        }

        public void AddNum(int num)
        {
            //! If the size is equal than max heap will contain 1 extra element
            if (_minHeap.Size == _maxHeap.Size)
            {
                _minHeap.Add(num);
                int curr = _minHeap.Poll();
                _maxHeap.Add(curr);
            }
            else
            {
                _maxHeap.Add(num);
                int curr = _maxHeap.Poll();
                _minHeap.Add(curr);
            }
        }

        public double FindMedian()
        {

            if (_maxHeap.Size > _minHeap.Size)
            {
                return _maxHeap.Peek();
            }
            else
            {
                return (double)(_minHeap.Peek() + _maxHeap.Peek()) / 2;
            }
        }
    }
}
