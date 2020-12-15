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
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            InitializeQueue(rooms, queue, visited);

            while (queue.Count != 0)
            {
                (int row, int column) = queue.Dequeue();

                foreach ((int r, int c) in GetNeighbors(rooms, row, column))
                {
                    if (!visited.Contains((r, c)))
                    {
                        rooms[r][c] = rooms[row][column] + 1;
                        visited.Add((r, c));
                        queue.Enqueue((r, c));
                    }
                }
            }
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

        private void InitializeQueue(int[][] rooms, Queue<(int x, int y)> queue, HashSet<(int, int)> visited)
        {
            for (int i = 0; i < rooms.Length; ++i)
            {
                for (int j = 0; j < rooms[0].Length; ++j)
                {
                    if (rooms[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                    if (rooms[i][j] == -1)
                    {
                        visited.Add((i, j));
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
