using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Easy
{
    public class _1710
    {
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {

            var comparer = Comparer<int[]>.Create((x, y) =>
            {

                return y[1].CompareTo(x[1]);
            });

            Array.Sort(boxTypes, comparer);

            int maxUnits = 0;
            foreach (int[] boxType in boxTypes)
            {
                int numberOfBoxes = boxType[0];
                int units = boxType[1];
                int boxesTook = Math.Min(numberOfBoxes, truckSize);                
                maxUnits += boxesTook * units;
                truckSize -= boxesTook;
            }
            return maxUnits;

        }


    }
}
