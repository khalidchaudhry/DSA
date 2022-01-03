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
            int[][] maze = new int[5][] {
                new int[] {0,0,1 },
                new int[] {0,0,0 },
                new int[] {0,0,0 },
                new int[] {1,1,0},
                new int[] {0,0,0}

            };

            _490 test = new _490();
            test.HasPath0(maze, new int[] { 1, 2 }, new int[] { 3, 2 });

        }

        public bool HasPath0(int[][] maze, int[] start, int[] destination)
        {

            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();
            return Solve(maze, start, destination, visited);
        }

        private bool Solve(int[][] maze, int[] start, int[] destination, HashSet<(int r, int c)> visited)
        {

            if (start[0] == destination[0] && start[1] == destination[1])
            {
                return true;
            }
            if (visited.Contains((start[0], start[1])))
            {
                return false;
            }
            //! once we visit cell, we will not  unvisit as per the question 
            /*
             * The ball can go through the empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. 
             * When the ball stops, it could choose the next direction.
             */
            visited.Add((start[0], start[1]));


            foreach ((int x, int y) in new List<(int x, int y)>() { (-1, 0), (1, 0), (0, 1), (0, -1) })
            {
                //! arrays are reference types. so we need to create new one. 
                //! int[] newStart=start will not work in this case
                //int[] newStart = new int[] { start[0], start[1] };
                int newRow = start[0];
                int newCol = start[1];
                //! before incrementing value we are checking if the value is valid . Only after that we increment
                //! maze[newStart[0] + x][newStart[1] + y] == 0 as per requiremnt ball won't stop rolling until hitting a wall(1)  
                //! why do we not check visited below ? 
                /*                 
                    Because the point [xx,yy] can be visited again in different direction. For eg: assume the matrix
                    [ 0 0 1 0 0 ]
                    [ 0 0 0 0 0 ]
                    [ 0 0 0 1 0 ]
                    [ 1 1 0 1 1 ]
                    [ 0 0 0 0 0 ]
                    Assume start is [0,4] and dest is [1,2]. 
                    Then the direction we will take is [0,4] -> [0,3] -> [1,3] -> [1,2](Cannot stop here) -> [1,1] -> [1,0] -> [2,0] -> [2,1] -> [2,2] ->[1,2](Stop here). 
                    (Technically [1,2] is visited twice but only when it is visited in one direction it counts.) Hope this helps.
                  */
                while (!IsOutOfBound(maze, newRow + x, newCol + y) && maze[newRow + x][newCol + y] == 0)
                {
                    newRow += x;
                    newCol += y;
                }
                if (Solve(maze, new int[] { newRow, newCol}, destination, visited))
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
