using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashSet
{
    class _706
    {


    }

    public class MyHashMap
    {

        /** Initialize your data structure here. */
        Dictionary<int, int> map;
        public MyHashMap()
        {
            map = new Dictionary<int, int>();
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                map[key] = value;
            }
            else
            {
                map.Add(key, value);
            }
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            if (map.ContainsKey(key))
                return map[key];
            else
                return -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            if (map.ContainsKey(key))
            {
                map.Remove(key);
            }
        }
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */

    public class MyHashMap2
    {
        private readonly int[] arr;

        public MyHashMap2()
        {
            arr = Enumerable.Repeat(-1, 1000001).ToArray();
        }

        public void Put(int key, int value)
        {
            arr[key] = value;
        }

        public int Get(int key)
        {
            return arr[key];
        }

        public void Remove(int key)
        {
            arr[key] = -1;
        }
    }






}
