using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1267
    {
        ///<summary>
        ///https://leetcode.com/problems/count-servers-that-communicate/discuss/436130/C%2B%2B-Simple-Preprocessing 
        //! During first traverse we count all servers and fill 2 separate arrays for columns and rows where counts how many servers on this column and this row.
        //! After this count we do next traverse and if we see that in this column and row we have rows and column count greater than 1
        ///</summary>
        public int CountServers(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[] rc = new int[m];
            int[] cc = new int[n];

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        ++rc[i];
                        ++cc[j];
                    }
                }
            }
            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; ++j)
                {
                    //!For each server, the row or the column must have another server except the current one.
                    if (grid[i][j] == 1 && (rc[i] > 1 || cc[j] > 1))
                    {
                        ++result;
                    }
                }
            }
            return result;
        }


    }
}
