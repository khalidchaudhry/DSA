using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Easy
{
    public class _733
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            //if old Color is same as new Color return immediately
            if (image[sr][sc] == newColor)
            {
                return image;
            }

            int rows = image.Length;
            int cols = image[0].Length;
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    if (r == sr && c == sc)
                    {
                        DFS(image, sr, sc, image[sr][sc], newColor);
                        break;
                    }
                }
            }
            return image;
        }
        private void DFS(int[][] image, int r, int c, int oldColor, int newColor)
        {
            if (IsOutOfBound(image, r, c) || image[r][c] != oldColor)
            {
                return;
            }

            image[r][c] = newColor;
            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                DFS(image, nr, nc, oldColor, newColor);
            }
        }
        private bool IsOutOfBound(int[][] grid, int r, int c)
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
