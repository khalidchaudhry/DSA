using System;
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

        }
        /// <summary>
        ///https://leetcode.com/problems/the-maze/discuss/97067/Simple-Java-DFS-with-comments
        ///See discussion
        /// </summary>
        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            return DFS(maze, start, destination);
        }

        private bool DFS(int[][] maze, int[] start, int[] destination)
        {
            int r = start[0], c = start[1];

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
