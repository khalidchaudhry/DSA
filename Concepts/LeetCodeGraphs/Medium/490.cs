﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _490
    {

        public static void _490Main()
        {
            int[][] maze = new int[5][] {
                new int[] {0,0,1 },
                new int[] {0,0,0 },
                new int[] {0,0,0 },
                new int[] {1,1,0},
                new int[] {0,0,0}

            };

            _490 test = new _490();
            test.HasPath0(maze,new int[] { 1,2},new int[] {3,2 });

        }

        public bool HasPath0(int[][] maze, int[] start, int[] destination)
        {

            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();
            return Solve(maze, start, destination, visited);
        }

        private bool Solve(int[][] maze, int[] start, int[] destination, HashSet<(int r, int c)> visited)
        {
            if (visited.Contains((start[0], start[1])))
            {
                return false;
            }
            if (start[0] == destination[0] && start[1] == destination[1])
            {
                return true;
            }
            visited.Add((start[0], start[1]));


            foreach ((int x, int y) in new List<(int x, int y)>() { (-1, 0), (1, 0), (0, 1), (0, -1) })
            {
                int[] newStart = new int[] { start[0], start[1] };
                while (!IsOutOfBound(maze, newStart[0] + x, newStart[1] + y) && maze[newStart[0] + x][newStart[1] + y] == 0)
                {
                    newStart[0] = newStart[0] + x;
                    newStart[1] = newStart[1] + y;
                }
                if (Solve(maze, newStart, destination, visited))
                {
                    return true;
                }
            }

            return false;

        }

        private bool IsOutOfBound(int[][] grid, int r, int c)
        {
            return r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length;
        }



        /// <summary>
        ///https://leetcode.com/problems/the-maze/discuss/97067/Simple-Java-DFS-with-comments
        ///See discussion
        /// </summary>
        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            return DFS(maze, start, destination);
        }

        private bool DFS(int[][] maze, int[] position, int[] destination)
        {
            int r = position[0], c = position[1];

            if (maze[r][c] == -1) return false;

            if (r == destination[0] && c == destination[1])
                return true;

            maze[r][c] = -1; //to denote that we have already started from this node

            int rows = maze.Length;
            int columns = maze[0].Length;

            //try UP
            int index = r;
            while (index >= 0 && maze[index][c] != 1)
            {
                --index;
            }
            bool up = DFS(maze, new int[] { index + 1, c }, destination);
            if (up)
                return true;

            //try down
            index = r;
            while (index < rows && maze[index][c] != 1)
            {
                index++;
            }
            bool down = DFS(maze, new int[] { index - 1, c }, destination);
            if (down)
            {
                return true;
            }

            //try left
            index = c;
            while (index >= 0 && maze[r][index] != 1)
            {
                index--;
            }
            bool left = DFS(maze, new int[] { r, index + 1 }, destination);
            if (left)
            {
                return true;
            }

            //try right
            index = c;
            while (index < columns && maze[r][index] != 1)
            {
                index++;
            }
            bool right = DFS(maze, new int[] { r, index - 1 }, destination);
            if (right)
            {
                return true;
            }

            return false;
        }
    }
}
