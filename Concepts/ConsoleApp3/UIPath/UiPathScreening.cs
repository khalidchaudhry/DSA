using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.UIPath
{
    public class UiPathScreening
    {
        public void Question()
        {
            /*
             
                  The board is made up of an m x n grid of cells, where each cell has an initial state: live (represented by a 1) or dead (represented by a 0).
                  Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules:
                  1. Any live cell with fewer than two live neighbors dies as if caused by under-population.
                  2. Any live cell with two or three live neighbors lives on to the next generation.
                  3. Any live cell with more than three live neighbors dies, as if by over-population.
                  4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
                  The next state is created by applying the above rules simultaneously to every cell in the current state. 
                  Given the current state of the 
                  m x n grid board, return the next state.
                  // 1 ----live 
                  // 0---dead
                 // < 2 -> dead
                 // 2 or 3 -> live
                 // >= 4 neighbors all 1  then this cell dies
                 //
         */
        }
        private int[][] ProvidedSolution(int[][] oldGrid)
        {
            int[][] newGrid = new int[oldGrid.Length][];
            for (int r = 0; r < oldGrid.Length; ++r)
            {
                for (int c = 0; c < oldGrid[0].Length; ++c)
                {
                    List<(int r, int c)> neighbors = GetNeighbors(oldGrid, r, c);
                    int sum = 0;
                    foreach ((int nr, int nc) in neighbors)
                    {
                        sum += oldGrid[nr][nc];
                    }
                    if (oldGrid[r][c] == 0)
                    {

                        if (sum >= 4)
                        {
                            newGrid[r][c] = 1;
                        }
                    }
                    else
                    {
                        if (sum < 2)
                        {
                            newGrid[r][c] = 0;
                        }
                        else if (sum == 2 || sum == 3)
                        {
                            newGrid[r][c] = 1;
                        }
                        else if (sum >= 8)
                        {
                            newGrid[r][c] = 0;
                        }
                    }
                }
            }
            return newGrid;

        }

        private void CorrectSoltion(int[][] grid)
        {
            int[,] clonedGrid = new int[grid.Length,grid[0].Length];
            for (int r = 0; r < grid.Length; ++r)
            {
                for (int c = 0; c < grid[0].Length; ++c)
                {
                    clonedGrid[r, c] = grid[r][c];
                }
            }

            for (int r = 0; r < grid.Length; ++r)
            {
                for (int c = 0; c < grid[0].Length; ++c)
                {
                    List<(int r, int c)> neighbors = GetNeighbors(clonedGrid, r, c);
                    int sum = 0;
                    foreach ((int nr, int nc) in neighbors)
                    {
                        sum += grid[nr][nc];
                    }
                    if (clonedGrid[r,c] == 0)
                    {
                        if (sum >= 4)
                        {
                            grid[r][c] = 1;
                        }
                    }
                    else
                    {
                        if (sum < 2)
                        {
                            grid[r][c] = 0;
                        }
                        else if (sum == 2 || sum == 3)
                        {
                            grid[r][c] = 1;
                        }
                        else if (sum >= 8)
                        {
                            grid[r][c] = 0;
                        }
                    }
                }
            }
        }

        private List<(int r, int c)> GetNeighbors(object grid, int r, int c)
        {
            throw new NotImplementedException();
        }
    }
}
