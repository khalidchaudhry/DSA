using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Medium
{
    public class _1094
    {
        /// <summary>
        //!1. Calculate inflow and outflow  in car at every location. 
        //!2. Sort  based on the key(location) in the map 
        //!3. check at every location , if you are over capacity. if yes than return false 
        /// </summary>      
        public bool CarPooling(int[][] trips, int capacity)
        {
            //!! Key is the location and value is the flow at that location
            Dictionary<int, int> map = new Dictionary<int, int>();
            ComputeFlow(map, trips);
            //! Sorting because we are  traveling from location 1 ,2,3..... n 
            map = map.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            int usedCapacity = 0;
            foreach (var keyValue in map)
            {
                usedCapacity += keyValue.Value;
                if (usedCapacity > capacity)
                    return false;
            }

            return true;
        }

        private void ComputeFlow(Dictionary<int, int> map, int[][] trips)
        {
            foreach (int[] trip in trips)
            {
                int passengers = trip[0];
                int src = trip[1];
                int dest = trip[2];
                
                if (!map.ContainsKey(src))
                {
                    map.Add(src, 0);
                }
                //! passengers inflow in car at src
                map[src] += passengers;

                if (!map.ContainsKey(dest))
                {
                    map.Add(dest, 0);
                }
                //! passengers outflow in car at dest
                map[dest] -= passengers;
            }
        }
    }
}
