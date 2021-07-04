using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Hard
{
    public class _460
    {



    }

    public class LFUCache
    {

        int _capacity;
        int _time;
        Dictionary<int, Data> _keyData;
        SortedSet<int> _key;
        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _keyData = new Dictionary<int, Data>();
            _time = 0;
            var comparer = Comparer<int>.Create((x, y) =>
            {
                if (_keyData[x].Freq == _keyData[y].Freq)
                {
                    return _keyData[x].Time.CompareTo(_keyData[y].Time);
                }
                return _keyData[x].Freq.CompareTo(_keyData[y].Freq);
            });
            _key = new SortedSet<int>(comparer);
        }

        public int Get(int key)
        {

            if (!_keyData.ContainsKey(key) || _capacity == 0)
                return -1;

            Put(key, _keyData[key].Value);
            return _keyData[key].Value;
        }

        public void Put(int key, int value)
        {

            if (_capacity == 0)
                return;

            if (_keyData.ContainsKey(key))
            {
                _key.Remove(key);
                ++_keyData[key].Freq;
                _keyData[key].Time = ++_time;
                _keyData[key].Value = value;
                _key.Add(key);
            }
            else
            {
                if (_keyData.Count == _capacity)
                {
                    int lfu = _key.First();
                    _key.Remove(lfu);
                    _keyData.Remove(lfu);
                }
                 Data newData = new Data(value, 1, ++_time);
                _keyData.Add(key, newData);
                _key.Add(key);
            }

        }
    }

    public class Data
    {
        public int Value;
        public int Freq;
        public int Time;
        public Data(int value, int freq, int time)
        {
            Value = value;
            Freq = freq;
            Time = time;
        }
    }
}
