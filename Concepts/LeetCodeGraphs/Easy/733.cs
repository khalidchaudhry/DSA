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

            int rows = image.Length;
            int columns = image[0].Length;
            HashSet<(int r, int c)> hs = new HashSet<(int r, int c)>();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    //if(i==sr && j==sc)
                    //{
                    DFS(image, sr, sc, image[sr][sc], newColor, hs);

                    //}                            
                }
            }
            return image;
        }
        private void DFS(int[][] image, int r, int c, int srcColor, int newColor, HashSet<(int r, int c)> hs)
        {
            if (IsOutOfBound(image, r, c) || image[r][c] != srcColor || hs.Contains((r, c)))
            {
                return;
            }

            image[r][c] = newColor;
            hs.Add((r, c));
            foreach ((int nr, int nc) in GetNeighbors(image, r, c))
            {
                DFS(image, nr, nc, srcColor, newColor, hs);
            }
        }

        private bool IsOutOfBound(int[][] image, int nr, int nc)
        {
            return nr < 0 || nr >= image.Length || nc < 0 || nc >= image[0].Length;
        }

        private List<(int nr, int nc)> GetNeighbors(int[][] images, int r, int c)
        {
            List<(int nr, int nc)> neighbors = new List<(int nr, int nc)>();
            foreach ((int nr, int nc) in new List<(int nr, int nc)>() { (r + 1, c), (r - 1, c),
                                                                         (r, c + 1), (r, c - 1)
                                                                      })
            {
                neighbors.Add((nr, nc));
            }
            return neighbors;
        }
    }
}
