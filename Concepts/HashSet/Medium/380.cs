using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class RandomizedSet
    {

        Dictionary<int, int> map;

        List<int> lst;

        Random random;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            map = new Dictionary<int, int>();
            lst = new List<int>();
            random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (map.ContainsKey(val))
            {
                return false;
            }
            else
            {
                int index = lst.Count;
                map.Add(val, index);
                lst.Add(val);
                return true;
            }
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!map.ContainsKey(val))
            {
                return false;
            }
            else
            {

                //! Get the element index to remove
                int index = map[val];
                // !Get the last element index in list . We will set it to value that we are planning to remove
                //! Why because we want to have Remove operation in O(1) time and list don't provide remove operation in O(1) time
                // !List.RemoveAt is O(n) operation because the remaining items in the list are renumbered to replace the removed item.
                //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=netcore-3.1
                //!By removing the last element there will not be any renumering for the remaining elements

                int lastElementIndex = lst.Count - 1;
              
                lst[index] = lst[lastElementIndex];
                //! As we have swapped the element we are removing with last element of list 
                //! After the swap we need to update the swapped elmenet index in dictionary
                // !lst[index]=Last element in the list 
                //! index=Index of the element we are removing. 
                map[lst[index]] = index;
                lst.RemoveAt(lastElementIndex);

                //!Remove it from dictionary
                map.Remove(val);
       
                return true;
            }
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return lst[random.Next(0, lst.Count)];
        }
    }

}
