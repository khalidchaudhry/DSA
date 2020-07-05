using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class TimeMap
    {

        /** Initialize your data structure here. */
        Dictionary<string, List<(string value, int timeStamp)>> map;
        public TimeMap()
        {
            map = new Dictionary<string, List<(string, int)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (map.ContainsKey(key))
            {
                map[key].Add((value, timestamp));
            }
            else
            {
                List<(string, int)> lst = new List<(string, int)>
                {
                    (value, timestamp)
                };
                map.Add(key, lst);
            }
        }

        public string Get(string key, int timestamp)
        {
            if (map.ContainsKey(key))
            {
                var lst = map[key];

                int left = 0;
                int right = lst.Count - 1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (lst[mid].timeStamp == timestamp)
                        return lst[mid].value;
                    else if (lst[mid].timeStamp > timestamp)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                if (left < lst.Count && lst[left].timeStamp <= timestamp)
                {
                    return lst[left].value;
                }
                else if (right >= 0 && lst[right].timeStamp <= timestamp)
                {
                    return lst[right].value;
                }
                else
                {
                    return string.Empty;
                }

            }
            else
            {
                return string.Empty;
            }
        }
    }
}
