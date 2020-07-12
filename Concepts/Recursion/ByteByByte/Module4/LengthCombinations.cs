using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class LengthCombinations
    {
        public List<List<int>> CombinationOfLengthBuildUp(int[] n, int length)
        {
            return CombinationOfLength(n, 0, length, 0);
        }

        private List<List<int>> CombinationOfLength(int[] n, int i, int targetLen, int currLen)
        {
            List<List<int>> toReturn = new List<List<int>>();

            if (currLen > targetLen)
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
            List<List<int>> include = CombinationOfLength(n, i + 1, targetLen, currLen + 1);
            //exclude current item
            List<List<int>> exclude = CombinationOfLength(n, i + 1, targetLen, currLen);

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
