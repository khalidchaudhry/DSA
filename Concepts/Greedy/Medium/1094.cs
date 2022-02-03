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
            //!! Key is the location and value is the passenger in the car at that location
            //! Sorted dictionary because we are  traveling from location 1 ,2,3..... n 
            SortedDictionary<int, int> locRequiredCap = new SortedDictionary<int, int>();
            foreach (int[] trip in trips)
            {
                int passengers = trip[0];
                int src = trip[1];
                int dest = trip[2];

                if (!locRequiredCap.ContainsKey(src))
                {
                    locRequiredCap.Add(src, 0);
                }
                //! passengers inflow in car at src
                locRequiredCap[src] += passengers;

                if (!locRequiredCap.ContainsKey(dest))
                {
                    locRequiredCap.Add(dest, 0);
                }
                //! passengers outflow in car at dest
                locRequiredCap[dest] -= passengers;
            }           

            int usedCapacity = 0;
            foreach (var keyValue in locRequiredCap)
            {
                usedCapacity += keyValue.Value;
                if (usedCapacity > capacity)
                    return false;
            }

            return true;
        }
        
    }
}
