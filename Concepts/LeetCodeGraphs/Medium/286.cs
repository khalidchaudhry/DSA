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

        public void WallsAndGates(int[][] rooms)
        {
            int rows = rooms.Length;
            if (rows == 0)
                return;
            int columns = rooms[0].Length;

            bool[][] visited = new bool[rows][];
            for (int i = 0; i < rows; ++i)
            {
                visited[i] = new bool[columns];
            }

            Queue<(int row, int column)> queue = new Queue<(int row, int columns)>();

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (rooms[i][j] == 0)
                    {
                        visited[i][j] = true;
                        queue.Enqueue((i, j));
                    }
                    if (rooms[i][j] == -1)
                    {
                        visited[i][j] = true;
                    }
                }
            }
            while (queue.Count != 0)
            {
                (int row, int column) = queue.Dequeue();

                int aboveRow = row - 1;
                int belowRow = row + 1;
                int rightColumn = column + 1;
                int leftColumn = column - 1;

                if (aboveRow >= 0 && !visited[aboveRow][column])
                {
                    rooms[aboveRow][column] = rooms[row][column] + 1;
                    visited[aboveRow][column] = true;
                    queue.Enqueue((aboveRow, column));
                }

                if (belowRow < rows && !visited[belowRow][column])
                {
                    rooms[belowRow][column] = rooms[row][column] + 1;
                    visited[belowRow][column] = true;
                    queue.Enqueue((belowRow, column));
                }

                if (rightColumn < columns && !visited[row][rightColumn])
                {
                    rooms[row][rightColumn] = rooms[row][column] + 1;
                    visited[row][rightColumn] = true;
                    queue.Enqueue((row, rightColumn));
                }

                if (leftColumn >= 0 && !visited[row][leftColumn])
                {
                    rooms[row][leftColumn] = rooms[row][column] + 1;
                    visited[row][leftColumn] = true;
                    queue.Enqueue((row, leftColumn));
                }
            }
        }

        public void WallsAndGates0(int[][] rooms)
        {
            if (rooms.Length == 0) return;

            int rows = rooms.Length;
            int columns = rooms[0].Length;

            int[][] directions = new int[4][]
            {
                new int[] {-1,0 },    //up
                new int[] {1,0 },    // down
                new int[] {0,-1 },  //left
                new int[] {0,1 }   //right
            };


            Queue<int[]> queue = new Queue<int[]>();
            //! Queue all the cells with zero value as we are starting with gates
            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (rooms[row][column] == 0)
                        queue.Enqueue(new int[] { row, column });
                }
            }

            while (queue.Count != 0)
            {
                int[] xyCoordintes = queue.Dequeue();
                int row = xyCoordintes[0];
                int column = xyCoordintes[1];
                foreach (int[] direction in directions)
                {
                    int r = row + direction[0];
                    int c = column + direction[1];

                    if (r < 0 ||
                        r >= rows ||
                        c < 0 ||
                        c >= columns ||
                        rooms[r][c] != int.MaxValue
                        )
                    {
                        continue;
                    }

                    rooms[r][c] = 1 + rooms[row][column];

                    queue.Enqueue(new int[] { r, c });
                }
            }
        }

        public void WallsAndGates1(int[][] rooms)
        {
            int rows = rooms.Length;
            int columns = rooms[0].Length;
            int empty = int.MaxValue;
            Queue<int[]> queue = new Queue<int[]>();
            //! Queue all the cells with zero value as we are starting with gates
            for (int row = 0; row < rows; ++row)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (rooms[row][column] == 0)
                        queue.Enqueue(new int[] { row, column });
                }
            }

            while (queue.Count != 0)
            {
                int[] coordintes = queue.Dequeue();
                int row = coordintes[0];
                int column = coordintes[1];

                int currentCellValue = rooms[row][column];

                if (row > 0 && rooms[row - 1][column] == empty) //up
                {
                    rooms[row - 1][column] = currentCellValue + 1;
                    queue.Enqueue(new int[] { row - 1, column });
                }
                if (row < rows - 1 && rooms[row + 1][column] == empty) //down
                {
                    rooms[row + 1][column] = currentCellValue + 1;
                    queue.Enqueue(new int[] { row + 1, column });
                }
                if (column > 0 && rooms[row][column - 1] == empty) //left
                {
                    rooms[row][column - 1] = currentCellValue + 1;
                    queue.Enqueue(new int[] { row, column - 1 });
                }
                if (column < columns - 1 && rooms[row][column + 1] == empty) //right
                {
                    rooms[row][column + 1] = currentCellValue + 1;
                    queue.Enqueue(new int[] { row, column + 1 });
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
                        DFS(rooms,row, column, 0);
                    }
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
