using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Hard
{
    class _381
    {
    }
    public class RandomizedCollection
    {
        List<int> _lst;
        Dictionary<int, HashSet<int>> _map;
        Random _random;
        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            _lst = new List<int>();
            _map = new Dictionary<int, HashSet<int>>();
            _random = new Random();

        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            bool toReturn = _map.ContainsKey(val) && _map[val].Count > 0 ? false : true;
            if (!_map.ContainsKey(val))
            {
              _map.Add(val, new HashSet<int>());               
            }

            //! adding element index into dictionary array
            _map[val].Add(_lst.Count);

            _lst.Add(val);

            return toReturn;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!_map.ContainsKey(val) || _map[val].Count == 0) return false;

            int removeIndex = _map[val].First();
            _map[val].Remove(removeIndex);

            int listLastElementIndex = _lst.Count - 1;
            int listLastElement = _lst[listLastElementIndex];
            //! Setting  remove index to last element and then delete last element 
            _lst[removeIndex] = _lst[listLastElementIndex];

            _map[listLastElement].Add(removeIndex);
            _map[listLastElement].Remove(listLastElementIndex);

            _lst.RemoveAt(listLastElementIndex);

            return true;

        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            int index = _random.Next(_lst.Count);
            return _lst[index];
        }
    }


}
