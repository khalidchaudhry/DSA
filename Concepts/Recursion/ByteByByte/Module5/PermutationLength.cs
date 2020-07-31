using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module5
{
    public class PermutationLength
    {
        /// <summary>
        //! Passed variable with a set of all available items approach(less preferable)
        /// </summary>
        /// <param name="items"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<List<int>> PermutationOfSetLength(HashSet<int> items, int length)
        {
            List<List<int>> result = new List<List<int>>();
            PermutationOfSetLength(items, length, new List<int>(), result);

            return result;
        }
        /// <summary>
        //! Passed variable with swapping approach(more popular and preferable)
        /// </summary>
        /// <param name="items"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<List<int>> PermutationOfSetLengthSwap(int[] items, int length)
        {
            List<List<int>> result = new List<List<int>>();
            PermutationOfSetLengthSwap(items, 0, length, new List<int>(), result);

            return result;
        }
      
        private void PermutationOfSetLengthSwap(int[] items, int i, int length, List<int> path, List<List<int>> result)
        {
            if (length == 0)
            {
                result.Add(new List<int>(path));
            }
            for (int j = i; j < items.Length; j++)
            {
                Swap(items, i, j);
                path.Add(items[i]);
                PermutationOfSetLengthSwap(items, i + 1, length - 1, path, result);               
                path.RemoveAt(path.Count - 1);
                Swap(items, i, j);
            }
        }

        private void Swap(int[] items, int i, int j)
        {
            int temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        private void PermutationOfSetLength(HashSet<int> items, int length, List<int> path, List<List<int>> result)
        {
            if (length == 0)
            {
                result.Add(new List<int>(path));
            }

            foreach (int item in new HashSet<int>(items))
            {
                items.Remove(item);
                path.Add(item);
                PermutationOfSetLength(items, length - 1, path, result);
                path.RemoveAt(path.Count - 1);
                items.Add(item);
            }
        }
    }
}
