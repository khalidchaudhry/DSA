using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashSet
{
    class _706
    {
        public static void _706Main()
        {
            //["MyHashMap","remove","get","put","put","put","get","put","put","put","put"]
            //[[],[14],[4],[7,3],[11,1],[12,1],[7],[1,19],[0,3],[1,8],[2,6]]

            MyHashMap map = new MyHashMap();
            //map.Remove(1);
            map.Get(79);
            map.Put(72, 7);
            map.Put(77, 1);
            map.Put(10, 21);
            map.Put(94, 5);
            map.Put(53, 35);
            map.Put(34, 9);
            var ans = map.Get(94);

            Console.ReadLine();

        }

    }

    /// <summary>
    //!Potiential followup 
    //!For simplicity, are the keys integers only?
    //!For collision resolution, can we use chaining?
    //!Do we have to worry about load factors?
    //!Can we assume inputs are valid or do we have to validate them?
    //!Can we assume this fits memory?
    /// </summary>
    public class MyHashMap
    {
        private List<List<(int key, int value)>> _buckets;
        private int _size;
        private int _itemsCount;
        private static float _loadFactor = 0.75f;
        public MyHashMap()
        {
            _itemsCount = 0;
            //In order to minimize the potential collisions, it is advisable to use a prime number as the base of modulo, e.g. 2069.
            _size = 2;
            _buckets = new List<List<(int key, int value)>>();
            InitializeBuckets();
        }

        public void Put(int key, int value)
        {
            int hashKey = key % _size;
            for (int i = 0; i < _buckets[hashKey].Count; ++i)
            {
                if (_buckets[hashKey][i].key == key)
                {
                    _buckets[hashKey][i] = (key, value);
                    return;
                }
            }
            //! Load factor is not part of original quesiton but its one of the potiential followup
            if (_itemsCount + 1 > _loadFactor * _size)
            {
                ReHash();
            }
            //! recompute the hash again as rehashing above changed the hash key
            hashKey = key % _size;
            //!Seperate channing 
            _buckets[hashKey].Add((key, value));
            ++_itemsCount;

        }

        public int Get(int key)
        {
            int hashKey = key % _size;
            foreach ((int k, int v) in _buckets[hashKey])
            {
                if (k == key)
                    return v;
            }
            return -1;
        }
        public void Remove(int key)
        {
            int hashKey = key % _size;

            //! its not possible to remove an item from list while iterating forward. 
            //! However iterating backward can do it :) 
            int bucketSize = _buckets[hashKey].Count;

            for (int i = bucketSize - 1; i >= 0; --i)
            {
                if (_buckets[hashKey][i].key == key)
                {
                    //!Making current item equal to last item and deleting the last to achieve O(1) deletion
                    (int tempKey, int tempValye) temp = _buckets[hashKey][i];
                    _buckets[hashKey][i] = _buckets[hashKey][bucketSize - 1];
                    _buckets[hashKey].RemoveAt(bucketSize - 1);
                    --_itemsCount;
                }
            }
        }

        private void ReHash()
        {
            List<List<(int key, int value)>> temp = new List<List<(int key, int value)>>(_buckets);

            _size = _size * 2;
            _itemsCount = 0;

            _buckets = new List<List<(int key, int value)>>();

            InitializeBuckets();

            foreach (List<(int key, int value)> bucket in temp)
            {
                foreach ((int key, int value) in bucket)
                {
                    Put(key, value);
                }
            }
        }

        private void InitializeBuckets()
        {
            for (int i = 0; i < _size; ++i)
            {
                _buckets.Add(new List<(int key, int value)>());
            }
        }
    }
}
