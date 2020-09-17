using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _119
    {
        /*
           [1],
          [1,1],
         [1,2,1],
        [1,3,3,1],
       [1,4,6,4,1]                         

        */




        public IList<int> GetRow1(int rowIndex)
        {
            List<IList<int>> triangle = new List<IList<int>>();
            List<int> result = new List<int>();
            
            // Adding the first row
            triangle.Add(new List<int> { 1 });

            for (int i = 1; i <= rowIndex; i++)
            {
                IList<int> prevRow = triangle[i - 1];

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
                triangle.Add(newRow);
            }

            return triangle[rowIndex];
        }


        //https://leetcode.com/problems/pascals-triangle-ii/discuss/38420/Here-is-my-brief-O(k)-solution
        public IList<int> GetRow2(int rowIndex)
        {
            List<int> ret = new List<int>();
            ret.Add(1);
            for (int i = 1; i <= rowIndex; i++)
            {
                for (int j = i - 1; j >= 1; j--)
                {
                    int tmp = ret[j - 1] + ret[j];
                    ret[j]= tmp;
                }
                ret.Add(1);
            }
            return ret;
        }
        //https://leetcode.com/problems/pascals-triangle-ii/discuss/38473/Java-O(k)-solution-with-explanation
        public List<int> GetRow3(int rowIndex)
        {
            List<int> res = new List<int>();
            for (int i = 0; i <= rowIndex; i++)
            {
                // Adding 1 bcz anyway it will always end with one
                // or next row will always be 1 more than previous row
                res.Add(1);
                // First two rows will not enter into below loop
                //j=i-1 because last entry will be 1 always 
                // j>0 because first entry will be 1 always 
                for (int j = i - 1; j > 0; j--)
                {
                    //grab previous value and current value to calcuate current value
                    res[j]= res[j - 1] + res[j];
                }
            }
            return res;
        }

    }
}
