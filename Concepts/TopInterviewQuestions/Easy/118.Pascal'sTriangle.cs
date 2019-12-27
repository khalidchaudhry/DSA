using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _118
    {
        /*
               [
                   [1],
                  [1,1],
                 [1,2,1],
                [1,3,3,1],
               [1,4,6,4,1]
       ]
       */
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> triangle = new List<IList<int>>();
            if (numRows == 0)
                return triangle;
                       
            List<int> firstRow = new List<int>();
            
            //add the first row
            firstRow.Add(1);
            triangle.Add(firstRow);
            // starting with 1 because we already 1
            for (int i = 1; i < numRows; i++)
            {
                // getting the previous row 
                 var prevRow = triangle[i - 1];
                 List<int> newRow = new List<int>();
                // first element will always be 1
                newRow.Add(1);
                // starting from 1 because we already added 1
                //prevRow.Count=We will add elements one element less than the previous row count
                //for [1,2,1] previous row contains [1,1] so will add only one element in center. One on left and right side 
                //for [1,3,3,1] previous row contains [1,2,1]
                for (int j = 1; j < prevRow.Count; j++)
                {
                    // Adding elements from previous row 
                    newRow.Add(prevRow[j-1]+prevRow[j]);
                }
                newRow.Add(1);
                triangle.Add(newRow);
            }

            return triangle; 

        }


    }
}
