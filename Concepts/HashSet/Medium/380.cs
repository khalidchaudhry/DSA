using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{

    /// <summary>
    //! Gotcha for this quesiton is its not allowing duplicate. 
    //! That reduces the problem scope because if they allow duplicate, then they also need to tell which occurance they need to delete
    //! Good converstion to have with interviewer.
    //! 1. In case of duplicates, what we need to do
    //! 2. In case item does not exist and user wants us to delete it than what we need return?    
    /// </summary>
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
                //! Why because we want to have Remove operation in O(1) time and list don't provide remove operation in O(1) time
                // !List.RemoveAt is O(n) operation because the remaining items in the list are renumbered to replace the removed item.
                //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=netcore-3.1
                //!By removing the last element there will not be any renumering for the remaining elements
                lst[index] = lst[lst.Count - 1];
                //! After the swap we need to update the swapped elmenet index in dictionary
                // !lst[index]=Last element in the list 
                //! index=Index of the element we are removing. 
                map[lst[index]] = index;

                lst.RemoveAt(lst.Count - 1);
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
