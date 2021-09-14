using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _1631
    {


        //! Very similar to question 1102
        public int MinimumEffortPath(int[][] heights)
        {

            //Since we need to minimize effort our search range is from 0 to 1000000
            int lo = -1;
            int hi = (int)Math.Pow(10, 6);
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (OK(heights, mid))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }
            return hi;
        }
        /// <summary>
        //! is the slected effort achievable  
        //! FFFFFFTTTTTTT 
        /// </summary>
           private bool OK(int[][] heights, int effort)
        {
            bool[,] visited = new bool[heights.Length, heights[0].Length];
            return DFS(heights, 0, 0, effort, visited);
        }

        private bool DFS(int[][] heights, int r, int c, int target, bool[,] visited)
        {
            if (r == heights.Length - 1 && c == heights[0].Length - 1)
                return true;

            visited[r, c] = true;

            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                if (IsOutOfBound(heights, nr, nc) || visited[nr, nc] || Math.Abs(heights[r][c] - heights[nr][nc]) > target)
                    continue;
                if (DFS(heights, nr, nc, target, visited))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsOutOfBound(int[][] heights, int r, int c)
        {
            return r < 0 || r >= heights.Length || c < 0 || c >= heights[0].Length;
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
