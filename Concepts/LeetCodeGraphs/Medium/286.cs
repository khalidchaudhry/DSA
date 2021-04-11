using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBreadthFirstSearch.Medium
{
    public class _286
    {
        public static void _286Main()
        {

        }

        /// <summary>
        //! Same pattern as followed in question 542 
        /// </summary>
        public void WallsAndGates(int[][] rooms)
        {
            int rows = rooms.Length;
            int columns = rooms[0].Length;

            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (rooms[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                }
            }

            while (queue.Count != 0)
            {
                (int r, int c) = queue.Dequeue();

                foreach ((int nr, int nc) in GetNeighbors(r, c))
                {
                    if (IsOutOfBound(rooms, nr, nc) || visited.Contains((nr, nc)) || rooms[nr][nc] == -1)
                    {
                        continue;
                    }

                    rooms[nr][nc] = 1 + rooms[r][c];

                    queue.Enqueue((nr, nc));
                    visited.Add((nr, nc));
                }
            }
        }
        private bool IsOutOfBound(int[][] rooms, int r, int c)
        {
            return r < 0 || r >= rooms.Length || c < 0 || c >= rooms[0].Length;
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

        /// <summary>
        //!https://www.youtube.com/watch?v=wCTbLn6QgTE
        //! DFS
        /// </summary>
        /// <param name="rooms"></param>
        public void WallsAndGates2(int[][] rooms)
        {

            if (rooms.Length == 0) return;
            int rows = rooms.Length;
            int columns = rooms[0].Length;

            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (rooms[row][column] == 0)
                    {
                        DFS(rooms, row, column, 0);
                    }
                }
            }
        }

        private IEnumerable<(int, int)> GetNeighbors(int[][] rooms, int row, int column)
        {
            foreach ((int r, int c) in new List<(int, int)>{ (row+1,column),(row-1,column),
                                                             (row,column+1),(row,column-1)
                                                           })
            {
                if (r >= 0 && r < rooms.Length && c >= 0 && c < rooms[0].Length)
                {
                    yield return (r, c);
                }
            }
        }
        private void DFS(int[][] rooms, int row, int column, int distance)
        {
            if (row < 0 ||
               row >= rooms.Length ||
               column < 0 ||
               column >= rooms[0].Length ||
               rooms[row][column] < distance
               )
            {
                return;
            }

            rooms[row][column] = distance;
            DFS(rooms, row - 1, column, distance + 1);
            DFS(rooms, row + 1, column, distance + 1);
            DFS(rooms, row, column - 1, distance + 1);
            DFS(rooms, row, column + 1, distance + 1);
        }
    }
}
