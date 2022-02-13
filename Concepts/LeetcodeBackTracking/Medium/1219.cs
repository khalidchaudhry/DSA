using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _1219
    {

        //Time and space complexity 
       //! Time =O(k*3^k) where k is the number  of cells with gold. (branchingfactor^recursionDepth)3^k
       //! Space=O(k)
        public int GetMaximumGold(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int maxGold = 0;
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    if (grid[r][c] > 0)
                    {
                        int max = GetMaximumGold(r, c, grid);
                        maxGold = Math.Max(max, maxGold);
                    }
                }
            }
            return maxGold;

        }
        private int GetMaximumGold(int r, int c, int[][] grid)
        {
            if (IsOutOfBound(r, c, grid) || grid[r][c] == 0)
            {
                return 0;
            }
            int prev = grid[r][c];
            int maxGold = prev;

            grid[r][c] = 0;
            int max = 0;
            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                max = Math.Max(max, GetMaximumGold(nr, nc, grid));
            }
            //! we need to backtrack hence resetting it to prev value 
            //! From every cell we are checking which neighbour gives us more gold. 
            //! If we don't unvisit it than we may get more gold from other neighbor comming to that cell
            grid[r][c] = prev; 
            
            maxGold += max;
            return maxGold;

        }
        private bool IsOutOfBound(int r, int c, int[][] grid)
        {
            return r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length;
        }
        private List<(int nr, int nc)> GetNeighbors(int r, int c)
        {
            List<(int nr, int nc)> neighbors = new List<(int nr, int nc)>();
            foreach ((int nr, int nc) in new List<(int nr, int nc)>() { (r + 1, c), (r - 1, c), (r, c + 1), (r, c - 1) })
            {
                neighbors.Add((nr, nc));
            }
            return neighbors;
        }


    }
}
