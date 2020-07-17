using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class LengthCombinations
    {
        public List<List<int>> CombinationOfLengthBuildUp(int[] n, int length)
        {
            return CombinationOfLengthBuildUp(n, 0, length, 0);
        }

        public List<List<int>> CombinationOfLengthPassedVariable(int[] n, int length)
        {
            List<List<int>> result = new List<List<int>>();
            CombinationOfLengthPassedVariable(n, 0, length, 0, new List<int>(), result);

            return result;
        }

        private void CombinationOfLengthPassedVariable(int[] n,
                                                       int i,
                                                       int targetLen,
                                                       int currLen,
                                                       List<int> path,
                                                       List<List<int>> result
                                                       )
        {
            if (currLen > targetLen) return;
            if (i == n.Length && currLen != targetLen) return;
            if (i == n.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            List<int> pathWithCurrent = new List<int>(path);
            pathWithCurrent.Add(n[i]);
            //!include           
            CombinationOfLengthPassedVariable(n, i + 1, targetLen, currLen + 1, pathWithCurrent, result);
            //!Exclude
            CombinationOfLengthPassedVariable(n, i + 1, targetLen, currLen, path, result);
        }

        private List<List<int>> CombinationOfLengthBuildUp(int[] n, int i, int targetLen, int currLen)
        {
            List<List<int>> toReturn = new List<List<int>>();

            if (currLen > targetLen)//!Backtracking
            {
                return toReturn;
            }

            if (i == n.Length && targetLen != currLen)
            {
                return toReturn;
            }

            if (i == n.Length)
            {
                toReturn.Add(new List<int>());
                return toReturn;
            }

            // include current item 
            List<List<int>> include = CombinationOfLengthBuildUp(n, i + 1, targetLen, currLen + 1);
            //exclude current item
            List<List<int>> exclude = CombinationOfLengthBuildUp(n, i + 1, targetLen, currLen);

            foreach (List<int> result in include)
            {
                result.Insert(0, n[i]);
                toReturn.Add(result);
            }

            toReturn.AddRange(exclude);

            return toReturn;
        }
    }
}
