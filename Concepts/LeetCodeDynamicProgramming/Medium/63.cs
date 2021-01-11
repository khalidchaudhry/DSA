using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _63
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {

            //! if first position itself is obstacle, then we can't have any path at all
            if (obstacleGrid[0][0] == 1) return 0;
            Dictionary<(int, int), int> cache = new Dictionary<(int, int), int>();
            return UniquePathsWithObstacles(obstacleGrid, 0, 0, cache);

        }
        private int UniquePathsWithObstacles(int[][] obstacleGrid, int row, int column, Dictionary<(int, int), int> cache)
        {
            if (row == obstacleGrid.Length - 1 && column == obstacleGrid[0].Length - 1)
            {
                return 1;
            }

            if (cache.ContainsKey((row, column)))
                return cache[(row, column)];

            int count = 0;
            foreach ((int nx, int ny) in GetNeighbors(obstacleGrid, row, column))
            {
                count += UniquePathsWithObstacles(obstacleGrid, nx, ny, cache);
            }

            cache[(row, column)] = count;

            return cache[(row, column)];
        }

        private IEnumerable<(int, int)> GetNeighbors(int[][] matrix, int row, int column)
        {
            foreach ((int x, int y) in new List<(int, int)>() { (row + 1, column), (row, column + 1) })
            {
                if (x < matrix.Length && y < matrix[0].Length && matrix[x][y] != 1)
                    yield return (x, y);
            }
        }


    }
}
