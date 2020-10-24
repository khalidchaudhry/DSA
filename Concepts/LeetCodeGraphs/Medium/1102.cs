using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1102
    {
        /// <summary>
        //! Appraoch based on discussion in Kai's mock interview. 
        //https://leetcode.com/problems/path-with-maximum-minimum-value/discuss/416227/Python-Dijkstra-Binary-Search-%2B-DFS-Union-Find-complexity-analysis
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int MaximumMinimumPath(int[][] A)
        {
            int rows = A.Length;
            int columns = A[0].Length;
            List<(int value, int x, int y)> lst = new List<(int value, int x, int y)>();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    lst.Add((A[i][j], i, j));
                }
            }
            //!Sort in descending order
            lst.Sort((a, b) => b.value.CompareTo(a.value));

            //! rows*columns because we are flattening 2d matrix to 1d so that we can handle with union find with ease
            //e.g. if are given 3*4 matrix then it will translat into 12 cells in one d array 
            UnionFind uf = new UnionFind(rows * columns);

            HashSet<(int x, int y)> seen = new HashSet<(int x, int y)>();
           
            List<(int x, int y)> directions = new List<(int x, int y)>
            {
                (-1,0),  // above row
                (1,0),   // below row
                (0,1),  // right column
                (0,-1)  // left column
            };

            foreach ((int value, int x, int y) in lst)
            {   //!We are using seen to ensure that we add edge between its neighbour 
                //! that is >= current node
                seen.Add((x, y));
                foreach ((int row, int column) in directions)
                {
                    //neighbour x and y coordinates 
                    int nx = row + x;
                    int ny = column + y;
                    if (nx >= 0 && nx < rows && 
                        ny >= 0 && ny < columns &&
                        //! As we are proceesing coordinates from largest to smallest
                        //!if we already seen its neigbour then we can union it
                        seen.Contains((nx,ny)) 
                       )
                    {
                        //! Translating 2d array into 1d array as union is build based on it 
                        //! Typical formula for recalculation of 2D array indices into 1D array index is
                        //! index = indexX * arrayWidth(columns) + indexY
                        uf.Union(x * columns + y, nx * columns + ny);
                        if (uf.Find(0) == uf.Find(rows * columns - 1))
                        {
                            return A[x][y];
                        }
                    }
                }
            }

            return 0;
        }
        public int MaximumMinimumPath2(int[][] A)
        {
            List<(int x, int y)> directions = new List<(int, int)>() {
                 (1, 0),    //bottom/down
                 (-1, 0),  //up
                 (0, 1),  //right
                 (0, -1) //left

            };

            var set = new SortedSet<(int score, int i, int j)>() { (A[0][0], 0, 0) }; //start
            var maxScore = A[0][0];
            A[0][0] = -1; //visited
            while (set.Any())
            {
                var max = set.Max;
                set.Remove(max);
                maxScore = Math.Min(maxScore, max.score);
                if (max.i == A.Length - 1 && max.j == A[0].Length - 1) //destination
                    break;
                foreach (var (x, y) in directions)
                {
                    var i = max.i + x;
                    var j = max.j + y;
                    if (i >= 0 && j >= 0 && i < A.Length && j < A[0].Length && //! Check if its out of bound
                        A[i][j] >= 0 //! If not already visited
                       )
                    {
                        set.Add((A[i][j], i, j));
                        //! Mark it as visited 
                        A[i][j] = -1;
                    }
                }
            }

            return maxScore;

        }
    }

    public class UnionFind
    {
        int[] parent;
        public UnionFind(int size)
        {
            parent = new int[size];
            //!making node parent of itself 
            for (int i = 0; i < parent.Length; ++i)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }

            return parent[x];
        }

        public void Union(int x, int y)
        {
            int xParent = Find(x);
            int yParent = Find(y);
            //making y parent of x. We can also use 
            //parent[x] = y;  but it will not do path compression
            if (xParent != yParent)
                parent[xParent] = parent[yParent];

        }
    }
}
