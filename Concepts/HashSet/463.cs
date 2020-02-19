using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _463
    {
        // https://www.youtube.com/watch?v=fFQVHjNUwyU
        //algo 
        // 1: search through ou grid for 1's
        // 2: Determine for each direction(left,right,up,down) if its 0 is out of bound 
        public int IslandPerimeter(int[][] grid)
        {
            int premierCount = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    premierCount+=PremierCount(grid, i, j);
                }
            }
            return premierCount;
        }

        private int PremierCount(int[][] grid, int i, int j)
        {
            int count = 0;
            // Moving  right/left we will change j index as it represents column in the grid
            // Moving up/down we will change i index as it represents row in the grid. 
            if (grid[i][j] == 1)
            {
                //left
                if (j-1 < 0 || grid[i][j - 1] == 0) ++count;
                //right
                if (j+1 >= grid[i].Length || grid[i][j + 1] == 0) ++count;
                //up
                if (i - 1 < 0 || grid[i - 1][j] == 0) ++count;
                //down
                if (i + 1 >= grid.Length || grid[i + 1][j] == 0) ++count;
            }
            return count;
        }
    }
}
