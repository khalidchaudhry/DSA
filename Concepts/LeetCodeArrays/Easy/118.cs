using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _118
    {
        /*
            [1],
           [1,1],
          [1,2,1],
         [1,3,3,1],
        [1,4,6,4,1]                         
        
         */
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (numRows == 0)
                return result;

            // Adding the first row
            result.Add(new List<int> { 1 });

            for (int i = 1; i < numRows; i++)
            {
                IList<int> prevRow = result[i - 1];

                List<int> newRow = new List<int>();

                // First element in row is  always 1
                newRow.Add(1);
                //j = 1 because you already added 1 hence start from 1
                // j < result[i - 1].Count ---> middle values count one less than previous values in row
                for (int j = 1; j < prevRow.Count; j++)
                {
                    // j-1 --> in upper row index on top one before the current index 
                    newRow.Add(prevRow[j - 1] + prevRow[j]);
                }
                // last element in row is always 1
                newRow.Add(1);
                // Add the row to the result tobe used for next iteration
                result.Add(newRow);
            }

            return result;
        }

    }
}
