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




        /// <summary>
        //  # <image url="https://static.javatpoint.com/math/images/pascal-triangle2.png" scale="0.5" /> 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>

        public IList<int> GetRow1(int rowIndex)
        {
            List<int> previousRow = new List<int>();
            previousRow.Add(1);

            for (int i = 1; i <= rowIndex; ++i)
            {
                int len = previousRow.Count;
                List<int> currentRow = new List<int>();

                currentRow.Add(1);
                for (int j = 1; j < len; ++j)
                {
                    currentRow.Add(previousRow[j - 1] + previousRow[j]);
                }
                currentRow.Add(1);

                previousRow = currentRow;

            }

            return previousRow;
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
                    ret[j] = tmp;
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
                    res[j] = res[j - 1] + res[j];
                }
            }
            return res;
        }

    }
}
