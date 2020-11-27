using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class TimeMap
    {

        /** Initialize your data structure here. */
        Dictionary<string, List<(string value, int timestamp)>> map;
        public TimeMap()
        {
            map = new Dictionary<string, List<(string value, int timestamp)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (map.ContainsKey(key))
            {
                map[key].Add((value, timestamp));
            }
            else
            {
                List<(string key, int value)> lst = new List<(string key, int value)>();
                lst.Add((value, timestamp));
                map.Add(key, lst);
            }
        }

        public string Get(string key, int timestamp)
        {
            if (!map.ContainsKey(key))
                return string.Empty;

            return BinarySearch(map[key], timestamp);
        }

        private string BinarySearch(List<(string value, int timeStamp)> lst, int timestamp)
        {
            int lo = 0;
            int hi = lst.Count - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (lst[mid].timeStamp == timestamp)
                    return lst[mid].value;
                else if (lst[mid].timeStamp > timestamp)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            //! if the asked time stamp(e.g. 20 ) is in the middle like  [10,30,40] than you will return 10     
            if (lo < lst.Count && lst[lo].timeStamp < timestamp)
            {
                return lst[lo].value;
            }
            //! if provided timestamp > all the existing values in map then we will return the value where hi pointing to. 
            //! If there are multiple such values, it returns the one with the largest timestamp_prev.
            if (hi >= 0 && lst[hi].timeStamp < timestamp)
            {
                return lst[hi].value;
            }

            return string.Empty;


        }
    }
}
