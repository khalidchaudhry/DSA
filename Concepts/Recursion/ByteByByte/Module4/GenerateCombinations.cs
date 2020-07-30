using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class GenerateCombinations
    {



        public static void GenerateCombinationsMain()
        {
            int[] n = new int[3] { 1, 2, 3 };
            var combinations = new GenerateCombinations();
            var result = combinations.CombinationsPassedVariable(n);
        }


        /// <summary>
        //!Time Complexity
        //! Height=n;
        //! Branching factor=1
        //! Work per schedule call 
        //!     iterate over and copy =O(2^n)    2^n are those many number of possible combinations 
        //!     lists of size O(n)
        //! Time complexity=O(2^n)*O(n)
        //! Space Complexity= O(2^n *n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<List<int>> CombinationsBuildUp(int[] n)
        {
            return CombinationsBuildUp(n, 0);

        }
        public List<List<int>> CombinationsPassedVariable(int[] n)
        {
            List<List<int>> result = new List<List<int>>();
             CombinationsPassedVariable(n, 0, result, new List<int>());
            //CombinationsPassedVariableBackTracking(n, 0, result, new List<int>());
            return result;
        }
        /// <summary>
        //!Time Complexity
        //! Height=n;
        //! Branching factor=2
        //! Work per schedule call 
        //!     iterate over and copy =O(2^n)    2^n are those many number of possible combinations 
        //!     lists of size O(n)
        //! Time complexity=O(2^n)*O(n)
        //! Space Complexity= O(2^n *n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="i"></param>
        /// <param name="result"></param>
        /// <param name="path"></param>
        private void CombinationsPassedVariable(int[] n, int i, List<List<int>> result, List<int> path)
        {
            if (i == n.Length)
            {
                result.Add(path);
                return;
            }
            List<int> pathWithCurrent = new List<int>(path);
            pathWithCurrent.Add(n[i]);
            //! exclude current item
            CombinationsPassedVariable(n, i + 1, result, path);
            //! include current item
            CombinationsPassedVariable(n, i + 1, result, pathWithCurrent);
        }

        private void CombinationsPassedVariableBackTracking(int[] n, int i, List<List<int>> result, List<int> path)
        {
            if (i == n.Length)
            {
                result.Add(path);
                return;
            }

            path.Add(n[i]);

            //! include current item
            CombinationsPassedVariableBackTracking(n, i + 1, result, path);

            //! exclude  current item
            path.RemoveAt(path.Count - 1);

            CombinationsPassedVariableBackTracking(n, i + 1, result, path);
        }

        private List<List<int>> CombinationsBuildUp(int[] n, int i)
        {
            List<List<int>> toReturn = new List<List<int>>();

            if (i == n.Length)
            {
                toReturn.Add(new List<int>());
                return toReturn;
            }

            foreach (List<int> result in CombinationsBuildUp(n, i + 1))
            {
                //exclude current item
                toReturn.Add(new List<int>(result));

                // include current item
                result.Insert(0, n[i]);
                toReturn.Add(result);
            }

            return toReturn;
        }
    }
}
