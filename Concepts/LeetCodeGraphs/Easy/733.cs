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
            bool[][] visited = new bool[image.Length][];

            for (int i = 0; i < visited.Length; ++i)
            {
                visited[i] = new bool[image[0].Length];
            }

            DFS(image,visited, sr, sc, newColor);

            return image;
        }

        private void DFS(int[][] image,
                        bool[][] visited,
                        int sr, int sc,
                        int newColor)
        {
            if (sr < 0 || sr >= image.Length ||
                sc < 0 || sc >= image[0].Length)
            {
                return;
            }

            visited[sr][sc] = true;

            List<(int x, int y)> directions = new List<(int x, int y)>
            {
                (-1,0),  // above row
                (1,0),   // below row
                (0,1),  // right column
                (0,-1)  // left column
            };

            foreach ((int x, int y) in directions)
            {
                int nx = sr + x;
                int ny = sc + y;

                if (nx >= 0 &&
                    nx < image.Length &&
                    ny >= 0 &&
                    ny < image[0].Length &&
                    image[nx][ny]==image[sr][sc] &&//!node color same color as the starting pixel
                    !visited[nx][ny]
                    )
                {
                    DFS(image, visited, nx, ny, newColor);
                }
            }

            image[sr][sc] = newColor;            
        }
    }
}
