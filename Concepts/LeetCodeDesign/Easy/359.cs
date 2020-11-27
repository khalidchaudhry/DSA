using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    public class _359
    {
        public class Logger
        {

            /** Initialize your data structure here. */
            Dictionary<string, int> map;
            public Logger()
            {
                map = new Dictionary<string, int>();
            }

            /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
                If this method returns false, the message will not be printed.
                The timestamp is in seconds granularity. */
            public bool ShouldPrintMessage(int timestamp, string message)
            {

                if (!map.ContainsKey(message))
                {
                    map.Add(message, timestamp);
                    return true;
                }
                int oldtimeStamp = map[message];
                if (timestamp-oldtimeStamp>=10)
                {
                    //! because u have new time that you need to record for the event
                    map[message] = timestamp;
                    return true;
                }
                return false;

            }
        }


    }
}
