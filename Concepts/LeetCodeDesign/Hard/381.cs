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

        Random _random;
        List<int> _vals;
        Dictionary<int, LinkedList<int>> _valueIdxs;

        public RandomizedCollection()
        {
            _random = new Random();
            _vals = new List<int>();
            _valueIdxs = new Dictionary<int, LinkedList<int>>();
        }

        public bool Insert(int val)
        {

            bool isAdded = !(_valueIdxs.ContainsKey(val)) || _valueIdxs[val].Count == 0 ? true : false;
            if (!_valueIdxs.ContainsKey(val))
            {
                _valueIdxs.Add(val, new LinkedList<int>());
            }
            _valueIdxs[val].AddLast(_vals.Count);
            _vals.Add(val);
            return isAdded;
        }

        public bool Remove(int val)
        {

            if (!_valueIdxs.ContainsKey(val) || _valueIdxs[val].Count == 0)
            {
                return false;
            }
            int firstIdx = _valueIdxs[val].First.Value;
            //_valueIdxs[val].RemoveFirst();

            int listlastIdx = _vals.Count - 1;
            int listLastVal = _vals[listlastIdx];

            _valueIdxs[listLastVal].Find(listlastIdx).Value = firstIdx;

            _vals[firstIdx] = listLastVal;

            //! We need to to REMOVALS in last because we may have just one  element that added and removed  e.g. added 1 ,removed 1
            //! If we remove first from linkedlist then line 54 will throw an exception since it will not find any element in linked list
            //! If not  found then  _valueIdxs[listLastVal].Find(listlastIdx) will return null and accessing value will return null
            _valueIdxs[val].RemoveFirst();
            _vals.RemoveAt(_vals.Count - 1);

            return true;
        }

        public int GetRandom()
        {
            int idx = _random.Next(0, _vals.Count);
            return _vals[idx];
        }
    }
    /// <summary>
    //!
    /// </summary>
    public class RandomizedCollection1
    {
        List<int> _lst;
        Dictionary<int, HashSet<int>> _map;
        Random _random;
        /** Initialize your data structure here. */
        public RandomizedCollection1()
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
            //! Use this example insert(1) remove(1) insert(1) to have justfication
            //TODO: Research more on it
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
