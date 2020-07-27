using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module6
{
    //Given N, find the number of unique BSTs you can create by inserting values 1-N into the tree
    public class UniqueBSTs
    {
        public int CountBSTs(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                count += CountBSTs(i) * CountBSTs(n - i - 1);
            }

            return count;
        }



    }
}
