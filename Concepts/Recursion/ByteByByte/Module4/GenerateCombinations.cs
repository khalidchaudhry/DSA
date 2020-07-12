using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class GenerateCombinations
    {


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
            return result;
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
            path.Insert(0, n[i]);

            //! exclude current item
            CombinationsPassedVariable(n, 1, result, path);
            //! include current item
            CombinationsPassedVariable(n, 1, result, pathWithCurrent);               
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
