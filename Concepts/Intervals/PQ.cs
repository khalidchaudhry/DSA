using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAndIntervals
{
    public class PQ<T>
    {

        private SortedDictionary<T, int> _map;       
        public int Size { get; private set; }
        public PQ()
        {
            _map = new SortedDictionary<T, int>();
            Size = 0;
        }

        public PQ(Comparer<T> comparer)
        {
            _map = new SortedDictionary<T, int>(comparer);
            Size = 0;
        }

        public T Poll()
        {
            if (_map.Count == 0)
            {
                return default(T);
            }
           
            T key = _map.First().Key;
            --_map[key];
            if (_map[key] == 0)
            {
                _map.Remove(key); 
            }
            --Size;

            return key;
        }
        public void Add(T ele)
        {          
            if (!_map.ContainsKey(ele))
            {
                _map.Add(ele, 0);
            }
            ++_map[ele];
            Size++;
        }
        public void AddForDups(T ele)
        {           
            if (_map.ContainsKey(ele))
            {
                _map.Add(ele, 1);
            }
            Size = _map.Count;
        }
        public T Peek()
        {
            return _map.First().Key;
        }
    }
}
