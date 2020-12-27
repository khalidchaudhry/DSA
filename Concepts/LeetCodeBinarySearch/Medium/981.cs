using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinarySearch.Medium
{

    /// <summary>
    //! Based on the template from Roger
    //! Question: Is the timestamp <=given time stamp?
    //! TTT'T'FFFFF
    /// </summary>
    public class TimeMap
    {

        /** Initialize your data structure here. */
        Dictionary<string, List<(string value, int timestamp)>> timemap;
        public TimeMap()
        {
            timemap = new Dictionary<string, List<(string value, int timestamp)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (timemap.ContainsKey(key))
            {
                timemap[key].Add((value, timestamp));
            }
            else
            {
                List<(string value, int timestamp)> lst = new List<(string value, int timestamp)>();
                lst.Add((value, timestamp));
                timemap.Add(key, lst);
            }
        }
        public string Get(string key, int timestamp)
        {

            if (!timemap.ContainsKey(key))
                return string.Empty;

            int lo = 0;
            int hi = timemap[key].Count;

            while (lo + 1 < hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (OK(key, timestamp, mid))
                    lo = mid;
                else
                    hi = mid;
            }
            //! If lo pointing to value which is greater then given timestamp than returns emoty string.  
            if (timemap[key][lo].timestamp > timestamp)
                return string.Empty;
            else
                return timemap[key][lo].value;
        }
        /// <summary>
        //! Return last time stamp if there are multiple time stamps that satisfies the condition. 
        //! TT'T'FFFFFF
        /// </summary>
        private bool OK(string key, int timestamp, int mid)
        {
            List<(string value, int timestamp)> lst = timemap[key];

            if (lst[mid].timestamp <= timestamp)
                return true;
            else
                return false;
        }
    }



    public class TimeMap2
    {
        /** Initialize your data structure here. */
        Dictionary<string, List<(string value, int timestamp)>> map;
        public TimeMap2()
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
