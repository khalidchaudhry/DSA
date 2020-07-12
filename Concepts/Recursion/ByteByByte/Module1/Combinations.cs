using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module1
{
    /// <summary>
    /// https://github.com/samgh/CIMRecursion/blob/master/java/Combinations.java
    /// </summary>
    public class Combinations
    {
        public static List<List<int>> CombinationsGlobal(int[] n)
        {
            List<List<int>> results = new List<List<int>>();
            CombinationsGlobal(n, 0, results, new List<int>());
            return results;
        }
        private static void CombinationsGlobal(int[] n, int i,
        List<List<int>> results, List<int> path)
        {
            if (i == n.Length)
            {
                results.Add(path);
                return;
            }
            List<int> pathWithCurrent = new List<int>(path);
            pathWithCurrent.Add(n[i]);
            // Find all the combinations that exclude current item
            CombinationsGlobal(n, i + 1, results, path);
            // Find all the combinations that include current item
            CombinationsGlobal(n, i + 1, results, pathWithCurrent);
        }

        public static List<List<int>> CombinationsBuiltUp(int[] n)
        {
            return CombinationsBuiltUp(n, 0);
        }

        private static List<List<int>> CombinationsBuiltUp(int[] n, int i)
        {
            List<List<int>> toReturn = new List<List<int>>();
            // When we reach the end of our array, we have a single result
            // -- An empty list
            if (i == n.Length)
            {
                toReturn.Add(new List<int>());
                // Return [[]]
                return toReturn;
            }
            // Get all combinations from i+1 to the end of the list. Then for each
            // of those, both include and exclude the current item
            foreach (List<int> result in CombinationsBuiltUp(n, i + 1))
            {
                // Exclude current item
                toReturn.Add(new List<int>(result));
                // Include current item
                result.Insert(0, n[i]);
                toReturn.Add(new List<int>(result));
            }

            return toReturn;
        }
    }
}
