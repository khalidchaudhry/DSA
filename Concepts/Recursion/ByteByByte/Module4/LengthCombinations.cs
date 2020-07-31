using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class LengthCombinations
    {
        public static void LengthCombinationsMain()
        {
            LengthCombinations lengthCombinations = new LengthCombinations();
            int[] n = new int[] { 1, 2, 3 };
            int targetLen = 2;
            var result = lengthCombinations.CombinationOfLengthPassedVariable2(n, targetLen);

            Console.ReadLine();

        }
        public List<List<int>> CombinationOfLengthBuildUp(int[] n, int length)
        {
            return CombinationOfLengthBuildUp(n, 0, length, 0);
        }

        /// <summary>
        //! Combination Of Length Passed Variable with pathWithCurrent approach   
        /// </summary>
        /// <param name="n"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<List<int>> CombinationOfLengthPassedVariable(int[] n, int length)
        {
            List<List<int>> result = new List<List<int>>();
            CombinationOfLengthPassedVariable(n, 0, length, 0, new List<int>(), result);

            return result;
        }
        /// <summary>
        //! Combination Of Length PassedVariable with add/remove from path approach
        ///////////////////////////////////////////////////////////////////////
        //! Time Complexity=branching_factor^recursion_depth* work_per_recursive_call
        //! branching_factor=2 since there are 2 recursve calls in function
        //! Recursion_depth=n where n is number of elements in an array.we will returns once we hit our length equals to array.Length
        //! work_per_recursive_call=O(n) because of the statement "new List<int>(path)" as we are creating\copying new list based on what we have in the path list
        //! Time Complexity=O(2^n)*O(n)
        ///////////////////////////////////////////////////////////////////////
        //! Space Complexity=recursion_depth*Space_per_recursive_call
        //! recursion_depth=O(n)
        //! Space_per_recursive_call=2^n --> maximum space we will use  (2^n is total number of combinations) 
        //! Space_Complexity=O(2^n)*O(n)
        //! However we ususally don't consider client space so time complexity will be O(n)
        //////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="n"></param>
        /// <param name="length"></param>
        /// <returns></returns>

        public List<List<int>> CombinationOfLengthPassedVariable2(int[] n, int length)
        {
            List<List<int>> result = new List<List<int>>();
            CombinationOfLengthPassedVariable2(n, 0, length, 0, new List<int>(), result);

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
                result.Add(path);
                return;
            }
            //! We can just get rid of below item declaration and exclude the item from path after including.  
            List<int> pathWithCurrent = new List<int>(path);
            pathWithCurrent.Add(n[i]);
            //!include           
            CombinationOfLengthPassedVariable(n, i + 1, targetLen, currLen + 1, pathWithCurrent, result);
            //!Exclude
            CombinationOfLengthPassedVariable(n, i + 1, targetLen, currLen, path, result);
        }

        private void CombinationOfLengthPassedVariable2(int[] n,
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

             path.Add(n[i]);
            //!include           
            CombinationOfLengthPassedVariable(n, i + 1, targetLen, currLen + 1, path, result);
            path.RemoveAt(path.Count-1);
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
