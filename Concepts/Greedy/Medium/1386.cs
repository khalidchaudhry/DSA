using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _1386
    {
        public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
          
            int reservedSeatsCnt = reservedSeats.Length - 1;

            Dictionary<int, HashSet<int>> rowReserveSeats = new Dictionary<int, HashSet<int>>();
            foreach (int[] reservedSeat in reservedSeats)
            {
                int rowNumber = reservedSeat[0];
                int seatNumber = reservedSeat[1];
                if (!rowReserveSeats.ContainsKey(rowNumber))
                {
                    rowReserveSeats.Add(rowNumber, new HashSet<int>());
                }
                rowReserveSeats[rowNumber].Add(seatNumber);
            }

            int maxGroups = (n - rowReserveSeats.Count) * 2;

            foreach (var keyValue in rowReserveSeats)
            {
                int left = 0;
                int right = 0;
                int mid = 0;
                HashSet<int> revervedSeats = keyValue.Value;
                //! our range is from 2--9  because even seat one or seate 10  is empty/occupied it will not impact the result
                for (int i = 2; i <= 9; ++i)
                {
                    if (revervedSeats.Contains(i))
                    {
                        continue;
                    }
                    if (i >= 2 && i <= 5)
                    {
                        ++left;
                    }
                    if (i >= 4 && i <= 7)
                    {
                        ++mid;
                    }
                    if (i >= 6 && i <= 9)
                    {
                        ++right;
                    }
                }
                if (left == 4 && right == 4)
                {
                    maxGroups += 2;
                }
                else if (left == 4 || mid == 4 || right == 4)
                {
                    ++maxGroups;
                }

            }
            return maxGroups;

        }
    }
}
