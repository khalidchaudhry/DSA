using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _1102
    {
        //! Very similar to question 1102
        public int MaximumMinimumPath(int[][] A)
        {

            int r = A.Length;
            int c = A[0].Length;

            int lo = 0; //Valid
            int hi = Math.Min(A[0][0], A[r - 1][c - 1]) + 1; //invalid

            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (OK(A, mid))
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }
            return lo;

        }

        //!Can we achieve at least 'mid' score
        //! We can only achieve 'mid' score if mid is the smallest value in the path.
        //! If neighbor valus is smaller than mid value then we can't achieve the mid score
        // TTTT'T'FFFFF
        private bool OK(int[][] A, int target)
        {
            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();
            return DFS(A, 0, 0, visited, target);
        }
        private bool DFS(int[][] A, int r, int c, HashSet<(int r, int c)> visited, int target)
        {
            if (IsOutOfBound(A, r, c) || visited.Contains((r, c)) || A[r][c] < target)
                return false;

            if (r == A.Length - 1 && c == A[0].Length - 1)
                return true;

            visited.Add((r, c));

            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                if (DFS(A, nr, nc, visited, target))
                {
                    return true;
                }
            }
            return false;
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

        private bool IsOutOfBound(int[][] A, int r, int c)
        {
            return r < 0 || r >= A.Length || c < 0 || c >= A[0].Length;
        }

    }
}
