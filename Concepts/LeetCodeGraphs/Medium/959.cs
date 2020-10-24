using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _959
    {
        /// <summary>      
        //! Look for the discussion in solution
        /// https://leetcode.com/problems/regions-cut-by-slashes/discuss/205674/C%2B%2B-with-picture-DFS-on-upscaled-grid
       
        /// </summary>   
        public int RegionsBySlashes(string[] grid)
        {

            int n = grid.Length;

            //!we are zooming/scaling out to 3.
            //! why 3 because scaling to 2 the minimal distance between the line is 2 which is impossible to detect 
            bool[][] map = new bool[3 * n][];

            int m = map.Length;
            for (int i = 0; i < m; ++i)
            {
                map[i] = new bool[m];
            }

            //! below code of turning everything to true is not necessary .
            //! Its to make DFS more similar to number of islands problem(200)
            //! Without below code, we need to do DFS where cell value is false and turn it to true 
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    map[i][j] = true;
                }
            }

            UpdateMap(grid, map);

            int result = 0;
            for (int i = 0; i < map.Length; ++i)
            {
                for (int j = 0; j < map.Length; ++j)
                {
                    if (map[i][j])
                    {
                        ++result;
                        DFS(map, i, j);
                    }
                }
            }

            return result;
        }
        /// /// # <image url="$(SolutionDir)\Images\959.png"  scale="0.2"/>
        private static void UpdateMap(string[] grid, bool[][] map)
        {
            //! Turn every cell to false where there is a / or \ since they make the region not connected 
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[i].Length; ++j)
                {
                    //! since we scaled to 3 , the row in given grid maps to our grid by multiplying it with 3
                    int actualRow = 3 * i;
                    int actualColumn = 3 * j;
                    if (grid[i][j] == '/')
                    {
                        map[actualRow][actualColumn + 2] = false;//top right
                        map[actualRow + 1][actualColumn + 1] = false;//center
                        map[actualRow + 2][actualColumn] = false;//bottom left
                    }

                    if (grid[i][j] == '\\')
                    {
                        map[actualRow][actualColumn] = false;//top left
                        map[actualRow + 1][actualColumn + 1] = false;//center
                        map[actualRow + 2][actualColumn + 2] = false;//bottom right
                    }
                }
            }
        }

        private void DFS(bool[][] map, int i, int j)
        {
            if (
                i < 0 ||
                i >= map.Length ||
                j < 0 ||
                j >= map.Length ||
                map[i][j] == false
                )
            {
                return;
            }

            map[i][j] = false;

            DFS(map, i - 1, j);//up
            DFS(map, i + 1, j);//down
            DFS(map, i, j - 1);//left
            DFS(map, i, j + 1);//right
        }

        // https://www.youtube.com/watch?v=tIZkh7mpIDo
        // https://www.youtube.com/watch?v=528smPZySRs
        //https://github.com/zebointexas/licold/blob/master/6_Union_Find/_959_Regions_Cut_By_Slashes
        //https://github.com/Nideesh1/Algo/blob/master/leetcode/L_959.java
        public int RegionsBySlashes2(String[] grid)
        {
            /*
                   -------
                  |\  0  /|
                  | \   / |
                  |  \ /  |
                  |1  / 2 |
                  |  / \  |
                  | / 3 \ |
                  -------- 
           */


            int N = grid.Length;/*grid length is the cube's height*/
            //! 
            DSU dsu = new DSU(4 * N * N); /*Here we cut the one single grid cell into 4 places two knives \ and / */

            for (int r = 0; r < N; ++r) /*Tranverse the grid height(row)*/
                for (int c = 0; c < N; ++c)  /*Tranverse the grid widht(row)*/
                {
                    //! since we are splitting every square into 4 triangles. We are multiplying by 4
                    // !  Roots will be like 0 , 4, 8, 12.......
                    int root = 4 * (r * N + c); /*record the total number of root so far, at this moment */
                    char val = grid[r][c];  /*check this cube's input ---> "\" or "/" or " "*/
                    // if val!=\\ than we can union 0 and 1, 2 and 3 regions since they are contiguous\connected 
                    if (val != '\\')
                    {
                        dsu.union(root + 0, root + 1);
                        dsu.union(root + 2, root + 3);
                    }
                    // if val!=/ than we can union 0 and 2, 1 and 3 regions since they are contiguous 
                    if (val != '/')
                    {
                        dsu.union(root + 0, root + 2);
                        dsu.union(root + 1, root + 3);
                    }

                    // (down and up) north south
                    if (r + 1 < N) /*if next row exist----down*/
                        dsu.union(root + 3, (root + 4 * N) + 0);
                    if (r - 1 >= 0)/*if previous  row exist----up*/
                        dsu.union(root + 0, (root - 4 * N) + 3);

                    //(right and left) east west
                    if (c + 1 < N) // if next column exist-----right 
                        dsu.union(root + 2, (root + 4) + 1);
                    if (c - 1 >= 0) // if previous column exist--- left
                        dsu.union(root + 1, (root - 4) + 2);
                }

            int ans = 0;
            for (int x = 0; x < 4 * N * N; ++x)
            {
                if (dsu.find(x) == x)
                    ans++;
            }

            return ans;
        }
    }
    // !DSU=Disjoint set union 
    class DSU
    {

        int[] parent;
        public DSU(int N)
        {
            parent = new int[N];
            for (int i = 0; i < N; ++i)
                parent[i] = i;
        }
        public int find(int x)
        {
            if (parent[x] != x)
                parent[x] = find(parent[x]);

            return parent[x];
        }
        public void union(int x, int y)
        {
            parent[find(x)] = find(y);
        }

    }

}
